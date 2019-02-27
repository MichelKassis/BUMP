using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{

    public int m_PlayerNumber = 1;
    private string m_MovementAxisName;
    private string m_TurnAxisName;
    private string m_BoostAxisName;
    public Text leftPlayerScoreText;
    public Text rightPlayerScoreText;
    private float m_MovementInputValue;
    private float m_TurnInputValue;
    private float m_BoostInputValue;
    private Rigidbody rbVictim;
    public int leftPlayerScore;
    public int rightPlayerScore;
    Vector3 originalPlayerPos;

    //public AudioClip song;

    public bool enter;
    public AudioClip alarm;
    private AudioSource source;



    // rotation that occurs in angles per second holding down input
    public float rotationRate = 220;

    // units moved per second holding down move input
    public float moveRate = 10;
    private float baseMoveRate; //original move rate
    public float boost = 2;

    //if true, boost is waiting on cooldown
    private bool boostCooldown = false;
    public float boostCooldownTime = 4;
    private Timer boostTimer;

    public Rigidbody rb;

    public bool boostOn = false;
    private bool blockInput = false;
    public bool BlockInput
    {
        get
        {
            return blockInput;
        }

        set
        {
            blockInput = value;
        }
    }

    // Use this for initialization
    void Start()
    {
        boostTimer = new Timer(boostCooldownTime);
        baseMoveRate = moveRate;
        m_MovementAxisName = "Vertical" + m_PlayerNumber;
        m_TurnAxisName = "Horizontal" + m_PlayerNumber;
        m_BoostAxisName = "Boost" + m_PlayerNumber;

        originalPlayerPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);


        //GetComponent<AudioSource>().playOnAwake = false;
        //GetComponent<AudioSource>().clip = song;

        rb = GetComponent<Rigidbody>();
        //rb.useGravity = true;

        enter = false;
        source = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        // Store the value of both input axes.
        m_MovementInputValue = Input.GetAxis(m_MovementAxisName);
        m_TurnInputValue = Input.GetAxis(m_TurnAxisName);
        m_BoostInputValue = Input.GetAxis(m_BoostAxisName);        
        RegisterBoost();

        //if (enter == true)
            //source.PlayOneShot(alarm);
    }
    private void FixedUpdate()
    {
        if (!BlockInput)
        {
            Move();
            Turn(m_TurnInputValue);
        }
    }

    void Move()
    {
        // Create a vector in the direction the bumper car is facing with a magnitude based on the input, speed and the time between frames.
        Vector3 movement = transform.forward * m_MovementInputValue * moveRate * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }
  
    private void Turn(float input)
    {
        Quaternion q = transform.rotation;
        q.eulerAngles = new Vector3(0, q.eulerAngles.y, 0);
        transform.rotation = q;
        transform.Rotate(0, input * rotationRate * Time.deltaTime, 0);
    }

    private bool RegisterBoost()
    {
        if (m_BoostInputValue != 0 ) //boost key pressed
        {
            if (!boostCooldown) //boost not on cooldown
            {
                boostCooldown = true;
                moveRate += boost;               
            }
        }        
        else if(boostCooldown)
        {
            moveRate = baseMoveRate; //back to normal speed           
            boostCooldown = !boostTimer.Tick();
        }

        return boostCooldown;
    }

    //void OnCollideEvent(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Boundary"))
    //    {
    //        GetComponent<AudioSource>().Play();

    //    }

    //}


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Boundary"))
        {
            enter = true;
            // Play the sound only on the trigger
            //source.PlayOneShot(alarm);

            gameObject.SetActive(false);
            if (m_PlayerNumber == 1){
                leftPlayerScore = leftPlayerScore + 1;
                SetLeftPlayerScoreText();

            }
            else{
                rightPlayerScore = rightPlayerScore + 1;
                SetRightPlayerScoreText();
            }

            gameObject.transform.position = originalPlayerPos;
            gameObject.SetActive(true);
        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Boundary"))
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
