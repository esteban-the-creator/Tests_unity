
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueEnemigo : MonoBehaviour {

    public float puntosDeVida;
    public float rangoAtaque;
    public float tiempoAtaque;
    float referenciaTiempoataque;
    public GameObject golpecito;
    public Perseguidora perseguidora;

   
	private void Start () {

        golpecito.SetActive(false);
        referenciaTiempoataque = tiempoAtaque;
        perseguidora = GetComponent<Perseguidora>();
	}

    // Update is called once per frame
    void Update() {
        if (perseguidora.distancia < rangoAtaque) { Atacar(); }
	}

    public void Atacar()
    {
        if(tiempoAtaque > 0 )
        {
            tiempoAtaque -= Time.deltaTime;

        }
        else
        {
            golpecito.SetActive(true);
            tiempoAtaque = referenciaTiempoataque;
            StartCoroutine(ApagarGolpecito());

        }
    }

    IEnumerator ApagarGolpecito()
    {
        yield return new WaitForSeconds(1f);
        golpecito.SetActive(false);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, rangoAtaque);
    }
}
