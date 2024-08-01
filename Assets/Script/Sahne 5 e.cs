using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderScene5 : MonoBehaviour
{
    public int sceneToLoad = 5;
    public bool isReturnPortal = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
