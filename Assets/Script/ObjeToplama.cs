using UnityEngine;

public class CollectableObject : MonoBehaviour
{
    public string objectID;
    public int sceneIndex; // Sahne indeksini tanýmlayýn

    void Start()
    {
        if (string.IsNullOrEmpty(objectID))
        {
            Debug.LogError("objectID ayarlanmamýþ: " + gameObject.name);
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
            Debug.Log($"Oyuncu nesneyi topladý: {objectID}");
            GameManager.Instance.CollectObject(objectID); // Sahne indeksini geçmeye gerek yok
            gameObject.SetActive(false);
        }
    }
}
