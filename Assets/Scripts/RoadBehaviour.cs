using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoadBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject RoadPiece;
    [SerializeField]
    private List<GameObject> Obstacles;

    [SerializeField]
    private int NumberOfObstacles;

    private Vector3 position;
    private float xPosition;
    private float yPosition;
    private float zPosition;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9) //layer 9 is the player layer
        {
            var temp = Instantiate(RoadPiece, new Vector3(Random.Range(-500f, 500f), Random.Range(-100f, 100f), Random.Range(transform.parent.localScale.z + transform.position.z, transform.parent.localScale.z + transform.position.z + 500f)), Quaternion.identity) as GameObject;
            temp.GetComponent<MoveAfterInstiate>().startMove(new Vector3(transform.position.x, transform.position.y, transform.position.z + transform.parent.localScale.z));

            //spawn obstacles
            for (int i = 0; i < NumberOfObstacles; i++)
            {
                xPosition = temp.transform.position.x;
                yPosition = temp.transform.position.y;
                zPosition = temp.transform.position.z;
                position = new Vector3(Random.Range(xPosition - temp.transform.localScale.x / 2, xPosition + temp.transform.localScale.x / 2),
                    yPosition + 1.7f,
                    Random.Range(zPosition - temp.transform.localScale.z / 2, zPosition + temp.transform.localScale.z / 2));
                var obj = Obstacles[Random.Range(0, Obstacles.Count)] as GameObject;

                var temp1 = Instantiate(obj, position, Quaternion.identity) as GameObject;
                //temp1.GetComponent<MoveAfterInstiate>().startMove(position);
                temp1.transform.position = position;
                if (temp != null)
                {
                    temp1.transform.SetParent(temp.transform);
                }
            }


        }
    }


}
