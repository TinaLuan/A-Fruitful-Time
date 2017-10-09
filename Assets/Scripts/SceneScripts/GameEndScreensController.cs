using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEndScreensController : MonoBehaviour {

    public void OnBackButtonPressed() {
        SceneManager.LoadScene("MainMenu");
    }
}