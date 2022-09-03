using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObstacleSpawner : MonoBehaviour
{
    private bool obstacleExists = false; // does the obstacle currently exist?
    private float obsSpawnDistance; // how far in front of zombi should i spawn in the new obstacle?
    private Rigidbody zombiRB;
    public GameObject obstacle; // the obstacle to spawn in
    private float lastVelocity = -1;
    long lastAccelerateTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        lastVelocity = -1;
        lastAccelerateTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (zombiRB != null)
        {
            if (zombiRB.velocity.magnitude - lastVelocity > 0.05) // 0.05 is arbitrary, but it seems to look good
            {
                lastVelocity = zombiRB.velocity.magnitude;
                lastAccelerateTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            }

            if (DateTimeOffset.Now.ToUnixTimeMilliseconds() - lastAccelerateTime >= 1000 && !obstacleExists)
            {
                Vector3 obstaclePos = zombiRB.position + zombiRB.velocity.normalized * obsSpawnDistance;
                Debug.Log("spawning in obstacle... at position: " + obstaclePos);
                CreateObstacle(obsSpawnDistance, obstaclePos);
                var cntrlrInstance = zombiRB.GetComponent<MotorController>().controller;
                cntrlrInstance.activate(Time.time);
                obstacleExists = true;
            }
        }
    }

    public void SetZombiRBAndDistance(Rigidbody rb, float distance)
    {
        this.zombiRB = rb;
        this.obsSpawnDistance = distance;
    }

    public void CreateObstacle(float range, Vector3 position)
    {
        GameObject newObstacle = Instantiate(obstacle, position, Quaternion.identity);
        newObstacle.tag = "Obstacle";
        newObstacle.transform.eulerAngles = new Vector3(0, 180, 0);

        SphereCollider rangeCollider = newObstacle.GetComponent<SphereCollider>();

        rangeCollider.radius = range;
    }
}
