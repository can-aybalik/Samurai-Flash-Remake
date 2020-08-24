using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Projectile : MonoBehaviour
{

    public float speed;
    private Transform player;
    private Vector3 target;
    private Vector3 upperPos;
    ObjectPool objectPool;
    public float cutSize;
    public GameObject slicedBullet;
    public GameObject bonus;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = FindObjectOfType<PlayerMovement>().anim;
        objectPool = ObjectPool.Instance;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector3(player.position.x, player.position.y + 1, player.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyShooting.trackingPlayer)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, player.position.y + 1, player.position.z), speed * Time.deltaTime);
            if (transform.position.x == player.position.x && transform.position.y == player.position.y && transform.position.z == player.position.z)
                DestroyProjectile();
        }
        else
        {

            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            if (transform.position.x == target.x && transform.position.y == target.y && transform.position.z == target.z)
                DestroyProjectile();
        }
        

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("HIT!");
            anim.SetBool("isShot", true);
            DestroyProjectile();
            FindObjectOfType<GameController>().GameOver();
        }
        else if (other.CompareTag("Katana") || other.CompareTag("Block"))
        {
            Debug.Log("CUT!");
            //speed = 0;
            DestroyProjectile();
            upperPos = new Vector3(transform.position.x, transform.position.y + cutSize, transform.position.z);

            if(other.CompareTag("Katana")){
                if (this.gameObject.tag == "Cube")
                {
                    objectPool.SpawnFromPool("CubeSliced", transform.position, Quaternion.identity);
                    objectPool.SpawnFromPool("CubeSliced", upperPos, Quaternion.identity);
                }

                if (this.gameObject.tag == "Bullet")
                {
                    objectPool.SpawnFromPool("BulletSliced", transform.position, Quaternion.identity);
                    objectPool.SpawnFromPool("BulletSliced", upperPos, Quaternion.identity);
                }
            }
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
  