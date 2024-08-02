using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Dictionary<string, bool> collectedObjects = new Dictionary<string, bool>();
    public int totalCollectibleObjects = 5; // Toplanmasý gereken toplam oyuncak sayýsý

    void Awake()
    {
        // Eðer Instance zaten mevcutsa, bu örneði yok et
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CollectObject(string objectID)
    {
        if (!string.IsNullOrEmpty(objectID))
        {
            Debug.Log($"Nesne toplandý: {objectID}");
            if (collectedObjects.ContainsKey(objectID))
            {
                collectedObjects[objectID] = true;
            }
            else
            {
                collectedObjects.Add(objectID, true);
            }

            // Tüm nesneler toplandý mý kontrol et
            CheckAllObjectsCollected();
        }
        else
        {
            Debug.LogError("ObjectID boþ veya geçersiz.");
        }
    }

    public bool IsObjectCollected(string objectID)
    {
        if (string.IsNullOrEmpty(objectID))
        {
            Debug.LogError("ObjectID boþ veya geçersiz.");
            return false;
        }

        return collectedObjects.ContainsKey(objectID) && collectedObjects[objectID];
    }

    public bool AreAllObjectsCollectedInScene(int sceneIndex)
    {
        Debug.Log($"Sahne {sceneIndex} içindeki tüm nesneler toplandý mý kontrol ediliyor...");
        foreach (var obj in FindObjectsOfType<CollectableObject>())
        {
            Debug.Log($"Nesne {obj.objectID} sahne {sceneIndex} içinde kontrol ediliyor...");
            if (obj.sceneIndex == sceneIndex && !IsObjectCollected(obj.objectID))
            {
                Debug.Log($"Nesne {obj.objectID} sahne {sceneIndex} içinde toplanmamýþ.");
                return false;
            }
        }
        Debug.Log($"Sahne {sceneIndex} içindeki tüm nesneler toplandý.");
        return true;
    }

    void CheckAllObjectsCollected()
    {
        Debug.Log("Tüm oyuncaklar toplandý mý kontrol ediliyor...");
        int collectedCount = 0;

        foreach (var obj in collectedObjects.Values)
        {
            if (obj) collectedCount++;
        }

        if (collectedCount >= totalCollectibleObjects)
        {
            // Eðer tüm oyuncaklar toplandýysa, "GameEnded" ekranýna geçiþ yap
            Debug.Log("Tüm oyuncaklar toplandý! Son ekran yükleniyor...");
            LoadEndScreen();
        }
    }

    void LoadEndScreen()
    {
        SceneManager.LoadScene("GameEnded");
    }
}
