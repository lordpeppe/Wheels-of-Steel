using UnityEngine;
using System.Collections;

public class MoveAfterInstiate : MonoBehaviour {
    private bool isMove;
    [SerializeField]
    private Vector3 endPosition;
    [SerializeField]
    private float moveSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	  if (isMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, moveSpeed * Time.deltaTime);
        }   
	}

    public void startMove(Vector3 endPosition)
    {
        this.endPosition = endPosition;
        this.isMove = true;

    }
}
