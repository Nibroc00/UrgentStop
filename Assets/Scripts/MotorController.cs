using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorController : MonoBehaviour
{
    public List<AxleInfo> axleInfos; // the information about each individual axle
    public float maxMotorTorque; // maximum torque the motor can apply to wheel
    public float maxSteeringAngle; // maximum steer angle the wheel can have
    //public Controller controller = Controller.Instance;
    public Controller controller = new Controller();
                                   
    public void ApplyLocalPositionToVisuals(WheelCollider collider, Transform transform)
    {
        //if (collider.transform.childCount == 0)
        //{
        //    return;
        //}

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        transform.position = position;
        transform.rotation = rotation;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        controller.Update(Time.fixedTime);
        float motor = maxMotorTorque * controller.Speed;
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        if (axleInfos[0].steering)
        {
            axleInfos[0].leftWheel.steerAngle = steering;
            axleInfos[0].rightWheel.steerAngle = steering;
        }
        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
            ApplyLocalPositionToVisuals(axleInfo.leftWheel, axleInfo.leftWheelT);
            ApplyLocalPositionToVisuals(axleInfo.rightWheel, axleInfo.rightWheelT);
        }
    }
}

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public Transform leftWheelT;
    public Transform rightWheelT;
    public bool motor; // is this wheel attached to motor?
    public bool steering; // does this wheel apply steer angle?
}
