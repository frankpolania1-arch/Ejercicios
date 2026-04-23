using UnityEngine;

public class Coliciones : MonoBehaviour
{
    GameEngine Engine;
    BoxCollider2D objecto;
    Temporizador temporizador;
    void Start()
    {
        objecto = GetComponent<BoxCollider2D>();

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 'other' es el objeto que acaba de tocar a este objeto
        string tagOtro = other.gameObject.tag;

        // Ejemplo de uso:
        if (other.CompareTag("Player"))
        {
            temporizador.ControlarTiempo(false);
        }
    }
}
