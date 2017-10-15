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

    private Mole[] moles;
    private float spawnTimer = 0f;
    private float resetTimer = 3f;

    // Use this for initialization
    void Start() {
        moles = moleContainer.GetComponentsInChildren<Mole>();
    }

    // Update is called once per frame
    void Update() {
        gameTimer -= Time.deltaTime;
        if (gameTimer > 0f) {
            infoText.text = "Hit all the moles!\nTime: " + Mathf.Floor(gameTimer) + "\nScore: " +
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

            resetTimer -= Time.deltaTime;
            if (resetTimer <= 0f) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}