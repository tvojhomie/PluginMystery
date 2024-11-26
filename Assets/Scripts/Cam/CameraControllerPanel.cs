using UnityEngine;
using UnityEngine.EventSystems;

public class CameraControllerPanel : MonoBehaviour, IPointerDownHandler,IPointerUpHandler
{
    public bool pressed = false;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        if(eventData.pointerCurrentRaycast.gameObject == gameObject)
        {
            pressed = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
    }

}
