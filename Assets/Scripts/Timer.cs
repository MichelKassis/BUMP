using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer {

    public Timer(float gameLength)
    {
        GameLength = gameLength;
        Stopwatch = GameLength;
    }

    //how long a game will last. This is set in the Main object
    private float gameLength;
    public float GameLength
    {
        get
        {
            return gameLength;
        }

        set
        {
            gameLength = value;
        }
    }

    //actual stopwatch that counts down
    private float stopwatch;
    public float Stopwatch
    {
        get
        {
            return stopwatch;
        }

        set
        {
            stopwatch = value;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //subtracts time from the stopwatch. returns true if the stopwatch hits 0 otherwise false
    public bool Tick()
    {
        Stopwatch -= Time.deltaTime;        
        if(Stopwatch <= 0)
        {
            Stopwatch = GameLength; //reset
            return true; //out of time
        }

        //stopwatch is still running
        return false;
    }

    

}
