/*
 * PlayerTracker
 * 
 * Controls player camera rotation with the mouse.
 *
 * Luis Fernando Lomelin Ibarra
 * Jair Antonio Bautista Loranca
 * David Alejandro Martínez Tristán
 *
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    public Transform trackedObject;
    public float maxDistance = 10;
    public float moveSpeed = 20;
    public float updateSpeed = 10;
    [Range(0, 10)]
    public float currentDistance = 5;
    private string moveAxis = "Mouse ScrollWheel";
    private GameObject ahead;
    private MeshRenderer _renderer;
    public float hideDistance = 1.5f;
    public float sensitivity = 100f;

    float rotateHorizontal;
    float rotateVertical;

    private float xRotationCamera = 0f;

    void Start()
    {
        ahead = new GameObject("ahead");
        _renderer = trackedObject.gameObject.GetComponent<MeshRenderer>();
        transform.position = trackedObject.transform.position;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate() {}

    void Update() {
        // Get mouse values
        rotateHorizontal = Input.GetAxis("Mouse X") *sensitivity * Time.deltaTime;
        rotateVertical = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        
        // Get mouse values
        xRotationCamera -= rotateVertical;
        xRotationCamera = Mathf.Clamp(xRotationCamera, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotationCamera, 0f, 0f);
        trackedObject.Rotate(Vector3.up * rotateHorizontal);
        _renderer.enabled = (currentDistance > hideDistance);
    }
}
