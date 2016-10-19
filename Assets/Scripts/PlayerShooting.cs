using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour
{
    private bool shooting;
    private bool canShoot = true;
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private float projectileSpeed;
    // Use this for initialization
    void Start()
    {

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
            var temp = Instantiate(projectile, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1.5f)
                , projectile.transform.rotation) as GameObject;
            temp.GetComponent<Rigidbody>().AddForce(Vector3.forward * (projectileSpeed + temp.GetComponent<Rigidbody>().velocity.z), ForceMode.VelocityChange);
            canShoot = false;
            StartCoroutine(instantiateDelay());
        }
    }

    IEnumerator instantiateDelay()
    {
        yield return new WaitForSeconds(0.3f);
        canShoot = true;
    }
}
