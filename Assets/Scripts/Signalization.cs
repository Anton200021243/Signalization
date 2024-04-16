using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Signalization : MonoBehaviour
{
    [SerializeField] private AudioSource _signalization;

    [SerializeField] private float _speed = 0.1f;

    private float _maxVolume = 1.0f;
    private float _minVolume = 0.0f;

    private Coroutine _coroutine;

    private void Start()
    {
        _signalization = GetComponent<AudioSource>();
        _signalization.volume = _minVolume;
    }

    public void StartSound()
    {
        StopRoutine();
        _signalization.Play();
        StartRoutine(_maxVolume);
    }
    
    public void StopSound()
    {
        StopRoutine();
        StartRoutine(_minVolume);
    }

    private void StartRoutine(float targetVolume)
    {
        _coroutine = StartCoroutine(ChangeVolume(targetVolume));
    }

    private void StopRoutine()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private IEnumerator ChangeVolume(float targetVolume)
    {
        while (_signalization.volume != targetVolume)
        {
            _signalization.volume = Mathf.MoveTowards(_signalization.volume, targetVolume, _speed * Time.deltaTime);
            yield return null;
        }

        if (_signalization.volume == _minVolume)
            _signalization.Stop();
    }
}
