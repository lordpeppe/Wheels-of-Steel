using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

private PlayerBehaviour playerScript;
private float playerHealth;

	// Use this for initialization
	void Start () {
	 	playerScript = FindObjectOfType<PlayerBehaviour>();
		playerHealth = playerScript.health;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerHealth <= 0) {
			
		}
	}
}
