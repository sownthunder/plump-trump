using UnityEngine;
using System.Collections;

/* Walk Speed: 
 * How fast the player moves when walking (the default). 
 * Run Speed: 
 * How fast the player moves when running. 
 * Limit Diagonal Speed: 
 * If checked, strafing combined with moving forward 
 * or backward can't exceed the normal movement rate. 
 * The horizontal and vertical movement axes are computed 
 * independently, so if this isn't checked, then diagonal speed is 
 * about 1.4 times faster than normal. 
 * Toggle Run: 
 * If checked, the player can toggle between running 
 * and walking by pressing the run button (there must be a button 
 * set up in the Input Manager called "Run"). 
 * If not checked, the player normally walks unless holding down the run button. 
 * Jump Speed: 
 * How high the player jumps when hitting the jump button 
 * (there must be a button set up in the Input Manager called "Jump", 
 * which there is by default). 
 * Gravity: 
 * How fast the player falls when not standing on anything. 
 * Falling Damage Threshold: 
 * How many units the player can fall before taking damage when landing. 
 * The script as-is merely prints the total number of units that the player fell if 
 * this happens, but the FallingDamageAlert function can be changed to do anything 
 * the programmer desires. The "fallDistance" local variable in this function contains 
 * the number of vertical units between the initial point of "catching air" and the 
 * final impact point. If falling damage is irrelevant, change the number to "Infinity" 
 * in the inspector, and the function will never be called. 
 * Slide When Over Slope Limit: 
 * If checked, the player will slide down slopes that are greater than the Slope Limit 
 * as defined by the Character Controller. Attempting to jump up such slopes will also fail. 
 * The player has no control until resting on a surface that is under the Slope Limit. 
 * Slide On Tagged Objects: 
 * If checked, the player will slide down any objects tagged "Slide" when standing on them, 
 * regardless of how much or little they are sloped. (The tag "Slide" must be added to the 
 * Tag Manager.) This can be used to create chutes, icy surfaces, etc. Note that tagged 
 * objects with zero slope will cause sliding in an undefined direction. 
 * Slide Speed: 
 * How fast the player slides when on slopes as defined above. 
 * Air Control: 
 * If checked, the player will be able to control movement while in the air, 
 * except when Slide When Over Slope Limit/Slide On Tagged Objects is enabled 
 * and the player is jumping off a slope over the limit (otherwise the player 
 * would be able to jump up supposedly inaccessible slopes). 
 * Anti Bump Factor: 
 * An amount used to reduce or eliminate the "bumping" that can occur when walking down 
 * slopes, which is a result of the player constantly toggling between walking and falling 
 * small distances. The default of .75 is sufficient for most cases, although a little bit 
 * can still occur on steep slopes, assuming sliding isn't enabled. Larger amounts will 
 * stop this from ever happening, but too much can result in excessive falling speeds when 
 * stepping over an edge. Very small amounts will enable bumping, if that's desired for some reason. 
 * Anti Bunny Hop Factor: 
 * Bunny hopping is repeated jumping by virtue of continuously holding down the jump button. 
 * Often considered annoying and silly, especially in multiplayer games. 
 * If the anti-hop value is at least 1, the player must release the jump button 
 * (and the release-and-hold-in-the-air trick is ineffective)
 * and be grounded for the specified number of physics frames before being able to 
 * jump again. If the value is 0, then bunny hopping is allowed. If using noticeably 
 * large values, implementing some kind of visual indicator of jump availability is 
 * recommended to avoid player frustration.
 */

[RequireComponent (typeof (CharacterController))]
public class FPSWalkerEnhanced: MonoBehaviour {

	public float walkSpeed = 6.0f;

	public float runSpeed = 11.0f;

	// If true, diagonal speed (when strafing + moving forward or back) can't exceed normal move speed; otherwise it's about 1.4 times faster
	public bool limitDiagonalSpeed = true;

	// If checked, the run key toggles between running and walking. Otherwise player runs if the key is held down and walks otherwise
	// There must be a button set up in the Input Manager called "Run"
	public bool toggleRun = false;

	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;

	// Units that player can fall before a falling damage function is run. To disable, type "infinity" in the inspector
	public float fallingDamageThreshold = 10.0f;

	// If the player ends up on a slope which is at least the Slope Limit as set on the character controller, then he will slide down
	public bool slideWhenOverSlopeLimit = false;

	// If checked and the player is on an object tagged "Slide", he will slide down it regardless of the slope limit
	public bool slideOnTaggedObjects = false;

	public float slideSpeed = 12.0f;

	// If checked, then the player can change direction while in the air
	public bool airControl = false;

	// Small amounts of this results in bumping when walking down slopes, but large amounts results in falling too fast
	public float antiBumpFactor = .75f;

	// Player must be grounded for at least this many physics frames before being able to jump again; set to 0 to allow bunny hopping
	public int antiBunnyHopFactor = 1;

