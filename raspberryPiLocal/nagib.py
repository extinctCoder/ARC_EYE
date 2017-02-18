import socket
import pyfirmata
PI_IP = '192.168.0.101'
PI_PORT = 8888
BUFFER_SIZE = 1024
PORT = '/dev/ttyACM0'
DELAY = 0
def printMsg(msg):
	print msg
	return
def excuteCommand(command):
	try:
		arduino.digital[command].write(1)
		printMsg("command excuated")
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
			arduino = pyfirmata.Arduino(PORT)
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
						command = guiClient.recv(BUFFER_SIZE)
						printMsg(command)
						guiClient.send("command excuted")
						#excuteCommand(command)
				finally:
					pass
		finally:
			printMsg("arduino protocall stoped")
	printMsg("connection closed")
	raspberryPi.close()
finally:
	printMsg("server shutdown")	
