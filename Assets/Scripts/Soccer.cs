using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Soccer : MonoBehaviour
{
    public GameObject soccer;
    public GameObject Goal1;
    public GameObject Goal2;
    public int leftPlayerScore;
    public int rightPlayerScore;
    public Text leftPlayerScoreText;
    public Text rightPlayerScoreText;
    Vector3 originalBallPos;

    public bool enter;
    public AudioClip alarm;
    private AudioSource source;



    private void Start()
    {
        leftPlayerScore = 0;
        rightPlayerScore = 0;
        originalBallPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        SetLeftPlayerScoreText();
        SetRightPlayerScoreText();

        enter = false;
        source = GetComponent<AudioSource>();


    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Left Goal"))
        {
            enter = true;

            //source.PlayOneShot(alarm);

            gameObject.SetActive(false);

            soccer.SetActive(false);
            rightPlayerScore = rightPlayerScore + 1;
            SetRightPlayerScoreText();
            gameObject.transform.position = originalBallPos;
            soccer.SetActive(true);
        }
        if (other.gameObject.CompareTag("Right Goal"))
        {
            //GetComponent<AudioSource>().Play();

            enter = true;

            soccer.SetActive(false);
            leftPlayerScore = leftPlayerScore + 1;
            SetLeftPlayerScoreText();
            gameObject.transform.position = originalBallPos;
            soccer.SetActive(true);

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Left Goal"))
        {
            enter = false;
        }
        if (other.gameObject.CompareTag("Right Goal"))
        {
            enter = false;
        }

        Debug.Log("Exited");
    }


    void SetLeftPlayerScoreText()
    {
        leftPlayerScoreText.text = "Blue Player Score: " + leftPlayerScore.ToString();

    }

    void SetRightPlayerScoreText()
    {
        rightPlayerScoreText.text = "Red Player Score: " + rightPlayerScore.ToString();

    }




}
