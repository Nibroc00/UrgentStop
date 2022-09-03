using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class massSlider : MonoBehaviour
{
    public TMP_Text massText;
    public float massValue;
    public Slider sliderObj;
    // Start is called before the first frame update
    void Start()
    {
        massValue = 100f;
        massText.text = "Car Mass = " + massValue.ToString() + " kg";
    }

    // Update is called once per frame
    void Update()
    {
        massValue = sliderObj.value;
        massText.text = "Car Mass = " + massValue.ToString() + " kg";

    }
}
