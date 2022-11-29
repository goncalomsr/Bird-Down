using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalCamera : MonoBehaviour
{
    [Header("Transform")]
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Transform cameraFocusPoint;

    [Header("Camera Distance")]
    [SerializeField] private float minCameraDistance;
    [SerializeField] private float maxCameraDistance;

    [Header("Rotation Speed")]
    [SerializeField] private float rotationSpeedPerSecond = 90.0f;

    [Header("Angle Limits")]
    [SerializeField] private float upperAngleLimits =  60.0f;
    [SerializeField] private float lowerAngleLimits = -60.0f;

    private Vector3 targetLocation = Vector3.zero;
    private Vector3 targetRotation = Vector3.zero;

    private float currentCameraDistance;

    private void Start()
    {
        // Cache The Initial Position and Rotation So Lerp Doesn't Do Weird Things
        targetLocation = cameraTransform.position;
        targetRotation = cameraTransform.rotation.eulerAngles;

        currentCameraDistance = Mathf.Abs((cameraTransform.position - cameraFocusPoint.position).magnitude);

        /// Lock the cursor in place when playing
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float XInputMovement = 0;
        float YInputMovement = 0;

        XInputMovement = Input.GetAxisRaw("Mouse X");
        YInputMovement = Input.GetAxisRaw("Mouse Y");

        /*
        if (Input.GetKey(KeyCode.Mouse1))
        {
            // Get The Input
            XInputMovement = Input.GetAxisRaw("Mouse X");
            YInputMovement = Input.GetAxisRaw("Mouse Y");
        }
        */

        currentCameraDistance = Mathf.Clamp(currentCameraDistance + -Input.mouseScrollDelta.y * 0.5f, minCameraDistance, maxCameraDistance);

        // Calculate rotation where we want to be
        Vector3 currentCameraRotation = cameraTransform.rotation.eulerAngles;
        targetRotation = targetRotation + (new Vector3( -YInputMovement, XInputMovement, 0.0f ) * rotationSpeedPerSecond * Time.deltaTime);
        targetRotation.x = Mathf.Clamp(targetRotation.x, lowerAngleLimits, upperAngleLimits);
        // TODO: Do some lerping
        cameraTransform.rotation = Quaternion.Euler(targetRotation);


        // Calculate position where we want to be
        Vector3 targetLocation = cameraFocusPoint.position - cameraTransform.forward * currentCameraDistance;

        RaycastHit hit;
        if (Physics.Raycast(cameraFocusPoint.position, (targetLocation - cameraFocusPoint.position).normalized, out hit, currentCameraDistance))
        {
            // If There is something in between lets adjust the target location to be infront
            targetLocation = hit.point + cameraTransform.forward * 0.01f;
        }

        cameraTransform.position = targetLocation;
    }
}
