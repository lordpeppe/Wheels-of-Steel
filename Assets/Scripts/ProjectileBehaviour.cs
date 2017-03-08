using UnityEngine;
using System.Collections;

public class ProjectileBehaviour : MonoBehaviour {
    [SerializeField]
    public float despawnTimer;

    public float projectileSpeed;
    
    public float projectileDamage;
    // Use this for initialization
    void Start () {
        StartCoroutine(despawnObject());
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    IEnumerator despawnObject()
    {
        yield return new WaitForSeconds(despawnTimer);
        Destroy(this.gameObject);
    }
}
