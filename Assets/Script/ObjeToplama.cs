using UnityEngine;

public class CollectableObject : MonoBehaviour
{
    public string objectID;
    public int sceneIndex; // Sahne indeksini tan�mlay�n

    void Start()
    {
        if (string.IsNullOrEmpty(objectID))
        {
            Debug.LogError("objectID ayarlanmam��: " + gameObject.name);
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
            Debug.Log($"Oyuncu nesneyi toplad�: {objectID}");
            GameManager.Instance.CollectObject(objectID); // Sahne indeksini ge�meye gerek yok
            gameObject.SetActive(false);
        }
    }
}
