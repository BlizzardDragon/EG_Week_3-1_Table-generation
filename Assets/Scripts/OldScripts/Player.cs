using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int Heals = 5;
    
    public void TakeDamage(int damage)
    {
        Heals -= damage;
        if(Heals <= 0)
        {
            Destroy(gameObject);
        }
    }
}
