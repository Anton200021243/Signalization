using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;

    private void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = verticalInput * _moveSpeed * Vector3.forward;

        transform.Translate(direction * Time.deltaTime);
    }

    private void Rotate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 rotateDirection = horizontalInput * _rotateSpeed * Vector3.up;

        transform.Rotate(rotateDirection * Time.deltaTime);
    }
}
