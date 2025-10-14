using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class pruebasFc : MonoBehaviour
{
    //Componentes
    private Rigidbody rb;
    //variables
    Vector3 fuerza_giroY;
    Vector3 fuerza_giroX;
    [SerializeField]
    private float giro_Fy;
    [SerializeField]
    private float giro_Fx;
    private float modulo_Fy;
    private float modulo_Fx;
    float controlY;
    float controlX;
    [SerializeField]
    float rotacionNave;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //angulo entre ambos vectores
        Debug.Log("--------Giro / Controller------------");
        Debug.Log("up: "+transform.up);
        Debug.Log("right-alas: " + transform.right);
        Debug.Log("vlocity: "+rb.velocity);
        //Fc en Y: producto vectorial de V y X(Alas)
        fuerza_giroY = Vector3.Cross(rb.velocity, transform.right);
        modulo_Fy = giro_Fy * controlY;
        rb.AddForce(fuerza_giroY * modulo_Fy);
        Debug.Log("Fuerza en Y - perpendicular a V: " + fuerza_giroY);
        //Fc en X: producto vectorial de V y Y(global)
        fuerza_giroX = Vector3.Cross(rb.velocity, new Vector3(0,-1,0));
        modulo_Fx = giro_Fx * controlX;
        rb.AddForce(fuerza_giroX * modulo_Fx);
        Debug.Log("Fuerza en X - perpendicular a V: " + fuerza_giroX);

        //GIRO NAVE
        //transform.rotation = Quaternion.FromToRotation(transform.forward, rb.velocity);
        Quaternion segumientoV = Quaternion.LookRotation(rb.velocity);
        
        //Rotacion sobre Z

    }

    //Evento
    //Control(X,Y) = Input
    void OnMove(InputValue inputActionData)
    {
        Debug.Log("------INPUT------- ");
        //Controles de Giro
        Vector2 controllerVector = (inputActionData).Get<Vector2>();
        controlX = controllerVector.x;
        controlY = controllerVector.y;
        //Rotar (sobre si misma)
        //transform.Rotate(new Vector3(-controlY, 0, 0));
    }

}
