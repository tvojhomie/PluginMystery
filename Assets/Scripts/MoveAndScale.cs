using UnityEngine;

public class MoveAndScale : MonoBehaviour
{
    [SerializeField] float SpeedLerp;
    [SerializeField] Vector3 TargetScale;
    [SerializeField] Vector3 MoveVector;

    private void Start()
    {
        Destroy(gameObject,1f);
    }

    private void Update()
    {
        transform.Translate(MoveVector * Time.unscaledDeltaTime);

        transform.localScale = Vector3.Lerp(transform.localScale, TargetScale, SpeedLerp * Time.deltaTime);
        if (transform.localScale.x <= 0)
        {
            Destroy(gameObject);
        }
    }
}
