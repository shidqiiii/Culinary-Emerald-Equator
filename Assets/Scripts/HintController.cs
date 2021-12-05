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
        int randomIndex = Random.Range(0, list.Count);

        if (currentHint > 0)
        {
            if (list[randomIndex].onTempel)
            {
                list.Remove(list[randomIndex]);
                UseHintJigsaw();
            }
            else
            {
                list[randomIndex].onPos = true;
                list[randomIndex].OnMouseUp();
                list.Remove(list[randomIndex]);
                currentHint--;
            }
            
        }
        else
        {
            currentHint = 0;
            Debug.Log("The list is empty: ");
        }

        PlayerPrefs.SetInt("Hint", currentHint);
    }
}
