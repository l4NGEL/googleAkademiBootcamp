using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InfoBox2 : MonoBehaviour
{
    public TextMeshProUGUI infoText; // TextMeshPro kullanıyorsanız
    // public Text infoText; // Text kullanıyorsanız
    public string message;
    public float typingSpeed = 0.05f;
    public Button closeButton; // Paneli kapatacak buton
    public GameObject newPanel; // Yeni açılacak panel

    private bool isDisplaying = false;

    void Start()
    {
        // Mesajı yazdırma coroutine'ini başlat
        StartCoroutine(TypeMessage());

        // Butonun click event'ine dinleyici ekle
        closeButton.onClick.AddListener(HideInfoBox);
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
    }

    void HideInfoBox()
    {
        isDisplaying = false;
        gameObject.SetActive(false);
        newPanel.SetActive(true);
    }
}
