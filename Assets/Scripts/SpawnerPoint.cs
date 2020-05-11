using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPoint : MonoBehaviour
{
    public GameObject[] obstacle;
    // Start is called before the first frame update
    void Start()
    {
        int i = Random.Range(0, obstacle.Length);
        Instantiate(obstacle[i], transform.position, Quaternion.identity);   
    }
}
