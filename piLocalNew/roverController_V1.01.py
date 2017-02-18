import sys
import socket
import pyfirmata
PI_IP = '192.168.0.101'
PI_PORT = 8888
BUFFER_SIZE = 1024
PORT = '/dev/ttyACM0'
DELAY = 0
global direction
global pwm
def printMsg(msg):
	print msg
	return
def excuteCommand(command):
	try:
		global direction
		global pwm
		pwm = 0
		direction = 0
		direction, pwm = command.split(',')
		direction = int(direction)
		print 'pwm : ', pwm
		pwm = float(pwm)
		pwm = pwm / 100
		print 'direction : ', direction
		print 'pwm : ', pwm
		if(direction == 0):
			printMsg("forward command")
			forwardMovement()
			pass
		if(direction == 1):
			printMsg("backward command")
			backwardMovement()
			pass
		if(direction == 2):
			printMsg("left command")
			leftMovement()
			pass
		if(direction == 3):
			printMsg("Right command")
			rightMovement()
			pass	
		if(direction == 4):
			printMsg("Stop command")
			stopMovement()
			pass
	except Exception as e:
		printMsg(e)
		return
	finally:
		pass
def forwardMovement():
	pin3_pwm.write(pwm)
	pin5_pwm.write(pwm)
	pin7_pwm.write(pwm)
	pin9_pwm.write(pwm)
	pin11_pwm.write(pwm)
	pin13_pwm.write(pwm)
	print "excuited pwm is : ", pwm

	arduino.digital[pin8_digital].write(1)
	arduino.digital[pin10_digital].write(1)
	arduino.digital[pin12_digital].write(1)

	arduino.digital[pin2_digital].write(0)
	arduino.digital[pin4_digital].write(0)
	arduino.digital[pin6_digital].write(0)

	printMsg("forwardMovement excuted")
	pass
def backwardMovement():
	pin3_pwm.write(pwm)
	pin5_pwm.write(pwm)
	pin7_pwm.write(pwm)
	pin9_pwm.write(pwm)
	pin11_pwm.write(pwm)
	pin13_pwm.write(pwm)
	print "excuited pwm is : ", pwm

	#board.digital[2].write(1)
	arduino.digital[pin8_digital].write(0)
	arduino.digital[pin10_digital].write(0)
	arduino.digital[pin12_digital].write(0)

	arduino.digital[pin2_digital].write(1)
	arduino.digital[pin4_digital].write(1)
	arduino.digital[pin6_digital].write(1)

	printMsg("backwardMovement excuted")
	pass
def leftMovement():
	pin3_pwm.write(pwm)
	pin5_pwm.write(pwm)
	pin7_pwm.write(pwm)
	pin9_pwm.write(pwm)
	pin11_pwm.write(pwm)
	pin13_pwm.write(pwm)
	print "excuited pwm is : ", pwm

	arduino.digital[pin8_digital].write(0)
	arduino.digital[pin10_digital].write(0)
	arduino.digital[pin12_digital].write(0)

	arduino.digital[pin2_digital].write(0)
	arduino.digital[pin4_digital].write(0)
	arduino.digital[pin6_digital].write(0)

	printMsg("leftMovement excuted")
	pass
def rightMovement():
	pin3_pwm.write(pwm)
	pin5_pwm.write(pwm)
	pin7_pwm.write(pwm)
	pin9_pwm.write(pwm)
	pin11_pwm.write(pwm)
	pin13_pwm.write(pwm)
	print "excuited pwm is : ", pwm

	arduino.digital[pin8_digital].write(1)
	arduino.digital[pin10_digital].write(1)
	arduino.digital[pin12_digital].write(1)

	arduino.digital[pin2_digital].write(1)
	arduino.digital[pin4_digital].write(1)
	arduino.digital[pin6_digital].write(1)

	printMsg("rightMovement excuted")
	pass
def stopMovement():
	pin3_pwm.write(0)
	pin5_pwm.write(0)
	pin7_pwm.write(0)
	pin9_pwm.write(0)
	pin11_pwm.write(0)
	pin13_pwm.write(0)
	print "excuited pwm is : 0"

	printMsg("stopMovement excuted")
	pass
#main app			
try:
	printMsg("wellcome to the server scripct")
	printMsg("trying to open the port")
	raspberryPi = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
	raspberryPi.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
	raspberryPi.bind((PI_IP,PI_PORT))
	raspberryPi.listen(4)
except Exception as e:
	printMsg(e)
else:
	printMsg("connection opend")
	printMsg("PI_IP : "+ PI_IP)
	printMsg("PI_PORT : 8888")
	while 1:
		try:
			printMsg("trying to connect with arduino")
			arduino = pyfirmata.ArduinoMega(PORT)
		except Exception as e:
			printMsg(e)
			break;
		else:
			printMsg("arduino connected")
			printMsg("COngiguring pin")
			pin3_pwm = arduino.get_pin('d:3:p')
			pin5_pwm = arduino.get_pin('d:5:p')
			pin7_pwm = arduino.get_pin('d:7:p')
			pin9_pwm = arduino.get_pin('d:9:p')
			pin11_pwm = arduino.get_pin('d:11:p')
			pin13_pwm = arduino.get_pin('d:13:p')
			pin8_digital = 8
			pin10_digital = 10
			pin12_digital = 12
			pin2_digital = 2
			pin4_digital = 4
			pin6_digital = 6
			printMsg("pin configured")
			printMsg("waiting for gui client")
			while 1:
				try:
					guiClient, guiClientAddress = raspberryPi.accept()
					printMsg(guiClientAddress)
				except Exception as e:
					printMsg(e)
				else:
					while 1:
						try:
							command = guiClient.recv(BUFFER_SIZE)
							excuteCommand(command)
						except Exception as e:
							printMsg(e)
							break	
				finally:
					pass
		finally:
			printMsg("arduino protocall stoped")
	printMsg("connection closed")
	raspberryPi.close()
finally:
	printMsg("server shutdown")	
