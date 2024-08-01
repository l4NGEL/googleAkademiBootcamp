using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Dictionary<string, bool> collectedObjects = new Dictionary<string, bool>();
    public Dictionary<int, bool> sceneCompleted = new Dictionary<int, bool>();

    void Awake()
    {
        // Eðer Instance zaten mevcutsa, bu örneði yok et
        if (Instance == null)
        {
            Instance = this;
            // Bu GameObject sahne deðiþikliklerinde yok edilmez
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Mevcut bir Instance varsa, bu yeni örneði yok et
            Destroy(gameObject);
        }
    }

    public void CollectObject(string objectID, int sceneIndex)
    {
        if (!string.IsNullOrEmpty(objectID))
        {
            if (collectedObjects.ContainsKey(objectID))
            {
                collectedObjects[objectID] = true;
            }
            else
            {
                collectedObjects.Add(objectID, true);
            }

            // Kontrol et: Tüm nesneler toplandý mý?
            if (AreAllObjectsCollectedInScene(sceneIndex))
            {
                sceneCompleted[sceneIndex] = true;
            }
        }
        else
        {
            Debug.LogError("ObjectID is null or empty.");
        }
    }

    public bool IsObjectCollected(string objectID)
    {
        if (string.IsNullOrEmpty(objectID))
        {
            Debug.LogError("ObjectID is null or empty.");
            return false;
        }

        return collectedObjects.ContainsKey(objectID) && collectedObjects[objectID];
    }

    public bool IsSceneCompleted(int sceneIndex)
    {
        return sceneCompleted.ContainsKey(sceneIndex) && sceneCompleted[sceneIndex];
    }

    public bool AreAllObjectsCollectedInScene(int sceneIndex)
    {
        foreach (var obj in FindObjectsOfType<CollectableObject>())
        {
            if (obj.sceneIndex == sceneIndex && !IsObjectCollected(obj.objectID))
            {
                return false;
            }
        }
        return true;
    }
}
