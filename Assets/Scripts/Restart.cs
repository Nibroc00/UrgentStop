using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    public Button restartButton;

    private void Start()
    {
        Button btn = restartButton.GetComponent<Button>();
        btn.onClick.AddListener(RestartGame);
    }

    public void RestartGame()
    {
        Debug.Log("Hello! Game button pressed");
        GameObject.DestroyImmediate(GameObject.FindGameObjectWithTag("Zombi"));
        GameObject.DestroyImmediate(GameObject.FindGameObjectWithTag("Untagged"));
        GameObject.DestroyImmediate(GameObject.FindGameObjectWithTag("Obstacle"));
        GameObject.FindGameObjectWithTag("Framework").GetComponent<framework>().restart();
        GameObject.Destroy(this);
        // Node: This is never being called. Don't look at this class further. 
        // Kept here for exanability purposes
    }

}