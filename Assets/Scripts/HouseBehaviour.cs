using UnityEngine;

public class HouseBehaviour : MonoBehaviour
{
    [SerializeField] private Signalization _signalization;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _signalization.StartSound();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _signalization.StopSound();
        }
    }
}
