using UnityEngine;

public class Player : MonoBehaviour
{

    public enum ControlType { HumanInput, AI };
    public ControlType controlType = ControlType.HumanInput;
    public float BestLapTime { get; private set; } = Mathf.Infinity;
    public float LastLapTime { get; private set; } = 0;
    public float CurrentLapTime { get; private set; } = 0;
    public int CurrentLap { get; private set; } = 0;

    private float lapTimer;
    private int lastCheckpointPassed = 0;
    private Transform checkpointsParent;
    private int checkpointsCount;
    private int checkpointLayer;
    private CarMovement carMovement;

    void Awake()
    {
        checkpointsParent = GameObject.Find("Checkpoints").transform;
        checkpointsCount = checkpointsParent.childCount;
        checkpointLayer = LayerMask.NameToLayer("Checkpoint");
        carMovement = GetComponent<CarMovement>();
    }

    void Update()
    {
        CurrentLapTime = lapTimer > 0 ? Time.time - lapTimer : 0;

        if (controlType == ControlType.HumanInput)
        {
            carMovement.Steer = GameManager.Instance.InputController.SteerInput;
            carMovement.Throttle = GameManager.Instance.InputController.ThrottleInput;
        }
    }

    void StartLap()
    {
        CurrentLap++;
        lastCheckpointPassed = 1;
        lapTimer = Time.time;
    }

    void EndLap()
    {
        LastLapTime = Time.time - lapTimer;
        BestLapTime = Mathf.Min(LastLapTime, BestLapTime);
        print(LastLapTime);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer != checkpointLayer)
        {
            return;
        }

        if (collider.gameObject.name == "1")
        {
            if (lastCheckpointPassed == checkpointsCount)
            {
                EndLap();
            }
            if (CurrentLap == 0 || lastCheckpointPassed == checkpointsCount)
            {
                StartLap();
            }
            return;
        }
        if (collider.gameObject.name == (lastCheckpointPassed + 1).ToString())
        {
            lastCheckpointPassed++;
        }
    }
}
