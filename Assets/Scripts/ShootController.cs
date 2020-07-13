using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab = null;
    [SerializeField] private float shootCooldown = 0;
    [SerializeField] private float shootSpeed = 0;
    [SerializeField] private float speedShootCooldown = 0;
    [SerializeField] private Animator armAnim = null;

    private float timer = 0;
    public bool speedShot = false;

    private float speedShotTimer = 10.0f;

    // Update is called once per frame
    void Update()
    {
        //Atira caso pressione o botão
        if (Input.GetKeyDown(KeyCode.Space) && timer <= 0 && !armAnim.GetCurrentAnimatorStateInfo(0).IsName("player_arm_attack_anim")) {
            armAnim.SetTrigger("attack");
            //CreateBullet();
        }

        //Atualização do cooldown do tiro
        timer -= Time.deltaTime;
        timer = Mathf.Clamp(timer, 0, shootCooldown);

        speedShotTimer -= Time.deltaTime;
        if(speedShotTimer <= 0) {
            speedShotTimer = 10.0f;
            speedShot = false;
        }
    }

    public void CreateBullet() {
        GameObject obj = Instantiate(projectilePrefab, transform.position
            + new Vector3(1.0f, 0), Quaternion.identity);

        float toSpeed = shootSpeed;
        if (speedShot) {
            toSpeed *= 2;
        }

        obj.GetComponent<Rigidbody2D>().AddForce(Vector2.right * toSpeed);
        if (speedShot)
            timer = speedShootCooldown;
        else
            timer = shootCooldown;
    }
}
