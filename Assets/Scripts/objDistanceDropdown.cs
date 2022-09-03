using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class objDistanceDropdown : MonoBehaviour
{
    public TMP_Dropdown dropdownObj;
    public int objectDistance;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(dropdownObj.value == 0)
        {
            objectDistance = 3;
        }
        else if(dropdownObj.value == 1)
        {
            objectDistance = 10;
        }
        else
        {
            objectDistance = 20;
        }
    }
}
