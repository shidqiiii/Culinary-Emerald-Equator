using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    public AudioSource BGM, SFX;
    public Toggle toggleBGM, toggleSFX;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(transform.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        if (PlayerPrefs.GetInt("bgm") == 1)
        {
            toggleBGM.isOn = true;
        }
        if (PlayerPrefs.GetInt("sfx") == 1)
        {
            toggleSFX.isOn = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BgmOnOff()
    {
        if (toggleBGM.isOn)
        {
            PlayerPrefs.SetInt("bgm", 1);
            BGM.mute = true;
        }
        else
        {
            PlayerPrefs.SetInt("bgm", 0);
            BGM.mute = false;
        }
    }

    public void SfxOnOff()
    {
        if (toggleSFX.isOn)
        {
            PlayerPrefs.SetInt("sfx", 1);
            SFX.mute = true;
        }
        else
        {
            PlayerPrefs.SetInt("sfx", 0);
            SFX.mute = false;
        }
    }
}
