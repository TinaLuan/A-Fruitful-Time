using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {
    
    public void startGame() {
        SceneManager.LoadScene("AbbyScene");
    }

    public void openInstructions() {
        SceneManager.LoadScene("Instructions");
    }

    public void openOptions() {
        SceneManager.LoadScene("Options");
    }
}
