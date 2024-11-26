using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RobbyCam : MonoBehaviour
{
    public Transform target;
    public float distance = 10.0f;
    public float height = 5.0f;
    public float rotationSpeed = 5.0f;

    private float currentX = 0.0f;
    private float currentY = 0.0f;

    public bool isMobileDevice = true;

    public GraphicRaycaster raycaster;
    public EventSystem eventSystem;

    void Start()
    {
        isMobileDevice = Application.isMobilePlatform;
    }

    void Update()
    {
        // Вращение камеры (независимо от того, используется ли джойстик)
        if (isMobileDevice)
        {
            // Работаем с несколькими касаниями
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);

                // Проверяем, что текущее касание не над элементом UI (например, не джойстик)
                if (!IsPointerOverUIElement(touch.position))
                {
                    // Если палец двигается, вращаем камеру
                    if (touch.phase == TouchPhase.Moved)
                    {
                        currentX -= touch.deltaPosition.x * rotationSpeed * Time.deltaTime;
                        currentY += touch.deltaPosition.y * rotationSpeed * Time.deltaTime; // направление вверх
                    }
                }
            }
        }
        else
        {
            // Управление мышью на ПК
            if (Input.GetMouseButton(1))
            {
                currentX += Input.GetAxis("Mouse X") * rotationSpeed;
                currentY -= Input.GetAxis("Mouse Y") * rotationSpeed;
            }
        }

        // Ограничение вращения по вертикали
        currentY = Mathf.Clamp(currentY, -35, 60);

        // Обновляем позицию и поворот камеры
        if (target != null)
        {
            Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
            Vector3 position = target.position - (rotation * Vector3.forward * distance + new Vector3(0, -height, 0));

            transform.position = position;
            transform.LookAt(target.position + Vector3.up * 2.0f);
        }
    }

    // Проверяем, находится ли палец над элементом UI
    bool IsPointerOverUIElement(Vector2 touchPosition)
    {
        PointerEventData pointerEventData = new PointerEventData(eventSystem);
        pointerEventData.position = touchPosition;

        var results = new System.Collections.Generic.List<RaycastResult>();
        raycaster.Raycast(pointerEventData, results);

        return results.Count > 0;
    }
}
