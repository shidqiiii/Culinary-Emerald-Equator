using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndCondition : MonoBehaviour
{
    public GameObject wincondition, puzzle;
    public Text time;
    [SerializeField]bool selesai = false;

    public GameObject star1, star2, star3;

    public TimeManager timeManager;
    public SingleLevel singleLevel;
    public CoinManager coinManager;

    // Start is called before the first frame update
    void Start()
    {
        puzzle.SetActive(true);
        wincondition.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!selesai)
        {
            CekPuzzle();
        }
    }

    public void CekPuzzle()
    {
        for(int i = 0; i < 4; i++)
        {
            if (transform.GetChild(i).GetComponent<Dragdrop>().onTempel)
            {
                selesai = true;
                time.text = time.text;
            }
            else
            {
                selesai = false;
                i = 4;
            }
        }

        if (selesai)
        {
            timeManager.timeActive = false;
            TimeStar();
            wincondition.SetActive(true);
            puzzle.SetActive(false);
            singleLevel.UpdateStar();
            coinManager.UpdateCoin();
        }
    }

    public void ResetPuzzle()
    {
        for (int i = 0; i < 4; i++)
        {
            puzzle.transform.GetChild(i).GetComponent<Dragdrop>().onTempel = false;
            puzzle.transform.GetChild(i).GetComponent<Dragdrop>().onPos = false;
            puzzle.transform.GetChild(i).position = puzzle.transform.GetChild(i).GetComponent<Dragdrop>().randomPos;
            puzzle.transform.GetChild(i).localScale = puzzle.transform.GetChild(i).GetComponent<Dragdrop>().scaleAwal;
            timeManager.currentTime = 0;
            timeManager.timeActive = true;
        }

        selesai = false;
        puzzle.SetActive(true);
        wincondition.SetActive(false);
    }

    void TimeStar()
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
}
