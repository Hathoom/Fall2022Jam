using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Player movement
    public float moveSpeed = 5f;
    public float sprintSpeed = 10f;

    // Rigidbody
    private Rigidbody rbody;

    // Game Manager
    //public GameManager gameManager;

    // Rotation/Camera Rotation
    //get camera transform

    private Transform camTransform;

    private float currentX = 0f;
    private float currentY = 0f;

    public float sensitivityX = 4.0f;
    public float sensitivityY = 1.0f;

    private Camera cam;



    // Start is called before the first frame update
    void Start()
    {
        rbody = gameObject.GetComponent<Rigidbody>();
        cam = gameObject.GetComponentInChildren<Camera>();
        camTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        // player movement
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        //set the rigidbody's velocity
        Vector3 targetDirection = new Vector3(x, 0f, z);
        targetDirection = Camera.main.transform.TransformDirection(targetDirection);
        rbody.velocity = new Vector3(targetDirection.x, rbody.velocity.y, targetDirection.z);

        // camera rotation
        currentX += Input.GetAxis("CameraHorizontal");
        currentY += Input.GetAxis("CameraVertical");

        currentX += Input.GetAxis("Mouse X") * sensitivityX;
        currentY += Input.GetAxis("Mouse Y") * sensitivityY * -1;

        Quaternion cameraRotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.rotation = cameraRotation;

        //Interact
        if (Input.GetAxis("Interact") > 0)
        {
            // create a Ray
            RaycastHit hit;

            if (Physics.Raycast(camTransform.position, camTransform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                Debug.DrawRay(camTransform.position, camTransform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
                Debug.Log(hit.collider);
                Debug.Log("Did Hit");
            }
            else
            {
                Debug.DrawRay(camTransform.position, camTransform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
                Debug.Log("Did not Hit");
            }
        }
    }
}
