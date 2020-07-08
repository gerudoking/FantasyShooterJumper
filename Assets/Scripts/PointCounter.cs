using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCounter : MonoBehaviour
{
    public static int points = 0;
    [SerializeField]
    private BaseHorizontalValue value = null;

    private float pointTime = 0.25f;
    private float timer = 0.25f;
    private int pointUpdate = 0;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0) {
            pointUpdate++;
            points++;
            timer = pointTime;
        }

        if(pointUpdate >= 500) {
            value.speed += 100;
            pointUpdate = 0;
        }

        GetComponent<Text>().text = "Score: " + points;
    }
}
