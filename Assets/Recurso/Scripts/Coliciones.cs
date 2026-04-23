using UnityEngine;
using UnityEngine.SceneManagement;

public class Coliciones : MonoBehaviour
{
    GameEngine Engine;
    BoxCollider2D objecto;
    Temporizador temporizador;

    void Start()
    {
        objecto = GetComponent<BoxCollider2D>();
        Engine = GetComponent<GameEngine>();

        temporizador = FindAnyObjectByType<Temporizador>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("¡Colisión con el jugador!");
            temporizador.ControlarTiempo(false);
            if ( SceneManager.GetActiveScene().name == "Nivel2" )
            {
                Object.Destroy(gameObject);
            }
           
        }
    }
}