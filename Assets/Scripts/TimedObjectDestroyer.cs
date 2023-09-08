using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class TimedObjectDestroyer : MonoBehaviour
{
    public float lifeTimeMin = 8.0f;
    public float lifeTimeMax = 10.0f;
    private float randomNumber;
    void Start()
    {
        randomNumber = Random.Range(lifeTimeMin, lifeTimeMax);
        Destroy(gameObject, randomNumber);
    }
}
