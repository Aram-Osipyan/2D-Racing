using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CarController : MonoBehaviour
{
    [SerializeField] float maxMotorTorque;
    [SerializeField] float maxSteeringAngle;
    [SerializeField] WheelJoint2D frontWheel;
    [SerializeField] WheelJoint2D backWheel;
    JointMotor2D jointMotor;
    private void Start()
    {
        jointMotor = frontWheel.motor;
    }

    public void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");
        Debug.Log(motor + " " + steering);

        jointMotor.motorSpeed = motor;
        frontWheel.motor = jointMotor;
        backWheel.motor = jointMotor;



    }
}