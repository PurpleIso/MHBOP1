using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    private Transform cam;

    void Start()
    {
        cam = Camera.main.transform;
    }

    void LateUpdate()
    {
        transform.forward = cam.forward;
    }
}
