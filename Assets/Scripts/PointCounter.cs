using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCounter : MonoBehaviour
{
    public static int points = 0;
    [SerializeField]
    private BaseHorizontalValue value = null;
    [SerializeField]
    private GameObject boss = null;
    public Transform startPos = null;
    public Transform finalPos = null;

    private float pointTime = 0.25f;
    private float timer = 0.25f;
    private int pointUpdate = 0;
    public int bossTreshold = 0;
    [SerializeField]
    private GameObject warningUI = null;
    [SerializeField]
    private float getToFinalSpeed = 0.0f;

    private float warningDuration = 3.0f;
    private float warningTimer = 0.0f;
    private bool warningSet = false;

    public bool bossBattle = false;

    private void Start() {
        warningTimer = warningDuration;
    }

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

        if(points >= bossTreshold && !warningSet && !bossBattle) {
            warningSet = true;
            warningUI.SetActive(true);
            bossBattle = true;
            bossTreshold += 400;
        }

        if (warningSet) {
            warningTimer -= Time.deltaTime;
            if(warningTimer <= 0) {
                warningUI.SetActive(false);
                boss.SetActive(true);
                warningTimer = warningDuration;
                warningSet = false;
            }
        }

        if (boss.activeSelf) {
            if (Vector3.Distance(boss.transform.position, finalPos.position) > 0.1f) {
                boss.transform.position = Vector2.MoveTowards(boss.transform.position, finalPos.position, getToFinalSpeed * Time.deltaTime);
            }
            else {
                boss.transform.position = finalPos.position;
            }
        }
    }
}
