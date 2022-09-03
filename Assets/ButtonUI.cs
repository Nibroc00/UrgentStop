using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI : MonoBehaviour
{
    [SerializeField] private string referenceToScene = "Scene";

    public void RestartButton()
    {
        Debug.Log("The RestartButton function fired off");

        //GameObject.DestroyImmediate(GameObject.FindGameObjectWithTag("Zombi"));
        //GameObject.DestroyImmediate(GameObject.FindGameObjectWithTag("Untagged"));
        //GameObject.DestroyImmediate(GameObject.FindGameObjectWithTag("Obstacle"));
        //GameObject.Destroy(this);
        SceneManager.LoadSceneAsync(referenceToScene);
        //GameObject.FindGameObjectWithTag("Framework").GetComponent<framework>().restart();
    }
}
