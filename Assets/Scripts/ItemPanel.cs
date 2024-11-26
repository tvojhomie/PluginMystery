using UnityEngine;
using UnityEngine.UI;
//using YG;

public class ItemPanel : MonoBehaviour
{
    [SerializeField] Text Tittle;
    [SerializeField] Text Name;

    [SerializeField] Image Icon;
    [SerializeField] Image bg;

    private void Start()
    {
       // if (YG2.lang == "ru")
       // {
        //    Debug.Log("ru done");
       // }
       // else
       // {
       //     Debug.Log("en done");
       // }
    }

    public void SetPanel(string _tittle, string _name, Sprite _icon)
    {
        Tittle.text = _tittle.ToString();
        Name.text = _name.ToString();
        Icon.sprite = _icon;

        bg.color = Color.red;
    }
}
