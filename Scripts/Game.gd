extends Node2D

var r = "res://Scenes/Game.tscn"
var menu = "res://Scenes/Menu.tscn"

func _process(delta):
	#if Input.is_action_just_pressed("Reload"):
		#get_tree().reload_current_scene()
	if Input.is_action_just_pressed("ui_cancel") and Engine.time_scale == 1.0:
		get_tree().change_scene(menu)
