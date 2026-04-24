using System.IO;
using System.Threading.Tasks;
using TMPro;
using Unity.VectorGraphics;
using Unity.VisualScripting;
using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameEngine : MonoBehaviour
{
    public TextMeshProUGUI text;
    int puntos = 0;
    byte vidas = 0;
    int PasosD = 0;
    int PasosI = 0;
    int saltos = 0;
    int PinasC = 0;
    int kiwisC = 0;
    string ruta;
    GameObject jugador;
    Botones botones;

    public class DatosJuego
{
    public int kiwis;
    public int pinas;
        public int total;
}

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        jugador = GameObject.FindGameObjectWithTag("Player");
        botones = GetComponent<Botones>();
        vidas = 3;
        ruta = Application.persistentDataPath + "/datos.json";
        Texto();

    }
    public void GuardarJuego()
    {
        if (SceneManager.GetActiveScene().name == "Nivel7")
        {
            if (string.IsNullOrEmpty(ruta))
            {
                ruta = Application.persistentDataPath + "/datos.json";
            }

            DatosJuego datos = new DatosJuego();

            datos.pinas = PinasC;
            datos.kiwis = kiwisC;
            datos.total = datos.pinas + datos.kiwis;

            string json = JsonUtility.ToJson(datos, true);

            File.WriteAllText(ruta, json);

            Debug.Log("Datos guardados en: " + ruta);
        }
    }
    public void Texto()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Nivel4":
                text.text = $"Vidas: {vidas}";
            break;
            case "Nivel5":
                    text.text = $"Puntos: {puntos}";
            break;
        }
    }

    public void Puntos(byte tipo)
    {
        switch (tipo)
        {
            case 0:
                puntos += 5;
                PinasC++;
                text.text = $"Puntos: {puntos}";
                break;
            case 1:
                puntos += 1;
                kiwisC++;
                text.text = $"Puntos: {puntos}";
                break;

        }
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

    public void Muerte()
    {
        vidas--;

        if (vidas == 0)
        {
            text.text = "Has perdido todas tus vidas, vuelve a intentarlo";
            Destroy(jugador);
            return;
        }
        text.text = $"Vidas: {vidas}";
        jugador.transform.position = new Vector2(-5.7f, -1.5f);
    }
}
