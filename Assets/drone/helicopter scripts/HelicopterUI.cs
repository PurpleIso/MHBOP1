using UnityEngine;
using TMPro;

public class HelicopterUI : MonoBehaviour
{
    private Rigidbody helicopterRb;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI altitudeText;
    public TextMeshProUGUI headingText;
    void Update()
    {
        if (helicopterRb == null) return;

        float speed = helicopterRb.linearVelocity.magnitude * 3.6f; 
        float altitude = helicopterRb.transform.position.y;
        float heading = helicopterRb.transform.eulerAngles.y;

        speedText.text = $"SPEED: {speed:F0} km/h";
        altitudeText.text = $"ALTITUDE: {altitude:F0} m";
        headingText.text = $"HEADING: {heading:F0}°";
    }
    public void SetHelicopter(Rigidbody rb)
    {
        helicopterRb = rb;
    }
}
