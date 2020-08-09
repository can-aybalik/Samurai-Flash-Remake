using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;

    public Boolean hitted = false;
    
    public float force;

    // Update is called once per frame
    void FixedUpdate()
    {

        if(transform.position.y < -30)
        {
            FindObjectOfType<GameController>().GameOver();
        }

        if (!hitted)
        {

            if (Input.GetKey("w"))
            {
                rb.AddForce(0, 0, force * Time.deltaTime);
            }

            if (Input.GetKey("s"))
            {
                rb.AddForce(0, 0, -force * Time.deltaTime);
            }

            if (Input.GetKey("a"))
            {
                rb.AddForce(-force * Time.deltaTime, 0, 0);
            }

            if (Input.GetKey("d"))
            {
                rb.AddForce(force * Time.deltaTime, 0, 0);
            }

            if (FindObjectOfType<GameController>().levelCompleteUI.activeSelf)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }

        }
    }

}
