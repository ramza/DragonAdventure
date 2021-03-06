using UnityEngine;
using System.Collections;

public class BasicFlight : MonoBehaviour {



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
    public float jumpSpeed = 8.0f;
    public float gravitySpeed = 20.0f;

    public float moveSpeed = 10f;
	public float liftSpeed = 10f;
	public float turnSpeed = 10f;
	public float boostSpeed = 20f;
	public float bankSpeed = 10f;
    public float dampening = 1f;
    Camera mainCamera;

    bool changeView = false;

    private void Start()
    {
        cameraTarget = GameObject.FindGameObjectWithTag("Dragon").transform;
        mainCamera = Camera.main;

    }

    public void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            changeView = !changeView;
        }
        if (changeView)
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
            Vector3 newCameraPosition = cameraTarget.position + (Quaternion.Euler(cameraPitch, cameraYaw, 0) * Vector3.back * 1.5f * cameraDistance);

            // Does new position put us inside anything?
            RaycastHit hitInfo;
            if (Physics.Linecast(cameraTarget.position, newCameraPosition, out hitInfo))
            {
                print("hitting the dragon back");
                //newCameraPosition = hitInfo.point+Vector3.up*2f;
                //lerpDistance = true;
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
    }


    void Update ()
    {
        if (!changeView)
        {
            Vector3 newposition = transform.position - new Vector3(0, -4, 0);
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, newposition, Time.deltaTime * dampening);

            mainCamera.transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0);
        }



        RaycastHit hitInfo;
        // allow the dragon to move forward if we hit the water
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, 4f))
        {
            print("dragon hit a " + hitInfo.transform.name);
            if(hitInfo.transform.gameObject.layer == 4)
            {
                if (Input.GetKey(KeyCode.W))
                    transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime); // As it says forward speed
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.W))
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime); // As it says forward speed
        }

		if(Input.GetKey(KeyCode.S))
			transform.Translate(Vector3.forward * boostSpeed * Time.deltaTime); //Turbo speed
		if(Input.GetKey(KeyCode.A))
			transform.Rotate(0f, -turnSpeed * Time.deltaTime, 0f, Space.World); // Left turn in relation to world not object
		if(Input.GetKey(KeyCode.D))
			transform.Rotate(0f, turnSpeed * Time.deltaTime, 0f, Space.World); // As above but right

		if(Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(liftSpeed * Time.deltaTime, 0f, 0f); // Descends object Same as actual plane joy stick forward is down
            float x = transform.eulerAngles.x;
            if ( x > 45 && x < 300)
            {
                transform.rotation = Quaternion.Euler(new Vector3(45, transform.eulerAngles.y, 0));
            }
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(-liftSpeed * Time.deltaTime, 0f, 0f); // Raises object
            float x = transform.eulerAngles.x;
            if ((x < 300 && x> 290))
            {
                transform.rotation = Quaternion.Euler(new Vector3(310, transform.eulerAngles.y, 0));
            }
        }
			
		
		if(Input.GetKey(KeyCode.LeftArrow))
			transform.Rotate(0f, 0f, bankSpeed * Time.deltaTime); // Bank left

        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(0f, 0f, -bankSpeed * Time.deltaTime); // Bank right
	}
} 