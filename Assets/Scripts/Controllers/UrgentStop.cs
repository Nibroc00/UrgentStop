using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Stops{
    public class UrgentStop
    {

        private float velocity;
        private float distance;
        private float lastPosition;
        private Rigidbody zombi;
        private GameObject closestObstacle;


        public UrgentStop(float instantiationTime)
        {
            this.zombi = GameObject.Find("Zombi").GetComponent<Rigidbody>();
            this.lastPosition = zombi.transform.position.z;
            GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
            float smallestDistance = 99999f;
            foreach(GameObject obstacle in obstacles) {
                float diff = (obstacle.transform.position - zombi.transform.position).magnitude;
                if (diff <= smallestDistance) {
                    closestObstacle = obstacle;
                    smallestDistance = diff;
                }
            }
            this.distance = (closestObstacle.transform.position - zombi.transform.position).magnitude - 1;
        }

        public float Stop(float time)
        {
            if (this.distance <= 0.011) {
                this.distance = 0.01F;
            } 
            else {
                this.distance = (closestObstacle.transform.position - zombi.transform.position).magnitude - 1;    ;        
            }
            this.velocity = (zombi.transform.position.z - lastPosition) / Time.deltaTime;
            this.lastPosition = zombi.transform.position.z;
            double accelerationNeeded = ((0 - Math.Pow(velocity, 3)) / (Math.Pow(distance, 2)));
            double value = ((accelerationNeeded/(4.5)) + 0.5) * 2;


            // Debug.Log("distance: " + this.distance);
            // Debug.Log("velocity: " + this.velocity);
            // Debug.Log("A: " + accelerationNeeded);
            // Debug.Log("%" + (accelerationNeeded/(4.5)));
            // Debug.Log("D3: " + this.distance);
            // Debug.Log("F: " + force);
            // Debug.Log("V: " + value);
            if (this.velocity < 0.05 && this.velocity > -0.05) {
                return 0;
            }
            if (value > 1) {
                return 1;
            }
            else if (value < -1) {
                return -1;
            }
            else {
                return (float)value;
            }
        }

    }
}