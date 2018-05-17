using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour {

    public float MaxHealth = 100;

    public float CurrentHealth;

    public float damage;

    public GameObject ParticlePrefab;


	// Use this for initialization
	void Start () {
        CurrentHealth = MaxHealth;
	}
    
    public void Die()
    {
        GameObject Temp = Instantiate(ParticlePrefab, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(Temp, .5f);
    }
	
	// Update is called once per frame
	void Update () {
		if(CurrentHealth <= 0)
        {
            Die();
        }
	}

    public void TakeDamage(float DamageAmount)
    {
        CurrentHealth -= DamageAmount;
    }
}