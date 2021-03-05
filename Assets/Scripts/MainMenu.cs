using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void Controls() {
        SceneManager.LoadScene("Controls");
    }

    public void Credits() {
        SceneManager.LoadScene("Credits");
    }

    public void BackMenu() {
        SceneManager.LoadScene("Main_Menu");
    }

    public void QuitGame() {
        Application.Quit();
    }

}
