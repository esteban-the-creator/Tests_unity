using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Target : MonoBehaviour {

    public bool canX;
    public float speed_X;
    public float amount_x;
    float m_internal_amount_X;
    public bool right;

	private void Start ()
    {
        m_internal_amount_X = amount_x;
	}
	
	// Update is called once per frame
	private void Update ()

    {
        if (right)
        {
            transform.Translate(Vector3.right * (speed_X * Time.deltaTime), Space.Self);
            amount_x -= Time.deltaTime;
            if (amount_x < m_internal_amount_X * -1)
            {
                right = false;
            }

        }
		else
        {
            transform.Translate(Vector3.left * (speed_X * Time.deltaTime), Space.Self);
            amount_x += Time.deltaTime;
            if (amount_x > m_internal_amount_X)
            {
                right = true;
            }
                
        }
	}
}
