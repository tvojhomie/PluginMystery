using UnityEngine;
using UnityEngine.UI;

public class CurrencyText : MonoBehaviour
{
	private int frameCounter;

	private Text text;

	public CurrencyManager.CurrencyType currencyType;

	private void Start()
	{
		text = GetComponent<Text>();
	}

	private void Update()
	{
		frameCounter++;

		if (frameCounter % 15 == 0)
		{
			switch (currencyType)
			{
			case CurrencyManager.CurrencyType.Money:
				text.text = CurrencyManager.Instance.Money.ToString();
				break;
				case CurrencyManager.CurrencyType.Cool:
					text.text = CurrencyManager.Instance.Cool.ToString();
					break;
			}
		}
	}
}
