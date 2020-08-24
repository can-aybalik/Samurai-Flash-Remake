using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BossController : MonoBehaviour
{
    public GameObject playerObj;
    Vector3 offset;
    private Vector3 upperPos;
    public float cutSize;
    ObjectPool objectPool;
    Vector3 bodyPosition;
    Vector3 hatPosition;
    Quaternion headRotation;
    Quaternion bodyRotation;

    private void Start()
    {
        
        objectPool = ObjectPool.Instance;
    }

    private void Update()
    {
        offset = new Vector3(playerObj.transform.position.x + 2, playerObj.transform.position.y, playerObj.transform.position.z);
        transform.LookAt(offset);
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
                hatPosition = new Vector3(transform.position.x, transform.position.y + (float)1.5, transform.position.z);
                bodyRotation = new Quaternion(transform.rotation.x + (float)0.6, transform.rotation.y, transform.rotation.z, transform.rotation.w);
                headRotation = new Quaternion(transform.rotation.x + (float)0.5, transform.rotation.y, transform.rotation.z, transform.rotation.w);
                //Instantiate(slicedEnemy, transform.position, Quaternion.identity);
                //Instantiate(slicedEnemy, upperPos, Quaternion.identity);
                objectPool.SpawnFromPool("Body", bodyPosition, bodyRotation);
                objectPool.SpawnFromPool("Head", upperPos, headRotation);
                objectPool.SpawnFromPool("Hat", hatPosition, Quaternion.identity);

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
