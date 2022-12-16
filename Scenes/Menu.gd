extends Node2D

var game = "res://Scenes/Game.tscn"


func _on_Play_Button_pressed():
	get_tree().change_scene(game)
	
