using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatapultExplosion : MonoBehaviour
{
    public float radius;
    public float explosionSpeed;
    public float power;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Catapult" || collider.gameObject.tag == "Player")
        {
            explode();
            
        }
    }
    public void explode()
    {

        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(power, explosionPos, radius, 3.0f);

            }
        }
        Destroy(this.gameObject);
    }
}
