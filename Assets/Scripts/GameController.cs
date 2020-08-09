using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameObject levelCompleteUI;

    bool isGameOver = false;

    public void GameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            Debug.Log("GAME OVER!");
            StartCoroutine(RestartWithDelay(1));
        }
    }

    IEnumerator RestartWithDelay(float time)
    {
        yield return new WaitForSeconds(time);

        Restart();
    }
    void Restart()
    {
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
