using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public Canvas PauseCanvas;

    public void PauseGame()
    {
        Time.timeScale = 0;

        PauseCanvas.gameObject.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;

        PauseCanvas.gameObject.SetActive(false);
    }
    public void NextLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        Debug.Log("Quitting");

    }
    public void Replay()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
    }
}
