using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weapon : MonoBehaviour
{
    public GameObject playerCam;
    public float range = 100f;
    public float damage = 25f;
    public float magicdamage = 50f;
    public float armordamage = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //Debug.Log("Shoot");
            Shoot();

        }

    }
    void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(playerCam.transform.position, transform.forward, out hit, range))
        {
            //Debug.Log("hit"); 
            Health health = hit.transform.GetComponent<Health>();
            if (health != null)
            {
                health.Hit(damage, armordamage, magicdamage);
            }
        }
    }
}
