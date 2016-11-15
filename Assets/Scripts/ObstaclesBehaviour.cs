using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstaclesBehaviour : MonoBehaviour {

    [SerializeField]
    private List<GameObject> Obstacles;

    private Vector3 position;
    private float xPosition;
    private float yPosition;
    private float zPosition;
    private GameObject prefab;


	// Use this for initialization
	void Start () {

        xPosition = transform.position.x;
        yPosition = transform.position.y;
        zPosition = transform.position.z;
        position = new Vector3(Random.Range(xPosition - transform.localScale.x / 2, xPosition + transform.localScale.x / 2), 
            3, 
            Random.Range(zPosition - transform.localScale.z / 2, zPosition + transform.localScale.z / 2));
        prefab = Obstacles[Random.Range(0,Obstacles.Count)];


        Instantiate(prefab, position, Quaternion.identity);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
