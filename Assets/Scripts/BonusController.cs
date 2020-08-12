using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusController : MonoBehaviour
{

    public GameObject player;

    public GameObject bonus;

    Renderer cubeRenderer = null;
    void Start()
    {
        Destroy(bonus);
        //Start the coroutine we define below named ExampleCoroutine.
        FindObjectOfType<Katana>().bonusCheck = true;
        cubeRenderer = player.GetComponent<Renderer>();
        cubeRenderer.material.SetColor("_Color", Color.green);
        StartCoroutine(ExampleCoroutine());
    }

    IEnumerator ExampleCoroutine()
    {
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        yield return new WaitForSeconds(5);
        FindObjectOfType<Katana>().bonusCheck = false;
        cubeRenderer.material.SetColor("_Color", Color.white);
    }







}
