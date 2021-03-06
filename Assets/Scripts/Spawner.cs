﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] toSpawn = null;
    [SerializeField] private float spawnTime = 0;
    [SerializeField] private Vector3 offset = Vector3.zero;

    private float timer = 0;
    private PointCounter points = null;

    // Start is called before the first frame update
    void Start()
    {
        points = FindObjectOfType<PointCounter>();
        timer = spawnTime/2/* * Random.Range(1.5f, 3.0f)*/;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0) {
            Instantiate(toSpawn[Random.Range(0, toSpawn.Length)], transform.position + offset, Quaternion.identity);

            timer = spawnTime/* + Random.Range(1.0f, 2.5f)*/;
            if (points.bossBattle) {
                timer *= 3;
            }
        }
    }

    public void Restart() {
        timer = spawnTime/2/* * Random.Range(2.5f, 5.0f)*/;
    }
}
