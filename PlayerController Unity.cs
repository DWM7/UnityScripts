/*
MonoBehaviour is a parent script
- transform (Describes where you are in the world, how your rotated in the world
and the scale of yourself in the world)
* transform.forward is where we are facing in the forward position
* transform.position is where we currently are
- gameObject refers to itself (GameObject.Destroy(gameObject);) example

*1 Unity code understands things like the "jump button" represents all things
that could be the jump button example space bar or A on a controller.

Time.deltaTime is the time between frames
*/
using UnityEngine;
using System.Collections;
public class PlayerController : MonoBehaviour {
	// Rotation speeds in degrees per second
	public float RollSpeed = 30.0f;
	public float PitchSpeed = 15.0f;
	public float YawSpeed = 0.1f;

	public float Speed = 5.0f;

    public Rigidbody PlayerRB;
	
	// Update is called once per frame
	void Update () {
		// Grab the input from the player
		/* *1 for an example here typing ("Horizontal") makes unity know
		that you mean the inputs of "A" or "D" or joystick ect. */
		float hInput = -Input.GetAxis ("Horizontal");
		float vInput = Input.GetAxis ("Vertical");

		// Vector3 stores 3 floats
		//  - Can be used to represent position
		//  - Can be used to represent rotation using roll, pitch and yaw (aka. euler angles)

        // Retrieve the roll angle
        float rollAngle = transform.eulerAngles.z;
        if (rollAngle > 180.0f)
            rollAngle -= 360.0f;

		// Calculate the change (ie. delta) in rotation
		/*
		(vInput * PitchSpeed * Time.deltaTime) the reason you times by a speed
		and deltaTime is to make it smooth, because updates calls upon frames
		so if a frame dropped it still keeps it consistant.
		*/
		Vector3 deltaRotation = new Vector3 (vInput * PitchSpeed * Time.deltaTime,
		                                    -rollAngle * YawSpeed * Time.deltaTime,
		                                     hInput * RollSpeed * Time.deltaTime);

		// Apply the deltaRotation
        transform.Rotate(deltaRotation);
	}
	
	void FixedUpdate()
    {
        // Move the player forwards
        Vector3 newPosition = transform.position + transform.forward * Speed * Time.fixedDeltaTime;
        PlayerRB.MovePosition(newPosition);
    }
}