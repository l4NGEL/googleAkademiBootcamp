using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public Canvas pauseMenuCanvas;
    public Button resumeButton;
    public Button mainMenuButton;
    private bool ignoreNextEsc = true; // First ESC press will be ignored

    void Start()
    {
        resumeButton.onClick.AddListener(Resume);
        mainMenuButton.onClick.AddListener(LoadMainMenu);
        // Ensure the pause menu is initially inactive
        pauseMenuCanvas.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (ignoreNextEsc)
            {
                ignoreNextEsc = false;
                return; // Ignore this ESC press
            }

            TogglePauseMenu();
        }
    }

    public void TogglePauseMenu()
    {
        if (pauseMenuCanvas.gameObject.activeSelf)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {
        pauseMenuCanvas.gameObject.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Pause()
    {
        pauseMenuCanvas.gameObject.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // Ensure the game is not paused when going to main menu
        SceneManager.LoadScene(0); // Replace "MainMenu" with the actual main menu scene name
    }
}
