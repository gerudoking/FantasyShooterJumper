using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(transform.position.x >= 30) {
            Debug.Log("Shoot!");
            Destroy(gameObject);
        }
    }
}
