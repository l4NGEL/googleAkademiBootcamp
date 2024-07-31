using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Dictionary<string, bool> collectedObjects = new Dictionary<string, bool>();

    void Awake()
    {
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
            if (collectedObjects.ContainsKey(objectID))
            {
                collectedObjects[objectID] = true;
            }
            else
            {
                collectedObjects.Add(objectID, true);
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
}
