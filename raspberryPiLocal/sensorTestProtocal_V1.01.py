import sys
import pyfirmata
PORT = '/dev/ttyACM0'


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


try:
	arduino = pyfirmata.Arduino(PORT)
except Exception as e:
	printErrorMsg(e)
else:
	printPiMsg("rover is ready to give data")
	it = pyfirmata.util.Iterator(arduino)
	it.start()
	arduino.analog[0].enable_reporting()
	i = 50
	while i>1:
		
		printArduinoMsg(arduino.analog[0].read())
		arduino.pass_time(1)
		i = i-1
	printPiMsg("arduino shutdown")
	arduino.exit()
finally:
	printPiMsg("system going down")
	exit()