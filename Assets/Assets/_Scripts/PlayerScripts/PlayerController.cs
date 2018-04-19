using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody RB;
    public Animator Anim;
    public float MovementSpeed = 100;


    public float SmoothDamp = 10;

    public GameObject bullet; 


    public Camera cam; 

    public Vector3 IP; // Movement Input

    float DT;

	// Use this for initialization
	void Start () {

        RB = GetComponent<Rigidbody>(); //Gets Rigidbody on object
        // anim passed in through editor
	}
	
    public void KeyInput()
    {
        IP.x = Input.GetAxisRaw("Horizontal");
        IP.z = Input.GetAxisRaw("Vertical");
    }

    public void doMovement(float DeltaTime, Vector3 MoveInput)
    {
        if (RB != null)
        {
            RB.AddForce(MoveInput * MovementSpeed * DeltaTime);
        }
    }

    public void doCombat()
    {
        //Movement();

        //if(Attacking)
        //{
        //    Instantiate(bullet)
        //}
    }

    public void updateAnim(Animator AnimationController)
    {
        if (AnimationController != null)
        {
            var localVel = transform.InverseTransformDirection(RB.velocity);
            AnimationController.SetFloat("ForwardSpeed", localVel.z);
            AnimationController.SetFloat("RightSpeed", localVel.x);
        }
    }
    public void doLook() //rotate our player towards the mouse cursor 
    {
        RaycastHit hit;

        Ray ray = cam.ScreenPointToRay(Input.mousePosition); //creating ray from mouse point on screen

        if(Physics.Raycast(ray, out hit, 100000)) //casting out a ray and populating our hit value
        {
            Vector3 forward = (transform.position - hit.point) * -1; //getting the direction between our position and our hitpoint position
            forward.y = 0; //zeroing out the y to stay upright
            forward.Normalize(); //Normalize to calculate direction

            transform.forward = Vector3.MoveTowards(transform.forward, forward, Time.deltaTime * 2); //Move our forward towards the direction between the positions 
        }
    }
	// Update is called once per frame
	void Update () {

        DT = Time.deltaTime;

        KeyInput();
        updateAnim(Anim);
	}

    private void FixedUpdate()
    {
        doLook();


        doMovement(DT, IP);
    }
}
