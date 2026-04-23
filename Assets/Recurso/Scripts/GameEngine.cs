using TMPro;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameEngine : MonoBehaviour
{
    TextMeshProUGUI text;
    Temporizador tiempoNivel2;
    int PasosD = 0;
    int PasosI = 0;
    Botones botones;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        tiempoNivel2 = GetComponent<Temporizador>();
        botones = GetComponent<Botones>();
        text.text = $"Pasos Derecha: {PasosD} \n Pasos Izquierda: {PasosI}";
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


}
