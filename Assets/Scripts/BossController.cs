using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BossController : MonoBehaviour
{
   
    private Vector3 upperPos;
    public float cutSize;
    ObjectPool objectPool;
    Vector3 bodyPosition;
    Quaternion headRotation;
    Quaternion bodyRotation;

    private void Start()
    {
        objectPool = ObjectPool.Instance;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Katana"))
        {
            Debug.Log("ENEMY CUT!");
            //speed = 0;
            DestroyEnemy();
            upperPos = new Vector3(transform.position.x-1, transform.position.y + 1, transform.position.z-1);

            if (other.CompareTag("Katana"))
            {
                bodyPosition = new Vector3(transform.position.x, transform.position.y + (float)0.2, transform.position.z);
                bodyRotation = new Quaternion(transform.rotation.x + (float)0.7, transform.rotation.y, transform.rotation.z, transform.rotation.w);
                headRotation = new Quaternion(transform.rotation.x + (float)0.5, transform.rotation.y, transform.rotation.z, transform.rotation.w);
                //Instantiate(slicedEnemy, transform.position, Quaternion.identity);
                //Instantiate(slicedEnemy, upperPos, Quaternion.identity);
                objectPool.SpawnFromPool("Body", bodyPosition, bodyRotation);
                objectPool.SpawnFromPool("Head", upperPos, headRotation);

            }


        }

        else if (other.CompareTag("Player"))
        {
            FindObjectOfType<GameController>().GameOver();
        }
    }

    void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
