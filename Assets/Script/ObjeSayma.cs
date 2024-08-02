using UnityEngine;
using TMPro;

public class CountObjects : MonoBehaviour
{
    GameObject objUI;

    void Start()
    {
        objUI = GameObject.Find("ObjectNum");

        if (objUI == null)
        {
            Debug.LogError("ObjectNum GameObject not found. Make sure it is named correctly and is active in the scene.");
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
                    objUIText.text = "Bu adadaki oyuncaðý topladýn.";
                }
            }
            else
            {
                Debug.LogError("TextMeshProUGUI component not found on ObjectNum GameObject.");
            }
        }
    }
}
