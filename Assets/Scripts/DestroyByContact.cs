using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {
	public GameObject explotion;
	public GameObject playerExplotion;
	public int scoreValue;
	private GameController gameController;

	void Start() {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		}
		if (gameController == null)
			Debug.Log ("Cannot find GameController");
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Boundary") return;

		Instantiate (explotion, transform.position, transform.rotation);
		if (other.tag == "Player") {
			Instantiate (playerExplotion, other.transform.position, other.transform.rotation);
			gameController.GameOver ();
		}
		gameController.addScore (scoreValue);
		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}
