using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstacles;

    private float timeSpawn;
    public float startTimeSpawn;

    private void Update(){
        if(timeSpawn <= 0){
            int i = Random.Range(0, obstacles.Length);
            Instantiate(obstacles[i], transform.position, Quaternion.identity);
            timeSpawn = startTimeSpawn;
        }
        else{
            timeSpawn -= Time.deltaTime;
        }
    }

}
