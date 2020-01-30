using UnityEngine;
using System.Collections;

public class BasicFlight : MonoBehaviour {
	public float moveSpeed = 10f;
	public float liftSpeed = 10f;
	public float turnSpeed = 10f;
	public float boostSpeed = 20f;
	public float bankSpeed = 10f;
    public float dampening = 1f;
    Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;

    }

    void Update ()
	{
        Vector3 newposition = transform.position - new Vector3(0, -4, 0);
        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, newposition, Time.deltaTime * dampening);
        mainCamera.transform.rotation = transform.rotation;


        RaycastHit hitInfo;

        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, 3f))
        {

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
            if ((x < 310 && x> 300))
            {
                transform.rotation = Quaternion.Euler(new Vector3(310, transform.eulerAngles.y, 0));
            }
        }
			
		
		//if(Input.GetKey(KeyCode.LeftArrow))
			//transform.Rotate(0f, 0f, bankSpeed * Time.deltaTime); // Bank left

        //if (Input.GetKey(KeyCode.RightArrow))
          //  transform.Rotate(0f, 0f, -bankSpeed * Time.deltaTime); // Bank right
	}
} 