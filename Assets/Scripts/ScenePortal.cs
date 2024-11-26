using UnityEngine;
using UnityEngine.SceneManagement;


public class ScenePortal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Robby>())
        {
            SceneManager.LoadScene("Level_01");
        }
    }
}
