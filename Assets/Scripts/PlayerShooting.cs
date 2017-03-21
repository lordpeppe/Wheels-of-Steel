using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour
{
    private bool shooting;
    private bool canShoot = true;
    private bool cooldown;
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private Image depletionMeter;



    //private ProjectileBehaviour projectileScript;


    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (canShoot)
            shooting = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            shooting = false;
        }

    }

    void FixedUpdate()
    {
        //if depletionMeter is empty run the cooldown logic
        if (depletionMeter.fillAmount <= 0 && canShoot)
        {
            depletionMeter.fillAmount = 0;
            canShoot = false;
            cooldown = true;
            StartCoroutine(depleted());
        }

        //if able to shoot run the shooting logic and slowly deplete depletionMeter
        if (shooting && canShoot)
        {
            instantiateProjectile();
            canShoot = false;
            StartCoroutine(instantiateDelay());

            if (depletionMeter.fillAmount > 0)
            {
                depletionMeter.fillAmount -= 0.1f;
             
            }
        }

        //Refill depletionMeter if correct scenario
        if (depletionMeter.fillAmount < 1 && !shooting && !cooldown)
        {
            depletionMeter.fillAmount += 0.02f;
        }

     
    }

    void instantiateProjectile()
    {
        var temp = Instantiate(projectile, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1.5f)
              , projectile.transform.rotation) as GameObject;
        var projectileScript = FindObjectOfType<ProjectileBehaviour>(); //get the script describing the behaviour of the projectile
        temp.GetComponent<Rigidbody>().AddForce(Vector3.forward * (projectileScript.projectileSpeed + temp.GetComponent<Rigidbody>().velocity.z), ForceMode.VelocityChange);
    }

    IEnumerator instantiateDelay()
    {
        yield return new WaitForSeconds(0.3f);
        canShoot = true;
    }

    IEnumerator depleted()
    {
        yield return new WaitForSeconds(5f);
        canShoot = true;
        cooldown = false;
        depletionMeter.fillAmount += 0.0001f;
    }

}
