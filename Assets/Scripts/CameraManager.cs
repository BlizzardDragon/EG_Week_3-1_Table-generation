using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 10f;
    [SerializeField] private float _lerpSpeed = 2f;
    [SerializeField] private float _startPositionZ;
    [SerializeField] private float _waitTime = 2f;
    [SerializeField] private float _endPositionZ;
    [SerializeField] Vector3 _moveDirection = new Vector3(0, -0.6f, 1f);
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
        StartCoroutine(Approximation());
    }

    private void LateUpdate()
    {
        _cameraCenter.transform.Rotate(_rotateDirectionCenter * Time.deltaTime);
        _camera.localPosition = Vector3.Lerp(_camera.localPosition, _targetPosition, Time.deltaTime * _lerpSpeed);
    }

    private IEnumerator Approximation()
    {
        while (_targetPosition.z < _endPositionZ)
        {
            _targetPosition += _moveDirection * Time.deltaTime * _movementSpeed;
            yield return null;
        }
        yield return new WaitForSeconds(_waitTime);
        StartCoroutine(Alienate());
    }

    private IEnumerator Alienate()
    {
        while (_targetPosition.z > _startPositionZ)
        {
            _targetPosition -= _moveDirection * Time.deltaTime * _movementSpeed;
            yield return null;
        }
        yield return new WaitForSeconds(_waitTime);
        StartCoroutine(Approximation());
    }
}

[System.Serializable]
public struct CameraData
{
    [SerializeField] private Vector3 _position;
    [SerializeField] private Vector3 _rotation;
}
