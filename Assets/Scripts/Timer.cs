
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public float targetTime;
    public Text timeText;

    private void Start()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (targetTime >= 0.0f)
            targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            timerEnded();
        }
        else
            DisplayTime(targetTime);
    }

    public void timerEnded()
    {
        FindObjectOfType<BalloonCount>().LevelFailed();
        Time.timeScale = 0f;

    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
