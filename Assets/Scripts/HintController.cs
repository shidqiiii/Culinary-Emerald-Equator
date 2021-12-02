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
    int indexHint = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Hint"))
        {
            currentHint = PlayerPrefs.GetInt("Hint");
        }

        UpdateHint();
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
        if(currentHint > 0)
        {
            currentHint--;
            PlayerPrefs.SetInt("Hint", currentHint);
            indexHint++;
            IndexHint();
        }
        else
        {
            currentHint = 0;
            indexHint = pieces.Length;
        }
        
    }

    public void IndexHint()
    {
        if (indexHint == 1)
        {
            dragdrops[0].onPos = true;
            dragdrops[0].OnMouseUp();
        }
        if (indexHint == 2)
        {
            dragdrops[1].onPos = true;
            dragdrops[1].OnMouseUp();
        }
        if (indexHint == 3)
        {
            dragdrops[2].onPos = true;
            dragdrops[2].OnMouseUp();
        }
        if (indexHint == 4)
        {
            dragdrops[3].onPos = true;
            dragdrops[3].OnMouseUp();
        }
    }

}
