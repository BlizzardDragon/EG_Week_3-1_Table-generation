using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float Speed;

    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * Speed * Input.GetAxis("Vertical");
        transform.position += transform.right * Time.deltaTime * Speed * Input.GetAxis("Horizontal");

        if (transform.forward.z > 0)
        {
            transform.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        else
        {
            transform.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }
}
