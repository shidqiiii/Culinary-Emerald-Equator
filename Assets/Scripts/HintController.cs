using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintController : MonoBehaviour
{
    public int currentHint = 0, Hint;
    public Text hintText;

    public List<Dragdrop> list = new List<Dragdrop>();
    

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
        if (currentHint > 0)
        {
            currentHint--;
            PlayerPrefs.SetInt("Hint", currentHint);
            IndexHint();
        }
        else
        {
            currentHint = 0;
        }

    }

    public void IndexHint()
    {
        /* if (dragdrops[i].onTempel)
         {
             dragdrops[i++].onPos = true;
             dragdrops[i++].OnMouseUp();
         }

         dragdrops[i].onPos = true;
         dragdrops[i].OnMouseUp();

         */
        if (list.Count > 0)
        {
            int randomIndex = Random.Range(0, list.Count);
            list[randomIndex].onPos = true;
            list[randomIndex].OnMouseUp();
            list.Remove(list[randomIndex]);
        }
        else
        {
            Debug.Log("The list is empty: ");
        }

    }
}
