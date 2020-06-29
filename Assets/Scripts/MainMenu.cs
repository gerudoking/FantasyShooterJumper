using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private BaseHorizontalValue value = null;
    [SerializeField] private Transform gameObjects = null;
    [SerializeField] private GameObject menuObjects = null;
    [SerializeField] private GameObject points = null;
    [SerializeField] private Text timerText = null;
    [SerializeField] private GameObject fakePlayer = null;
    public static int gameState = 0;
    private float timer = 3.0f;
    private bool onTimer = false;

    public void PlayGame ()
    {
        timerText.gameObject.SetActive(true);
        fakePlayer.SetActive(true);
        value.speed *= 2;
        onTimer = true;

        menuObjects.SetActive(false);
    }

    private void Update() {
        if (onTimer) {
            timer -= Time.deltaTime;

            timerText.text = Mathf.CeilToInt(timer).ToString();
            if(timer <= 0) {
                gameState = 1;
                gameObjects.gameObject.SetActive(true);
                points.SetActive(true);
                fakePlayer.SetActive(false);
                timerText.gameObject.SetActive(false);
                onTimer = false;
                timer = 3.0f;
            }
        }
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
