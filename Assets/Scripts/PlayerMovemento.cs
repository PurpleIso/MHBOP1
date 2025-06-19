using UnityEngine;

public class PlayerMovemento : MonoBehaviour

{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private int _speed;
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(x, -1, y);
        _characterController.Move(move * Time.deltaTime * _speed);

    }
}
