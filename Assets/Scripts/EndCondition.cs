using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndCondition : MonoBehaviour
{
    public GameObject wincondition, puzzle;
    public Text time;
    [SerializeField]bool selesai = false;

    public GameManager gameManager;
    public SingleLevel singleLevel;

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
                time.text = gameManager.timeText.text;
            }
            else
            {
                selesai = false;
                i = 4;
            }
        }

        if (selesai)
        {
            gameManager.timeActive = false;
            wincondition.SetActive(true);
            puzzle.SetActive(false);
            singleLevel.UpdateStar();
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
            gameManager.currentTime = 0;
            gameManager.timeActive = true;
        }

        selesai = false;
        puzzle.SetActive(true);
        wincondition.SetActive(false);
    }
}
