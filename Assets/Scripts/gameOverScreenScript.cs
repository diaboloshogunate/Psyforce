using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOverScreenScript : MonoBehaviour {

    private Scene currentScene;

	void Start () {
        currentScene = SceneManager.GetActiveScene();
	}

    public void RestartScene() {
        SceneManager.LoadScene(currentScene.name);
    }

    public void MainMenu() {
        SceneManager.LoadScene(0);
    }
}
