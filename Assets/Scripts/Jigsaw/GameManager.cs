using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject endcondition, pausemenu, puzzle;

    public TimeManager timeManager;
    public EndCondition endCondition;
    public HintController hintController;

    public GameObject star1, star2, star3;

    public bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndCondition()
    {
        puzzle.SetActive(false);
        endcondition.SetActive(true);
        pausemenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void PauseMenu()
    {        
        if (isPaused)
        {
            isPaused = false; 
            puzzle.SetActive(true);
            pausemenu.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            isPaused = true; 
            puzzle.SetActive(false);
            pausemenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void ResetGame()
    {
        endCondition.ResetPuzzle();
        puzzle.SetActive(true);
        endcondition.SetActive(false);
        pausemenu.SetActive(false); 
        Time.timeScale = 1f;
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
        Time.timeScale = 1f;
    }

}
