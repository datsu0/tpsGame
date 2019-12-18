using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTps : MonoBehaviour
{   public GameObject target; // an object to follow
    public Vector3 offset=new Vector3(0,2,0); // offset form the target object

    private float distance = 5.0f; // distance from following object
    private float polarAngle = 45.0f; // angle with y-axis
    private float azimuthalAngle = 45.0f; // angle with x-axis

    private float minDistance = 3.0f;
    private float maxDistance = 8.0f;
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
