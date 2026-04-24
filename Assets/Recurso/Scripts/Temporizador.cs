using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Temporizador : MonoBehaviour
{
    private TextMeshProUGUI Reloj;
    private float segundos = 0;
    public float segundos2 = 0;
    private float minutos = 0;
    public int estaCorriendo = 0;

    void Start()
    {
        Reloj = GetComponent<TextMeshProUGUI>();
        segundos2 = 30;
    }

    void Update()
    {
        if (estaCorriendo == 3)
        {
            Reloj.text = string.Format("00:{0:00}:{1:00}", minutos, (int)segundos);
            return;
        }

        if (SceneManager.GetActiveScene().name == "Nivel2")
        {
            segundos += Time.deltaTime;

            if (segundos >= 60)
            {
                minutos++;
                segundos = 0;
            }
            Reloj.text = string.Format("00:{0:00}:{1:00}", minutos, (int)segundos);
            return;

        }
        if (SceneManager.GetActiveScene().name == "Nivel6")
        {
            segundos2 -= Time.deltaTime;

            // Si pasa de 60 al sumar tiempo
            if (segundos2 >= 60)
            {
                minutos += (int)(segundos2 / 60);
                segundos2 = segundos2 % 60;
            }

            // Si baja de 0
            if (segundos2 < 0)
            {
                if (minutos > 0)
                {
                    minutos--;
                    segundos2 += 60;
                }
                else
                {
                    segundos2 = 0;
                    Reloj.text = "Se acabó el tiempo";

                    Destroy(GameObject.FindGameObjectWithTag("Player"));
                    Destroy(GameObject.FindGameObjectWithTag("Kiwi"));

                    return;
                }
            }

            Reloj.text = string.Format("00:{0:00}:{1:00}", minutos, (int)segundos2);
            return;
        }
    }
    // Este es el método que llamarás desde afuera (botón o colisión)
    public void ControlarTiempo(int estado)
    {
        estaCorriendo = estado;
    }
}