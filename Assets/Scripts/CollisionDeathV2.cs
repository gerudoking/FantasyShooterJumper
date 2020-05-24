using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CollisionDeathV2 : MonoBehaviour
{
    [SerializeField] private GameObject gameOverMenu = null;
    [SerializeField] private GameObject gameObjects = null;
    [SerializeField] private BaseHorizontalValue value = null;
    [SerializeField] private GameObject points = null;
    [SerializeField] private Text gameoverPoints = null;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstaculo")
        {
            GameOver();
        }
    }

    private void Update()
    {
        if (transform.position.y > Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y) {
            GameOver();
        }
        if (transform.position.y < Camera.main.ScreenToWorldPoint(Vector3.zero).y) {
            GameOver();
        }
    }

    private void GameOver() {
        Debug.Log("Game Over");
        value.speed /= 2;
        gameObjects.transform.GetChild(0).position = new Vector3(-7, 0, 0);

        for (int i = 1; i < gameObjects.transform.childCount; i++) {
            gameObjects.transform.GetChild(i).GetComponent<Spawner>().Restart();
        }

        gameoverPoints.text = "Points: " + PointCounter.points;

        PointCounter.points = 0;

        points.SetActive(false);
        gameOverMenu.SetActive(true);
        gameObjects.SetActive(false);
    }
}
