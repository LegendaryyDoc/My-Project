using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHealthComponenet : MonoBehaviour {

    public float MaxHealth = 100;

    public float CurrentHealth;

    public bool destroyOnDeath;


	// Use this for initialization
	void Start () {
        CurrentHealth = MaxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
