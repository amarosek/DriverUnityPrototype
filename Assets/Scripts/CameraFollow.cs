using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;

    public Vector3 offset;
    public Vector3 eulerRotation;
    public float damper;

    void Start()
    {
        transform.eulerAngles = eulerRotation;
    }

    void Update()
    {
        if (player == null)
        { return; }

        transform.position = Vector3.Lerp(transform.position, player.position + offset, damper * Time.deltaTime);
    }
}
