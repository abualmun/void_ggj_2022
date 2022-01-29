using System;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private PlayerCombat player;

    public bool isGamePaused = false;
    public bool didLose = false;

    private void OnEnable() {
    }

    private void Start() {
        player = PlayerCombat.player;
        player.onPlayerDead += OnPlayerDead;
    }

    private void Update() {

    }

    private void OnPlayerDead() {
        SetPause(true);
        // show Lose Menu
        didLose = true;
    }

    public void SetPause(bool isPaused) {
        if (!isPaused) {
            isGamePaused = false;
            Time.timeScale = 1f;
        } else {
            isGamePaused = true;
            Time.timeScale = 0f;
        }

    }

    private void OnDisable() {
        player.onPlayerDead -= OnPlayerDead;
    }
}
