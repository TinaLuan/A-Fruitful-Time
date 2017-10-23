using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWonController : MonoBehaviour {

	public void OnBackButtonPressed() {
		SceneManager.LoadScene("MainMenu");
	}
}