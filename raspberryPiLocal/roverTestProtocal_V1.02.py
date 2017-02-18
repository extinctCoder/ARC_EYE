import pyfirmata
PORT = '/dev/ttyACM0'
motorA1_1 = 2
motorA1_2 = 3
motorA2_1 = 4
motorA2_2 = 5
motorB1_1 = 6
motorB1_2 = 7
motorB2_1 = 8
motorB2_2 = 9
motorC1_1 = 10
motorC1_2 = 11
motorC2_1 = 12
motorC2_2 = 13

DELAY = 1

def printPiMsg(msg):
	print "raspberryPi\t:", msg
	return
def printArduinoMsg(msg):
	print "ARDUINO\t\t:", msg
	return
def printErrorMsg(expr):
	printPiMsg("arduino connection failed")
	print "error\t\t:", expr
	return

def roverForwardDerection():
	printPiMsg("command send")
	arduino.digital[motorA1_1].write(1)
	arduino.digital[motorA1_2].write(0)
	arduino.digital[motorB1_1].write(1)
	arduino.digital[motorB1_2].write(0)
	arduino.digital[motorC1_1].write(1)
	arduino.digital[motorC1_2].write(0)
	arduino.digital[motorA2_1].write(1)
	arduino.digital[motorA2_2].write(0)
	arduino.digital[motorB2_1].write(1)
	arduino.digital[motorB2_2].write(0)
	arduino.digital[motorC2_1].write(1)
	arduino.digital[motorC2_2].write(0)
	arduino.pass_time(DELAY)
	printArduinoMsg("command excuated")
	printPiMsg("work done")
	return
def roverBackwardDerection():
	printPiMsg("command send")
	arduino.digital[motorA1_1].write(0)
	arduino.digital[motorA1_2].write(1)
	arduino.digital[motorB1_1].write(0)
	arduino.digital[motorB1_2].write(1)
	arduino.digital[motorC1_1].write(0)
	arduino.digital[motorC1_2].write(1)
	arduino.digital[motorA2_1].write(0)
	arduino.digital[motorA2_2].write(1)
	arduino.digital[motorB2_1].write(0)
	arduino.digital[motorB2_2].write(1)
	arduino.digital[motorC2_1].write(0)
	arduino.digital[motorC2_2].write(1)
	arduino.pass_time(DELAY)
	printArduinoMsg("command excuated")
	printPiMsg("work done")
	return
def roverLeftDerection():
	printPiMsg("command send")
	arduino.digital[motorA1_1].write(1)
	arduino.digital[motorA1_2].write(0)
	arduino.digital[motorB1_1].write(1)
	arduino.digital[motorB1_2].write(0)
	arduino.digital[motorC1_1].write(1)
	arduino.digital[motorC1_2].write(0)
	arduino.digital[motorA2_1].write(0)
	arduino.digital[motorA2_2].write(1)
	arduino.digital[motorB2_1].write(0)
	arduino.digital[motorB2_2].write(1)
	arduino.digital[motorC2_1].write(0)
	arduino.digital[motorC2_2].write(1)
	arduino.pass_time(DELAY)
	printArduinoMsg("command excuated")
	printPiMsg("work done")
	return
def roverRightDerection():
	printPiMsg("command send")
	arduino.digital[motorA1_1].write(1)
	arduino.digital[motorA1_2].write(0)
	arduino.digital[motorB1_1].write(0)
	arduino.digital[motorB1_2].write(1)
	arduino.digital[motorC1_1].write(0)
	arduino.digital[motorC1_2].write(1)
	arduino.digital[motorA2_1].write(1)
	arduino.digital[motorA2_2].write(0)
	arduino.digital[motorB2_1].write(1)
	arduino.digital[motorB2_2].write(0)
	arduino.digital[motorC2_1].write(1)
	arduino.digital[motorC2_2].write(0)
	arduino.pass_time(DELAY)
	printArduinoMsg("command excuated")
	printPiMsg("work done")
	return
 

try:
	arduino = pyfirmata.Arduino(PORT)
except Exception as e:
	printErrorMsg()
else:
	printPiMsg("rover is ready to movement")
	while 1:
		command = raw_input("please chose your command: ")
		if command == 'w':
			roverForwardDerection()
		elif command == 'a':
			roverLeftDerection()
		elif command == 'd':
			roverRightDerection()
		elif command == 's':
			roverBackwardDerection()
		else:
			printPiMsg("wrong command")

finally:
	printPiMsg("arduino shutdown")
	pass