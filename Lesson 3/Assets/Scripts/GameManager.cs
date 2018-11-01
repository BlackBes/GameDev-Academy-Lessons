using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Image playerOne;
    public Image playerTwo;
    public Sprite[] playerSprites;
    public Text manageText;

    private int gameStage = 0;
    private float timer = 0;
    private float bangTimer = 0;
    private bool isPlayerOneShot = false;
    private bool isPlayerTwoShot = false;

    public void StartGame() {
        manageText.text = "ready";
        playerOne.sprite = playerSprites[1];
        playerTwo.sprite = playerSprites[1];
        gameStage = 1;
    }

    public void Update() {
        if (gameStage == 1) {
            if (timer >= 1.0f) {
                manageText.text = "steady";
                bangTimer = Random.Range(1.0f, 3.0f);
                gameStage = 2;
                timer = 0;
            } else {
                timer += Time.deltaTime;
            }
        } else if (gameStage == 2) {
            if (timer >= bangTimer) {
                manageText.text = "!bang!";
                bangTimer = 0;
                gameStage = 3;
                timer = 0;
            } else {
                timer += Time.deltaTime;
            }
        }
    }

    public void Shot(int player) {
        if (gameStage == 0) return;
        Image activePlayer = (player == 1) ? playerOne : playerTwo;
        if (gameStage == 3) {
            Image enemyPlayer = (player == 2) ? playerOne : playerTwo;
            activePlayer.sprite = playerSprites[2];
            enemyPlayer.sprite = playerSprites[3];
            manageText.text = "player " + player + " win!";
            gameStage = 0;
            isPlayerOneShot = false;
            isPlayerTwoShot = false;
        } else {
            if (player == 1) isPlayerOneShot = true;
            if (player == 2) isPlayerTwoShot = true;
            if (isPlayerOneShot && isPlayerTwoShot) {
                manageText.text = "Too fast, guys!";
                bangTimer = 0;
                gameStage = 0;
                timer = 0;
                isPlayerOneShot = false;
                isPlayerTwoShot = false;
            }
            activePlayer.sprite = playerSprites[4];
        }
    }
}
