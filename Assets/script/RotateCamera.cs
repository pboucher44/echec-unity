using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public bool rotateAroundMap = true;
    private Vector3 _cameraOffset;
    public float SmoothFactor = 0.5f;

    public float RotationSpeed = 5.0f;

    private GameObject centre;
    // Start is called before the first frame update
    void Start()
    {
        centre = GameObject.Find("Centre");
        _cameraOffset = transform.position - centre.transform.position;
    
    }

    // Update is called once per frame
    void Update()
    {
      rotateCamera();
    }

    private void rotateCamera() //use to rotate the camera when right mouse button is down
    {
            if (Input.GetMouseButton(1))
      {
          Quaternion camturnAngle = 
                Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationSpeed, Vector3.up);

            _cameraOffset = camturnAngle * _cameraOffset;

            Vector3 newPos = _cameraOffset + centre.transform.position;

            transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);
            transform.LookAt(centre.transform);
      }
    }
}
