using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
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
        transform.rotation = Quaternion.Euler(0, player.transform.eulerAngles.y, 0);
    }
}
