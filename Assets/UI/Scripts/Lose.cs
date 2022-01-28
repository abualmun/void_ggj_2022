using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Lose : MonoBehaviour {

    private Label loseText;
    private Button retryBtn;
    private Button mainMenuBtn;

    void Start() {
        var root = GetComponent<UIDocument>().rootVisualElement;
        loseText = root.Q<Label>("lose-text");
        retryBtn = root.Q<Button>("retry");
        mainMenuBtn = root.Q<Button>("main-menu");

        retryBtn.clicked += RetryBtnClicked;
        mainMenuBtn.clicked += MainMenuBtnClicked;
    }

    void RetryBtnClicked() {
        // TODO: reload the scene, using GameManager
        Debug.Log("Retry Button Clicked");
    }

    void MainMenuBtnClicked() {
        // TODO: load mainMenu Scene, using GameManager
        Debug.Log("Main Menu Button Clicked");
    }
}
