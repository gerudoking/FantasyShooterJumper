using UnityEngine;

public class Jump : MonoBehaviour
{
    public Vector2 JumpForce = Vector2.zero;
    private Rigidbody2D rb = null;
    private Animator anim = null;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            Debug.Log("Jumped");
            if (rb.velocity.y < 0) {
                rb.velocity = Vector2.zero;
            }
            //rb.AddForce(JumpForce * Time.deltaTime, ForceMode2D.Impulse);
            rb.velocity = new Vector2(rb.velocity.x, JumpForce.y);

            anim.SetTrigger("jump");
        }
    }
}
