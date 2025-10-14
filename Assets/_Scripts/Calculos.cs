using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculos : MonoBehaviour
{

    //convertir grados a radianes
    public static float grados_toRad(float grados)
    {
        float dif_gradosRad = 180 / Mathf.PI;
        float radianes = (grados / dif_gradosRad);
        return radianes;
    }
    //Girar un vector con angulos de Euler - De Global a Local
    public static Vector3 GiroEuler(Vector3 vectorInicial, Vector3 eulerVector)
    {
        //Tranformar los angulos de Euler a radianes:
        float elevation = grados_toRad(eulerVector.x);
        float giro_horizontal = grados_toRad(eulerVector.y);
        float alabeo = grados_toRad(eulerVector.z);
        //Matriz de giro / Giro del vector (1,1,1) :
        //Vector transformado de  x / Giro de (1,0,0):
        float rotacionDeX_x = Mathf.Sin(alabeo) * Mathf.Sin(elevation) * Mathf.Sin(giro_horizontal) + Mathf.Cos(alabeo) * Mathf.Cos(giro_horizontal);
        float rotacionDeX_y = Mathf.Sin(alabeo) * Mathf.Cos(elevation);
        float rotacionDeX_z = Mathf.Sin(alabeo) * Mathf.Sin(elevation) * Mathf.Cos(giro_horizontal) - Mathf.Cos(alabeo) * Mathf.Sin(giro_horizontal);
        Vector3 rotacionDeX = new Vector3(rotacionDeX_x, rotacionDeX_y, rotacionDeX_z);
        //Vector transformado de  y / Giro de (0,1,0):
        float rotacionDeY_x = Mathf.Cos(alabeo) * Mathf.Sin(elevation) * Mathf.Sin(giro_horizontal) - Mathf.Sin(alabeo) * Mathf.Cos(giro_horizontal);
        float rotacionDeY_y = Mathf.Cos(alabeo) * Mathf.Cos(elevation);
        float rotacionDeY_z = Mathf.Cos(alabeo) * Mathf.Sin(elevation) * Mathf.Cos(giro_horizontal) + Mathf.Sin(alabeo) * Mathf.Sin(giro_horizontal);
        Vector3 rotacionDeY = new Vector3(rotacionDeY_x, rotacionDeY_y, rotacionDeY_z);
        //Vector transformado de z / Giro de (0,0,1):
        float rotacionDeZ_x = (Mathf.Cos(elevation) * Mathf.Sin(giro_horizontal));
        float rotacionDeZ_y = (-Mathf.Sin(elevation));
        float rotacionDeZ_z = (Mathf.Cos(elevation) * Mathf.Cos(giro_horizontal));
        Vector3 rotacionDeZ = new Vector3(rotacionDeZ_x, rotacionDeZ_y, rotacionDeZ_z);
        //Transformacion de V / Giro del vector inicial
        //Vector transformado de Vx:
        float vector_x = vectorInicial.x;
        Vector3 vector_xRotado = vector_x * rotacionDeX;
        //Vector transformado de Vy:
        float vector_y = vectorInicial.y;
        Vector3 vector_yRotado = vector_y * rotacionDeY;
        //Vector transformado de Vz:
        float vector_z = vectorInicial.z;
        Vector3 vector_zRotado = vector_z * rotacionDeZ;
        //El vector rotado, es igual a la suma de sus componentes rotadas:
        Vector3 vectorRotado = vector_xRotado + vector_yRotado + vector_zRotado;
        return vectorRotado;
    }
    //proyeccion de un vector sobre otro
    public static Vector3 proyeccion_sobre_Vector (Vector3 vector_proyectado, Vector3 vector_referencia)
    {
        float anguloGrados_vectores = 0.0f;
        float anguloRad_vectores = 0.0f;
        float longitud_proyeccion = 0.0f;
        Vector3 vector_proyeccion = new Vector3();
        //angulo entre ambos vectores
        anguloGrados_vectores = Vector3.Angle(vector_referencia, vector_proyectado);
        anguloRad_vectores = grados_toRad(anguloGrados_vectores);
        //Longitud de V sobre Z (Teniendo en cuenta el angulo entre Z y V)
        longitud_proyeccion = vector_proyectado.magnitude * Mathf.Cos(anguloRad_vectores);
        //Proyeccion: Longitud (de la poryeccion) * dir (del vector sobre el que se proyecta)
        vector_proyeccion = longitud_proyeccion * vector_referencia.normalized;
        return vector_proyeccion;
    }

    /* Cálculos de Unity:
        * 3 Angulos de Euler            - transform.rotation.eulerAngles
        * Vector Normal                 - vector.normalized
        * Girar Objeto hacia...         - Quaternion.FromToRotation
        * Girar Orientacion poco a poco - Quaternion.RotateTowards
        * Angulo entre dos vectores     - Vector3.Angle()
        * Producto vectorial            - Vector3.Cross();
        */

}
