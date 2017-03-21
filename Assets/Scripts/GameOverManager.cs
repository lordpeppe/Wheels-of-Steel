using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour {

private PlayerBehaviour playerScript;
private float playerHealth;
[SerializeField]
private float restartDelay = 5.0f; //timer used for time before restartDelay

[SerializeField]
private float restartTimer; //timer to count up to restarting the level 

[SerializeField]
private Text lblGameOver; 

	// Use this for initialization
	void Start () {
	 	playerScript = FindObjectOfType<PlayerBehaviour>();
		lblGameOver.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

		//check playerhealth
		playerHealth = playerScript.health;

		if (playerHealth <= 0) {
			
			
			restartTimer += Time.deltaTime; //increment timer to count up to restart

			lblGameOver.enabled = true;

			if (restartTimer > restartDelay) {
			
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);	//loads the current scene
			}
		}
	}
}
