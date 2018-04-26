using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletContoller : MonoBehaviour
{
    public GameObject Owner;

    public float DamageAmount = 10; //how much damage this bullet does

    public float BulletSpeed = 50; //how fast this bullet should shoot

    public float BulletDelay = .2f; //how often we can shoot this bullet

    public void OnTriggerEnter(Collider other) //Other = object we collide with
    {
        if (other.gameObject != Owner) //Verify that bullet is not in collision with owner
        {
            HealthComponent Temp = other.GetComponent<HealthComponent>(); //Store a reference to the owners healthcompononent
            if(Temp != null) //if the owner has a health component
            {
                Temp.TakeDamage(DamageAmount); //Call take damage from health componenet 
            }
            Destroy(gameObject);
        }
    }
}