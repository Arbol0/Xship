using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void chancheScene() {
        SceneManager.LoadScene("Scene1");
        Debug.Log("Escena Cargada");
    }
    public void activarSonido() {

    }
    public void desactivarSonido()
    {

    }
}
