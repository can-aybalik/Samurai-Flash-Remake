using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public bool finished = false;

    // Update is called once per frame
    void Update()
    {

        if (!finished)
        {
            transform.position = player.position + offset;
        }
        

        if (finished)
        {
            transform.RotateAround(player.position, Vector3.up, 60 * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, player.position.y + 1, player.position.z), 5 * Time.deltaTime);
        }
            
    }




}
