using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class framework : MonoBehaviour
{
    public GameObject zombi;
    public GameObject HUD;
    public GameObject obstacle;
    public GameObject startMenu;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Instantiate<GameObject>(startMenu);
    }

    public void restart()
    {
        GameObject.Instantiate<GameObject>(startMenu);
    }

    // Update is called once per frame
    void Update()
    {
        // Exit Sample  
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }

    public GameObject getObstacle()
    {
        return obstacle;
    }
}
