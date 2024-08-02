using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public GameObject buttonPanel; // Main menu'deki button panel
    public GameObject howToPlayPanel; // How to play paneli
    public Button newGameButton; // New Game butonu

    void Start()
    {
        // Başlangıçta HowToPlay panelini kapat
        howToPlayPanel.SetActive(false);

        // NewGameButton'a OnClick event'ini ekle
        newGameButton.onClick.AddListener(OnNewGameButtonClicked);
    }

    public void OnNewGameButtonClicked()
    {
        // Button paneli kapat
        buttonPanel.SetActive(false);
        // How to play panelini aç
        howToPlayPanel.SetActive(true);
    }
}
