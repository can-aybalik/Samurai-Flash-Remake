using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katana : MonoBehaviour
{
    public Transform player;

    PlayerMovement playerMovement;

    public float rotationSize;

    public Boolean bonusCheck;

    void Start()
    {
        bonusCheck = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerMovement = player.GetComponent<PlayerMovement>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, player.position.z);

        if (!playerMovement.hitted)
        {

            if (Input.GetKey("a"))
            {
                transform.Rotate(0, -rotationSize, 0);
            }

            if (Input.GetKey("d"))
            {
                transform.Rotate(0, +rotationSize, 0);
            }

        }


    }
}