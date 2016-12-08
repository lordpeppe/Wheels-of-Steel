using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstaclesBehaviour : MonoBehaviour
{

    [SerializeField]
    private float health;
    [SerializeField]
    private float forceResistance;
    [SerializeField]
    private float damage;
    [SerializeField]
    private bool destroyable;


    // Use this for initialization
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        if (destroyable == true)
        {
            if (other.gameObject.layer == 9) // player layer
            {

                var playerScript = FindObjectOfType<PlayerMovement>();
                if (playerScript != null)
                {
                    var playerVelocity = playerScript.gameObject.GetComponent<Rigidbody>().velocity.z;

                    if (Mathf.Abs(playerVelocity) > forceResistance)
                    {
                        takeDamage(100); //gives the obstacle an amount of damage equals to it's health
                    }

                }

            }
            if (other.gameObject.tag.Equals("bullet")) //bullet
            {
                var projectileScript = FindObjectOfType<ProjectileBehaviour>(); // get projectile script
                if (projectileScript != null)
                {
                    var incDamage = projectileScript.projectileDamage; //damage of projectile

                    takeDamage(incDamage);

                    Destroy(other.gameObject); //destroy projectile
                }
               
            }
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
