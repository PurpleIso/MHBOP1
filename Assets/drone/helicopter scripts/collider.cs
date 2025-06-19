using UnityEngine;

public class RotorHitbox : MonoBehaviour
{
    public AudioSource rotorImpactSource;
    public AudioClip impactClip;
    public float cooldown = 0.1f;
    private float lastPlayTime = -Mathf.Infinity;
    void OnTriggerEnter(Collider other)
    {
        if (impactClip != null && rotorImpactSource != null)
        {
            if (Time.time - lastPlayTime >= cooldown)
            {
                rotorImpactSource.PlayOneShot(impactClip);
                lastPlayTime = Time.time;
            }
        }
    }
}
