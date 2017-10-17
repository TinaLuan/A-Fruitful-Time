using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

    public Slider difficultySlider;

    public void OnBackButtonPressed() {
		TimerScript.setTimerCount(difficultySlider.value);
        SceneManager.LoadScene("MainMenu");
    }
}