using TMPro;
using UnityEngine;

public class Temporizador : MonoBehaviour
{
    private TextMeshProUGUI Reloj;
    private float segundos = 0;
    private float minutos = 0;
    public bool estaCorriendo;

    void Start()
    {
        Reloj = GetComponent<TextMeshProUGUI>();
        estaCorriendo = true;
    }

    void Update()
    {
        if (estaCorriendo)
        {
            segundos += Time.deltaTime;

            if (segundos >= 60)
            {
                minutos++;
                segundos = 0;
            }
        }

        // Actualizamos el texto siempre para que se vea el último tiempo registrado
        Reloj.text = string.Format("00:{0:00}:{1:00}", minutos, (int)segundos);
    }

    // Este es el método que llamarás desde afuera (botón o colisión)
    public void ControlarTiempo(bool estado)
    {
        estaCorriendo = estado;
    }
}