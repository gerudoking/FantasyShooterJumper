using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    [Tooltip("Objeto escriptável do tipo BaseHorizontalValue, usado para determinar a velocidade horizontal do objeto.")]
    [SerializeField] private BaseHorizontalValue value = null;
    [Tooltip("Velocidade adicional para o objeto além da velocidade horizontal base")]
    [SerializeField] private float extraSpeed = 0;
    [Tooltip("Posição final do movimento do objeto. Ao atingir essa posição, volta para a posição inicial.")]
    [SerializeField] private float finalPosition = 0;
    [Tooltip("Marcar para que a movimentação faça uso do efeito Parallax")]
    [SerializeField] private bool usesParallax = false;
    [Tooltip("Fator que altera a velocidade, causando o efeito Parallax")]
    [SerializeField] private float parallaxFactor = 0;
    [Tooltip("Se marcado, o objeto é destruído ao chegar na posição final ao invés de retornar pra posição inicial.")]
    [SerializeField] private bool destroyOnFinal = false;

    private float startPosition = 0;
    private Rigidbody2D rb = null;

    private void Start() {
        startPosition = transform.position.x;
        rb = GetComponent<Rigidbody2D>();
        value.SetupSpeed();
    }

    private void Update() {
        if(transform.position.x <= finalPosition) {
            if (destroyOnFinal) {
                Destroy(gameObject);
                return;
            }

            transform.position = new Vector3(startPosition, transform.position.y, transform.position.z);
        }
    }

    private void FixedUpdate() {
        if(value.speed != 0) {
            float step = -value.speed - extraSpeed;
            if (usesParallax) {
                step /= parallaxFactor;
            }

            rb.MovePosition((Vector2)transform.position + new Vector2(step * Time.fixedDeltaTime, 0));
        }
    }
}
