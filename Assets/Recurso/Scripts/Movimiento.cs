using UnityEngine;
using UnityEngine.InputSystem;

public class Movimiento : MonoBehaviour
{
    float movimiento;
    public float movimientoSpeed = 5f;
    public float fuerzaSalto = 5f;
    Rigidbody2D rb;
    public GameEngine Engine;
    public bool ecena1 = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Engine = FindAnyObjectByType<GameEngine>();
    }

    void Update()
    {
        movimiento = 0f;

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f); // Reset Y
            rb.AddForce(new Vector2(0f, fuerzaSalto), ForceMode2D.Impulse);
        }

        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
            movimiento = 1f;
            if (ecena1)
            {
                Engine.CuentaPasos(1);
            }
        }
        else if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            movimiento = -1f;
            if (ecena1)
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