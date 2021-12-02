using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndCondition : MonoBehaviour
{
    public GameObject puzzle;
    public Text time, coin;
    [SerializeField]bool selesai = false;

    public TimeManager timeManager;
    public SingleLevel singleLevel;
    public CoinManager coinManager;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {

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
                time.text = timeManager.timeText.text;
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
            gameManager.EndCondition();
            gameManager.TimeStar();
            //singleLevel.UpdateStar();
            coinManager.UpdateCoin();
            coin.text = coinManager.coinText.text;
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
    }

    
}
