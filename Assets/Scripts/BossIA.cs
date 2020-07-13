using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIA : MonoBehaviour
{
    [SerializeField]
    private float spitCooldown = 0.0f;
    [SerializeField]
    private Transform spitPos = null;
    [SerializeField]
    private GameObject spitBullet = null;
    [SerializeField]
    private float spitSpeed = 0;
    public int life = 0;
    public int maxLife = 0;
    private float spitTimer = 0.0f;
    public Animator anim = null;
    private Transform player = null;
    private GameObject[] mat;
    public bool isDissolving = false;
    private float fade = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        mat = GameObject.FindGameObjectsWithTag("boss");
        anim = GetComponent<Animator>();
        spitTimer = spitCooldown;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        life = maxLife;
    }

    // Update is called once per frame
    void Update()
    {
        spitTimer -= Time.deltaTime;

        if(spitTimer <= 0) {
            anim.SetTrigger("spit");
            spitTimer = spitCooldown;
        }

        if (life <= 0 && !isDissolving) {
            anim.SetBool("die", true);
            isDissolving = true;
        }

        if (isDissolving) {
            fade -= Time.deltaTime * 0.5f;

            if (fade <= 0.0f) {
                fade = 0.0f;
                CallDie();
            }

            foreach (GameObject obj in mat) {
                obj.GetComponent<SpriteRenderer>().material.SetFloat("_Fade", fade);
            }
        }
    }

    public void CallSpit() {
        GameObject bullet = Instantiate(spitBullet, spitPos.position,
            Quaternion.LookRotation(Vector3.forward, player.position - spitPos.position));

        bullet.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * spitSpeed);
    }

    public void CallDie() {
        gameObject.SetActive(false);
        transform.position = FindObjectOfType<PointCounter>().startPos.position;
        FindObjectOfType<PointCounter>().bossBattle = false;
        life = maxLife;
        anim.SetBool("die", false);
        isDissolving = false;
        foreach (GameObject obj in mat) {
            obj.GetComponent<SpriteRenderer>().material.SetFloat("_Fade", 1.0f);
        }
        fade = 1.0f;
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "bullet") {
            Destroy(collision.gameObject);
            life--;
        }
    }

}
