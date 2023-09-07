using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public float health = 100;

    public void Hit(float damage)
    {
        health -= damage;
        if(health <=0)
        {
            SceneManager.LoadScene(0);
            Debug.Log("Game Over");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}