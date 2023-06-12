using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    [SerializeField] private Transform _playerCamera;
    [SerializeField] private Transform _portal;
    [SerializeField] private Transform _otherPortal;

    // Update is called once per frame
    void Update()
    {
        Vector3 playerOffsetFromPortal = _playerCamera.position - _otherPortal.position;
        transform.position = _portal.position + playerOffsetFromPortal;
        
        float angularDifferenceBetweenPortalRotations = Quaternion.Angle(_portal.rotation, _otherPortal.rotation);

        Quaternion portalRotationDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
        Vector3 newCameraDirection = portalRotationDifference * _playerCamera.forward;
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
    }
}
