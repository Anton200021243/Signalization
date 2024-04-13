using UnityEngine;

public class HouseBehaviour : MonoBehaviour
{
    [SerializeField] private SignalizationSound _signalization;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            _signalization.StartSound();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            _signalization.StopSound();
        }
    }
}
