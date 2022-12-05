using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Vector3 _rotateDirectionCenter = Vector3.up * 5;

    [Space]
    [SerializeField] private Transform _cameraCenter;
    [SerializeField] private Transform _camera;

    [Space]
    [SerializeField] private List<CameraData> _cameraData = new List<CameraData>(); 

    private void Update()
    {
        _cameraCenter.transform.Rotate(_rotateDirectionCenter * Time.deltaTime);
    }
}

[System.Serializable]
public struct CameraData 
{
    [SerializeField] private Vector3 _position;
    [SerializeField] private Vector3 _rotation;
}
