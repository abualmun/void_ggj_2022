using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PauseMenu : MonoBehaviour {

    private Button resumeBtn;
    private Button restartBtn;
    private Button mainMenuBtn;

    void Start() {
        var root = GetComponent<UIDocument>().rootVisualElement;
        resumeBtn = root.Q<Button>("resume");
        restartBtn = root.Q<Button>("restart");
        mainMenuBtn = root.Q<Button>("main-menu");

        resumeBtn.clicked += ResumeBtnClicked;
        restartBtn.clicked += RestartBtnClicked;
        mainMenuBtn.clicked += MainMenuBtnClicked;
    }

    void ResumeBtnClicked() {
        // TODO: pause the game, using GameManager
        Debug.Log("Resume Button Clicked");
    }

    void RestartBtnClicked() {
        // TODO: reload the scene, using GameManager
        Debug.Log("Restart Button Clicked");
    }

    void MainMenuBtnClicked() {
        // TODO: load mainMenu Scene, using GameManager
        Debug.Log("Main Menu Button Clicked");
    }
}
