using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float explosionForce = 5.0f;
    public float explosionRadius = 10.0f;
   // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return null;

        // An array of nearby colliders
        Collider[] cols = Physics.OverlapSphere(transform.position, explosionRadius);

        List<Rigidbody> rigidbodies = new List<Rigidbody>();

        foreach (Collider col in cols)
        {
            if (col.attachedRigidbody != null && !rigidbodies.Contains(col.attachedRigidbody))
                rigidbodies.Add(col.attachedRigidbody);

        }

        foreach (Rigidbody rb in rigidbodies)
        {
            rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, 1, ForceMode.Impulse);
        }
    }
}
