using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<PlayerMovement>().rb.velocity = new Vector3(0, 0, 0);
            FindObjectOfType<PlayerMovement>().rb.AddForce(0, 12, 0, ForceMode.Impulse);
        }
    }
}
