using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private BaseHorizontalValue value = null;
    [SerializeField] private Transform gameObjects = null;
    public static int gameState = 0;

    public void PlayGame ()
    {
        value.speed *= 2;
        gameState = 1;
        gameObjects.gameObject.SetActive(true);

        foreach(Transform t in transform) {
            t.gameObject.SetActive(false);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
