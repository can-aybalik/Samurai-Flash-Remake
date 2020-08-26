using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BossController : MonoBehaviour
{
    public GameObject playerObj;
    Vector3 offset;
    private Vector3 upperPos;
    private Vector3 bulletPos;
    public float cutSize;
    ObjectPool objectPool;
    Vector3 bodyPosition;
    Vector3 hatPosition;
    Vector3 gunPosition;
    Quaternion headRotation;
    Quaternion bodyRotation;
    private Transform player;
    private Vector3 target;
    public bool isTracking;
    public static bool trackingPlayer;
    private float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject bullet;
    public GameObject gun;
    public bool setFire = false;
    public bool hasUzi = false;
    public Animator anim;
    bool firstTimeCheck = true;

    private void Start()
    {
        if (isTracking)
            trackingPlayer = true;
        else
            trackingPlayer = false;

        timeBtwShots = startTimeBtwShots;
        objectPool = ObjectPool.Instance;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector3(player.position.x, player.position.y, player.position.z);
        offset = new Vector3(playerObj.transform.position.x + (float)1.8, playerObj.transform.position.y, playerObj.transform.position.z);
        transform.LookAt(offset);

        if (hasUzi)
        {
            anim.SetBool("hasUzi", true);
        }
        
    }

    private void Update()
    {
        offset = new Vector3(playerObj.transform.position.x + (float)1.8, playerObj.transform.position.y, playerObj.transform.position.z);
        transform.LookAt(offset);

        if (Math.Abs(transform.position.z - GameObject.FindGameObjectWithTag("Player").transform.position.z) < 20)
        {
            if (setFire)
            {
                bulletPos = new Vector3(gun.transform.position.x, gun.transform.position.y, gun.transform.position.z);
                Instantiate(bullet, bulletPos, Quaternion.identity);
                setFire = false;
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
            upperPos = new Vector3(transform.position.x - 1, transform.position.y + 1, transform.position.z - 1);

            bodyPosition = new Vector3(transform.position.x, transform.position.y + (float)0.2, transform.position.z);
            hatPosition = new Vector3(transform.position.x, transform.position.y + (float)1.5, transform.position.z);
            hatPosition = new Vector3(transform.position.x, transform.position.y + (float)1.3, transform.position.z);
            bodyRotation = new Quaternion(transform.rotation.x + (float)0.6, transform.rotation.y, transform.rotation.z, transform.rotation.w);
            headRotation = new Quaternion(transform.rotation.x + (float)0.5, transform.rotation.y, transform.rotation.z, transform.rotation.w);
            //Instantiate(slicedEnemy, transform.position, Quaternion.identity);
            //Instantiate(slicedEnemy, upperPos, Quaternion.identity);
            if (firstTimeCheck)
            {
                objectPool.SpawnFromPool("Body", bodyPosition, bodyRotation);
                objectPool.SpawnFromPool("Head", upperPos, headRotation);
                objectPool.SpawnFromPool("Hat", hatPosition, Quaternion.identity);
                firstTimeCheck = false;


                if (hasUzi)
                {
                    objectPool.SpawnFromPool("Uzi", hatPosition, Quaternion.identity);
                }
                else
                {
                    objectPool.SpawnFromPool("Pistol", hatPosition, Quaternion.identity);
                }
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

    void OpenFire()
    {
        setFire = true;
    }


}
