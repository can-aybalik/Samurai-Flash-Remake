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

    public bool cutscene = false;

    public GameObject level01;

    public GameObject level02;

    public GameObject objectPool;

    // Update is called once per frame
    void Update()
    {

        if(transform.position.y < -100)
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
                rb.AddForce(-force * Time.deltaTime , 0, 0);
            }

            if (Input.GetKey("d"))
            {
                rb.AddForce(force * Time.deltaTime, 0, 0);
            }

            if (FindObjectOfType<GameController>().levelCompleteUI.activeSelf)
            {
                if (Input.GetKey(KeyCode.Space))
                {

                    FindObjectOfType<ObjectPool>().clearPool();
                    FindObjectOfType<GameController>().failedUI2.SetActive(false);
                    FindObjectOfType<GameController>().levelCompleteUI.SetActive(false);
                    FindObjectOfType<GameController>().failedUI2.SetActive(true);
                    level01.SetActive(false);
                    level02.SetActive(true);

                    rb.position = new Vector3(0, (float)0.5, -6);
                    rb.drag = 1;
                }
            }

            if((Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d")) || cutscene)
            {
                //Time flows
                TimeController.continueTime();
            }
            else
            {
                //Stop Time
                TimeController.freezeTime();
            }

        }
    }

}
