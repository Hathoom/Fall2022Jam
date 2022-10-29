using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
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

    // Pick things up
    private float pickupRange = 2f;

    public float distanceToNearestMetal = float.MaxValue;
    public float baseDistance;                      // The distance where the pitch of the metal detector is 1
    // Note: maybe change it later to only being a list of objects that collide with a larger hit box around the player
    public GameObject[] metalList;                  // List of all the metal objects in the game
    public AudioSource metalBeep;
    public float minBeepPitch;
    public float maxBeepPitch;

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
        PlayerMovement();

        metalList = GameObject.FindGameObjectsWithTag("Metal");

        for (int i = 0; i < metalList.Length; i++) {
            if (Vector3.Distance(transform.position, metalList[i].transform.position) < distanceToNearestMetal) {
                distanceToNearestMetal = Vector3.Distance(transform.position, metalList[i].transform.position);
                Debug.Log(distanceToNearestMetal);
            }
        }

        if (distanceToNearestMetal != 0)
            metalBeep.pitch = baseDistance / distanceToNearestMetal;
            //Debug.Log(metalBeep.pitch);
            if (metalBeep.pitch < minBeepPitch) {
                metalBeep.pitch = minBeepPitch;
                Debug.Log("lowest pitch");
            }
            if (metalBeep.pitch > maxBeepPitch) {
                metalBeep.pitch = maxBeepPitch;
                Debug.Log("highest pitch");
            }
        else
            metalBeep.pitch = 0;

        distanceToNearestMetal = float.MaxValue;
    }

    void PlayerMovement() {
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

            if (Physics.Raycast(camTransform.position, camTransform.TransformDirection(Vector3.forward), out hit, pickupRange))
            {
                // If we hit the object, destroy it or pick it up.
                // Debug.DrawRay(camTransform.position, camTransform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
                
                Debug.Log(hit.collider);
                if (hit.collider.tag == "Pickupable" || hit.collider.tag == "Metal")
                {
                    Destroy(hit.collider.gameObject);
                }
                //Debug.Log("Did Hit");
            }
            else
            {
                //Debug.DrawRay(camTransform.position, camTransform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
                //Debug.Log("Did not Hit");
            }
        }
    }
}
