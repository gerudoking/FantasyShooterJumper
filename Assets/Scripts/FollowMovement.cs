using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMovement : MonoBehaviour
{
    [SerializeField] private float speed = 0;

    private Rigidbody2D rb = null;
    private float timer = 0;
    private Transform player = null;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float toMove = 0.0f;
        if(player.position.y > transform.position.y) {
            toMove = speed * Time.deltaTime;
        }
        else if(player.position.y < transform.position.y) {
            toMove = (-speed) * Time.deltaTime;
        }

        rb.velocity = new Vector2(rb.velocity.x, toMove);
    }
}
