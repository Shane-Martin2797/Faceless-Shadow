using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController2D))]
public class PlayerMovement : MonoBehaviour
{
    // movement config
    public float gravity = -25f;
    public float runSpeed = 8f;
    public float groundDamping = 20f; // how fast do we change direction? higher means faster
    public float inAirDamping = 5f;
    public float jumpHeight = 3f;
	private float cooldown = .2f;
	public float JumpAmount = 2;
	private float totalJumps = 0;

    [HideInInspector]
    private float normalizedHorizontalSpeed = 0;

    private CharacterController2D controller;
    //private //animator //animator;
    private Vector3 velocity;

    void Awake()
    {
       //animator = GetComponent<//animator>();
       controller = GetComponent<CharacterController2D>();
		totalJumps = 0;
    }

    // the Update loop contains a very simple example of moving the character around and controlling the animation
    void Update()
    {
		if (cooldown >= 0) {
			cooldown -= Time.deltaTime;
		}
		if (controller.isGrounded && totalJumps != 0) {
			totalJumps = 0;
		}
        // grab our current _velocity to use as a base for all calculations
        velocity = controller.velocity;

        if (controller.isGrounded)
            velocity.y = 0;

        if (InControl.InputManager.ActiveDevice.LeftStickX.IsPressed)
        {
            normalizedHorizontalSpeed = InControl.InputManager.ActiveDevice.LeftStickX.Value;
			if(normalizedHorizontalSpeed < 0){
            transform.localEulerAngles = Vector3.zero;
			} else if (normalizedHorizontalSpeed > 0){
				transform.localEulerAngles = new Vector3(0, 180, 0);
			}

            if (controller.isGrounded){
                //animator.Play(//animator.StringToHash("Run"));
			}
        }
        else
        {
            normalizedHorizontalSpeed = 0;

            if (controller.isGrounded){
                //animator.Play(//animator.StringToHash("Idle"));
			}
        }


        // we can only jump whilst grounded
		if (checkJumpInput() && (controller.isGrounded || totalJumps < JumpAmount))
        {
            velocity.y = Mathf.Sqrt(2f * jumpHeight * -gravity);
			totalJumps++;
            //animator.Play(//animator.StringToHash("Jump"));
        }


        // apply horizontal speed smoothing it
        var smoothedMovementFactor = controller.isGrounded ? groundDamping : inAirDamping; // how fast do we change direction?
        velocity.x = Mathf.Lerp(velocity.x, normalizedHorizontalSpeed * runSpeed, Time.deltaTime * smoothedMovementFactor);

        // apply gravity before moving
        velocity.y += gravity * Time.deltaTime;

        controller.move(velocity * Time.deltaTime);
    }

	bool checkJumpInput(){
		if (((InControl.InputManager.ActiveDevice.Action1.WasPressed) || (InControl.InputManager.ActiveDevice.LeftStickY.WasPressed))) {
			cooldown = .2f;
			return true;
		} else {
			return false;
		}
	}

}
