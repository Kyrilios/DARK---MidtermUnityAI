using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public float rotSpeed = 10f;
    
    private Rigidbody myRigidbody;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    private Camera mainCamera;

    public GunController theGun;

    void Start()
    {
      myRigidbody = GetComponent<Rigidbody>();   
      mainCamera = FindObjectOfType<Camera>();
    }
   
    void Update()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;

        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if(groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3  pointToLook = cameraRay.GetPoint(rayLength);   
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

            // Vector3 direction = (new Vector3(pointToLook.x, 0f, pointToLook.z));

            // this.transform.rotation = Quaternion.Slerp(this.transform.rotation, 
			// 									Quaternion.LookRotation(direction), 
			// 									Time.deltaTime*rotSpeed);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));


        }
        if(Input.GetMouseButtonDown(0))
        {
            theGun.isFiring = true;
        }
        if(Input.GetMouseButtonUp(0))
        {
            theGun.isFiring = false;
        }

    }

    void FixedUpdate()
    {
        myRigidbody.velocity = moveVelocity;



    }
}
