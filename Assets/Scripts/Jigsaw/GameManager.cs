using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject endcondition, puzzle;

    public TimeManager timeManager;
    public CoinManager coinManager;
    public GameObject star1, star2, star3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EndCondition()
    {
        coinManager.UpdateCoin();
        puzzle.SetActive(false);
        endcondition.SetActive(true);

    }

    public void ResetGame()
    {
        puzzle.SetActive(true);
        endcondition.SetActive(false);
    }

    public void TimeStar()
    {
        if (timeManager.currentTime < 5f)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
        }
        else if (timeManager.currentTime >= 5f && timeManager.currentTime < 10f)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(false);
        }
        if (timeManager.currentTime >= 10f)
        {
            star1.SetActive(true);
            star2.SetActive(false);
            star3.SetActive(false);
        }
    }

    public void LoadScene(string _SceneName)
    {
        SceneManager.LoadScene(_SceneName);
    }

}
