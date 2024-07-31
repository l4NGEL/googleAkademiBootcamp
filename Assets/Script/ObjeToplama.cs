using UnityEngine;

public class CollectableObject : MonoBehaviour
{
    public string objectID;

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
            GameManager.Instance.CollectObject(objectID);
            gameObject.SetActive(false);
        }
    }
}
