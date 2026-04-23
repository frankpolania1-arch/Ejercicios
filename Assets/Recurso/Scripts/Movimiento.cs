using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Movimiento : MonoBehaviour
{
    float movimiento;
    public float movimientoSpeed = 5f;
    public float fuerzaSalto = 5f;
    Rigidbody2D rb;
    public GameEngine Engine;
    BoxCollider2D suelo;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Engine = FindAnyObjectByType<GameEngine>();

        suelo = GameObject.Find("Dsuelo").GetComponent<BoxCollider2D>();
    }

  
    void Update()
    {
        movimiento = 0f;

        if (Keyboard.current.spaceKey.wasPressedThisFrame && Dsuelo.tocandoSuelo)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }

        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
            movimiento = 1f;

            if (SceneManager.GetActiveScene().name == "Nivel1")
            {
                Engine.CuentaPasos(1);
            }
        }
        else if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            movimiento = -1f;

            if (SceneManager.GetActiveScene().name == "Nivel1")
            {
                Engine.CuentaPasos(0);
            }
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(movimiento * movimientoSpeed, rb.linearVelocity.y);
    }
}