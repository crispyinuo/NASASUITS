using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
// [CustomEditor(typeof(UserController))]
// public class UserControllerEditor : Editor
// {
//     public override void OnInspectorGUI()
//     {
//         DrawDefaultInspector(); // Draws the default inspector

//         UserController script = (UserController)target;

//         if (GUILayout.Button("Up"))
//         {
//             script.MoveUp();
//         }
//         if (GUILayout.Button("Down"))
//         {
//             script.MoveDown();
//         }
//         if (GUILayout.Button("Left"))
//         {
//             script.MoveLeft();
//         }
//         if (GUILayout.Button("Right"))
//         {
//             script.MoveRight();
//         }
//     }
// }
public class UserController : MonoBehaviour
{
    public float speed = 5.0f;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (Mathf.Abs(horizontal) > 0 || Mathf.Abs(vertical) > 0)
        {
            Debug.Log("Input detected: Horizontal = " + horizontal + ", Vertical = " + vertical);
        }

        Vector3 movement = new Vector3(horizontal, 0, vertical);
        movement.Normalize();

        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }

    public void MoveUp() => Move(Vector3.forward);
    public void MoveDown() => Move(Vector3.back);
    public void MoveLeft() => Move(Vector3.left);
    public void MoveRight() => Move(Vector3.right);

    private void Move(Vector3 direction)
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }
}
