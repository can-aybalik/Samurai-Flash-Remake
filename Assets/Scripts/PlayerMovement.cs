using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;

    public Boolean hitted = false;

    public float force;

    public bool cutscene = false;

    bool falling = false;

    bool grounded = true;

    public GameObject objectPool;

    public GameObject playerObj;

    public float rotationSize;

    public Animator anim;

    // Update is called once per frame
    void Update()
    {

        //Debug.Log("GROUNDED = " + grounded);
        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }

        if(GameController.currentLevelIndex != 4)
        {
            if (transform.position.y < -(float)0.5)
            {
                falling = true;
                anim.SetBool("isFalling", true);
            }

            if (transform.position.y < -5)
            {
                FindObjectOfType<GameController>().GameOver();
                falling = false;
            }
        }
        else
        {

            if (grounded)
            {
                anim.SetBool("isSwinging", false);
            }
            else
            {
                anim.SetBool("isSwinging", true);
            }
            
            if (transform.position.y < -20)
            {
                anim.SetBool("isSwinging", false);
                anim.SetBool("isFalling", true);
                FindObjectOfType<GameController>().GameOver();
                falling = false;
                grounded = true;
            }
        }
        if (!hitted)
        {
            if (Input.GetKey("w"))
            {
                rb.AddRelativeForce(0, 0, force * Time.deltaTime);

            }

            if (Input.GetKey("s"))
            {
                rb.AddRelativeForce(0, 0, -force * Time.deltaTime);

            }

            if (Input.GetKey("a"))
            {
                transform.Rotate(0, -rotationSize, 0);
            }

            if (Input.GetKey("d"))
            {
                transform.Rotate(0, +rotationSize, 0);
            }

            if (FindObjectOfType<GameController>().levelCompleteUI.activeSelf)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    FindObjectOfType<GameController>().clearOldLevel();
                    anim.SetBool("isFinished", false);
                    //playerObj.GetComponent<TrailRenderer>().enabled = false;
                    playerObj.transform.position = new Vector3(0, 0, 0);
                    rb.drag = 1;
                }
            }

            if ((Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d")) || cutscene || falling)
            {
                //Time flows
                TimeController.continueTime();

                /*
                if (!playerObj.GetComponent<TrailRenderer>().enabled && !cutscene)
                {
                    playerObj.GetComponent<TrailRenderer>().enabled = true;
                }
                */
            }
            else
            {
                //Stop Time
                TimeController.freezeTime();
                rb.velocity = Vector3.zero;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ExitDetector"))
        {
            anim.SetBool("isSwinging", false);
            grounded = true;
            //other.GetComponent<BoxCollider>().isTrigger = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ExitDetector"))
        {
            //other.GetComponent<MeshCollider>().isTrigger = false;
            grounded = false;
        }
    }




}
