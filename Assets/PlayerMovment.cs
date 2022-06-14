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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //motion = new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Jump"), Input.GetAxis("Vertical"));
        //rb.velocity = -motion * speed;
        //rb.MovePosition(transform.position - motion * speed);
        //rb.AddRelativeForce(motion*speed);
        moveVer = Input.GetAxis("Vertical");
        print(transform.position + (transform.forward * moveVer) * speed);
        //rb.MovePosition(transform.position + (transform.forward*moveVer) * speed);
        transform.position += (transform.forward * moveVer) * speed*Time.deltaTime;
        moveHor = Input.GetAxis("Horizontal");
        //rb.MovePosition(transform.position + (transform.right * moveHor) * speed);
        transform.position += (transform.right * moveHor) * speed * Time.deltaTime;
        moveZ = new Vector3(0, Input.GetAxis("Jump"), 0);
        rb.MovePosition(transform.position + moveZ * (speed*1f) * Time.deltaTime);

    }
}
