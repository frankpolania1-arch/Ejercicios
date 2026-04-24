using UnityEngine;
using UnityEngine.SceneManagement;

public class Puntos : MonoBehaviour
{
    Temporizador temporizador;
    GameEngine Engine;
    void Start()
    {
        temporizador = FindAnyObjectByType<Temporizador>();
        Engine = FindAnyObjectByType<GameEngine>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (SceneManager.GetActiveScene().name == "Nivel6")
        {
            temporizador.segundos2 += 5;
            Destroy(gameObject);
            return;
        }
        if (SceneManager.GetActiveScene().name == "Nivel4")
        {
            if (other.CompareTag("Player"))
            {
                Engine.text.text = ("Nivel Completado");
                Object.Destroy(gameObject);
                Destroy(GameObject.FindGameObjectWithTag("Player"));
            }
        }
        if (other.CompareTag("Player") && SceneManager.GetActiveScene().name == "Nivel5")
        {
            if (gameObject.tag == "Piña")
            {
                Engine.Puntos(0);
                Destroy(gameObject);
            }
            else if (gameObject.tag == "Kiwi")
            {
                Engine.Puntos(1);
                Destroy(gameObject);
            }
        }
    }
}
