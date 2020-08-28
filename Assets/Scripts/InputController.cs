using UnityEngine;

public class InputController : MonoBehaviour
{
    public string inputSteeringAxis = "Horizontal";
    public string inputThrottleAxis = "Vertical";

    public float SteerInput { get; private set; }
    public float ThrottleInput { get; private set; }

    void Update()
    {
        SteerInput = Input.GetAxis(inputSteeringAxis);
        ThrottleInput = Input.GetAxis(inputThrottleAxis);
    }
}
