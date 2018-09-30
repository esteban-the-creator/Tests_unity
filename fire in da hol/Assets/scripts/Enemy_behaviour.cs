using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_behaviour : MonoBehaviour {

    public GameObject jugador;
    public float movSpeed = 2f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.LookAt(jugador.transform);
        transform.Translate(0, 0, movSpeed * Time.deltaTime);
		
	}
}
