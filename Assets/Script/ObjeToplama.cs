using UnityEngine;

public class CollectableObject : MonoBehaviour
{
    public string objectID;
    public int sceneIndex; // Add scene index to identify which scene this object belongs to

    void Start()
    {
        if (string.IsNullOrEmpty(objectID))
        {
            Debug.LogError("objectID is not set for " + gameObject.name);
            return;
        }

        if (GameManager.Instance.IsObjectCollected(objectID))
        {
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.CollectObject(objectID, sceneIndex); // Pass the scene index
            gameObject.SetActive(false);
        }
    }
}
