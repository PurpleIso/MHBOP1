using UnityEngine;

public class AutomaticCannon : MonoBehaviour
{
    public GameObject lineBulletPrefab;
    public Transform firePoint; 
    public float bulletSpeed = 20f;
    public float fireRate = 0.5f; 
    private float lastFireTime = 0f;
    public float fadeDuration = 1f;

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Time.time - lastFireTime > fireRate)
        {
            FireLineBullet();
            lastFireTime = Time.time;
        }
    }

    void FireLineBullet()
    {
        GameObject lineBullet = Instantiate(lineBulletPrefab, firePoint.position, firePoint.rotation);
        Vector3 targetPosition = firePoint.position + firePoint.forward * 100f; 
        LineRenderer lineRenderer = lineBullet.GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, targetPosition);
        StartCoroutine(MoveLineBullet(lineBullet, targetPosition, lineRenderer));
    }

    System.Collections.IEnumerator MoveLineBullet(GameObject lineBullet, Vector3 targetPosition, LineRenderer lineRenderer)
    {
        float journeyLength = Vector3.Distance(lineBullet.transform.position, targetPosition);
        float startTime = Time.time;
        Color startColor = lineRenderer.startColor;
        while (Vector3.Distance(lineBullet.transform.position, targetPosition) > 0.1f)
        {
            float distanceCovered = (Time.time - startTime) * bulletSpeed;
            float fractionOfJourney = distanceCovered / journeyLength;
            lineBullet.transform.position = Vector3.Lerp(lineBullet.transform.position, targetPosition, fractionOfJourney);

            float fadeAmount = Mathf.Lerp(1f, 0f, fractionOfJourney); 
            lineRenderer.startColor = new Color(startColor.r, startColor.g, startColor.b, fadeAmount);
            lineRenderer.endColor = new Color(startColor.r, startColor.g, startColor.b, fadeAmount);

            yield return null;
        }

        Destroy(lineBullet);
    }
}
