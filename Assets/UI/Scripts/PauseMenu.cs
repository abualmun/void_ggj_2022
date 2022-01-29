using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PauseMenu : MonoBehaviour {

    private bool isPaused;
    private VisualElement myRoot;
    private Button resumeBtn;
    private Button restartBtn;
    private Button mainMenuBtn;
    private GameManager gameManager;

    void Start() {
        gameManager = FindObjectOfType<GameManager>();

        var root = GetComponent<UIDocument>().rootVisualElement;
        myRoot = root.Q<VisualElement>("root");
        resumeBtn = root.Q<Button>("resume");
        restartBtn = root.Q<Button>("restart");
        mainMenuBtn = root.Q<Button>("main-menu");

        resumeBtn.clicked += ResumeBtnClicked;
        restartBtn.clicked += RestartBtnClicked;
        mainMenuBtn.clicked += MainMenuBtnClicked;
    }

    private void Update() {
        if (gameManager.isGamePaused && !isPaused && !gameManager.didLose) {
            ShowPauseMenu();
            isPaused = true;
        } else if (!gameManager.isGamePaused && isPaused) {
            HidePauseMenu();
            isPaused = false;
        }
    }

    void ShowPauseMenu() {
        myRoot.style.visibility = Visibility.Visible;
    }

    void HidePauseMenu() {
        myRoot.style.visibility = Visibility.Hidden;
    }

    void ResumeBtnClicked() {
        // TODO: pause the game, using GameManager
        Debug.Log("Resume Button Clicked");
        gameManager.SetPause(false);
    }

    void RestartBtnClicked() {
        // TODO: reload the scene, using GameManager
        Debug.Log("Restart Button Clicked");
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
