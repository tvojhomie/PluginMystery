using UnityEngine;

public class SearchItem : MonoBehaviour
{
    public int index;
    [SerializeField] GameObject DoneIndicator;
    [SerializeField] ItemPanel ItemPanel;

    [SerializeField] string tittle;
    [SerializeField] string name;
    [SerializeField] SpriteRenderer icon;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Item" + index))
        {
            OpenItem();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Robby>())
        {
            if (!PlayerPrefs.HasKey("Item" + index))
            {
                OpenItem();
                GeneratePanel();
                PlayerPrefs.SetInt("Item" + index, 1);
            }
        }
    }

    private void GeneratePanel()
    {
        Transform current = GameObject.Find("Canvas").GetComponent<Transform>();

        ItemPanel newPanel = Instantiate(ItemPanel, current);
        newPanel.SetPanel(tittle,name,icon.sprite);
    }
    private void OpenItem()
    {
        DoneIndicator.SetActive(true);
    }
}
