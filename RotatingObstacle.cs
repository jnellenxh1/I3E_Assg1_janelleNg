/*
* Author: Janelle Ng
* Date: 15-06-2025
* Description: Rotates the log continuously around specified local axes for obstacle movement
*/

using UnityEngine;

public class RotatingObstacle : MonoBehaviour
{
    [Header("Rotation Settings")]
    /// Rotation speed in degrees per second for each axis (X, Y, Z)
    public Vector3 rotation = new Vector3(0, 100, 0);

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(rotation * Time.deltaTime);
    }
}