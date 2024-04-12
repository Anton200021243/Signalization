using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Signalization : MonoBehaviour
{
    [SerializeField] private AudioSource _signalization;

    [SerializeField] private Player _player;

    [SerializeField] private float _maxVolume = 1.0f;

    [SerializeField] private float _speed = 2.0f;

    private void Start()
    {
        _signalization = GetComponent<AudioSource>();

        _signalization.volume = 0.0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == _player.name)
        {
            _signalization.Play();
            StartCoroutine(nameof(ChangeVolume));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == _player.name)
        {
            _signalization.Stop();
            _signalization.volume = 0.0f;
            StopCoroutine(nameof(ChangeVolume));
        }
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
