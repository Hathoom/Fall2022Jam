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
        cam = Camera.main;
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
        currentY += Input.GetAxis("Mouse Y") * sensitivityY;

        Quaternion cameraRotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.rotation = cameraRotation;
    }
}
