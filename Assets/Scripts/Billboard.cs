using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Transform target;

    private void Start()
    {
        target = Robby.instance.transform;
    }

    void LateUpdate()
    {
        if (target != null)
        {
            transform.LookAt(target.position);
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        }
    }
}
