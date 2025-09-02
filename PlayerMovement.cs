using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{

    public Rigidbody2D rb2D;
    public float thrustUp = 0f;
    public float thrustSideways = 500f;
    public int score = 0;
    public int maxScore = -1;
    private GameObject playerObj = null;
    public bool hit = false;

    void GameOver()
    {
        FindObjectOfType<GameManager>().EndGame();
    }

    void JumpUp()
    {
        rb2D.AddForce(transform.up * thrustUp * Time.deltaTime, ForceMode2D.Impulse);
        thrustUp = 0f;
    }

    void Left()
    {
        rb2D.AddForce(-transform.right * thrustSideways * Time.deltaTime, ForceMode2D.Force);
    }

    void Right()
    {
        rb2D.AddForce(transform.right * thrustSideways * Time.deltaTime, ForceMode2D.Force);
    }

    void Start()
    {
        playerObj = FindObjectOfType<PlayerMovement>().gameObject;
    }

    void FixedUpdate()
    {
        //if(Input.GetKey("w") || Input.GetKey("space") || Input.GetKey("up")) JumpUp();
        if (Input.GetKey("d") || Input.GetKey("right")) Right();
        if (Input.GetKey("a") || Input.GetKey("left")) Left();
        if(playerObj.transform.position.y < maxScore - 30f)
        {
            GameOver();
        }

        if (hit)
        {
            score = Convert.ToInt32(playerObj.transform.position.y);
            if (score > maxScore)
            {
                maxScore = score;
                ScoreUpdate.scoreValue = maxScore;
            }
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.tag == "Asteroid")
        {
            if (!hit) hit = true;
            thrustUp = 1350f;
            JumpUp();
            
            Debug.Log("asteroid");
        }
        
    }
}
