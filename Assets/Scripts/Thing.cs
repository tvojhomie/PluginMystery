using UnityEngine;

public class Thing : MonoBehaviour
{
    public int CoolValue;
    public string key;
    public GameObject ButtonShop;

    private void Start()
    {
        CurrencyManager.Instance.AddCool(CoolValue);
        if (!PlayerPrefs.HasKey(key))
        {
            CurrencyManager.Instance.AddCool(-CoolValue);
            gameObject.SetActive(false);
            ButtonShop.SetActive(true);
        }
    }

    public void Select()
    {
        PlayerPrefs.SetInt(key,1);
        CurrencyManager.Instance.AddCool(CoolValue);
        ButtonShop.SetActive(false);
    }
}
