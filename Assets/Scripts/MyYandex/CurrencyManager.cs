using System.Collections;
using UnityEngine;
//using YG;

public class CurrencyManager : MonoBehaviour
{
	//private void OnEnable() => YandexGame.GetDataEvent += LoadCloud;
	//private void OnDisable() => YandexGame.GetDataEvent -= LoadCloud;

	public enum CurrencyType
	{
		Money,
		Cool,
	}

	public static CurrencyManager Instance;

	public int Money;
	public int Cool = 1;
	public int BestMoney;

//	public GameObject X3;

	private bool newBest;

	private void Awake()
	{
		Instance = this;
	}

    private void Start()
    {
		//if (//YandexGame.SDKEnabled)
		//{
		//	LoadCloud();
		//}
		//else
	//	{
			Money = PlayerPrefs.GetInt("Money");
			BestMoney = PlayerPrefs.GetInt("BestMoney");
	//	}

		StartCoroutine(AutoClick());
	}

	 IEnumerator AutoClick()
    {
        while (true)
        {
			yield return new WaitForSeconds(1);
			AddMoney(10);

		//	YandexGame.SaveProgress();

			if (newBest)
			{
				//YandexGame.NewLeaderboardScores("Score", BestMoney);
			}
		}
    }

	public void AddMoney(int n)
	{
		Money += n;
		//X3.SetActive(true);

		if (Money < 0)
        {
			Money = 0;
		}

		if (Money >= BestMoney)
		{
			BestMoney = Money;
			//YandexGame.savesData.BestMoney = BestMoney;
			PlayerPrefs.SetInt("BestMoney", BestMoney);
			newBest = true;
		}

		//YandexGame.savesData.Money = Money;
		PlayerPrefs.SetInt("Money", Money);
	}

	public void AddCool(int n)
	{
		Cool += n;
	}

	private void LoadCloud()
	{//
		//Money = YandexGame.savesData.Money;
		//BestMoney = YandexGame.savesData.BestMoney;
	}
}
