using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab = null;
    [SerializeField] private float shootCooldown = 0;
    [SerializeField] private float shootSpeed = 0;
    [SerializeField] private Animator armAnim = null;

    private float timer = 0;

    // Update is called once per frame
    void Update()
    {
        //Atira caso pressione o botão
        if (Input.GetKeyDown(KeyCode.Space) && timer <= 0) {
            armAnim.SetTrigger("attack");
            //CreateBullet();
        }

        //Atualização do cooldown do tiro
        timer -= Time.deltaTime;
        timer = Mathf.Clamp(timer, 0, shootCooldown);
    }

    public void CreateBullet() {
        GameObject obj = Instantiate(projectilePrefab, transform.position
            + new Vector3(1.0f, 0), Quaternion.identity);

        obj.GetComponent<Rigidbody2D>().AddForce(Vector2.right * shootSpeed * Time.deltaTime);
        timer = shootCooldown;
    }
}
