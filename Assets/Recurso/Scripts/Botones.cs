using System;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Botones : MonoBehaviour
{
    Button boton;
    public Movimiento movimiento;
    public Temporizador temporizador;
    GameEngine engine;
    private void Start()
    {
        
        boton = GetComponent<Button>();
        movimiento = FindAnyObjectByType<Movimiento>();
        boton.onClick.AddListener(OnClick);
       

    }

    private void OnClick()
    {
        string nivel = boton.name.Substring(3, 1);
        switch(nivel)
        {
            case "1":
                SceneManager.LoadScene("Nivel1");

                break;
            case "2": 
                SceneManager.LoadScene("Nivel2");
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
