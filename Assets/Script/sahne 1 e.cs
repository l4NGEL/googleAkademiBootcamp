using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderScene1 : MonoBehaviour
{
    public int sceneToLoad = 1;
    public bool isReturnPortal = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
