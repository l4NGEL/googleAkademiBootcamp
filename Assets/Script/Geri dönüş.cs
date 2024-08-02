using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnPortal : MonoBehaviour
{
    public bool isReturnPortal = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.Instance.AreAllObjectsCollectedInScene(SceneManager.GetActiveScene().buildIndex))
            {
                SceneManager.LoadScene(6); // Ana sahneye d�n
            }
            else
            {
                Debug.LogError("You must collect all objects in the scene before returning.");
            }
        }
    }
}
