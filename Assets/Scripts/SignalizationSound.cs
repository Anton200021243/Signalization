using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SignalizationSound : MonoBehaviour
{
    [SerializeField] private AudioSource _signalization;

    [SerializeField] private float _maxVolume = 1.0f;
    [SerializeField] private float _minVolume = 0.0f;
    [SerializeField] private float _speed = 0.1f;

    private Coroutine _coroutine;

    private void Start()
    {
        _signalization = GetComponent<AudioSource>();
        _signalization.volume = 0.0f;
    }

    public void StartSound()
    {
        StopRoutine();
        _signalization.Play();
        StartRoutine();
    }
    
    public void StopSound()
    {
        StopRoutine();
        _coroutine = StartCoroutine(ChangeVolume(_minVolume));
    }

    private void StartRoutine()
    {
        _coroutine = StartCoroutine(ChangeVolume(_maxVolume));
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
