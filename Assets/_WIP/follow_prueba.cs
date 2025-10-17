using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow_prueba : MonoBehaviour
{
    //variables
    Vector3 rotateX_ship;
    //Componentes
    GameObject player;

    void Start()
    {
        player = GameObject.Find("Supernova_Spaceship");
    }

    void Update()
    {
        //posicion 
        transform.position = GameObject.Find("Supernova_Spaceship").transform.position;
        //rotation
        transform.rotation = Quaternion.FromToRotation(transform.forward, GameObject.Find("Supernova_Spaceship").transform.forward);
    }
}
