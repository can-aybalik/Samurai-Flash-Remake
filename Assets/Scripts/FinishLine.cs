using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<PlayerMovement>().anim.SetBool("isFinished", true);
            FindObjectOfType<FollowPlayer>().finished = true;
            FindObjectOfType<GameController>().CompleteLevel();
        }

    }

}
