using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SignalizationSound : MonoBehaviour
{
    [SerializeField] private AudioSource _signalization;

    [SerializeField] private float _maxVolume = 1.0f;
    [SerializeField] private float _speed = 0.1f;

    private void Start()
    {
        _signalization = GetComponent<AudioSource>();
        _signalization.volume = 0.0f;
    }

    public void StartSound()
    {
        _signalization.Play();
        StartCoroutine(nameof(ChangeVolume));
    }
    
    public void StopSound()
    {
        _signalization.Stop();
        _signalization.volume = 0.0f;
        StopCoroutine(nameof(ChangeVolume));
    }

    private IEnumerator ChangeVolume()
    {
        while (_signalization.volume != _maxVolume)
        {
            _signalization.volume = Mathf.MoveTowards(_signalization.volume, _maxVolume, _speed * Time.deltaTime);
            yield return null;
        }
    }
}
