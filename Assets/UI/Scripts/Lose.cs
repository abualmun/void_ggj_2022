using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Lose : MonoBehaviour {

    private VisualElement myRoot;
    private Label loseText;
    private Button retryBtn;
    private Button mainMenuBtn;
    private GameManager gameManager;
    private bool didLose = false;

    void Start() {
        gameManager = FindObjectOfType<GameManager>();
        var root = GetComponent<UIDocument>().rootVisualElement;
        myRoot = root.Q<VisualElement>("root");
        loseText = root.Q<Label>("lose-text");
        retryBtn = root.Q<Button>("retry");
        mainMenuBtn = root.Q<Button>("main-menu");

        retryBtn.clicked += RetryBtnClicked;
        mainMenuBtn.clicked += MainMenuBtnClicked;
    }

    private void Update() {
        if (gameManager.didLose && !didLose) {
            didLose = true;
            myRoot.style.visibility = Visibility.Visible;
        }
    }

    void RetryBtnClicked() {
        // TODO: reload the scene, using GameManager
        Debug.Log("Retry Button Clicked");
        gameManager.SetPause(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void MainMenuBtnClicked() {
        // TODO: load mainMenu Scene, using GameManager
        Debug.Log("Main Menu Button Clicked");
        gameManager.SetPause(false);
        SceneManager.LoadScene("MainMenu");
    }
}
