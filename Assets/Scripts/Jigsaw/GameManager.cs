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
        if (SceneManager.GetActiveScene().name == "Level 1" || SceneManager.GetActiveScene().name == "Level 2")
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
        }

        else if (SceneManager.GetActiveScene().name == "Level 3" || SceneManager.GetActiveScene().name == "Level 4")
        {
            if (timeManager.currentTime < 60f)
            {
                star1.SetActive(true);
                star2.SetActive(true);
                star3.SetActive(true);
            }
            else if (timeManager.currentTime >= 60f && timeManager.currentTime < 120f)
            {
                star1.SetActive(true);
                star2.SetActive(true);
                star3.SetActive(false);
            }
            else if(timeManager.currentTime >= 120f)
            {
                star1.SetActive(true);
                star2.SetActive(false);
                star3.SetActive(false);
            }
            else if (timeManager.currentTime >= 180f)
            {
                star1.SetActive(false);
                star2.SetActive(false);
                star3.SetActive(false);
            }
        }
        else if (SceneManager.GetActiveScene().name == "Level 5")
        {
            if (timeManager.currentTime < 90f)
            {
                star1.SetActive(true);
                star2.SetActive(true);
                star3.SetActive(true);
            }
            else if (timeManager.currentTime >= 90f && timeManager.currentTime < 150f)
            {
                star1.SetActive(true);
                star2.SetActive(true);
                star3.SetActive(false);
            }
            else if (timeManager.currentTime >= 150f)
            {
                star1.SetActive(true);
                star2.SetActive(false);
                star3.SetActive(false);
            }
            else if (timeManager.currentTime >= 240f)
            {
                star1.SetActive(false);
                star2.SetActive(false);
                star3.SetActive(false);
            }
        }
        
    }

    public void LoadScene(string _SceneName)
    {
        SceneManager.LoadScene(_SceneName);
        Time.timeScale = 1f;
    }

}
