using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CreditsScroll : MonoBehaviour
{
    public TextMeshProUGUI creditsText; // TextMeshPro kullanıyorsanız
    // public Text creditsText; // Text kullanıyorsanız
    public float scrollSpeed = 50f; // Kayma hızı
    public float endPositionY = 1000f; // Kaymanın duracağı Y pozisyonu
    public string mainMenuSceneName = "MainMenu"; // Ana menü sahnesinin adı

    private RectTransform creditsRectTransform;
    private bool reachedEnd = false;

    void Start()
    {
        if (creditsText != null)
        {
            creditsRectTransform = creditsText.GetComponent<RectTransform>();
        }
        else
        {
            Debug.LogError("Credits text component not assigned.");
        }
    }

    void Update()
    {
        if (creditsRectTransform != null && !reachedEnd)
        {
            creditsRectTransform.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;

            if (creditsRectTransform.anchoredPosition.y >= endPositionY)
            {
                reachedEnd = true;
                StartCoroutine(WaitAndLoadMainMenu());
            }
        }
    }

    IEnumerator WaitAndLoadMainMenu()
    {
        yield return new WaitForSeconds(5f); // 5 saniye bekle
        SceneManager.LoadScene(mainMenuSceneName); // Ana menü sahnesine geçiş yap
    }
}
