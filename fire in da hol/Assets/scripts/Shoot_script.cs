using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_script : MonoBehaviour {

    public GameObject pref_Bullet;
    GameObject bullet;
    public GameObject gunflash;
    public Transform spawnPoint;
    public float force;



    private void Update()
    {
		if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
	}

    void Shoot()
    {
        bullet = Instantiate(pref_Bullet, spawnPoint.position, Quaternion.identity);
        bullet.AddComponent<Rigidbody>();
        bullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * force, ForceMode.Impulse);
        Destroy(bullet, 5f);
    
    }
} 
