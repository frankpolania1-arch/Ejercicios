using UnityEngine;
using UnityEngine.SceneManagement;

public class Dsuelo : MonoBehaviour
{
    public static bool tocandoSuelo;
    GameEngine Engine;

    void Start()
    {
        Engine = FindAnyObjectByType<GameEngine>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Suelo"))
        {
            tocandoSuelo = true;
            if (SceneManager.GetActiveScene().name == "Nivel3") Engine.CuentaSaltos(false);

        }
        if (other.CompareTag("Plataforma"))
        {
            tocandoSuelo = true;
            if (SceneManager.GetActiveScene().name == "Nivel3") Engine.CuentaSaltos(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Suelo") || other.CompareTag("Plataforma"))
        {
            tocandoSuelo = false;
        }
    }

}
