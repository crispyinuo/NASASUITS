using UnityEngine;

public class CubeController : MonoBehaviour
{
    public float speed = 1.4f; // Average human walking speed in meters per second

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // Gets left/right movement (A/D or Left/Right Arrow)
        float moveVertical = Input.GetAxis("Vertical"); // Gets forward/backward movement (W/S or Up/Down Arrow)

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
}
