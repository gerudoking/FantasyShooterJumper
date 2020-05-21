using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] toSpawn = null;
    [SerializeField] private float spawnTime = 0;

    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        timer = spawnTime * Random.Range(2.5f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0) {
            Instantiate(toSpawn[Random.Range(0, toSpawn.Length)], transform.position, Quaternion.identity);

            timer = spawnTime;
        }
    }
}
