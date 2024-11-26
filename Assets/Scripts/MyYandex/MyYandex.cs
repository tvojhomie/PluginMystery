using UnityEngine;
using YG;
using UnityEngine.UI;


public class MyYandex : MonoBehaviour
{
	public static MyYandex Instance;
	public GameObject p;
	//public LeaderboardYG L;

	//private void OnEnable() => YandexGame.RewardVideoEvent += Rewarded;
	//private void OnDisable() => YandexGame.RewardVideoEvent -= Rewarded;

	public Text timerText;
	public Thing[] Things;

    private void Awake()
	{
		Instance = this;
	}

    private void Start()
    {
	//	YG2.InterstitialAdvShow();

	}

    private void Update()
    {
		timerText.text = YG2.timerInterAdv.ToString("00.0");

        if (YG2.timerInterAdv <= 0)
        {
			p.SetActive(true);
		}
	}

    void Rewarded(int id)
	{
		if (id <= Things.Length - 1)
		{
			Things[id].gameObject.SetActive(true);
			Things[id].Select();
		}
	}

	//public void NewLeader(int _score)
	//{
	//	L.NewScore(_score);
	//	L.UpdateLB();
	//}

	public void ShowReview()
	{
	//	YandexGame.ReviewShow(YandexGame.EnvironmentData.reviewCanShow);
	}

	public void ExampleOpenRewardAd(int id)
	{
	//	YandexGame.RewVideoShow(id);
	}

	public void ShowLikeGame()
	{
	//	YandexGame.ReviewShow(false);
	}
}
