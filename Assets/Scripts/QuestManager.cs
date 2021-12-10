using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public bool unlocked;

    CoinManager coinManager;
    HintManager hintManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Achievement(int reward)
    {
        switch (reward)
        {
            case 1:
                coinManager.currentCoin += 500;
                break;

            case 2:
                coinManager.currentCoin += 1000;
                break;

            case 3:
                hintManager.currentHint += 3;
                break;

            case 4:
                coinManager.currentCoin += 1000;
                break;

            case 5:
                coinManager.currentCoin += 500;
                break;

        }
    }
}
