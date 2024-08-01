using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderScene3 : MonoBehaviour
{
    public int sceneToLoad = 3;
    public bool isReturnPortal = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
