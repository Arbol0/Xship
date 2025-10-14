using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ModoInmortal : MonoBehaviour
{
    //variables/componentes
    [SerializeField]
    private InputActionReference inmortalButton;
    private bool inmortal;
    private CapsuleCollider colliderShip;


    void Start()
    {
        inmortal = false;
        colliderShip = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        //si se presiona q
        if (inmortalButton.action.IsPressed()) {
            if (inmortal)
            {
                //modo inmortal desactivado
                inmortal = false;
                //activar colliders
                colliderShip.enabled = true;
            }
            else {
                //modo inmortal activado
                inmortal = true;
                //desactivar colliders
                colliderShip.enabled = false;
            }
        }
    }
}
