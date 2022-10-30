using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager gameManager;

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

    // Metal Detector Sounds
    public float distanceToNearestMetal = float.MaxValue;
    public float baseDistance;                      // The distance where the pitch of the metal detector is 1
    // Note: maybe change it later to only being a list of objects that collide with a larger hit box around the player
    public GameObject[] metalList;                  // List of all the metal objects in the game
    public AudioSource metalBeep;
    public float minBeepPitch;
    public float maxBeepPitch;

    // Swap inventory items

    // Only 2 equippables right now so that value will be 2
    public GameObject[] equippables = new GameObject[2];
    public GameObject metalDetector;
    public GameObject shovel;
    // A number to remember what is equipped
    private int equipped = 0;

    private Transform backTransform;
    private Transform handTransform;



    // Start is called before the first frame update
    void Start()
    {
        rbody = gameObject.GetComponent<Rigidbody>();
        cam = gameObject.GetComponentInChildren<Camera>();
        camTransform = transform;
        handTransform = gameObject.transform.GetChild(1);
        backTransform = gameObject.transform.GetChild(2);

        equippables[0] = metalDetector;
        equippables[1] = shovel;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();

        // Swap Item
        if (Input.GetKeyDown("0"))
        {
            UnequipItems();
            equipped = 0;

            Debug.Log("Switched to 0");
        }
        if (Input.GetKeyDown("1"))
        {
            UnequipItems();
            equipped = 1;
            EquipItem(equipped);
            Debug.Log("Switched to 1");
        }
        if (Input.GetKeyDown("2"))
        {
            UnequipItems();

            equipped = 2;

            EquipItem(equipped);
            Debug.Log("Switched to 2");
        }

        metalList = GameObject.FindGameObjectsWithTag("Metal");

        if (equipped == 1)
        {
        for (int i = 0; i < metalList.Length; i++) {
            if (Vector3.Distance(transform.position, metalList[i].transform.position) < distanceToNearestMetal) {
                distanceToNearestMetal = Vector3.Distance(transform.position, metalList[i].transform.position);
            }
        }

        if (distanceToNearestMetal != 0) {
            metalBeep.pitch = baseDistance / distanceToNearestMetal;
            if (metalBeep.pitch < minBeepPitch) {
                metalBeep.pitch = minBeepPitch;
                //Debug.Log("lowest pitch");
            }
            if (metalBeep.pitch > maxBeepPitch) {
                metalBeep.pitch = maxBeepPitch;
                //Debug.Log("highest pitch");
            }
        }
        else
            metalBeep.pitch = 0;
        
        }
        else
        {
            metalBeep.pitch = 0;
        }

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
                    gameManager.AddItem(hit.collider.GetComponent<Item>().itemID);
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

    void UnequipItems() {
        // if something is equipped: unequip it
        if (equipped != 0)
        {
            equippables[equipped - 1].transform.position = backTransform.position;
        }
    }

    void EquipItem(int num) {
        if (num == 0)
        {
            //Do Nothing
        }
        
        equippables[num - 1].transform.position = handTransform.position;
    }
}
