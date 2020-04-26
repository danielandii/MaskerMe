using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject obj;
    //private float currentSpeed;
    private float speed;

    void Start()
    {
        incraseSpeed getObj = obj.GetComponent<incraseSpeed>();
        speed = getObj.speed;
    }

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        //Debug.Log(speed);
    }

}
