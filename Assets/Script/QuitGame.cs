using UnityEngine;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour
{
    public Button quitButton;

    void Start()
    {
        // Ensure the button is assigned
        if (quitButton != null)
        {
            quitButton.onClick.AddListener(Quit);
        }
        else
        {
            Debug.LogError("Quit button is not assigned!");
        }
    }

    void Quit()
    {
        #if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying needs to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
