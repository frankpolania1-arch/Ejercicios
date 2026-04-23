using TMPro;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameEngine : MonoBehaviour
{
    TextMeshProUGUI text;
    int PasosD = 0;
    int PasosI = 0;
    int saltos = 0;
    Botones botones;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        botones = GetComponent<Botones>();

    }
    public void CuentaPasos(int paso)
    {
        if (paso == 1)
        {
            PasosD++;
        }
        else if (paso == 0)
        {
            PasosI++;
        }
        text.text = $"Pasos Derecha: {PasosD}\nPasos Izquierda: {PasosI}";
    }

    public void CuentaSaltos(bool saltoV)
    {
        if (SceneManager.GetActiveScene().name =="Nivel3")
        {
            if (saltoV)
            {
                saltos++;
                text.text = $"Saltos: {saltos}";
            }
            else
            {
                text.text = $"Saltos: {saltos}";
            }
        } 
    }
}
