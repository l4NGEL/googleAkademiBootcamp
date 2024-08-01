using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderScene4 : MonoBehaviour
{
    public int sceneToLoad = 4;
    public bool isReturnPortal = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
