using UnityEngine;
using Lean.Touch;

public class LeanThreeFingerRotateXY : MonoBehaviour
{
    public float sensitivity = 0.25f;

    void Update()
    {
        // Only rotate when exactly 3 fingers touch
        if (LeanTouch.Fingers.Count == 3)
        {
            var fingers = LeanTouch.Fingers;
            Vector2 delta = LeanGesture.GetScreenDelta(fingers);

            float rotX = -delta.y * sensitivity;  // Up-down
            float rotY =  delta.x * sensitivity;  // Left-right

            transform.Rotate(rotX, rotY, 0, Space.World);
        }
    }
}
