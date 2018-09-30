using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activar_mision : MonoBehaviour {

    public GameObject prueba_1;

    private void Start()
    {
        prueba_1.SetActive(false);
    }

    private void OnTriggerEnter(Collider sensor)
    {
        if (sensor.transform.tag == "Player")
        {
            prueba_1.SetActive(true);
        }
    }

    
}
