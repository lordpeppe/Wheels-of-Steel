using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

private PlayerBehaviour playerScript;
private float playerHealth;
[SerializeField]
private float restartDelay = 5.0f; //timer used for time before restartDelay

[SerializeField]
private float restartTimer; //timer to count up to restarting the level 
	// Use this for initialization
	void Start () {
	 	playerScript = FindObjectOfType<PlayerBehaviour>();
	}
	
	// Update is called once per frame
	void Update () {

		//check playerhealth
		playerHealth = playerScript.health;

		if (playerHealth <= 0) {
			
			//increment timer to count up to restart
			restartTimer += Time.deltaTime;

			if (restartTimer > restartDelay) {
				//loads the current scene
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
		}
	}
}
