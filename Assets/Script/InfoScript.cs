using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Eğer TextMeshPro kullanıyorsanız

public class InfoBox : MonoBehaviour
{
    public TextMeshProUGUI infoText; // TextMeshPro kullanıyorsanız
    // public Text infoText; // Text kullanıyorsanız
    public string message;
    public float typingSpeed = 0.05f;
    public float displayTime = 5f;

    private bool isDisplaying = false;

    void Start()
    {
        StartCoroutine(TypeMessage());
    }

    void Update()
    {
        if (isDisplaying && (Input.GetKeyDown(KeyCode.Escape)))
        {
            HideInfoBox();
        }
    }

    IEnumerator TypeMessage()
    {
        isDisplaying = true;
        infoText.text = "";
        foreach (char letter in message.ToCharArray())
        {
            infoText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        yield return new WaitForSeconds(displayTime);
        HideInfoBox();
    }

    void HideInfoBox()
    {
        isDisplaying = false;
        gameObject.SetActive(false);
    }
}
