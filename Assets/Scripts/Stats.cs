using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats {

    public Stats(int numPlayers)
    {
        NumPlayers = numPlayers;
        Score = new int[NumPlayers];
    }

    private int numPlayers;
    public int NumPlayers
    {
        get
        {
            return numPlayers;
        }

        set
        {
            numPlayers = value;
        }
    }

    //player score. index corresponds to the player i.e 0 is player 1, 1 is player 2 etc
    private int[] score;
    public int[] Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
        }
    }

    // Use this for initialization
    void Start () {
        InitStats();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void InitStats()
    {
        for( int i = 0; i < NumPlayers; i++)
        {
            score[i] = 0;
        }
    }

}
