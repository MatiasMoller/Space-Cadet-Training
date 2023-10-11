using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Vector3 rotateAmount;
    public float speed = 2;

    void Update()
    {
        transform.Rotate(rotateAmount * Time.deltaTime);
        
   
   
       

        transform.Translate(Vector3.right * Mathf.Sin(Time.time) * 2f * Time.deltaTime);
    }
}
