using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signalization : MonoBehaviour
{
    [SerializeField] private AudioSource _signalization;

    [SerializeField] private float _maxVolume = 1.0f;

    [SerializeField] private float _speed = 2.0f;

    private void Start()
    {
        _signalization = GetComponent<AudioSource>();

        _signalization.volume = 0.0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            _signalization.Play();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            _signalization.volume = Mathf.MoveTowards(_signalization.volume, _maxVolume, _speed * Time.deltaTime);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            _signalization.Stop();
            _signalization.volume = 0.0f;
        }
    }
}
