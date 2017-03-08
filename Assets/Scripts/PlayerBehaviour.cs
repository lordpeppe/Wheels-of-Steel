using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    private bool moveForward;
    private bool brake;
    private bool moveLeft;
    private bool moveRight;
    private bool grounded;
    private bool jump;
    [SerializeField]
    public float speed;
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private float jumpHeight;
    [SerializeField]
    private float hullTurnSpeed;
    [SerializeField]
    private float brakeSpeed;
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private Text lblVelocity;
    [SerializeField]
    private Text lblHealth;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private float turnSpeed;
    [SerializeField]
    public float health;

    [HideInInspector]
    public float velocity;
    

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
            animator.SetBool("IsGoingLeft", true);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            moveLeft = false;
            animator.SetBool("IsGoingLeft", false);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveRight = true;
            animator.SetBool("IsGoingRight", true);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            moveRight = false;
            animator.SetBool("IsGoingRight", false);
        }

        lblHealth.text = "Health" + "   " + health.ToString();
        lblVelocity.text = "Velocity" + "   " + GetComponent<Rigidbody>().velocity.z.ToString("0");

        checkHealth();
    }

    void FixedUpdate()
    {
        if (moveForward && !brake)
        {
            if (GetComponent<Rigidbody>().velocity.z < maxSpeed)
            {
                GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, speed));
                velocity = GetComponent<Rigidbody>().velocity.z;
            }
        }

        if (brake)
        {
            if (GetComponent<Rigidbody>().velocity.z > 0.05f)
                GetComponent<Rigidbody>().AddForce(Vector3.back * brakeSpeed);
            else
                GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, GetComponent<Rigidbody>().velocity.y,0);
        }

        if (moveLeft)
        {
            //GetComponent<Rigidbody>().AddForce(Vector3.left * hullTurnSpeed, ForceMode.Acceleration);
            GetComponent<Rigidbody>().velocity = new Vector3(-turnSpeed, GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.z);
        }

        else if (moveRight)
        {
            //GetComponent<Rigidbody>().AddForce(Vector3.right * hullTurnSpeed, ForceMode.Acceleration);
            GetComponent<Rigidbody>().velocity = new Vector3(turnSpeed, GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.z);
        }
        else
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.z);
        }

        grounded = Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), 0.1f, groundLayer);

        if (jump && grounded)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpHeight, 0), ForceMode.VelocityChange);
            jump = false;
        }
    }


    void takeDamage(float damage)
    {
        health = health - damage;
        checkHealth();
    }
    void checkHealth()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