	private Vector3 moveDirection = Vector3.zero;
	private bool grounded = false;
	private CharacterController controller;
	private Transform myTransform;
	private float speed;
	private RaycastHit hit;
	private float fallStartLevel;
	private bool falling;
	private float slideLimit;
	private float rayDistance;
	private Vector3 contactPoint;
	private bool playerControl = false;
	private int jumpTimer;

	void Start() {
		controller = GetComponent<CharacterController>();
		myTransform = transform;
		speed = walkSpeed;
		rayDistance = controller.height * .5f + controller.radius;
		slideLimit = controller.slopeLimit - .1f;
		jumpTimer = antiBunnyHopFactor;
	}

	void FixedUpdate() {
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");
		// If both horizontal and vertical are used simultaneously, limit speed (if allowed), so the total doesn't exceed normal move speed
		float inputModifyFactor = (inputX != 0.0f && inputY != 0.0f && limitDiagonalSpeed)? .7071f : 1.0f;

		if (grounded) {
			bool sliding = false;
			// See if surface immediately below should be slid down. We use this normally rather than a ControllerColliderHit point,
			// because that interferes with step climbing amongst other annoyances
			if (Physics.Raycast(myTransform.position, -Vector3.up, out hit, rayDistance)) {
				if (Vector3.Angle(hit.normal, Vector3.up) > slideLimit)
					sliding = true;
			}
			// However, just raycasting straight down from the center can fail when on steep slopes
			// So if the above raycast didn't catch anything, raycast down from the stored ControllerColliderHit point instead
			else {
				Physics.Raycast(contactPoint + Vector3.up, -Vector3.up, out hit);
				if (Vector3.Angle(hit.normal, Vector3.up) > slideLimit)
					sliding = true;
			}

			// If we were falling, and we fell a vertical distance greater than the threshold, run a falling damage routine
			if (falling) {
				falling = false;
				if (myTransform.position.y < fallStartLevel - fallingDamageThreshold)
					FallingDamageAlert (fallStartLevel - myTransform.position.y);
			}

			// If running isn't on a toggle, then use the appropriate speed depending on whether the run button is down
			if (!toggleRun)
				speed = Input.GetButton("Run")? runSpeed : walkSpeed;

			// If sliding (and it's allowed), or if we're on an object tagged "Slide", get a vector pointing down the slope we're on
			if ( (sliding && slideWhenOverSlopeLimit) || (slideOnTaggedObjects && hit.collider.tag == "Slide") ) {
				Vector3 hitNormal = hit.normal;
				moveDirection = new Vector3(hitNormal.x, -hitNormal.y, hitNormal.z);
				Vector3.OrthoNormalize (ref hitNormal, ref moveDirection);
				moveDirection *= slideSpeed;
				playerControl = false;
			}
			// Otherwise recalculate moveDirection directly from axes, adding a bit of -y to avoid bumping down inclines
			else {
				moveDirection = new Vector3(inputX * inputModifyFactor, -antiBumpFactor, inputY * inputModifyFactor);
				moveDirection = myTransform.TransformDirection(moveDirection) * speed;
				playerControl = true;
			}

			// Jump! But only if the jump button has been released and player has been grounded for a given number of frames
			if (!Input.GetButton("Jump"))
				jumpTimer++;
			else if (jumpTimer >= antiBunnyHopFactor) {
				moveDirection.y = jumpSpeed;
				jumpTimer = 0;
			}
		}
		else {
			// If we stepped over a cliff or something, set the height at which we started falling
			if (!falling) {
				falling = true;
				fallStartLevel = myTransform.position.y;
			}

			// If air control is allowed, check movement but don't touch the y component
			if (airControl && playerControl) {
				moveDirection.x = inputX * speed * inputModifyFactor;
				moveDirection.z = inputY * speed * inputModifyFactor;
				moveDirection = myTransform.TransformDirection(moveDirection);
			}
		}

		// Apply gravity
		moveDirection.y -= gravity * Time.deltaTime;

		// Move the controller, and set grounded true or false depending on whether we're standing on something
		grounded = (controller.Move(moveDirection * Time.deltaTime) & CollisionFlags.Below) != 0;
	}

	void Update () {
		// If the run button is set to toggle, then switch between walk/run speed. (We use Update for this...
		// FixedUpdate is a poor place to use GetButtonDown, since it doesn't necessarily run every frame and can miss the event)
		if (toggleRun && grounded && Input.GetButtonDown("Run"))
			speed = (speed == walkSpeed? runSpeed : walkSpeed);
	}

	// Store point that we're in contact with for use in FixedUpdate if needed
	void OnControllerColliderHit (ControllerColliderHit hit) {
		contactPoint = hit.point;
	}

	// If falling damage occured, this is the place to do something about it. You can make the player
	// have hitpoints and remove some of them based on the distance fallen, add sound effects, etc.
	void FallingDamageAlert (float fallDistance) {
		print ("Ouch! Fell " + fallDistance + " units!");   
	}
}
