using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour

{


    private CharacterController controller;
    private Vector3 playerVelocity;
    public float speed = 5f;
    private bool isGrounded;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;
    public bool lerpCrouch;
    public bool crouching;
    public bool sprinting;
    public float crouchTimer;
    private AudioSource walkAudioSource;
    private AudioSource jumpAudioSource;

    //sounds 
    public AudioClip walkSound;
    public AudioClip sprintSound;
    public AudioClip jumpSound;
    public float sprintPitchMultiplier = 1.5f;

    private float timeSinceLastSound = 0f;
    private float soundInterval = 0.5f; // Adjust this value to set the interval

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        walkAudioSource = gameObject.AddComponent<AudioSource>();
        jumpAudioSource = gameObject.AddComponent<AudioSource>();
        walkAudioSource.volume = 0.2f;
        jumpAudioSource.volume = 0.2f;
    }


        // Update is called once per frame
        void Update()
    {
        isGrounded = controller.isGrounded;
        if (lerpCrouch)
        {
            crouchTimer += Time.deltaTime;
            float p = crouchTimer / 1;
            p *= p;
            if (crouching)
                controller.height = Mathf.Lerp(controller.height, 0.3f, p);
            else
                controller.height = Mathf.Lerp(controller.height, 2, p);

            if (p > 1)
            {
                lerpCrouch = false;
                crouchTimer = 0f;
            }

        }
        timeSinceLastSound += Time.deltaTime;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        bool hasInput = Mathf.Abs(horizontalInput) > 0.1f || Mathf.Abs(verticalInput) > 0.1f;

        if (hasInput && timeSinceLastSound >= soundInterval)
        {
            PlaySoundEffect(walkAudioSource, walkSound);

            // Reset the timer
            timeSinceLastSound = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }





    //Recieve the inputs for out InputManager.cs and apply them to our character controller
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2;
        controller.Move(playerVelocity * Time.deltaTime);
        Debug.Log(playerVelocity.y);

        bool hasInput = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);

        if (hasInput && timeSinceLastSound >= soundInterval)
        {
            PlaySoundEffect(walkAudioSource, walkSound);

            // Reset the timer
            timeSinceLastSound = 0f;
        }
    }









    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            PlaySoundEffect(jumpAudioSource, jumpSound);
        }
    }

    public void Crouch()
    {
        crouching = !crouching;
        crouchTimer = 0;
        lerpCrouch = true;
    }
    public void Sprint()
    {
        sprinting = !sprinting;

        float pitchMultiplier = sprinting ? sprintPitchMultiplier : 1.0f;

        bool hasInput = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);

        if (hasInput && timeSinceLastSound >= soundInterval)
        {
            PlaySoundEffect(walkAudioSource, walkSound, pitchMultiplier);

            // Reset the timer
            timeSinceLastSound = 0f;
        }

        if (sprinting)
            speed = 15f;
        else
            speed = 8f;
    }


    private void PlaySoundEffect(AudioSource audioSource, AudioClip clip, float pitch = 1.0f)
    {
        audioSource.clip = clip;
        audioSource.pitch = pitch;
        audioSource.Play();
    }
}


