using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        float view = cam.fieldOfView - scroll*5;
        float sensitiveMove=1f;
        cam.fieldOfView = Mathf.Clamp(value: view, min: 0.1f, max: 100f);
        if (Input.GetMouseButton(1))
        {
            float moveX = Input.GetAxis("Mouse X") * -sensitiveMove;
            float moveY = Input.GetAxis("Mouse Y") * sensitiveMove;
            cam.transform.localPosition -= new Vector3(moveX, moveY, 0.0f);
        }
    }
}
