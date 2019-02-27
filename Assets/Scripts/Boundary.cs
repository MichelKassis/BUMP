using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour {
    public AudioClip song;
    private Main main;

	// Use this for initialization
	void Start () {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = song;
        main = GameObject.FindObjectOfType<Main>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollideEvent(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {        
            GetComponent<AudioSource>().Play();
            if (col.gameObject != null)
            {
                Player p = col.gameObject.GetComponent<Player>();
                Respawner respawner = col.gameObject.GetComponent<Respawner>();
                if (p != null)
                {
                    int otherPlayer = (p.m_PlayerNumber == 1 ? 1 : 0);

                    //add score to opposing player
                    main.ScorePlayer(otherPlayer, 10);

                    //dissapear player from sight
                    col.gameObject.transform.SetPositionAndRotation(new Vector3(0,-10,0),new Quaternion(0,0,0,0));
                    print("player " + (otherPlayer+1) + ": " + main.GetScore(otherPlayer) );
                    respawner.Countdown();
                }               
            }

        }
    }

}
