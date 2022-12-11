using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 10f;
    [SerializeField] private float _lerpSpeed = 2f;
    [SerializeField] private Vector3 _rotateDirectionCenter = Vector3.up * 5;

    [Space]
    [SerializeField] private Transform _cameraCenter;
    [SerializeField] private Transform _camera;

    [Space]
    [SerializeField] private List<CameraData> _cameraData = new List<CameraData>();

    private Vector3 _targetPosition;

    private void Start()
    {
        _targetPosition = _camera.localPosition;
    }

    private void Update()
    {
        _cameraCenter.transform.Rotate(_rotateDirectionCenter * Time.deltaTime);

        Vector3 moveDirection = new Vector3(0, -0.25f, 1f);
        if (Input.GetKey(KeyCode.W))
        {
            _targetPosition += _camera.transform.InverseTransformDirection(moveDirection) * Time.deltaTime * _movementSpeed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            _targetPosition -= _camera.transform.InverseTransformDirection(moveDirection) * Time.deltaTime * _movementSpeed;
        }

        _camera.localPosition = Vector3.Lerp(_camera.localPosition, _targetPosition, Time.deltaTime * _lerpSpeed);
    }
}

[System.Serializable]
public struct CameraData
{
    [SerializeField] private Vector3 _position;
    [SerializeField] private Vector3 _rotation;
}
