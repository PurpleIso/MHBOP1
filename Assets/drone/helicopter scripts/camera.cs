using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    private Transform target;

    public float distance = 5f;
    public float height = 2f;
    public float rotationSpeed = 5f;
    public float minPitch = -30f;
    public float maxPitch = 60f;
    private float yaw = 0f;
    private float pitch = 15f;

    void LateUpdate()
    {
        if (target == null) return;

        distance -= Input.GetAxis("Mouse ScrollWheel") * 5f;
        distance = Mathf.Clamp(distance, 2f, 20f);
        if (Input.GetMouseButton(1))
        {
            yaw += Input.GetAxis("Mouse X") * rotationSpeed;
            pitch -= Input.GetAxis("Mouse Y") * rotationSpeed;
            pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
        }
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        Vector3 offset = rotation * new Vector3(0, 0, -distance);
        Vector3 finalPosition = target.position + Vector3.up * height + offset;

        transform.position = finalPosition;
        transform.LookAt(target.position + Vector3.up * height);
    }
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
        yaw = newTarget.eulerAngles.y;
        pitch = 15f;
    }
}
