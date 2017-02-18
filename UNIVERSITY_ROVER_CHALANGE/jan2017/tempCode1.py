import sys
import socket
import pyfirmata
PI_IP = '192.168.0.103'
PI_PORT = 8888
BUFFER_SIZE = 1024
PORT = '/dev/ttyACM0'
DELAY = 0
global pin
global pwm
global torquePin
global pwmPin
def printMsg(msg):
	print msg
	return
def excuteCommand(command):
	try:
		global pin
		global pwm
		global torquePin
		pin, pwm, torquePin = command.split(',')
	except Exception as e:
		printMsg(e)
		return
	finally:
		pin = int(pin)
		pwm = float(pwm)
		torquePin = int(torquePin)
		print "pin : ", pin
		print "pwm : ", pwm
		print "torquePin : ", torquePin
		try:
			arduino.digital[2].write(torquePin)
			arduino.digital[3].write(pin)	
			pwmPin.write(pwm)
		except Exception as e:
			printMsg(e)
		finally:
			pass
try:
	raspberryPi = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
	raspberryPi.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
	raspberryPi.bind((PI_IP,PI_PORT))
	raspberryPi.listen(2)
except Exception as e:
	printMsg(e)
else:
	printMsg("connection opend")
	while 1:
		try:
			arduino = pyfirmata.ArduinoMega(PORT)
		except Exception as e:
			printMsg(e)
			break;
		else:
			printMsg("arduino connected")
			printMsg("8888")
			printMsg("waiting for gui client")
			printMsg("pwm : 4, derectionPin : 3, torquePin : 2")
			while 1:
				try:
					guiClient, guiClientAddress = raspberryPi.accept()
					printMsg(guiClientAddress)
				except Exception as e:
					printMsg(e)
				else:
					pwmPin = arduino.get_pin('d:4:p')
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
