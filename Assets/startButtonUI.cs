using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class startButtonUI : MonoBehaviour
{
    public Button startButton;
    public GameObject framework;
    private TerrainManager tm;
    private ObstacleSpawner os;
    private HUD hud;
    public Slider sliderObj;
    public TMP_Dropdown dropdownObj;
    public TMP_Dropdown dropdownStopDist;
    public string terrainValue;


    // Start is called before the first frame update
    void Start()
    {
        framework = GameObject.FindGameObjectWithTag("Framework");
        Button btn = startButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        tm = framework.GetComponent<TerrainManager>();
        os = framework.GetComponent<ObstacleSpawner>();
        hud = framework.GetComponent<HUD>();
    }
    public void TaskOnClick()
    {
        terrainValue = dropdownObj.options[dropdownObj.value].text;
        if (terrainValue == "Asphalt")
        {
            GameObject asphalt = GameObject.Instantiate(tm.asphaltTerrain);
            asphalt.name = "asphaltTerrain";

        }
        else if (terrainValue == "Grass")
        {
            GameObject quad = GameObject.Instantiate(tm.quadTerrain);
            quad.name = "quadTerrain";

        }
        else
        {
            GameObject snow = GameObject.Instantiate(tm.snowTerrain);
            snow.name = "snowTerrain";

        }

        GameObject zombi = GameObject.Instantiate(framework.GetComponent<framework>().zombi);
        zombi.name = "Zombi";

        GameObject HUD = GameObject.Instantiate(framework.GetComponent<framework>().HUD);
        HUD.name = "HUD";
        HUD.GetComponent<HUD>().setStopDistanceText(dropdownStopDist.options[dropdownStopDist.value].text);

        //Change Mass Of Zombi Based On Slider Value
        Rigidbody zombiBody = zombi.GetComponent<Rigidbody>();
        zombiBody.mass = sliderObj.value;

        os.SetZombiRBAndDistance(zombiBody, float.Parse(dropdownStopDist.options[dropdownStopDist.value].text));

        Destroy(GameObject.Find("Canvas"));
    }
}
