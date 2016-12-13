using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour
{
    private bool shooting;
    private bool canShoot = true;
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private GameObject depletionBar;
    private float barMaxWidth;
    private float barMinWidth;
    private RectTransform depletionMeter;

    //private ProjectileBehaviour projectileScript;


    // Use this for initialization
    void Start()
    {
        depletionMeter = depletionBar.gameObject.transform.GetChild(0) as RectTransform;
        barMaxWidth = depletionMeter.position.x;
        barMinWidth = depletionMeter.position.x - depletionMeter.sizeDelta.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            shooting = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            canShoot = false;
            shooting = false;
        }

    }

    void FixedUpdate()
    {
        if (shooting && canShoot)
        {
            instantiateProjectile();
            canShoot = false;
            StartCoroutine(instantiateDelay());

            if (depletionMeter.position.x <= barMaxWidth && depletionMeter.position.x >= barMinWidth)
            {
                depletionMeter.position = new Vector3(depletionMeter.position.x - 5f, depletionMeter.position.y, depletionMeter.position.z);
                //if (depletionMeter.position.x == barMinWidth)
                //{
                //    canShoot = false;
                //    depleted();
                //}
            }
        }

        if (depletionMeter.position.x < barMaxWidth && !shooting)
        {
            depletionMeter.position = new Vector3(depletionMeter.position.x + 0.5f, depletionMeter.position.y, depletionMeter.position.z);
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
    }

}
