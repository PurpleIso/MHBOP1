using UnityEngine;

public class RayHit : MonoBehaviour
{

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shooting();
        }
    }
    public void shooting()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitInfo, 20f))
        {
            Debug.Log("Hit Something");
            print(hitInfo.collider.gameObject.name);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitInfo.distance, Color.red);

            ShootingTartget Enemy = hitInfo.transform.GetComponent<ShootingTartget>();

            if (Enemy != null)
            {
                Enemy.TakeDamage(1);
            }
        }
        else
        {
            Debug.Log("Hit nothing");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 20f, Color.green);
        }
    }
}
