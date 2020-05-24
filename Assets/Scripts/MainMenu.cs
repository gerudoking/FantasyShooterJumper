using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private BaseHorizontalValue value = null;
    [SerializeField] private Transform gameObjects = null;
    [SerializeField] private GameObject menuObjects = null;
    [SerializeField] private GameObject points = null;
    public static int gameState = 0;

    public void PlayGame ()
    {
        value.speed *= 2;
        gameState = 1;
        gameObjects.gameObject.SetActive(true);
        points.SetActive(true);

        menuObjects.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
