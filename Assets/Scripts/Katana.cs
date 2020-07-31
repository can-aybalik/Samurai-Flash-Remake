using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katana : MonoBehaviour
{
    public Transform player;

    public float rotationSize;

    public Boolean bonusCheck = true;

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position;

        if (Input.GetKey("a"))
        {
            transform.Rotate(0, -rotationSize, 0);
        }

        if (Input.GetKey("d"))
        {
            transform.Rotate(0, +rotationSize, 0);
        }

        if (Input.GetKey(KeyCode.Space) && bonusCheck)
        {
            transform.Rotate(0, +rotationSize*5, 0);
        }
    }
}