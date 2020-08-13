using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    private void Start()
    {
        if (GameController.checkpointEnabled)
        {
            gameObject.SetActive(false);
        }
    }
    public GameObject checkpointText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Checkpoint Enabled");
            GameController.checkpointEnabled = true;
            Destroy(gameObject);
            checkpointText.SetActive(true);
        }
    }
}
