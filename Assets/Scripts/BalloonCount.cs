using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalloonCount : MonoBehaviour
{
    public GameObject Targets;
    public Text countText;
    public Canvas LevelFail;
    public Canvas LevelComplete;
    public ParticleSystem Confetti;


    public float score;
    public float targetScore;

    private void Start()
    {

        for(int i=0;i< Targets.transform.childCount; i++)
        {
            targetScore += Targets.transform.GetChild(i).childCount;
        }
        //targetScore= Targets.transform.childCount;
        
    }
    void Update()
    {
        countText.text = score.ToString();
        if (score == targetScore)
            LevelFinish();
    }

    public void LevelFinish()
    {

        //Time.timeScale = 0f;
        LevelComplete.gameObject.SetActive(true);
        Confetti.gameObject.SetActive(true);

    }

    public void LevelFailed()
    {

        Time.timeScale = 0f;
        LevelFail.gameObject.SetActive(true);


    }
}
