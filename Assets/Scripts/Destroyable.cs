using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "bullet") {
            StartDestroy();
        }
    }

    private void StartDestroy() {
        PointCounter.points += 10;
        Destroy(gameObject);
    }
}
