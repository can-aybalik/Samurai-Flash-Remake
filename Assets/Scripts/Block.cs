using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Block : MonoBehaviour
{

    public GameObject slicedEnemy;

    private Vector3 lowerPos;

    private Vector3 upperPos;

    public float cutSize;

    public ObjectPool objectPool;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Katana"))
        {
            DestroyBlock();
            lowerPos = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
            upperPos = new Vector3(transform.position.x + cutSize / 8, transform.position.y + cutSize, transform.position.z);

            if (other.CompareTag("Katana"))
            {
                objectPool.SpawnFromPool("BlockSliced", lowerPos, gameObject.transform.rotation);
                objectPool.SpawnFromPool("BlockSliced2", upperPos, gameObject.transform.rotation);
            }
        }
    }

    void DestroyBlock()
    {
        Destroy(gameObject);
    }
}
