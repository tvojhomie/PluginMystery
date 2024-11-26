using UnityEngine;

public class SoundSetting : MonoBehaviour
{
    [SerializeField] GameObject OpenObj;
    private bool soundOn = true;

    private void Start()
    {
        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            OpenObj.SetActive(false);
            AudioListener.volume = 1;
            soundOn = true;
        }
        else
        {
            OpenObj.SetActive(true);
            AudioListener.volume = 0;
            soundOn = false;
        }
    }

    public void ToggleSound()
    {
        soundOn = !soundOn;

        if (soundOn)
        {
            OpenObj.SetActive(false);
            PlayerPrefs.SetInt("Sound", 0);
            AudioListener.volume = 1;
        }
        else
        {
            OpenObj.SetActive(true);
            PlayerPrefs.SetInt("Sound", 1);
            AudioListener.volume = 0;
        }
    }

    public void AdsSoundOff()
    {
        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            AudioListener.volume = 0;
        }
    }

    public void AdsSoundOn()
    {
        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            AudioListener.volume = 1;
        }
    }
}
