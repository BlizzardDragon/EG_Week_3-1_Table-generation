using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _cameraSencility = 2;
    [SerializeField] private float _playerRotateSencility = 20;
    [SerializeField] private float _speedMove = 10;
    [SerializeField] private float _jumpForce = 2500;
    [SerializeField] private bool _grounded;
    private float _xRotation;

    private void LateUpdate()
    {
        RotateCamera();

        if (Input.GetKeyDown(KeyCode.Space) && _grounded)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
        RotatePlayer();
    }

    private void MovePlayer()
    {
        Vector3 InputVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 SpeedVector = InputVector * _speedMove;
        Vector3 SpeedVectroRelativeToPlayer = transform.TransformVector(SpeedVector);
        _rigidbody.velocity = new Vector3(SpeedVectroRelativeToPlayer.x, _rigidbody.velocity.y, SpeedVectroRelativeToPlayer.z);
    }

    private void RotatePlayer()
    {
        _rigidbody.angularVelocity = Vector3.up * Input.GetAxisRaw("Mouse X") * _playerRotateSencility;
    }

    private void RotateCamera()
    {
        _xRotation += Input.GetAxisRaw("Mouse Y") * _cameraSencility;
        _xRotation = Mathf.Clamp(_xRotation, -60, 60);
        _cameraTransform.transform.localEulerAngles = new Vector3(-_xRotation, 0, 0);
    }

    private void Jump()
    {
        _rigidbody.AddForce(0, _jumpForce * 0.02f, 0, ForceMode.Impulse);
    }

    private void OnCollisionStay(Collision collision)
    {
        Vector3 normal = collision.contacts[0].normal;
        float dot = Vector3.Dot(normal, Vector3.up);
        if (dot > 0.5f)
        {
            _grounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        _grounded = false;
    }
}
