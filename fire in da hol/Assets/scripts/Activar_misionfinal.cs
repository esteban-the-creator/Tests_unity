using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activar_misionfinal : MonoBehaviour
{

    public GameObject prueba_final;

    private void Start()
    {
        prueba_final.SetActive(false);
    }

    private void OnTriggerEnter(Collider sensor_final)
    {
        if (sensor_final.transform.tag == "Player")
        {
            prueba_final.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider sensor_final)
    {
        if (sensor_final.transform.tag == "Player")
        {
            prueba_final.SetActive(false);
        }
        
    }

}