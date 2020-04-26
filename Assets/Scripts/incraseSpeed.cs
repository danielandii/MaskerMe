using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class incraseSpeed : MonoBehaviour
{
    public float speed;

    void Update()
    {
        speed += Time.deltaTime / 100;
        //setSpeed += speed;
        //Debug.Log(speed);

    }

}
