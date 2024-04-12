using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private void Start()
    {
        transform.position = _player.position;
        transform.rotation = _player.rotation;
    }

    private void LateUpdate()
    {
        transform.position = _player.position;
        transform.rotation = _player.rotation;
    }
}
