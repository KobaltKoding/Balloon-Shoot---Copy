using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Image logo;
    public Canvas UICanvas;
    public Canvas difficulty;
    public Canvas levelSelect;
    public Canvas levelComplete;

    public void Start()
    {
        Time.timeScale = 1;
        StartCoroutine(QuickStart());
    }
    public void StartGame()
    {
        UICanvas.gameObject.SetActive(false);
        difficulty.gameObject.SetActive(true);
    }

    public IEnumerator QuickStart()
    {
        yield return new WaitForSeconds(1.2f);
        logo.gameObject.SetActive(false);
        //yield return new WaitForSeconds(2);
        UICanvas.gameObject.SetActive(true);
        //yield return new WaitForSeconds(1);
        //difficulty.gameObject.SetActive(true);

    }

    public void SelectDifficulty()
    {
        difficulty.gameObject.SetActive(false);
        levelSelect.gameObject.SetActive(true);
    }

    public void SelectLevel(int level)
    {
        SceneManager.LoadScene(level);
    }



    public void Quit()
    {
        Debug.Log("QUITTING");
        Application.Quit();
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
