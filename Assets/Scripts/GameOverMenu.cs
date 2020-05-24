using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuObjects = null;

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void Menu()
    {
        menuObjects.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
            
    }

}
