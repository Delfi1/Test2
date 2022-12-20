extends KinematicBody2D

const ACCELERATION = 500
const MAX_SPEED = 120
const FRICTION = 0.25
const GRAVITY = 280
const JUMP_FORCE = 150
const AIR_RESISTANCE = 0.015

onready var sprite = $Sprite
#onready var animation = $AnimationPlayer

var motion = Vector2.ZERO

func _ready():
	hp(false)

func _physics_process(delta):
	var x_input = Input.get_action_strength("ui_right") - Input.get_action_strength("ui_left")
	
	if x_input != 0:
		motion.x += x_input * ACCELERATION * delta	
		motion.x = clamp(motion.x, -MAX_SPEED, MAX_SPEED)
		sprite.flip_h = x_input < 0
		
	motion.y += GRAVITY * delta
	
	if is_on_floor():
		if x_input == 0:
			motion.x = lerp(motion.x, 0, FRICTION)
		
		if Input.is_action_pressed("ui_up"):
			motion.y  = -JUMP_FORCE
	else:
		
		if Input.is_action_just_released("ui_up") and motion.y < -JUMP_FORCE/2:
			motion.y = -JUMP_FORCE/2
		
		if x_input == 0:
			motion.x = lerp(motion.x, 0, AIR_RESISTANCE)
		
	motion = move_and_slide(motion, Vector2.UP)

func hp(state):
	if state == true:
		pass
	else:
		get_node("TextureProgress").visible = false;
