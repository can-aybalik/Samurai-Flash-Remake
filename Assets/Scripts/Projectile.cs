using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed;
    private Transform player;
    private Vector3 target;
    private Vector3 upperPos;

    public float cutSize;

    public GameObject slicedBullet;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector3(player.position.x, player.position.y, player.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y && transform.position.z == target.z)
            DestroyProjectile();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyProjectile();
            Debug.Log("HIT!");
        }
        else if (other.CompareTag("Katana"))
        {
            Debug.Log("CUT!");
            //speed = 0;
            DestroyProjectile();
            upperPos = new Vector3(transform.position.x, transform.position.y + cutSize, transform.position.z);

            Instantiate(slicedBullet, transform.position, Quaternion.identity);
            Instantiate(slicedBullet, upperPos, Quaternion.identity);
            

        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
  