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

    private Material mat;
    private Material armMat;
    private bool isDissolving = false;
    private float fade = 1.0f;
    public bool withShield = false;
    private bool invFrame = false;
    private float invFrameDuration = 1.5f;
    private float invFrameTimer = 0.0f;

    private void Start() {
        mat = GetComponent<SpriteRenderer>().material;
        armMat = transform.GetChild(0).GetComponent<SpriteRenderer>().material;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstaculo")
        {
            if (withShield) {
                transform.GetChild(1).GetComponent<ShieldDestroy>().StartDestroy();
                invFrame = true;
                invFrameTimer = invFrameDuration;
                withShield = false;
                return;
            }

            if (invFrame) {
                return;
            }

            isDissolving = true;
        }
    }

    private void Update()
    {
        if (invFrame) {
            invFrameTimer -= Time.deltaTime;

            if(invFrameTimer <= 0) {
                invFrame = false;
            }
        }

        if (isDissolving) {
            fade -= Time.deltaTime * 2;

            if (fade <= 0.0f) {
                fade = 0.0f;
                GameOver();
            }

            mat.SetFloat("_Fade", fade);
            armMat.SetFloat("_Fade", fade);
        }

        if (transform.position.y > Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y) {
            isDissolving = true;
        }
        if (transform.position.y < Camera.main.ScreenToWorldPoint(Vector3.zero).y) {
            isDissolving = true;
        }
    }

    private void GameOver() {
        Debug.Log("Game Over");
        value.speed = 140;
        gameObjects.transform.GetChild(0).position = new Vector3(-7, 0, 0);

        if (FindObjectOfType<BossIA>()) {
            FindObjectOfType<BossIA>().CallDie();
        }

        /*for (int i = 1; i < gameObjects.transform.childCount; i++) {
            gameObjects.transform.GetChild(i).GetComponent<Spawner>().Restart();
        }*/

        gameObjects.transform.GetChild(2).GetComponent<Spawner>().Restart();

        gameoverPoints.text = "Score: " + PointCounter.points;

        PointCounter.points = 0;

        FindObjectOfType<PointCounter>().bossTreshold = 300;
        isDissolving = false;

        fade = 1.0f;

        mat.SetFloat("_Fade", 1.0f);
        armMat.SetFloat("_Fade", 1.0f);
        points.SetActive(false);
        gameOverMenu.SetActive(true);
        gameObjects.SetActive(false);
    }
}
