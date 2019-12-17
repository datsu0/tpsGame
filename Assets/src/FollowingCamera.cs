﻿// These codes are licensed under CC0.
// http://creativecommons.org/publicdomain/zero/1.0/deed.ja

using UnityEngine;

/// <summary>
/// The camera added this script will follow the specified object.
/// The camera can be moved by left mouse drag and mouse wheel.
/// </summary>
[ExecuteInEditMode, DisallowMultipleComponent]
public class FollowingCamera : MonoBehaviour
{
    public GameObject target; // an object to follow
    public Vector3 offset; // offset form the target object

    public Vector3 addPos=new Vector3(-1,3,-1);

    private float distance = 4.0f; // distance from following object
    private float polarAngle = 45.0f; // angle with y-axis
    private float azimuthalAngle = 45.0f; // angle with x-axis

    private float minDistance = 1.0f;
    private float maxDistance = 7.0f;
    private float minPolarAngle = 5.0f;
    private float maxPolarAngle = 75.0f;
    private float mouseXSensitivity = 5.0f;
    private float mouseYSensitivity = 5.0f;
    private float scrollSensitivity = 5.0f;

    void Start(){
        this.target = GameObject.Find("unitychan");
    }

    void LateUpdate()
    {
        if (Input.GetMouseButton(0)) {
            updateAngle(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        }
        updateDistance(Input.GetAxis("Mouse ScrollWheel"));

        var lookAtPos = target.transform.position + offset;
        updatePosition(lookAtPos);
        transform.LookAt(lookAtPos);
    }

    void updateAngle(float x, float y)
    {
        x = azimuthalAngle - x * mouseXSensitivity;
        azimuthalAngle = Mathf.Repeat(x, 360);

        y = polarAngle + y * mouseYSensitivity;
        polarAngle = Mathf.Clamp(y, minPolarAngle, maxPolarAngle);
    }

    void updateDistance(float scroll)
    {
        scroll = distance - scroll * scrollSensitivity;
        distance = Mathf.Clamp(scroll, minDistance, maxDistance);
    }

    void updatePosition(Vector3 lookAtPos)
    {
        var da = azimuthalAngle * Mathf.Deg2Rad;
        var dp = polarAngle * Mathf.Deg2Rad;
        transform.position = new Vector3(
            lookAtPos.x + distance * Mathf.Sin(dp) * Mathf.Cos(da),
            lookAtPos.y + distance * Mathf.Cos(dp),
            lookAtPos.z + distance * Mathf.Sin(dp) * Mathf.Sin(da));
    }
}