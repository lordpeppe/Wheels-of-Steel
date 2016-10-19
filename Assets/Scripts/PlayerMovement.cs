using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private bool moveForward;
    private bool brake;
    private bool moveLeft;
    private bool moveRight;
    private bool grounded;
    private bool jump;
    [SerializeField]
    private float speed;
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private float jumpHeight;
    [SerializeField]
    private float hullTurnSpeed;
    [SerializeField]
    private float brakeSpeed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveForward = true;
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            moveForward = false;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            brake = true;
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            brake = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            jump = false;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveLeft = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            moveLeft = false;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveRight = true;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            moveRight = false;
        }
        
    }

    void FixedUpdate()
    {
        if (moveForward && !brake)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, speed));
        }

        if (brake)
        {
            if (GetComponent<Rigidbody>().velocity.z > 0.05f)
                GetComponent<Rigidbody>().AddForce(Vector3.back * brakeSpeed);
            else
                GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        if (moveLeft)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.left * hullTurnSpeed, ForceMode.Force);
        }

        if (moveRight)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.right * hullTurnSpeed, ForceMode.Force);
        }
        
        grounded = Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), 0.1f, groundLayer);

        if (jump && grounded)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpHeight, 0), ForceMode.VelocityChange);
            jump = false;
        }
    }

}
