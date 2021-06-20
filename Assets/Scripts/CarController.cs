using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(WheelJoint2D))]
public class CarController : MonoBehaviour
{
    [SerializeField] float maxMotorTorque;
    [SerializeField] float rotationSpeed;

    JointMotor2D jointMotor;
    float movement;
    float rotation;
    WheelJoint2D[] wheels;
    Rigidbody2D rigbody;
    private void Start()
    {
        wheels = GetComponents<WheelJoint2D>();
        rigbody = GetComponent<Rigidbody2D>();
        jointMotor = wheels[0].motor;
    }

    private void Update()
    {
        movement =  Input.GetAxis("Vertical");
        rotation = Input.GetAxis("Horizontal");
        
    }
    public void FixedUpdate()
    {
        jointMotor.motorSpeed = -maxMotorTorque * movement;
        foreach (var item in wheels)
        {
            item.motor = jointMotor;
        }
        rigbody.AddTorque(-rotation * rotationSpeed * Time.fixedDeltaTime);

    }
}