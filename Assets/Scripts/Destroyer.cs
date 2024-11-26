using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] float sec;

    private void Start()
    {
        Destroy(gameObject, sec);
    }

    public void DestroyObj()
    {
        Destroy(gameObject);
    }
}
