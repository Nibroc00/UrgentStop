using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class terrainDropdown : MonoBehaviour
{
    public TMP_Dropdown dropdownObj;
    public string terrainValue;
    // Start is called before the first frame update
    void Start()
    {
        terrainValue = dropdownObj.options[dropdownObj.value].text;
    }

    // Update is called once per frame
    void Update()
    { 
        terrainValue = dropdownObj.options[dropdownObj.value].text;
    }
}
