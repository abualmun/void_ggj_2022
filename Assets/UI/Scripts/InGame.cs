using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InGame : MonoBehaviour {

    private Button pauseButton;
    private GameManager gameManager;

    void Start() {
        gameManager = FindObjectOfType<GameManager>();

        var root = GetComponent<UIDocument>().rootVisualElement;
        pauseButton = root.Q<Button>("pause");

        pauseButton.clicked += () => gameManager.SetPause(true);
    }
}
