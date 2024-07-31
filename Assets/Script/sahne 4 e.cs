using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderScene4 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(4);
        }
    }
}
