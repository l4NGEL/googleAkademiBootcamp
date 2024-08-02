using UnityEngine;
using TMPro;

public class CountObjects : MonoBehaviour
{
    GameObject objUI;
    public GameObject infoMenuCanvas; // InfoMenuCanvas referansı

    void Start()
    {
        objUI = GameObject.Find("ObjectNum");

        if (objUI == null)
        {
            Debug.LogError("ObjectNum GameObject not found. Make sure it is named correctly and is active in the scene.");
        }

        if (infoMenuCanvas == null)
        {
            Debug.LogError("InfoMenuCanvas GameObject not assigned. Please assign it in the inspector.");
        }
    }

    void Update()
    {
        if (objUI != null)
        {
            TextMeshProUGUI objUIText = objUI.GetComponent<TextMeshProUGUI>();

            if (objUIText != null)
            {
                int remainingObjects = 0;
                foreach (var obj in FindObjectsOfType<CollectableObject>())
                {
                    if (!GameManager.Instance.IsObjectCollected(obj.objectID))
                    {
                        remainingObjects++;
                    }
                }

                objUIText.text = remainingObjects.ToString();

                if (remainingObjects == 0)
                {
                    objUIText.text = "Bu Adadaki Oyuncağı Buldun";

                    if (infoMenuCanvas != null)
                    {
                        infoMenuCanvas.SetActive(false); // InfoMenuCanvas'ı inactive yap
                    }
                }
            }
            else
            {
                Debug.LogError("TextMeshProUGUI component not found on ObjectNum GameObject.");
            }
        }
    }
}
