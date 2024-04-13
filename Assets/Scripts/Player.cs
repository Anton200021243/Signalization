using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;

    private float _verticalInput;
    private float _horizontalInput;

    private void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        _verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = _verticalInput * _moveSpeed * Vector3.forward;

        transform.Translate(direction * Time.deltaTime);
    }

    private void Rotate()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        Vector3 rotateDirection = _horizontalInput * _rotateSpeed * Vector3.up;

        transform.Rotate(rotateDirection * Time.deltaTime);
    }
}
