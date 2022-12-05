using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator : MonoBehaviour
{
    public GameObject NewBoxPrefab;
    public Material MaterialA;
    public Material MaterialB;
    public float speedBulets;
    

    void Update()
    {
        
        if(Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = Instantiate(NewBoxPrefab,transform.position, transform.rotation);
            newBullet.transform.localScale = Vector3.one * Random.Range(0.5f,1);

            newBullet.GetComponent<Rigidbody>().velocity = transform.forward * speedBulets;

            if(Random.Range(0,2) == 0)
            {
                newBullet.GetComponent<Renderer>().material = MaterialA; 
            }
            else
            {
                newBullet.GetComponent<Renderer>().material = MaterialB; 
            }
        }
    }
}
