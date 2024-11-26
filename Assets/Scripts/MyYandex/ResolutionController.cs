using UnityEngine;
using UnityEngine.UI;

public class ResolutionController : MonoBehaviour
{
    public CanvasScaler canvasScaler;
    public float r;

    void Start()
    {
        UpdateCanvasScaler();
    }

    void Update()
    {
        // ????????? ????????? ?????????? ??????
        if (Screen.width != canvasScaler.referenceResolution.x || Screen.height != canvasScaler.referenceResolution.y)
        {
            UpdateCanvasScaler();
        }
    }

    void UpdateCanvasScaler()
    {
        float aspectRatio = (float)Screen.width / Screen.height;

        if (aspectRatio > r)
        {
            // ????????????? ????? ?????
            canvasScaler.matchWidthOrHeight = 1f;
        }
        else
        {
            // ??????????? ????? ?????
            canvasScaler.matchWidthOrHeight = 0f;
        }
    }
}
