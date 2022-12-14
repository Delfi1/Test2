extends Camera2D

onready var zoomFactor = 1 # Отдаление / приближение камеры, где 1 - 100%
onready var zoomSpeed = 20 # Скорость отдаления / приближения камеры
onready var zoomStep = 0.03 # Расстояние приближения
onready var factorStep = 0.01


func _ready():
	pass

func _process(delta):
	zoom.x = lerp(zoom.x, zoomFactor * zoom.x, zoomSpeed * delta)
	zoom.y = lerp(zoom.y, zoomFactor * zoom.y, zoomSpeed * delta)

	zoom.x = clamp(zoom.x, 0.35, 1.2)
	zoom.y = clamp(zoom.y, 0.35, 1.2)
	
	if zoomFactor > 1:
		zoomFactor -= factorStep
	elif zoomFactor < 1:
		zoomFactor += factorStep

func _input(event):
	
	if event is InputEventMouseButton:
		if event.button_index == BUTTON_WHEEL_UP:
			zoomFactor -= zoomStep	
		elif event.button_index == BUTTON_WHEEL_DOWN:
			zoomFactor += zoomStep;
