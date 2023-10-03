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
        
   
   
        // Moves the object forward at two units per second.
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
  

        }
}
