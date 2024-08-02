using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Dictionary<string, bool> collectedObjects = new Dictionary<string, bool>();
    public int totalCollectibleObjects = 5; // Toplanmas� gereken toplam oyuncak say�s�

    void Awake()
    {
        // E�er Instance zaten mevcutsa, bu �rne�i yok et
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
            Debug.Log($"Nesne topland�: {objectID}");
            if (collectedObjects.ContainsKey(objectID))
            {
                collectedObjects[objectID] = true;
            }
            else
            {
                collectedObjects.Add(objectID, true);
            }

            // T�m nesneler topland� m� kontrol et
            CheckAllObjectsCollected();
        }
        else
        {
            Debug.LogError("ObjectID bo� veya ge�ersiz.");
        }
    }

    public bool IsObjectCollected(string objectID)
    {
        if (string.IsNullOrEmpty(objectID))
        {
            Debug.LogError("ObjectID bo� veya ge�ersiz.");
            return false;
        }

        return collectedObjects.ContainsKey(objectID) && collectedObjects[objectID];
    }

    public bool AreAllObjectsCollectedInScene(int sceneIndex)
    {
        Debug.Log($"Sahne {sceneIndex} i�indeki t�m nesneler topland� m� kontrol ediliyor...");
        foreach (var obj in FindObjectsOfType<CollectableObject>())
        {
            Debug.Log($"Nesne {obj.objectID} sahne {sceneIndex} i�inde kontrol ediliyor...");
            if (obj.sceneIndex == sceneIndex && !IsObjectCollected(obj.objectID))
            {
                Debug.Log($"Nesne {obj.objectID} sahne {sceneIndex} i�inde toplanmam��.");
                return false;
            }
        }
        Debug.Log($"Sahne {sceneIndex} i�indeki t�m nesneler topland�.");
        return true;
    }

    void CheckAllObjectsCollected()
    {
        Debug.Log("T�m oyuncaklar topland� m� kontrol ediliyor...");
        int collectedCount = 0;

        foreach (var obj in collectedObjects.Values)
        {
            if (obj) collectedCount++;
        }

        if (collectedCount >= totalCollectibleObjects)
        {
            // E�er t�m oyuncaklar topland�ysa, "GameEnded" ekran�na ge�i� yap
            Debug.Log("T�m oyuncaklar topland�! Son ekran y�kleniyor...");
            LoadEndScreen();
        }
    }

    void LoadEndScreen()
    {
        SceneManager.LoadScene("GameEnded");
    }
}
