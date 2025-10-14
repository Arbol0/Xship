using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meta : MonoBehaviour
{
    //Variables/Componentes
    followPlayer Origin_followPlayer;


    private void OnTriggerEnter(Collider collider)
    {
        //Si la colision es con el player
        if (collider.gameObject.CompareTag("Player"))
        {
            //La camara deja de seguir al player
            Origin_followPlayer = GameObject.Find("XR Origin").GetComponent<followPlayer>();
            Origin_followPlayer.enabled = false;
            //

        }
    }
}
