import serial
arduino_port = '/dev/ttyACM0'
arduino_band = 9600

def printMsg(msg):
	print'raspberryPi\t:', msg
	return
def printErrorMsg(expr):
	print 'error\t\t:', expr
	return
def printArduinoMsg(msg):
	print msg
	return

printMsg('rover client started')
try:
	arduino = serial.Serial(arduino_port, arduino_band, timeout=0)
except Exception as e:
	printMsg('unable to connect with arduino')
	printErrorMsg(e)
else:
	printMsg('arduino connected')
	#arduino client code
	printArduinoMsg(arduino.readline())
	arduino.close()
	printMsg('arduino disConnected')
finally:
	printMsg('rover client shutdown')

