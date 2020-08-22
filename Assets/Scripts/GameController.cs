using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject playerObj;
    public GameObject objectPoolInstance;
    public GameObject levelCompleteUI;
    public GameObject failedUI;
    public GameObject failedUI2;
    public GameObject[] levels;

    public int currentLevelIndex = 0;

    bool isGameOver = false;
    public bool isShellActive = false;


    public static bool checkpointEnabled = false;

    Renderer cubeRenderer = null;

    private Transform player;

    private void Start()
    {
        FindObjectOfType<PlayerMovement>().cutscene = true;
        TimeController.continueTime();
        failedUI2.SetActive(true);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        cubeRenderer = player.GetComponent<Renderer>();
    }

    public void GameOver()
    {
        if (!isGameOver)
        {
            if (!isShellActive)
            {
                player.GetComponent<PlayerMovement>().hitted = true;
                isGameOver = true;
                Debug.Log("GAME OVER!");
                //cubeRenderer.material.SetColor("_Color", Color.red);
                failedUI.SetActive(true);
                StartCoroutine(RestartWithDelay(1));
            }
            else
            {
                cubeRenderer.material.SetColor("_Color", Color.white);
                isShellActive = false;
            }
            
        }
    } 

    IEnumerator RestartWithDelay(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CompleteLevel()
    {
        FindObjectOfType<PlayerMovement>().cutscene = true;
        TimeController.continueTime();
        Debug.Log("FINISH!");
        levelCompleteUI.SetActive(true);
        FindObjectOfType<PlayerMovement>().rb.drag = 20;
        
    }

    public void activateShell()
    {
        cubeRenderer.material.SetColor("_Color", Color.green);
        isShellActive = true;
    }

    public void clearOldLevel()
    {
        for (int i = 0; i < objectPoolInstance.transform.childCount; i++)
        {
            objectPoolInstance.transform.GetChild(i).gameObject.SetActive(false);
        }
        failedUI2.SetActive(false);
        levelCompleteUI.SetActive(false);
        failedUI2.SetActive(true);
        levels[currentLevelIndex].SetActive(false);
        currentLevelIndex++;
        levels[currentLevelIndex].SetActive(true);
        playerObj.GetComponent<TrailRenderer>().enabled = true;
    }

}
