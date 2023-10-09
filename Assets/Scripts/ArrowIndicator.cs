using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ArrowIndicator : MonoBehaviour
{
    public Transform goal;
    public float rotationSpeed;
    
        
    

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(goal.position - transform.position), rotationSpeed *Time.deltaTime);
    }
}
