using UnityEngine;

public class RotaterL : MonoBehaviour
{
    [SerializeField] Vector3 RotateVector;

    private void Update()
    {
        transform.Rotate(RotateVector * Time.deltaTime);
    }
}
