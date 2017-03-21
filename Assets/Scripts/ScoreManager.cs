using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
	[HideInInspector]
	public float score; 

	private float startPos;
	private float currentPos;

	[SerializeField]
	private Text lblScore; 
	
	private GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("PlayerCar");
		startPos = player.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		currentPos = player.transform.position.z; //get current position of player

		var temp = currentPos - startPos; //calculate distance for score

		score = temp / 10;
		lblScore.text = "Score " + score.ToString("0");
	}
}
