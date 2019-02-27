using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPhysics : MonoBehaviour {
    public float forcePower = 175.0f;
    private Rigidbody rbVictim; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnCollisionEnter(Collision collision)
	{
        rbVictim = collision.gameObject.GetComponent<Rigidbody>();
        Vector3 dir = collision.contacts[0].point - transform.position;
        rbVictim.AddForce(dir * forcePower);
	}
}
