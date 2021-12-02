using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintController : MonoBehaviour
{
    public int currentHint = 0, Hint;
    public Text hintText;

    public GameObject[] pieces;
    public Dragdrop[] dragdrops;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Hint"))
        {
            currentHint = PlayerPrefs.GetInt("Hint");
        }
    }

    // Update is called once per frame
    void Update()
    {
        hintText.text = currentHint.ToString();
    }

    public void UpdateHint()
    {
        currentHint += Hint;
        PlayerPrefs.SetInt("Hint", currentHint);
        hintText.text = currentHint.ToString();
    }

    public void UseHint()
    {
        
        int randomIndex = Random.Range(1, pieces.Length);

        if(currentHint > 0)
        {
            currentHint -= Hint;
            if (randomIndex == 1)
            {
                dragdrops[0].onPos = true;
                dragdrops[0].OnMouseUp();
            }
            if (randomIndex == 2)
            {
                dragdrops[1].onPos = true;
                dragdrops[1].OnMouseUp();
            }
            if (randomIndex == 3)
            {
                dragdrops[2].onPos = true;
                dragdrops[2].OnMouseUp();
            }
            if (randomIndex == 4)
            {
                dragdrops[3].onPos = true;
                dragdrops[3].OnMouseUp();
            }
        }
    }

}
