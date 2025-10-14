using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class InterfazController : MonoBehaviour
{
    //components
    private Transform textTiempo;
    private TextMeshProUGUI textTiempoComponent;
    [SerializeField]
    private InputActionReference pauseButton;
    [SerializeField]
    private GameObject pauseMenu;
    //variables
    private float tiempo;
    private string tiempoString;
    bool paussed;



    void Start()
    {
        textTiempo = transform.Find("timeText");
        textTiempoComponent = textTiempo.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        contadorTiempo();
        pausarJuego();
    }

    //Metodos
    public void contadorTiempo() {
        //Tiempo
        tiempo += Time.deltaTime;
        ///recortar decimales
        tiempo = Mathf.Round(tiempo * 1000f) / 1000f;
        tiempoString = (tiempo.ToString());
        //Mostrarlo en la UI
        textTiempoComponent.text = tiempoString;
    }
    public void pausarJuego() {
        //Si se presiona Enter
        if (pauseButton.action.IsPressed())
        {
            Debug.Log("INtro a tope");
            if (pauseMenu.activeSelf)
            {
                paussed = false;
                Resume();
            }
            else
            {
                paussed = true;
                Pause();
            }
        }
    }
    void Pause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    void Resume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

}

