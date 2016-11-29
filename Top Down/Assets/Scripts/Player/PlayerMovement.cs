using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour{

    public float moveSpeed;

    private Rigidbody rb;    //TODO: Is not currently in use.

    
    private Vector3 moveInput;
    private Vector3 moveVelocity;

       

    private Camera mainCamera;

    public GunController theGun;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
    }

    void Update()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;


        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

            transform.LookAt(new Vector3(pointToLook.x,transform.position.y ,pointToLook.z)); // Makes the object look at the position of the ray cast.

        }


        if (Input.GetMouseButtonDown(0))
        {
            theGun.isFiring = true;           
        }
        if (Input.GetMouseButtonUp(0))
        {
            theGun.isFiring = false;

        }

        

    }

    
    void FixedUpdate()
    {
        rb.velocity = moveVelocity;


    }


}
