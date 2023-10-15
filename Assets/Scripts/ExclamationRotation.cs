using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExclamationRotation : MonoBehaviour
{
    public float jumpHeight =100f;  // Adjust this value for the desired height
    private float jumpSpeed = 0.5f;
    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        float newY = initialPosition.y + Mathf.PingPong(Time.time * jumpSpeed, jumpHeight / 10) - jumpHeight;

        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

}
