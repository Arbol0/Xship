using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador_piezas : MonoBehaviour
{
    //Clases
    [SerializeField]
    protected GameObject[] listaPiezas_prefabs;
    protected GameObject[] listaRandom;
    private bool nv_valido;
    //List<GameObject> listaPiezas_Instanciadas;

    void Start()
    {
        listaRandom = listaRandom_prefabs();
        //Crear piezas 
        creador_piezas();
    }

    void Update()
    {
        
    }

    //Metodos
    public void creador_piezas()
    {
        //Variables
        Vector3 offsetGlobal;
        //CREAR PIEZAS PROCEDURALES:
        GameObject pieza1_prefab;
        GameObject pieza1_objeto;
        GameObject pieza2_prefab;
        GameObject pieza2_objeto;
        //PIEZA 0
        pieza1_prefab = listaRandom[0];
        generarPieza(pieza1_prefab, 0);
        //colocar - sobre la nave:
        pieza1_objeto= GameObject.Find("pieza_" + (0));
        offsetGlobal = pieza1_objeto.transform.Find("Entrada").position - pieza1_objeto.transform.position;
        pieza1_objeto.transform.position = GameObject.Find("Supernova_Spaceship").transform.position - offsetGlobal;
        //PIEZAS i - Generar y Colocar
        for (int i = 1; i < listaRandom.Length; i++)
        {
            pieza2_prefab = listaRandom[i];
            //generar y encotrar en Escena:
            generarPieza(pieza2_prefab, i);
            pieza1_objeto = GameObject.Find("pieza_" + (i - 1));
            pieza2_objeto = GameObject.Find("pieza_" + i);
            //colocar pieza:
            pieza2_objeto.transform.rotation = pieza1_objeto.transform.Find("Salida").rotation;
            //posicion relativa de entrada (offset)
            offsetGlobal = pieza2_objeto.transform.Find("Entrada").position - pieza2_objeto.transform.position;
            //Restar la posicion relativa(rotada) de la entrada, a la posicion target
            pieza2_objeto.transform.position = pieza1_objeto.transform.Find("Salida").transform.position - offsetGlobal;
        }
    }
    //lista random
    public GameObject[] listaRandom_prefabs() {
        GameObject[] listaRandom= new GameObject[50];
        int num;
        //aleatorio
        for (int i = 0; i < listaRandom.Length; i++)
        {
            num = Random.Range(0, 4);
            listaRandom[i] = (listaPiezas_prefabs[num]);
        }

        return listaRandom;
    }
    //generador
    public void generarPieza(GameObject piezaPrefab_i, int id)
    {
        //Generar sala
        piezaPrefab_i = Instantiate(piezaPrefab_i, transform);
        //Convertirla en child de Mundo
        piezaPrefab_i.transform.parent = this.transform;
        //Nombrar (id)
        piezaPrefab_i.name = "pieza_" + id;
    }
}
