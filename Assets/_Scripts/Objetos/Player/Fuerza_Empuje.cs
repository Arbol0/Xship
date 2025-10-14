using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Fuerza_Empuje : MonoBehaviour
{
    //Valores
    [SerializeField]
    private InputActionReference turboButton;
    private bool modo_Turbo;
    [SerializeField]
    private float modulo_velocidadTurbo;
    [SerializeField]
    private float modulo_velocidad;
    [SerializeField]
    private float correccion_Vz;
    [SerializeField]
    private float correccion_Vxy;
    private Vector3 Vz_correcta;
    //Componentes
    private Rigidbody player_rb;

    void Start()
    //Inicializar atributos
    {
        //Valores
        modo_Turbo = false;
        //Componentes
        player_rb = GetComponent<Rigidbody>();
    }

    //Fuerzas
    void FixedUpdate()
    {
        //Velocidad z=
        player_rb.AddForce(ajustar_velocidadIncorrecta());
        //Corrector de Iniercia (en XY local)
        player_rb.AddForce(corrector_lateral());
    }


    //Comprobar V
    public Vector3 comprobar_velocidad_Z()
    {
        //variables
        Vector3 velocity;
        Vector3 localZ;
        Vector3 Vz = new Vector3();
        float velocityModule;
        Vector3 correction_Force;
        //VELOCIDAD EN Z
        velocity = player_rb.velocity;
        localZ = transform.forward;
        //Proyeccion de V en Z
        Vz = Calculos.proyeccion_sobre_Vector(velocity, localZ);
        return Vz;
    }

    //Ajustar Velocidad Incorrecta
    public Vector3 ajustar_velocidadIncorrecta()
    {
        //Variables
        Vector3 Vz = comprobar_velocidad_Z();
        Vector3 correccion_Force;
        modo_Turbo = (turboButton.action.ReadValue<float>() == 1);
        //Vz correcta = Z(local) * |V_correcta|
        if (modo_Turbo)
        {
            //Vz correcta en turbo
            Vz_correcta = transform.forward * modulo_velocidadTurbo;
        }
        else
        {
            //Vz correcta en normal
            Vz_correcta = transform.forward * modulo_velocidad;
        }
        //Fuerza = diferecia entre Vz(correcta) y Vz(actual)
        correccion_Force = (Vz_correcta - Vz) * correccion_Vz;

        return correccion_Force;
    }

    public Vector3 corrector_lateral()
    {
        //Variables
        Vector3 Vz = comprobar_velocidad_Z();
        Vector3 inerciaLateral;
        Vector3 lateralCorrection_force;
        //I lateral(XY) = V(total) - Vz
        inerciaLateral = player_rb.velocity - Vz;
        //F correctora = -I
        lateralCorrection_force = -inerciaLateral * correccion_Vxy; //Lo que tarda en corregirse la V lateral
        return lateralCorrection_force;
    }
}