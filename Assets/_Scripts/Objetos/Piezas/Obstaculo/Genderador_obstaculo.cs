using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Genderador_obstaculo : MonoBehaviour
{
    private GameObject obstaculo;
    [SerializeField]
    private GameObject[] obstaculosList;


    void Start()
    {
        elegirObstaculo();
        generador(obstaculo);
    }

    
    public void elegirObstaculo() {
        int num = Random.Range(0, 3);
        obstaculo = obstaculosList[num];
    }
    //Generador
    public void generador(GameObject obstaculoPrefab_i)
    {
        //variables
        GameObject obstaculo_i;
        //Generar obstaculoPref
        obstaculoPrefab_i = Instantiate(obstaculoPrefab_i, transform);

        //Convertirla en child obstaculoVacio
        obstaculoPrefab_i.transform.parent = this.transform;
        //Nombrar (id)
        obstaculoPrefab_i.name = transform.name;
    }

}