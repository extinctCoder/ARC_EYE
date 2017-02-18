import sys
import socket
import pyfirmata
PI_IP = '192.168.0.106'
PI_PORT = 8888
BUFFER_SIZE = 1024
PORT = '/dev/ttyACM0'
DELAY = 0
global pin_1
global pin_2
global pin_1_status
global pin_2_status
global servoPin
servoPin = [0,0,0,0,0,0,0]
global servoAddress
servoAddress = [None, None, None, None, None, None, None]
def printMsg(msg):
	print msg
	return
def excuteCommand(command):
	try:
		global pin_1
		global pin_2
		global pin_1_status
		global pin_2_status
		pin_1, pin_2, pin_1_status, pin_2_status = command.split(' ')
	except Exception as e:
		printMsg(e)
		return
	finally:
		pin_1 = int(pin_1)
		pin_2 = int(pin_2)
		pin_1_status = int(pin_1_status)
		pin_2_status = int(pin_2_status)
		print "pin_1 : ", pin_1
		print "pin_2 : ", pin_2
		print "pin_1_status : ", pin_1_status
		print "pin_2_status : ", pin_2_status
		try:
			if pin_1 == 00:
				if pin_2 == 42 and pin_2_status == 1:
					servoDriver(0,0,0)
					pass
				elif pin_2 == 40 and pin_2_status == 1:
					servoDriver(0,0,1)
					pass
				elif pin_2 == 46 and pin_2_status == 1:
					servoDriver(1,1,0)
					pass
				elif pin_2 == 44 and pin_2_status == 1:
					servoDriver(1,1,1)
					pass
				elif pin_2 == 50 and pin_2_status == 1:
					servoDriver(2,2,1)
					pass
				elif pin_2 == 48 and pin_2_status == 1:
					servoDriver(2,2,0)
					pass
				elif pin_2 == 53 and pin_2_status == 1:
					servoDriver(3,3,1)
					pass
				elif pin_2 == 52 and pin_2_status == 1:
					servoDriver(3,3,0)
					pass
				elif pin_2 == 51 and pin_2_status == 1:
					servoDriver(4,4,0)
					pass
				elif pin_2 == 49 and pin_2_status == 1:
					servoDriver(4,4,1)
					pass
				elif pin_2 == 32 and pin_2_status == 1:
					servoDriver(5,5,1)
					pass
				elif pin_2 == 34 and pin_2_status == 1:
					servoDriver(5,5,0)
					pass
				elif pin_2 == 36 and pin_2_status == 1:
					servoDriver(6,6,0)
					pass
				elif pin_2 == 38 and pin_2_status == 1:
					servoDriver(6,6,1)
					pass
			elif pin_1 != 00:
				arduino.digital[pin_1].write(pin_1_status)
				arduino.digital[pin_2].write(pin_2_status)
		except Exception as e:
			printMsg(e)
		finally:
			printMsg("waiting for command")
			pass
def servoDefultPosition():
	servoAddress[0].write(90)
	servoAddress[1].write(180)
	servoAddress[2].write(90)
	servoAddress[3].write(0)
	servoAddress[4].write(90)
	servoAddress[5].write(90)
	servoAddress[6].write(90)
	printMsg("all servo set to defult position")
	pass
def servoDriver(sAddress, sPin, sDerection):
	if(sDerection==1):
		if servoPin[sPin] <180:
			servoPin[sPin] = servoPin[sPin] + 10;
			printMsg("servo command excuted ... !!!!")
			pass
		else:
			printMsg("max position")
			pass
	elif(sDerection==0):
		if servoPin[sPin] >0:
			servoPin[sPin] = servoPin[sPin] - 10;
			printMsg("servo command excuted ... !!!!")
			pass
		else:
			printMsg("max position")
			pass
	pass
#main app			
try:
	printMsg("wellcome to the server scripct")
	printMsg("trying to open the port")
	raspberryPi = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
	raspberryPi.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
	raspberryPi.bind((PI_IP,PI_PORT))
	raspberryPi.listen(2)
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
			try:
				printMsg("arduino connected")
			except Exception as e:
				printMsg(e)
			else:
				printMsg("trying to initilize servo")	
				servoAddress[0]=arduino.get_pin('d:3:s')	#	1st d
				servoAddress[1]=arduino.get_pin('d:4:s')	#	2nd d
				servoAddress[2]=arduino.get_pin('d:5:s')	#	3rd d
				servoAddress[3]=arduino.get_pin('d:6:s')	#	4th d
				servoAddress[4]=arduino.get_pin('d:7:s')	#	5st d
				servoAddress[5]=arduino.get_pin('d:8:s')	#	cam up
				servoAddress[6]=arduino.get_pin('d:9:s')	#	cam dwn
				printMsg("servo initiliziation complite")
				servoDefultPosition()
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
