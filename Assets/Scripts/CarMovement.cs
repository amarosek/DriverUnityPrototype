using System;
using UnityEngine;

public class CarMovement : MonoBehaviour
{

    public float maxMotorTorque = 300f;
    public float maxBreakTorque = 500f;
    public float maxSteerAngle = 40f;

    public Transform centerOfMass;
    private Rigidbody rigidbody;
    private Wheel[] wheels;

    public float minPitch = 1;
    public float maxPitch = 3;
    public float maxSpeed = 150;

    private float pitchModifier;


    [SerializeField] AudioSource engineSound;
    [SerializeField] WheelCollider wheelCollider;

    public float Steer { get; set; }
    public float Throttle { get; set; }

    void Start()
    {
        wheels = GetComponentsInChildren<Wheel>();
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.centerOfMass = centerOfMass.localPosition;
    }


    void Update()
    {
        foreach (var wheel in wheels)
        {
            wheel.SteerAngle = Steer * maxSteerAngle;
            wheel.Torque = Throttle * maxMotorTorque;
        }
    }

    void FixedUpdate()
    {

        var currentSpeed = rigidbody.velocity.magnitude;
        print(currentSpeed);
        pitchModifier = (maxPitch - minPitch) * 2;
        engineSound.pitch = minPitch + (currentSpeed / maxSpeed) * pitchModifier;

    }
}
