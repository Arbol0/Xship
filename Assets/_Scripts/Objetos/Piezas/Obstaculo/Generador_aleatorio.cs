using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Genderador_aleatorio : MonoBehaviour
{
    public GameObject obstaculo;


    void Start()
    {
        generador(obstaculo);
    }

    //Generador
    public void generador(GameObject obstaculoPrefab_i)
    {
        //variables
        GameObject obstaculo_i;
        //Generar obstaculoPref
        obstaculoPrefab_i = Instantiate(obstaculoPrefab_i, transform);
        Debug.Log("Objeto encontrado: " + transform.name);
        //Colocar obstaculo

        //Convertirla en child obstaculoVacio
        obstaculoPrefab_i.transform.parent = this.transform;
        //Nombrar (id)
        obstaculoPrefab_i.name = transform.name;
    }

}