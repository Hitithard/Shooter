using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    public GameObject player;
    public float damage = 20f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<NavMeshAgent>().destination = player.transform.position;
        //Add enemy animator first to continue
        //if(GetComponent<NavMeshAgent>().velocity.magnitude > 1){}

    }
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject == player)
        {
            Debug.Log("Loving Player !");
            player.GetComponent<PlayerManager>().Hit(damage);
        }
    }
}
