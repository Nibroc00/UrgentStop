using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelFriction : MonoBehaviour
{
    public WheelCollider wheel;
    private WheelFrictionCurve forwardFrictionCurve;
    private WheelFrictionCurve sidewaysFrictionCurve;
    
    // Start is called before the first frame update
    void Start()
    {
        forwardFrictionCurve = wheel.forwardFriction;
        sidewaysFrictionCurve = wheel.sidewaysFriction;
    }

    // Update is called once per frame
    void Update()
    {
        WheelHit ground;
        if (wheel.GetGroundHit(out ground)) {
            // Debug.Log(ground.collider.name);
            if (ground.collider.name == "asphaltTerrain") {
                forwardFrictionCurve.stiffness = 1.0f;
                wheel.forwardFriction = forwardFrictionCurve;
                sidewaysFrictionCurve.stiffness = 1.0f;
                wheel.sidewaysFriction = sidewaysFrictionCurve;
            }
            else if (ground.collider.name == "quadTerrain") {
                forwardFrictionCurve.stiffness = 0.5f;
                wheel.forwardFriction = forwardFrictionCurve;
                sidewaysFrictionCurve.stiffness = 0.5f;
                wheel.sidewaysFriction = sidewaysFrictionCurve;
            }
            else if (ground.collider.name == "snowTerrain") {
                forwardFrictionCurve.stiffness = 0.2f;
                wheel.forwardFriction = forwardFrictionCurve;
                sidewaysFrictionCurve.stiffness = 0.2f;
                wheel.sidewaysFriction = sidewaysFrictionCurve;
            }
        }
    }
}
