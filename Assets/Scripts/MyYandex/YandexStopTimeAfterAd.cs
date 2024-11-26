using UnityEngine;

public class YandexStopTimeAfterAd : MonoBehaviour
{
    [SerializeField] GameObject AdPanel;

    void Update()
    {
        if (AdPanel.active == true)
        {
            Time.timeScale = 0;
        }
    }
}
