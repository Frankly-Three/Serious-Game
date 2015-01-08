private var motor : CharacterMotor;
private var prevY: float = 0.0f;
private var jump : boolean = false;
private var model : GameObject;
private var anim : Animator;
private var offset : float = 0.0f;

// Use this for initialization
function Awake () {
	motor = GetComponent(CharacterMotor);
	
	model = GameObject.FindGameObjectWithTag("AnimModel");
	anim = model.GetComponent("Animator");
}

// Update is called once per frame
function Update () {
	// Get the input vector from keyboard or analog stick
	var directionVector = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
	
	if (directionVector != Vector3.zero) {
		// Get the length of the directon vector and then normalize it
		// Dividing by the length is cheaper than normalizing when we already have the length anyway
		var directionLength = directionVector.magnitude;
		directionVector = directionVector / directionLength;
		
		// Make sure the length is no bigger than 1
		directionLength = Mathf.Min(1, directionLength);
		
		// Make the input vector more sensitive towards the extremes and less sensitive in the middle
		// This makes it easier to control slow speeds when using analog sticks
		//directionLength = directionLength * directionLength;
		
		// Multiply the normalized direction vector by the modified length
		directionVector = directionVector * directionLength;
		
		//var speed = ((transform.position - lastPosition) / Time.fixedDeltaTime);
		//Debug.Log(Time.fixedDeltaTime + " - " + speed.x);
		//lastPosition = transform.position;
	//UnityEngine.Debug.Log(prevY + 1325);
	
	}
	
	var script = model.GetComponent("OrientModel");
	var speed : Vector3 = GameObject.FindGameObjectWithTag("Player").GetComponent("CharacterMotor").GetVelocity();

	if( Mathf.Abs(speed.x) > 0.00001f ) {
		script.SetDirection(speed.x > 0);
	}
	
    if( Input.GetButtonDown("Jump") && motor.grounded ) {
        anim.Play(0, -1, 0.11f);
	}
	
	var target: float;
	if(motor.grounded){
		target = 0.0f;
	}else{
		target = 1.0f;
	}
	offset = offset + (target - offset) / 3.0f;
	var vertical : float = Mathf.Abs(speed.y / 20) + offset;
	var speedx : float = Mathf.Abs(speed.x);
	
	model.GetComponent("Animator").SetFloat("Vertical", vertical);
	model.GetComponent("Animator").SetFloat("Speed", speedx);
	
	// Apply the direction to the CharacterMotor
	motor.inputMoveDirection = transform.rotation * directionVector;
	motor.inputJump = Input.GetButton("Jump");
}

// Require a character controller to be attached to the same game object
@script RequireComponent (CharacterMotor)
@script AddComponentMenu ("Character/FPS Input Controller")
