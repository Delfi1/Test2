extends Node

const END_VALUE = 1

var is_active = false
var time_start
var duration_ms
var start_value


func start(duration = 2.5, strength = 0.9):
	time_start = OS.get_ticks_msec()
	duration_ms = duration * 1000
	start_value = 1 - strength
	Engine.time_scale = start_value
	is_active = true

var timer = null
var slow_mode_reload = 5.5
var can_use = false

func _ready():
	timer = get_node("Timer")
	timer.set_wait_time(slow_mode_reload)
	timer.connect("timeout", self, "_on_timeout_complete")

func _on_timeout_complete():
	can_use = true

func _process(delta):
	#print("test ", is_active)
	if Input.is_action_pressed("Slow") and can_use:
		start()
		can_use = false
		timer.start()

	if is_active:
		var current_time = OS.get_ticks_msec() - time_start
		var value = circl_easy_in(current_time, start_value, END_VALUE, duration_ms)
		if current_time >= duration_ms:
			is_active = false
			value = END_VALUE
		Engine.time_scale = value


func circl_easy_in(time, sv, ev, duration):
	time /= duration
	return -ev * (sqrt(1 - time * time) - 1) + sv 
