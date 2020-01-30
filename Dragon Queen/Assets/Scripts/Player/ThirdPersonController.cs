using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(CharacterController))]
public class ThirdPersonController : MonoBehaviour
{
    CharacterController controller;
    Vector3 moveDirection = Vector3.zero;

    public bool canMove = true;
    Transform cameraTarget;
    float cameraPitch = 40.0f;
    float cameraYaw = 0;
    float cameraDistance = 5.0f;
    bool lerpYaw = false;
    bool lerpDistance = false;

    public float cameraPitchSpeed = 2.0f;
    public float cameraPitchMin = -10.0f;
    public float cameraPitchMax = 80.0f;
    public float cameraYawSpeed = 5.0f;
    public float cameraDistanceSpeed = 5.0f;
    public float cameraDistanceMin = 2.0f;
    public float cameraDistanceMax = 12.0f;
    public float moveDirectionSpeed = 6.0f;
    public float turnSpeed = 3.0f;
    public float jumpSpeed = 8.0f;
    public float gravitySpeed = 20.0f;

    bool isWalled = false;

    public void Start()
    {
        //GetComponent<MeshRenderer>().material.color = Color.blue;

        controller = GetComponent<CharacterController>();
        cameraTarget = transform; // Camera will always face this
    }


    // Fixme: save all Inputs in Update, then look at saved values here and in FixedUpdate
    // Fixme: camera code should be in its own script probably
    public void LateUpdate()
    {

        // If mouse button down then allow user to look around
        if (Input.GetMouseButton(1))
        {
            cameraPitch += Input.GetAxis("Mouse Y") * cameraPitchSpeed;
            cameraPitch = Mathf.Clamp(cameraPitch, cameraPitchMin, cameraPitchMax);
            cameraYaw += Input.GetAxis("Mouse X") * cameraYawSpeed;
            cameraYaw = cameraYaw % 360.0f;
            lerpYaw = false;
        }
        else if (Input.GetMouseButton(2))
        {
            //cameraPitch= 40f;

            //cameraYaw= 0;
   
            //lerpYaw = false;
        }
        else
        {
            // If moving then make camera follow
            if (lerpYaw)
                cameraYaw = Mathf.LerpAngle(cameraYaw, cameraTarget.eulerAngles.y, 5.0f * Time.deltaTime);
        }

        // Zoom
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            cameraDistance -= Input.GetAxis("Mouse ScrollWheel") * cameraDistanceSpeed;
            cameraDistance = Mathf.Clamp(cameraDistance, cameraDistanceMin, cameraDistanceMax);
            lerpDistance = false;
        }

        // Calculate camera position
        Vector3 newCameraPosition = cameraTarget.position + (Quaternion.Euler(cameraPitch, cameraYaw, 0) * Vector3.back *1.5f* cameraDistance);

        // Does new position put us inside anything?
        RaycastHit hitInfo;
        if (Physics.Linecast(cameraTarget.position, newCameraPosition, out hitInfo))
        {
            newCameraPosition = hitInfo.point;
            lerpDistance = true;
        }
        else
        {
            if (lerpDistance)
            {
                float newCameraDistance = Mathf.Lerp(Vector3.Distance(cameraTarget.position, Camera.main.transform.position), cameraDistance, 1.0f * Time.deltaTime);
                newCameraPosition = cameraTarget.position + (Quaternion.Euler(cameraPitch, cameraYaw, 0) * Vector3.back * newCameraDistance);
            }
        }

        Camera.main.transform.position = newCameraPosition;
        Camera.main.transform.LookAt(cameraTarget.position);
    }

    // Fixme: add running
    public void FixedUpdate()
    {
        if (!canMove)
        {
            return;
        }

        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        // Have camera follow if moving
        if (!lerpYaw && (h != 0 || v != 0))
            lerpYaw = true;

        if (Input.GetMouseButton(2))
        {
            transform.rotation = Quaternion.Euler(0, cameraYaw, 0); // Face camera

        }

        else
            transform.Rotate(0, h * turnSpeed, 0); // Turn left/right

        //See if we hit a wall
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2f))
        {
            isWalled = true;
        }

        // Only allow user control when on ground
        if (controller.isGrounded)
        {
            if (Input.GetMouseButton(2))
                moveDirection = new Vector3(h, 0, v); // Strafe
            else
                moveDirection = Vector3.forward * v; // Move forward/backward

            isWalled = false;
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= moveDirectionSpeed;
            // Jumping
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
            // Speed Boost
            if (Input.GetKey(KeyCode.LeftShift))
                moveDirection *= 1.25f;
        }

        if (isWalled)
        {
            moveDirection.x = 0;
            moveDirection.z = 0;
        }
        moveDirection.y -= gravitySpeed * Time.deltaTime; // Apply gravity
        controller.Move(moveDirection * Time.deltaTime);
    }
}

