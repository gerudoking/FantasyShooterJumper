using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    private Material mat;
    private bool isDissolving = false;
    private float fade = 1.0f;

    private void Start() {
        mat = GetComponent<SpriteRenderer>().material;
    }

    private void Update() {
        if (isDissolving) {
            fade -= Time.deltaTime * 1.5f;

            if(fade <= 0.0f) {
                fade = 0.0f;
                Destroy(gameObject);
            }

            mat.SetFloat("_Fade", fade);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "bullet") {
            Destroy(collision.gameObject);
            StartDestroy();
        }
    }

    private void StartDestroy() {
        PointCounter.points += 10;
        GetComponent<Collider2D>().enabled = false;
        isDissolving = true;
    }
}
