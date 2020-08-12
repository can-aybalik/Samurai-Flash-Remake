using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{

    private Transform player;

    public float speed;
    
    private Vector3 target;

    public GameObject bullet;

    public GameObject slicedEnemy;

    private Vector3 upperPos;

    public float cutSize;

    private float timeBtwShots;

    public float startTimeBtwShots;

    ObjectPool objectPool;

    // Start is called before the first frame update
    void Start()
    {
        timeBtwShots = startTimeBtwShots;
        objectPool = ObjectPool.Instance;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector3(player.position.x, player.position.y, player.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (Math.Abs(transform.position.z - GameObject.FindGameObjectWithTag("Player").transform.position.z) < 20) {

            if (timeBtwShots < -0)
            {
                Instantiate(bullet, transform.position, Quaternion.identity);
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Katana"))
        {
            Debug.Log("ENEMY CUT!");
            //speed = 0;
            DestroyEnemy();
            upperPos = new Vector3(transform.position.x + cutSize/8, transform.position.y + cutSize, transform.position.z);

            if (other.CompareTag("Katana"))
            {
                //Instantiate(slicedEnemy, transform.position, Quaternion.identity);
                //Instantiate(slicedEnemy, upperPos, Quaternion.identity);
                objectPool.SpawnFromPool("EnemySliced", transform.position, Quaternion.identity);
                objectPool.SpawnFromPool("EnemySliced", upperPos, Quaternion.identity);

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