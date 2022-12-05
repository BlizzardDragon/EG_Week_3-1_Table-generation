using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSimulation : MonoBehaviour
{
    Rigidbody _rigibady;
    // Start is called before the first frame update
    void Start()
    {
        _rigibady = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position.y <=0)
        {
            _rigibady.AddForce(0, 50, 0);
        }
    }
}
