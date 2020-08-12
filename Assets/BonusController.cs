using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusController : MonoBehaviour
{

    public GameObject bonus;
    void Start()
    {
        Destroy(bonus);
        //Start the coroutine we define below named ExampleCoroutine.
        FindObjectOfType<Katana>().bonusCheck = true;
        StartCoroutine(ExampleCoroutine());
        
    }

    IEnumerator ExampleCoroutine()
    {
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        yield return new WaitForSeconds(5);
        FindObjectOfType<Katana>().bonusCheck = false;
    }






}
