using UnityEngine;
using System.Collections;

public class RotorSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip startupClip;
    public AudioClip idleClip;
    public MonoBehaviour helicopterControlScript;

    public ParticleSystem[] exhaustParticles; 

    private bool isOn = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (!isOn)
            {
                StartCoroutine(StartHelicopter());
            }
            else
            {
                ShutDownHelicopter();
            }
        }
    }

    private IEnumerator StartHelicopter()
    {
        isOn = true;

        if (startupClip != null)
        {
            audioSource.clip = startupClip;
            audioSource.loop = false;
            audioSource.Play();
        }

        if (helicopterControlScript != null)
            helicopterControlScript.enabled = false;


        foreach (var ps in exhaustParticles)
        {
            if (ps != null)
                ps.Play();
        }

        yield return new WaitForSeconds(startupClip.length);

        if (idleClip != null)
        {
            audioSource.clip = idleClip;
            audioSource.loop = true;
            audioSource.Play();
        }

        if (helicopterControlScript != null)
            helicopterControlScript.enabled = true;
    }

    private void ShutDownHelicopter()
    {
        isOn = false;

        audioSource.Stop();

        if (helicopterControlScript != null)
            helicopterControlScript.enabled = false;


        foreach (var ps in exhaustParticles)
        {
            if (ps != null)
                ps.Stop();
        }
    }
}
