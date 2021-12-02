using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintController : MonoBehaviour
{
    public int currentHint = 0, Hint;
    public Text hintText;

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

    public void UseHintJigsaw()
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
            indexHint = dragdrops.Length;
        }
        
    }

    public void IndexHint()
    {
        int i = indexHint;
        dragdrops[i].onPos = true;
        dragdrops[i].OnMouseUp();
    }

}
