using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Giro : MonoBehaviour
{
    //Controles XY
    private float controlX;
    private float controlY;
    //Giro
    [SerializeField]
    private float giro;
    [SerializeField]
    private float desplazamientoY;
    [SerializeField]
    private float fuerzaX;
    //Rotate - Parameters
    private float giroX;
    private Vector3 giroX_vector;
    private Vector3 albaeo_vector;
    //Componentes
    private Rigidbody player_rb;

    void Start()
    {
        //Componentes
        player_rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //Giro de la nave
        giroX = giroX_limitado();
        rotarNave(giroX);
    }

    void Update()
    {
        
    }

    //Metodo giro
    public void rotarNave(float giroX)
    {
        float anguloZ_deg;
        float w_giroX;
        Vector3 vector_desplazamientoY;
        //Alabeo
        anguloZ_deg = transform.rotation.eulerAngles.z;
        albaeo_vector = new Vector3(0, 0, -giroX) * giro;
        transform.Rotate(albaeo_vector, Space.Self);
        //Wx - proporcional a la inclinacion (alabeo)
        w_giroX = -Mathf.Sin(Calculos.grados_toRad(anguloZ_deg));
        //Giro X
        giroX_vector = new Vector3(0, w_giroX*fuerzaX, 0);
        transform.Rotate(giroX_vector, Space.World);
        //Giro Y
        /*rotation_ship = new Vector3(-controlY * fuerzaY, 0, 0);
        transform.Rotate(rotation_ship, Space.World);*/
        vector_desplazamientoY = new Vector3(0, controlY, 0);
        player_rb.AddForce(vector_desplazamientoY * desplazamientoY, ForceMode.Impulse);
    }
    public float giroX_limitado() {
        float limite_giroX=0;
        float anguloZ_deg;
        float anguloZ_rad;
        float cos_80;
        cos_80 = 0.7f; 
        //Angulo Z - Alabeo
        anguloZ_deg = transform.rotation.eulerAngles.z;
        anguloZ_rad = Calculos.grados_toRad(anguloZ_deg);
        //Comprobar si se pasa de los limites
        if (Mathf.Cos(anguloZ_rad) <= cos_80)
        //Si el angulo es menor que cos(), esta fuera del limite
        {
            if ((Mathf.Sin(anguloZ_rad) > 0) && (controlX == -1))
            //Si acaba de pasar el limite(de 80) y sigue hacia la izquierda(x == -1)
            {
                //Para
                limite_giroX = 0;
            }
            else if ((Mathf.Sin(anguloZ_rad) < 0) && (controlX == 1))
            //Si acaba de pasar el limite(de -80) y sigue hacia la derecha(x == 1)
            {
                //Para
                limite_giroX = 0;
            }
            else {
                limite_giroX = controlX;
            }
        }
        else {
            limite_giroX = controlX;
        }
        return limite_giroX;
    }

    public Vector3 get_giroX() {
        return giroX_vector;
    }

    //Evento - Controles XY
    void OnMove(InputValue inputActionData)
    {
        //Controles de Giro
        Vector2 controllerVector = (inputActionData).Get<Vector2>();
        controlX = controllerVector.x;
        controlY = controllerVector.y;
    }



}
