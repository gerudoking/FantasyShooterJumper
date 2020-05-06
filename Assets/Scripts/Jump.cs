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
        if (Input.GetKeyDown(KeyCode.Space))
            GetComponent<Rigidbody2D>().AddForce(JumpForce);
    }
}
