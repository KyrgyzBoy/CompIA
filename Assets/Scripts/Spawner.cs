using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] enemies;
	public Vector3 spawnValues;
    public Vector3 spawnPosition;
    public float spawnTime = 10f;

	int randEnemy;

    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Respawn");
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }
    void Spawn()
    {
        spawnPosition.x = Random.Range(-10, 10);
        spawnPosition.y = 0.5f;
        spawnPosition.z = Random.Range(-10, 10);

        Instantiate(enemies[Random.Range(0,1)], spawnPosition, Quaternion.identity);
        spawnTime = Random.Range(3, 15);
    }
}
