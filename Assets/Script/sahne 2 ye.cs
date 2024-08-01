using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderScene2 : MonoBehaviour
{
    public int sceneToLoad = 2;
    public bool isReturnPortal = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
