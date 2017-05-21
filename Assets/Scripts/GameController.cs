using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;

	private int score;
	private bool restart;
	private bool gameOver;


	void Start() {
		score = 0;
		gameOver = false;
		restart = false;

		restartText.text = "";
		gameOverText.text = "";

		UpdateScore ();
		StartCoroutine (SpawnWawes ());
	}

	void Update() {
		if (restart) {
			if (Input.GetKeyDown(KeyCode.R)) {				
				SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
			}
		}
	}

	IEnumerator SpawnWawes() {
		yield return new WaitForSeconds (startWait);
		while(true) {
			for(int i = 0; i < hazardCount; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
			if (gameOver) {
				restartText.text = "Press R for restart";
				restart = true;
				break;
			}
		}
	}

	public void addScore(int newScoreValue) {
		score += newScoreValue;
		UpdateScore ();
	}

	public void GameOver() {
		gameOverText.text = "Game over";
		gameOver = true;
	}

	void UpdateScore(){
		scoreText.text = "Score: " + score;
	}
}
