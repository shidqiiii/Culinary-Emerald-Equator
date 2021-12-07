using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuShop : MonoBehaviour
{
    public HintManager hintManager;
    public CoinManager coinManager;

    int coin, hint;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Coin"))
        {
            coinManager.currentCoin = PlayerPrefs.GetInt("Coin");
        }
        if (PlayerPrefs.HasKey("Hint"))
        {
            hintManager.currentHint = PlayerPrefs.GetInt("Hint");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PriceHint(int price)
    {
        if(coinManager.currentCoin >= coin)
        {
            switch (price)
            {
                case 1:
                    Debug.Log("bayar 1000");
                    coin = 1000;
                    hint = 1;
                    break;

                case 2:
                    Debug.Log("bayar 2500");
                    coin = 2500;
                    hint = 3;
                    break;

                case 3:
                    Debug.Log("bayar 7000");
                    coin = 7000;
                    hint = 10;
                    break;

                case 4:
                    Debug.Log("bayar 8500");
                    coin = 8500;
                    hint = 15;
                    break;

                case 5:
                    Debug.Log("bayar 10000");
                    coin = 10000;
                    hint = 20;
                    break;
            }
            coinManager.currentCoin -= coin;
            hintManager.currentHint += hint;
        }
        else
        {
            Debug.Log("You don't have enough money");
        }
        

        PlayerPrefs.SetInt("Coin", coinManager.currentCoin);
        PlayerPrefs.SetInt("Hint", hintManager.currentHint);

    }
    public void LoadScene(string _SceneName)
    {
        SceneManager.LoadScene(_SceneName);
    }
}
