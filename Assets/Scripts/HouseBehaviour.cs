using UnityEngine;

public class HouseBehaviour : MonoBehaviour
{
    [SerializeField] private SignalizationSound _signalization;
    [SerializeField] private Player _player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == _player.name)
        {
            _signalization.StartSound();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == _player.name)
        {
            _signalization.StopSound();
        }
    }
}
