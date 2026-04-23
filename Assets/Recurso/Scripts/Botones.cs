using System;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Botones : MonoBehaviour
{
    Button boton;
    GameEngine Engine;
    Movimiento movimiento;
    Temporizador temporizador;
    private void Start()
    {
        
        boton = GetComponent<Button>();
        Engine = FindAnyObjectByType<GameEngine>();
        boton.onClick.AddListener(OnClick);
    }
    
    private void OnClick()
    {
        string nivel = boton.name.Substring(3, 1);
        switch(nivel)
        {
            case "1":
                SceneManager.LoadScene("Nivel1");
                movimiento.ecena1 = true;
                break;
            case "2":
                SceneManager.LoadScene("Nivel2");
                temporizador.ControlarTiempo(true); 
                movimiento.ecena1 = false;
                break;
            case "3":
                SceneManager.LoadScene("Nivel3");
                break;
            default:
                Debug.Log("No se encontro el nivel");
                break;
        }

    }
}
