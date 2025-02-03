using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public void LoadMainMenu()
    {
        Time.timeScale = 1; // <- Ekledik
        AudioManager.Instance.PlayMusic("MainMenu");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
        ButtonSfx();
    }

    public void LoadGame()
    {
        Time.timeScale = 1; // <- Ekledik
        AudioManager.Instance.PlayMusic("Gameplay");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game Scene");
        ButtonSfx();
    }

    public void ReloadScene()
    {
        Time.timeScale = 1; // <- Ekledik
        AudioManager.Instance.PlayMusic("Gameplay");
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        ButtonSfx();
    }

    public void InfoButton()
    {
        Application.OpenURL("https://www.linkedin.com/in/teyavuz/");
        ButtonSfx();
    }

    public void QuitGame()
    {
        Application.Quit();
        ButtonSfx();
    }

    private void ButtonSfx()
    {
        AudioManager.Instance.PlaySFX("Button");
    }
}
