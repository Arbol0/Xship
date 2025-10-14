using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    /*
    //Valores
    float controlX;
    float controlY;
    Vector3 eulerVector;
    Vector3 player_velocity;
    Vector3 player_velocityDir;
    Vector3 ejeZ_local;
    float angulo_ejeZ_velocidad;
    //Componentes
    Rigidbody playerRB;
    void Start()
    {
        //Componentes
        playerRB = GetComponent<Rigidbody>();
        //valores
        controlX = 0.0f;
        controlY = 0.0f;
        eulerVector = new Vector3();
        player_velocity = new Vector3();
    }
    //Fisicas
    void FixedUpdate()
    {
        //Debug.Log("-----------------------------------------------PlayerController--------------------------------------");
        //Calcular valores: (rotacion, velocidad, ejes locales...)
        eulerVector = transform.rotation.eulerAngles;
        //Debug.Log("transform froward: " + transform.forward);
        //Debug.Log("z Local: " + ejeZ_local);
        player_velocity = playerRB.velocity;
        //Aplicar fuerzas de giro (cuando hay un valor en los controles X o Y)
        playerRB.AddForce(calcular_FuerzaGiroY());
        playerRB.AddForce(calcular_FuerzaGiroX());
    }

    private void Update()
    {
        //Ajustar orientacion - para que la nave mire hacia V
        Debug.Log("Z: " + transform.forward);
        Debug.Log("vlocidad " + playerRB.velocity);
        angulo_ejeZ_velocidad = Vector3.Angle(transform.forward, player_velocity);
        Debug.Log("Angulo ente Z y velocidad: " + angulo_ejeZ_velocidad);
        while (angulo_ejeZ_velocidad > 1.0f) //Si es mas grande de lo que debería
        {
            //gira 1 grado en Y en sus ejes locales
            transform.Rotate(new Vector3(1.0f, 0.0f, 0.0f), Space.Self);
            Debug.Log("SPACE SELF:       -------------------    : " + Space.Self);
            //para de girar cuando este cerca de v
            angulo_ejeZ_velocidad = Vector3.Angle(transform.forward, player_velocity);
        }
        /*
        Debug.Log("---------Update - FromToRotation --------------------------------");
        //Ajustar orientacion(transform), para que la nave miere hacia V
        player_velocityDir = player_velocity.normalized;
        Debug.Log("Eje Z: "+transform.forward+"  player_velocityDir: "+player_velocityDir);
        transform.rotation = Quaternion.FromToRotation(transform.forward, player_velocity);
        Debug.Log("Giro Transform de Eje Z a V: " + transform.rotation.eulerAngles);*/ /*
        
    }

    //Metodos
    public Vector3 calcular_FuerzaGiroX()
    {
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
    }
    public Vector3 calcular_FuerzaGiroY()
    {
        Vector3 ejeY_local;
        Vector3 proyeccion_ejeY;
        Vector3 dir_fuerzaGiroY;
        Vector3 fuerzaGiroY;
        float controlY = this.controlY * 5.0f;
        //Proyeccion de Y en el plano perpendicular a V
        //Debug.Log("Velocidad: " + player_velocity);
        ejeY_local = Calculos.GiroEuler(transform.up, eulerVector);
        //Debug.Log("Eje Y: " + ejeY_local);
        proyeccion_ejeY = Calculos.proyeccionPerpendicular_aVector(ejeY_local, player_velocity);
        //Debug.Log("Poryeccion de EjeY perpendicular a V : " + proyeccion_ejeY);
        dir_fuerzaGiroY = proyeccion_ejeY.normalized;
        //Debug.Log("Direccion de Fc = " + dir_fuerzaGiroY);
        //Fuerza de giro en Y
        fuerzaGiroY = dir_fuerzaGiroY * controlY;
        return fuerzaGiroY;
    }
    //Eventos
    void OnMove(InputValue inputActionData)
    {
        Vector2 controllerVector = (inputActionData).Get<Vector2>();
        controlX = controllerVector.x;
        Debug.Log("CONTROLEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEESSSSSSSSSSSSSSSSSS");
        Debug.Log("Control x = " + controlX);
        controlY = controllerVector.y;
        Debug.Log("Control y = " + controlY);
    }
    */
}
