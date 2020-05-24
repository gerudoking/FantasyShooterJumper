using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCounter : MonoBehaviour
{
    public static int points = 0;

    private float pointTime = 0.25f;
    private float timer = 0.25f;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0) {
            points++;
            timer = pointTime;
        }

        GetComponent<Text>().text = "Points: " + points;
    }
}
