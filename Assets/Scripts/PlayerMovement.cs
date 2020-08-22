using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;

    public Boolean hitted = false;

    public float force;

    public bool cutscene = false;

    bool falling = false;

    public GameObject objectPool;

    public GameObject playerObj;

    public GameObject katanaObj;

    public float rotationSize;

    public Animator anim;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }


        if (transform.position.y < -(float)0.5)
        {
            falling = true;
        }

        if (transform.position.y < -5)
        {
            FindObjectOfType<GameController>().GameOver();
            falling = false;
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
                    //playerObj.GetComponent<TrailRenderer>().enabled = false;
                    playerObj.transform.localPosition = new Vector3(0, (float)0.5, -6);
                    katanaObj.transform.rotation = new Quaternion(0, 0, 0, 0);
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
}
