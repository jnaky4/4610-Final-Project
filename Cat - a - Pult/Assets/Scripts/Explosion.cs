using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Explosion : MonoBehaviour
{
    public float radius;
    public float explosionSpeed;
    public float power;
    //public GameObject explosionEffect;
    // Start is called before the first frame update

    public void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            explode();
        }




    }

    // Update is called once per frame
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
