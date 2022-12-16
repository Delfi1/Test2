extends Node2D

var r = "res://Scenes/Game.tscn"

func _process(delta):
	if Input.is_action_just_pressed("Reload"):
		get_tree().reload_current_scene()
