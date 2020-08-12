using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameObject levelCompleteUI;

    public GameObject failedUI;

    public GameObject failedUI2;

    bool isGameOver = false;

    Renderer cubeRenderer = null;

    private Transform player;

    private void Start()
    {
        failedUI2.SetActive(true);
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void GameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            Debug.Log("GAME OVER!");
            cubeRenderer = player.GetComponent<Renderer>();
            cubeRenderer.material.SetColor("_Color", Color.red);
            failedUI.SetActive(true);
            StartCoroutine(RestartWithDelay(1));
        }
    } 

    IEnumerator RestartWithDelay(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CompleteLevel()
    {
        Debug.Log("FINISH!");
        levelCompleteUI.SetActive(true);
        FindObjectOfType<PlayerMovement>().rb.drag = 20;
        
    }

    public void LoadNextLevel()
    {
        Debug.Log("NEXT LEVEL!");
    }



}
