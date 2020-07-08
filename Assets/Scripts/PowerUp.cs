using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private int powerUpType = 0;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            if (powerUpType == 0) {
                collision.GetComponent<CollisionDeathV2>().withShield = true;
                collision.transform.GetChild(1).gameObject.SetActive(true);
                Destroy(gameObject);
            }
        }
    }
}
