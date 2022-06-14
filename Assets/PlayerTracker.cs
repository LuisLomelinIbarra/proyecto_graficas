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
    // Start is called before the first frame update
    void Start()
    {
        ahead = new GameObject("ahead");
        _renderer = trackedObject.gameObject.GetComponent<MeshRenderer>();
        transform.position = trackedObject.transform.position;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        
        //transform.RotateAround(trackedObject.transform.position, -Vector3.up, rotateHorizontal * sensitivity); 
        //transform.RotateAround(Vector3.zero, transform.right, rotateVertical * sensitivity); 
    }

    void Update() {
        rotateHorizontal = Input.GetAxis("Mouse X") *sensitivity * Time.deltaTime;
        rotateVertical = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        //print(rotateHorizontal);
        xRotationCamera -= rotateVertical;
        xRotationCamera = Mathf.Clamp(xRotationCamera, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotationCamera, 0f, 0f);
        trackedObject.Rotate(Vector3.up * rotateHorizontal);
        _renderer.enabled = (currentDistance > hideDistance);
        //transform.position = trackedObject.transform.position;


    }

    // Update is called once per frame
    /*void Update()
    {
        ahead.transform.position = trackedObject.position + trackedObject.forward * (maxDistance * 0.25f);
        currentDistance += Input.GetAxisRaw(moveAxis) * moveSpeed * Time.deltaTime;
        currentDistance = Mathf.Clamp(currentDistance,0,maxDistance);
        //transform.position = Vector3.MoveTowards(transform.position, trackedObject.position + Vector3.up * currentDistance - trackedObject.forward * (currentDistance +maxDistance*0.5f),updateSpeed*Time.deltaTime);
        //transform.LookAt(ahead.transform);
        _renderer.enabled = (currentDistance > hideDistance);
    }*/
}
