using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawnerBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject Ball = null;
    [SerializeField]
    private GameObject SpawnerPoint = null;
    private float timer;
    private int ballSpawned = 0;
     
      // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 1.2f)
        {
            Ball = Instantiate(Ball, SpawnerPoint.transform.position,SpawnerPoint.transform.rotation);
            Ball.transform.SetParent(SpawnerPoint.transform);
            ballSpawned++;
             if (ballSpawned > 10)
            {

                Destroy(SpawnerPoint.transform.GetChild(0).gameObject);
                ballSpawned--;
            }
            timer = 0.0f;
        }
    }
}
