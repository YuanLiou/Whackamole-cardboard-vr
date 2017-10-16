using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public TextMesh infoText;
    public Player player;
    public GameObject moleContainer;
    public float spawnDuration = 1.5f;
    public float spawnDecrement = 0.1f;
    public float minimumSpawnDuration = 0.5f;
    public float gameTimer = 15f;
    private bool gameStart = false;
    public bool IsGameStart {
        get { return gameStart; }
    }

    private Mole[] moles;
    private float spawnTimer = 0f;
    private float defaultGameTime = 0f;
    private float hintTimer = 3f;
    private float gameplayCountdownTimer = 3f;

    // Use this for initialization
    void Start() {
        moles = moleContainer.GetComponentsInChildren<Mole>();
        defaultGameTime = gameTimer;
        infoText.text = "shot here to play";
    }

    // Update is called once per frame
    void Update() {
        if (!gameStart) {
            return;
        }

        gameplayCountdownTimer -= Time.deltaTime;
        if (gameplayCountdownTimer <= 0f) {
            gameTimer -= Time.deltaTime;
            if (gameTimer > 0f) {
                infoText.text = "Hit all the moles!\nTime: " + Mathf.Floor(gameTimer) +
                                "\nScore: " +
                                player.score;

                spawnTimer -= Time.deltaTime;
                if (spawnTimer <= 0f) {
                    moles[Random.Range(0, moles.Length)].Rise();

                    spawnDuration -= spawnDecrement;
                    if (spawnDuration < minimumSpawnDuration) {
                        spawnDuration = minimumSpawnDuration;
                    }
                    spawnTimer = spawnDuration;
                }
            } else {
                infoText.text = "Game over\nYour score: " + player.score;
                hintTimer -= Time.deltaTime;
                if (hintTimer <= 0f) {
                    gameStart = false;
                    infoText.text += "\n\nshot here\nto restart game";
                }
            }
        } else {
            infoText.text = "Ready?  " + (Mathf.Floor(gameplayCountdownTimer) + 1);
        }
    }

    public void StartGame() {
        gameTimer = defaultGameTime;
        player.score = 0;
        gameplayCountdownTimer = 3f;
        gameStart = true;
        hintTimer = 3f;
    }
}