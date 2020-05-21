using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscillatoryVerticalMovement : MonoBehaviour
{
    [SerializeField] private float speed = 0;
    [SerializeField] private float angularSpeed = 0;

    private Rigidbody2D rb = null;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        float toMove = Mathf.Sin(timer * angularSpeed) * speed;

        rb.velocity = new Vector2(rb.velocity.x, toMove);
    }
}
