using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour {

    private Label title;
    private Button playBtn;
    private Button quitBtn;

    void Start() {
        var root = GetComponent<UIDocument>().rootVisualElement;
        title = root.Q<Label>("title");
        playBtn = root.Q<Button>("play");
        quitBtn = root.Q<Button>("quit");

        playBtn.clicked += PlayBtnPressed;
        quitBtn.clicked += QuitBtnPressed;
    }

    void PlayBtnPressed() {
        // TODO: LoadNextScene, using GamaManager
        Debug.Log("Play Button Clicked");
        SceneManager.LoadScene("Level1");
    }

    void QuitBtnPressed() {
        Debug.Log("Quit Button Clicked");
        Application.Quit();
    }
}
