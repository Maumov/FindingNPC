using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private float maxAngle = 60f, minAngle = -40f;
    [SerializeField] private float sensitivityX = 5f;
    [SerializeField] private float sensitivityY = 5f;
    
    private Vector3 direction;
    private Transform playerCamera;
    Quaternion m_CameraTargetRot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable() {
        
        playerCamera = GetComponentInChildren<Camera>().transform;
        m_CameraTargetRot = playerCamera.localRotation;
    }

    private void OnDisable() {

    }

    // Update is called once per frame
    void Update() {
        Inputs();
        Move();
    }

    void Inputs() {
        direction = new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0f);
    }
    Quaternion ClampRotationAroundXAxis(Quaternion q) {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1.0f;
        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);
        angleX = Mathf.Clamp(angleX, minAngle, maxAngle);
        q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);
        return q;
    }

    void Move() {
        m_CameraTargetRot *= Quaternion.Euler(-direction.x * sensitivityY, 0f, 0f);
        m_CameraTargetRot = ClampRotationAroundXAxis(m_CameraTargetRot);
        playerCamera.localRotation = m_CameraTargetRot;

        transform.localRotation *= Quaternion.Euler(0f, direction.y * sensitivityX, 0f);
        
    }
}
