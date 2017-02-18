import socket
import pyfirmata
PI_IP = '192.168.0.106'
PI_PORT = 8888
BUFFER_SIZE = 1024
PORT = '/dev/ttyACM0'
DELAY = 0
def printMsg(msg):
	print msg
	return
def excuteCommand(command):
	pin_1, pin_2, pin_1_status, pin_2_status = command.split(' ')
	pin_1 = int(pin_1)
	pin_2 = int(pin_2)
	pin_1_status = int(pin_1_status)
	pin_2_status = int(pin_2_status)
	print "pin_1 : ", pin_1
	print "pin_2 : ", pin_2
	print "pin_1_status : ", pin_1_status
	print "pin_2_status : ", pin_2_status
	try:
		if pin_1 != 00:
			arduino.digital[pin_1].write(pin_1_status)
		arduino.digital[pin_2].write(pin_2_status)
	except Exception as e:
		printMsg(e)
	finally:
		return
print "\t\t\t sever is started loading \t\t\t"
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
