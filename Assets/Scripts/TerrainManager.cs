using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour
{
    private GameObject activeTerrain;
    public GameObject snowTerrain;
    public GameObject asphaltTerrain;
    public GameObject quadTerrain;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetTerrain(GameObject terrain)
    {
        Debug.Log("terrain change: " + terrain.name);
        activeTerrain = terrain;
        Instantiate(activeTerrain, activeTerrain.transform.position, Quaternion.identity);
    }
}

