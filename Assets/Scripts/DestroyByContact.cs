using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {
	public GameObject explotion;
	public GameObject playerExplotion;

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Boundary") return;

		Instantiate (explotion, transform.position, transform.rotation);
		if (other.tag == "Player") {
			Instantiate (playerExplotion, other.transform.position, other.transform.rotation);
		}
		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}
