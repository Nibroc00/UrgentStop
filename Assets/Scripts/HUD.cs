using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    private float speed;
    private float mass;
    private Vector3 lastPosition;
    private string stopDistanceText;

    private Text speedometer;
    private Text obstacleDistanceText;
    private float obstacleDistance;

    private Rigidbody zombi;
    
    void Start()
    {
        speed = 0f;
        zombi = GameObject.Find("Zombi").GetComponent<Rigidbody>();
        speedometer = GameObject.Find("Speedometer").GetComponent<Text>();
        lastPosition = zombi.transform.position;

        Terrain terrain = GetClosestCurrentTerrain(zombi.transform.position);
        Text terrainFriction = GameObject.Find("TerrainFriction").GetComponent<Text>();
        terrainFriction.text = "Terrain Friction: " + terrain.GetComponent<TerrainCollider>().material.dynamicFriction;

        Text stopDistance = GameObject.Find("StopDistance").GetComponent<Text>();
        stopDistance.text = stopDistanceText;

        Text massText = GameObject.Find("Mass").GetComponent<Text>();
        massText.text = zombi.mass.ToString("Mass: 0" + " kg");

        obstacleDistanceText = GameObject.Find("ObstacleDistance").GetComponent<Text>();
        obstacleDistance = 99999f;


    }

    void FixedUpdate()
    {
        this.updateSpeed();
        this.updateObstacleDistance();
    }

    private void updateSpeed()
    {
        speed = (zombi.transform.position - lastPosition).magnitude / Time.deltaTime;
        lastPosition = zombi.transform.position;
        speedometer.text = speed.ToString("0.00") + " m/s";
    }

    //Reference: https://stackoverflow.com/a/52359587
    private Terrain GetClosestCurrentTerrain(Vector3 zombiPos)
    {
        //Get all terrain
        Terrain[] terrains = Terrain.activeTerrains;

        //Make sure that terrains length is ok
        if (terrains.Length == 0)
            return null;

        //If just one, return that one terrain
        if (terrains.Length == 1)
            return terrains[0];

        //Get the closest one to zombi
        float lowDist = (terrains[0].GetPosition() - zombiPos).sqrMagnitude;
        var terrainIndex = 0;

        for (int i = 1; i < terrains.Length; i++)
        {
            Terrain terrain = terrains[i];
            Vector3 terrainPos = terrain.GetPosition();

            //Find the distance and check if it is lower than the last one then store it
            var dist = (terrainPos - zombiPos).sqrMagnitude;
            if (dist < lowDist)
            {
                lowDist = dist;
                terrainIndex = i;
            }
        }
        return terrains[terrainIndex];
    }

    private void updateObstacleDistance() 
    {
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        float smallestDistance = 99999f;
        foreach(GameObject obstacle in obstacles) {
            float diff = (obstacle.transform.position - zombi.transform.position).magnitude;
            if (diff <= smallestDistance) {
                obstacleDistance = diff;
                obstacleDistanceText.text = obstacleDistance.ToString("0 m");
            }
        }
    }

    public void setStopDistanceText(string distance) {
        stopDistanceText = "Stop Distance: " + distance + " m";
    }
}
