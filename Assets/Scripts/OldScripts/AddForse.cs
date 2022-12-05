using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForse : MonoBehaviour
{
    private Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(0, 300, 0);
        }
    }
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.A))
        {
            _rigidbody.AddForce(-15, 0, 0);
        }
        if(Input.GetKey(KeyCode.D))
        {
            _rigidbody.AddForce(15, 0, 0);
        }
    }
}
