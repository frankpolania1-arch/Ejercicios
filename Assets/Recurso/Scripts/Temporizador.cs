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

        }
        if (SceneManager.GetActiveScene().name == "Nivel6")
        {
            segundos2 -= Time.deltaTime;
            Reloj.text = string.Format("00:{0:00}:{1:00}", minutos, (int)segundos2);
            return;
        }
        Reloj.text = string.Format("00:{0:00}:{1:00}", minutos, (int)segundos);

    }


    // Este es el método que llamarás desde afuera (botón o colisión)
    public void ControlarTiempo(int estado)
    {
        estaCorriendo = estado;
    }
}