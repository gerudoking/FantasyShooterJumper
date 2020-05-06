using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDeath : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstaculo")
        {
            Debug.Log("Game Over");
        }
            
    }
        

}
