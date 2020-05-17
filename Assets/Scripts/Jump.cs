using UnityEngine;

public class Jump : MonoBehaviour
{
    public Vector2 JumpForce;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            Debug.Log("Jumped");
            if (rb.velocity.y < 0) {
                rb.velocity = Vector2.zero;
            }
            rb.AddForce(JumpForce * Time.deltaTime, ForceMode2D.Impulse);
        }
    }
}
