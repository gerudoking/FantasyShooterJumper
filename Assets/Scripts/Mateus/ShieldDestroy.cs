using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldDestroy : MonoBehaviour
{

    public Material ShieldDissolve;
    public Material Bloom;
    private bool isDissolving = false;
    private float fade = 1.0f;
    public GameObject Shield2;
    void Start()
    {
        Shield2.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstaculo")
        {
            Debug.Log("GameOver");
                StartDestroy();
        }
    }


    private void StartDestroy()
    {
        isDissolving = true;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GetComponent<SpriteRenderer>().material = Bloom;
            isDissolving = false;
            fade = 1.0f;
        }

        if (Input.GetKeyDown(KeyCode.G))
            StartDestroy();

   
        if (isDissolving)
        {
            fade -= Time.deltaTime * 1.5f;

            if (fade <= 0.0f)
            {
                fade = 0.0f;
                Shield2.SetActive(false);
            }
            ShieldDissolve = GetComponent<SpriteRenderer>().material = ShieldDissolve;
            ShieldDissolve.SetFloat("_Fade", fade);
        }
    }

}
