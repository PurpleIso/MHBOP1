using UnityEngine;

public class RotorSpin : MonoBehaviour
{
    public bool isTailRotor = false;
    public float maxSpeed = 1000f;
    public float spinUpTime = 7f;
    private float currentSpeed = 0f;
    private float targetSpeed = 0f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (targetSpeed == 0f)
            {
                targetSpeed = maxSpeed; 
            }
            else
            {
                targetSpeed = 0f;
            }
        }
        currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, (maxSpeed / spinUpTime) * Time.deltaTime);

        if (isTailRotor)
        {
            transform.Rotate(Vector3.right * currentSpeed * Time.deltaTime);
        }
        else
        {
            transform.Rotate(Vector3.forward * currentSpeed * Time.deltaTime);
        }
    }
}
