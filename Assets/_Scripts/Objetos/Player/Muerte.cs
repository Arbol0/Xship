using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Muerte : MonoBehaviour
{
    PlayerInput playerInput;

    void Start()
    {
        playerInput = this.gameObject.GetComponent<PlayerInput>();
    }

    //Este evento detecta todas las colisiones con los colliders de otros objetos
    private void OnTriggerEnter(Collider collider)
    {
        //Si la colision es con un limite
        if (collider.gameObject.CompareTag("Limit"))
        {
            //la nave muere
            Destroy(this.gameObject);
        }
    }

    //Caundo la nave sea destruida
    public void OnDestroy()
    {
        //Mandar al menu principal
        SceneManager.LoadScene("MenuPrincipal");
    }
}
