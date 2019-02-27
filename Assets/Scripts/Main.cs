using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Main : MonoBehaviour
{

    public int playerAmount = 2;

    //time it takes for a player to respawn
    public float respawnTime = 2;

    //list of players. Must be selected manually in the editor
    public Player[] players;
    public Text leftPlayerScoreText;
    public Text rightPlayerScoreText;

    public float gameLength = 10;
    Timer timer;
    private Stats stats;

    private bool gameOver;

    // Use this for initialization
    void Start()
    {
        stats = new Stats(playerAmount);
        timer = new Timer(gameLength);

        //SetPlayerScoreText(0);
        //SetPlayerScoreText(1);

    }

    // Update is called once per frame
    void Update()
    {
        //countdown time remaining
        CountDown();
    }

    //subtracts from remainig game time
    private void CountDown()
    {
        if (!gameOver && timer.Tick())
        {
            gameOver = true;
            for (int i = 0; i < playerAmount; i++)
            {
                players[i].BlockInput = true;
            }           
        }       
    }

    public int ScorePlayer(int player, int score)
    {
        stats.Score[player] += score;
        SetPlayerScoreText(player);
        return stats.Score[player];
    }

    public int GetScore(int player)
    {
        return stats.Score[player];
    }

    void SetPlayerScoreText(int playerNumber)
    {
        if (playerNumber == 0)
        {
            leftPlayerScoreText.text = "Player " + (playerNumber + 1).ToString() + " :" + GetScore(playerNumber).ToString();
        }
        else
        {
            rightPlayerScoreText.text = "Player " + (playerNumber + 1).ToString() + " :" + GetScore(playerNumber).ToString();
        }
    }



}
