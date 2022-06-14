/*
 * PlayerMovement
 * 
 * Controls player movement with arrow keys, spacebar and shift key.
 *
 * Luis Fernando Lomelin Ibarra
 * Jair Antonio Bautista Loranca
 * David Alejandro Martínez Tristán
 *
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float speed = 0.5f;
    private Vector3 motion;
    private Rigidbody rb;
    public float moveVer, moveHor;
    private Vector3 moveZ;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Up and down arrow keys: forward and backward
        moveVer = Input.GetAxis("Vertical");
        transform.position += (transform.forward * moveVer) * speed*Time.deltaTime;

        // Left and right arrow keys: sideways
        moveHor = Input.GetAxis("Horizontal");
        transform.position += (transform.right * moveHor) * speed * Time.deltaTime;

        // Spacebar and shift key: up and down
        moveZ = new Vector3(0, Input.GetAxis("Jump"), 0);
        rb.MovePosition(transform.position + moveZ * (speed*1f) * Time.deltaTime);
    }
}
