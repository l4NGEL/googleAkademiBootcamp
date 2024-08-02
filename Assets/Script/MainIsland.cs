using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainIsland : MonoBehaviour
{
    public Button transitionButton; // Sahne geçişini yapacak buton
    public string sceneName; // Geçiş yapılacak sahnenin adı

    void Start()
    {
        // Butonun click event'ine dinleyici ekle
        transitionButton.onClick.AddListener(OnTransitionButtonClicked);
    }

    void OnTransitionButtonClicked()
    {
        // Sahneye geçiş yap
        SceneManager.LoadScene(sceneName);
    }
}
