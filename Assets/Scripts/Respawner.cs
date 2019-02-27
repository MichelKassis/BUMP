using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour {

    //reference to main object
    private Main main;

    //time it takes for player to respawn
    private float respawnTimer;

    //whether to start counting the timer
    private bool countdown = false;

	// Use this for initialization
	void Start () {
        main = GameObject.FindObjectOfType<Main>();
        respawnTimer = main.respawnTime;
    }
	
	// Update is called once per frame
	void Update () {
        if (countdown)
        {
            respawnTimer -= Time.deltaTime;            
            if (respawnTimer <= 0)
            {
                countdown = false;
                respawnTimer = main.respawnTime;
                gameObject.transform.SetPositionAndRotation(new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));               
            }
        }
	}

    public void Countdown()
    {
        countdown = true;
    }
}
