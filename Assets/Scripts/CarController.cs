using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(WheelJoint2D))]
public class CarController : MonoBehaviour
{
    [SerializeField] float maxMotorTorque;
    [SerializeField] float rotationSpeed;

    private JointMotor2D jointMotor;
    private float movement;
    private WheelJoint2D[] wheels;
    private void Start()
    {
        wheels = GetComponents<WheelJoint2D>();
        jointMotor = wheels[0].motor;
    }

    private void Update()
    {
        movement =  Input.GetAxis("Vertical");

    }
    public void FixedUpdate()
    {        
        jointMotor.motorSpeed = (movement <= 0 && wheels[0].jointSpeed+10 > 0)? 0:-maxMotorTorque * movement;
        foreach (var item in wheels)
        {
            item.motor = jointMotor;            
        }

    }
}