using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaPosicion : MonoBehaviour
{
    [SerializeField]
    protected GameObject[] listaPiezas_prefabs;
    // Start is called before the first frame update
    void Start()
    {

    }

    


    public void colocarEntradaPieza() {
        //COLOCAR LA ENTRADA en UNA POSICION
            //posicion relativa de la entrada - respescto a la pieza (offset)
        Vector3 offsetLocal = transform.InverseTransformPoint(this.transform.Find("Entrada").position);
        Debug.Log("offset: " + offsetLocal);
            //Restar la posicion relativa de la entrada, a la posicion target
        transform.position = new Vector3(0, 0, 0) - offsetLocal;
    }

    public void colocarEntradaPieza_rotada() {
        //1- COLOCAR LA ENTRADA, DESPUES DE ROTAR LA PIEZA
            //posicion relativa de la entrada - respescto a la pieza (offset)
        Vector3 offsetGlobal = transform.Find("Entrada").position - transform.position;
        Debug.Log("offset g: " + offsetGlobal);
            //Restar la posicion relativa(rotada) de la entrada, a la posicion target
        transform.position = new Vector3(0, 0, 0) - offsetGlobal;
    }

    public void colocarEntradaPieza_rotada_segunOtroObjeto()
    {
        //2- ROTAR LA PIEZA EN BASE A LA ROTACION DE OTRO OBJETO (un cubo rotado en la pos 000)
        transform.rotation = GameObject.Find("Plane").transform.Find("Capsule").transform.rotation;
        //posicion relativa de la entrada - respescto a la pieza (offset)
        Vector3 offsetGlobal = transform.Find("Entrada").position - transform.position;
        Debug.Log("offset g: " + offsetGlobal);
        //Restar la posicion relativa(rotada) de la entrada, a la posicion target
        transform.position = new Vector3(0, 0, 0) - offsetGlobal;
    }



    public void generarPieza(GameObject piezaPrefab_i, int id)
    {
        //Generar sala
        piezaPrefab_i= Instantiate(piezaPrefab_i);
        Debug.Log("PIEZA " + id + " generada");
        //Convertirla en child de Mundo
        //pieza_i.transform.parent = this.transform;
        //Nombrar (id)
        piezaPrefab_i.name = "pieza_" + id;
    }

    public void creador_piezas()
    {
        //CREAR PIEZAS PROCEDURALES:
        GameObject pieza1_prefab;
        GameObject pieza1_objeto;
        GameObject pieza2_prefab;
        GameObject pieza2_objeto;
        //PIEZA 0
        pieza1_prefab = listaPiezas_prefabs[0];
        generarPieza(pieza1_prefab, 0);
        //PIEZAS i - Generar y Colocar
        for (int i = 1; i < listaPiezas_prefabs.Length; i++)
        {
            //variables
            Vector3 offsetGlobal;
            pieza2_prefab = listaPiezas_prefabs[i];
            //generar y encotrar en Escena:
            generarPieza(pieza2_prefab, i);
            pieza1_objeto = GameObject.Find("pieza_" + (i - 1));
            pieza2_objeto = GameObject.Find("pieza_" + i);

            //colocar pieza:
            pieza2_objeto.transform.rotation = pieza1_objeto.transform.Find("Salida").rotation;
            //posicion relativa de entrada (offset)
            offsetGlobal = pieza2_objeto.transform.Find("Entrada").position - pieza2_objeto.transform.position;
            Debug.Log("offset: " + offsetGlobal);
            //Restar la posicion relativa(rotada) de la entrada, a la posicion target
            pieza2_objeto.transform.position = pieza1_objeto.transform.Find("Salida").transform.position - offsetGlobal;
        }
    }
}
