import sys
import socket
import pyfirmata
PI_IP = '192.168.0.101'
PI_PORT = 8888
BUFFER_SIZE = 10
PORT = '/dev/ttyACM0'
DELAY = 0
global direction
global pwm
def printMsg(msg):
	print msg
	return
def excuteCommand(command):
	try:
		#global direction
		#global pwm
		direction, pwm = command.split(',')
		print 'pwm : ', pwm
		direction = int(direction)
		pwm = float(pwm)
		pwm = pwm / 100
		print 'direction : ', direction
		print 'pwm : ', pwm
	except Exception as e:
		printMsg("data los excuting seafty procudre")
		stopMovement()
		pass
	else:
		if(direction == 0):
			printMsg("forward command")
			forwardMovement(pwm)
			pass
		if(direction == 1):
			printMsg("backward command")
			backwardMovement(pwm)
			pass
		if(direction == 2):
			printMsg("left command")
			leftMovement(pwm)
			pass
		if(direction == 3):
			printMsg("Right command")
			rightMovement(pwm)
			pass	
		if(direction == 4):
			printMsg("Stop command")
			stopMovement()
			pass
	finally:
		#stopMovement()
		pass
def forwardMovement(xpwm):
	pin3_pwm.write(xpwm)
	pin5_pwm.write(xpwm)
	pin7_pwm.write(xpwm)
	pin9_pwm.write(xpwm)
	pin11_pwm.write(xpwm)
	pin13_pwm.write(xpwm)
	print "excuited pwm is : ", xpwm

	arduino.digital[pin8_digital].write(1)
	arduino.digital[pin10_digital].write(1)
	arduino.digital[pin12_digital].write(1)

	arduino.digital[pin2_digital].write(0)
	arduino.digital[pin4_digital].write(0)
	arduino.digital[pin6_digital].write(0)

	printMsg("forwardMovement excuted.............................................................................................................")
	pass
def backwardMovement(xpwm):
	pin3_pwm.write(xpwm)
	pin5_pwm.write(xpwm)
	pin7_pwm.write(xpwm)
	pin9_pwm.write(xpwm)
	pin11_pwm.write(xpwm)
	pin13_pwm.write(xpwm)
	print "excuited pwm is : ", xpwm

	#board.digital[2].write(1)
	arduino.digital[pin8_digital].write(0)
	arduino.digital[pin10_digital].write(0)
	arduino.digital[pin12_digital].write(0)

	arduino.digital[pin2_digital].write(1)
	arduino.digital[pin4_digital].write(1)
	arduino.digital[pin6_digital].write(1)

	printMsg("backwardMovement excuted!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!")
	pass
def leftMovement(xpwm):
	pin3_pwm.write(xpwm)
	pin5_pwm.write(xpwm)
	pin7_pwm.write(xpwm)
	pin9_pwm.write(xpwm)
	pin11_pwm.write(xpwm)
	pin13_pwm.write(xpwm)
	print "excuited pwm is : ", xpwm

	arduino.digital[pin8_digital].write(0)
	arduino.digital[pin10_digital].write(0)
	arduino.digital[pin12_digital].write(0)

	arduino.digital[pin2_digital].write(0)
	arduino.digital[pin4_digital].write(0)
	arduino.digital[pin6_digital].write(0)

	printMsg("leftMovement excuted#####################################################################################################################")
	pass
def rightMovement(xpwm):
	pin3_pwm.write(xpwm)
	pin5_pwm.write(xpwm)
	pin7_pwm.write(xpwm)
	pin9_pwm.write(xpwm)
	pin11_pwm.write(xpwm)
	pin13_pwm.write(xpwm)
	print "excuited pwm is : ", xpwm

	arduino.digital[pin8_digital].write(1)
	arduino.digital[pin10_digital].write(1)
	arduino.digital[pin12_digital].write(1)

	arduino.digital[pin2_digital].write(1)
	arduino.digital[pin4_digital].write(1)
	arduino.digital[pin6_digital].write(1)

	printMsg("rightMovement excuted****************************************************************************************************************")
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
def initilizeArduino():
	printMsg("initialize arduino")
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
			#initilizeArduino()
			printMsg("Congiguring pin")
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
			stopMovement()
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
						except Exception as e:
							printMsg(e)
							break
						else:
							excuteCommand(command)
						finally:
							pass	
				finally:
					stopMovement()
					pass
		finally:
			stopMovement()
			printMsg("arduino protocall stoped")
	printMsg("connection closed")
	raspberryPi.close()
finally:
	printMsg("server shutdown")	
