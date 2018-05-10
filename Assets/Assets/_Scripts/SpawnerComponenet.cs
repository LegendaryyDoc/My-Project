using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerComponenet : MonoBehaviour {

    public float spawnDelay = 3.0f;
    private float setSpawnDelay;
    float DT;

    public GameObject AIPrefab;
    public GameObject AITarget;


	// Use this for initialization
	void Start ()
    {
      AITarget = GameObject.FindObjectOfType<PlayerController>().gameObject;
    }

    public void SpawnAI(GameObject Prefab)
    {
        GameObject TempAI = Instantiate(Prefab, transform.position, transform.rotation);

        TempAI.GetComponent<AIController>().TargetPoint = AITarget;
    }
    public void Update()
        {
            DT = Time.deltaTime;

            setSpawnDelay -= DT;

            if (setSpawnDelay <= 0)
            {
                SpawnAI(AIPrefab);
            setSpawnDelay = spawnDelay;
            }
        } 
}
