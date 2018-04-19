using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float movespeed;

    public GameObject Player;

    private Vector3 offset; 

    public void CameraMoveTowards()
    {
        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position + offset, movespeed * Time.deltaTime); 
    }
	// Use this for initialization
	void Start () {

        offset = transform.position - Player.transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {
        CameraMoveTowards();
            
		
	}
}
