using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PruebaGiro : MonoBehaviour
{
    //Componentes
    Rigidbody player_rb;
    //Valores
    Vector3 player_velocity;
    Vector3 fuerzaGiro;
    [SerializeField]
    float valorGiro;
    float controlX;
    float controlY;

    // Start is called before the first frame update
    void Start()
    {
        //componentes
        player_rb = GetComponent<Rigidbody>();
        //valor
        fuerzaGiro = new Vector3();
    }

    private void FixedUpdate()
    {
        //Valores
        player_velocity = player_rb.velocity;
        Debug.Log("1 - Velocity player: " + player_velocity);
        //Fuerza de giro (de la velocidad)
        Debug.Log("2 - Control Y: " + controlY);
        player_rb.AddForce(calcular_FuerzaGiroY());
        player_rb.AddForce(calcular_FuerzaGiroX());
        //Rotacion de la nave (sobre el eje X)
        transform.rotation = Quaternion.AngleAxis(controlY*50, transform.right);  //player_rb.AddTorque(fuerzaGiro, ForceMode.VelocityChange);
        transform.rotation = Quaternion.AngleAxis(controlX*50, transform.up);
        transform.rotation = Quaternion.AngleAxis(controlX*-50, transform.forward);
    }

    //Metodos
    public void rotarNave() 
    {
        //Vacio
    }
    public Vector3 calcular_FuerzaGiroX()
    {
        /*
        Vector3 ejeX_local;
        Vector3 proyeccion_ejeX;
        Vector3 dir_fuerzaGiroX;
        Vector3 fuerzaGiroX;
        float controlY = this.controlX * 5.0f;
        //Proyeccion de Y en el plano perpendicular a V
        //Debug.Log("Velocidad: " + player_velocity);
        ejeX_local = Calculos.GiroEuler(transform.right, eulerVector);
        //Debug.Log("Eje Y: " + ejeY_local);
        proyeccion_ejeX = Calculos.proyeccionPerpendicular_aVector(ejeX_local, player_velocity);
        //Debug.Log("Poryeccion de EjeY perpendicular a V : " + proyeccion_ejeY);
        dir_fuerzaGiroX = proyeccion_ejeX.normalized;
        //Debug.Log("Direccion de Fc = " + dir_fuerzaGiroY);
        //Fuerza de giro en Y
        fuerzaGiroX = dir_fuerzaGiroX * controlY;
        return fuerzaGiroX;
        */
        return new Vector3();
    }
    public Vector3 calcular_FuerzaGiroY()
    {
        /*
        Vector3 ejeY_local;
        Vector3 proyeccion_ejeY;
        Vector3 dir_fuerzaGiroY;
        Vector3 fuerzaGiroY;
        float controlY = this.controlY * 5.0f;
        //Proyeccion de Y en el plano perpendicular a V
        ejeY_local = Calculos.GiroEuler(transform.up, eulerVector);
        //Debug.Log("Eje Y: " + ejeY_local);
        proyeccion_ejeY = Calculos.proyeccionPerpendicular_aVector(ejeY_local, player_velocity);
        Debug.Log("3 - Mov Y perpendicular a la Velocidad: " + proyeccion_ejeY);
        //Debug.Log("Poryeccion de EjeY perpendicular a V : " + proyeccion_ejeY);
        dir_fuerzaGiroY = proyeccion_ejeY.normalized;
        //Debug.Log("Direccion de Fc = " + dir_fuerzaGiroY);
        //Fuerza de giro en Y
        fuerzaGiroY = dir_fuerzaGiroY * controlY;
        return fuerzaGiroY;
        */
        return new Vector3();
    }
    //Eventos
    void OnMove(InputValue inputActionData)
    {
        Vector2 controllerVector = (inputActionData).Get<Vector2>();
        controlX = controllerVector.x;
        controlY = controllerVector.y;
    }

}
