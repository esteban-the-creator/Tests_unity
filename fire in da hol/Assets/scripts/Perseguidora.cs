using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perseguidora : MonoBehaviour 
{


    public CharacterController controller;
    Vector3 posicionzAzar;
    public float velocidadMovimiento;
    public float velocidadRotacion;
    public float tiempoDeambular;
    float referenciaDeambular;
    public float tiempoEstatico;
    float referenciaEstatico;
    public float rango;
    public Transform jugador;
    public float distancia;



    // Use this for initialization
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        posicionzAzar = new Vector3(Random.Range(-100, 100f), 0, Random.Range(-100, 100f));
        referenciaDeambular = tiempoDeambular;
        referenciaEstatico = tiempoEstatico;
    }

    // Update is called once per frame
    private void Update()
    {
        distancia = Vector3.Distance(jugador.position, transform.position);
        if (distancia < rango)
        {
            perseguir();
        }
        else
        {
            Deambular();
        }
    }
    void Deambular()
    {
        if (tiempoDeambular > 0)
        {
            Quaternion rotacion = Quaternion.LookRotation(posicionzAzar);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacion, velocidadRotacion * Time.deltaTime);
            Vector3 movimiento = transform.TransformDirection(Vector3.forward);
            controller.SimpleMove(movimiento * velocidadMovimiento);
            tiempoDeambular -= Time.deltaTime;

        }
        else if (tiempoDeambular < 0 && tiempoEstatico > 0)
        {
            tiempoEstatico -= Time.deltaTime;
        }
        else
        {
            posicionzAzar = new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100));
            tiempoDeambular = referenciaDeambular;
            tiempoEstatico = referenciaEstatico;
        }
    }
    void perseguir()
    {
        Vector3 direccion = (jugador.position - transform.position);
        direccion.y = 0;
        Quaternion rotacion = Quaternion.LookRotation(direccion);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotacion, velocidadRotacion * Time.deltaTime);
        Vector3 movimiento = transform.TransformDirection(Vector3.forward);
        controller.SimpleMove(movimiento * velocidadMovimiento);
        tiempoDeambular -= Time.deltaTime;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rango);
    }
}