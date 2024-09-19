using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.Menu;

public class MainMenu : MonoBehaviour {
    public void OnStartGame() {
        SceneManager.LoadScene(1);
    }

    public void OnQuitGame() {
        Application.Quit();
    }
}
