using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSpawn : MonoBehaviour
{
    public GameObject Shield2;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            Shield2.SetActive(true);
    }
}

