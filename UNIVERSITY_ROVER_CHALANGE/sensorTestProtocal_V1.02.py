import sys
import pyfirmata
PORT = '/dev/ttyACM0'
data = 0
xData = 0
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
    while 1:
        xData = arduino.analog[0].read()
        if data != xData:
            data = xData
            printArduinoMsg(data)
        #arduino.pass_time(1)
    printPiMsg("arduino shutdown")
    arduino.exit()
finally:
    printPiMsg("system going down")
    exit()
