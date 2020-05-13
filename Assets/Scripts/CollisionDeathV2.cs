using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDeathV2 : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstaculo")
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene(0);
        }
    }

    private void Update()
    {
        if (transform.position.y > 5.5)
            SceneManager.LoadScene(0);
        if (transform.position.y < -4.2)
            SceneManager.LoadScene(0);
    }


}
