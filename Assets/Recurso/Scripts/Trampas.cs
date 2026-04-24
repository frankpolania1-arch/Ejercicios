using UnityEngine;
using UnityEngine.SceneManagement;

public class Trampas : MonoBehaviour
{
    GameEngine Engine;
    void Start()
    {
        Engine = FindAnyObjectByType<GameEngine>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           Engine.Muerte();
        }
    }

}
