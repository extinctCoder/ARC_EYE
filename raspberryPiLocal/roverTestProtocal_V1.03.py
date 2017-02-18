import socket
import pyfirmata
PI_IP = '192.168.0.101'
PI_PORT = 8888
BUFFER_SIZE = 1024
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

DELAY = 0
def printPiMsg(msg):
	print "raspberryPi\t:", msg
	return
def printArduinoMsg(msg):
	print "ARDUINO\t\t:", msg
	return
def printErrorMsg(expr):
	printPiMsg("connection failed")
	print "error\t\t:", expr
	return
def printGuiClientMsg(msg):
        print"guiClient\t:",msg
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
	printArduinoMsg("roverForwardDerection")
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
	printArduinoMsg("roverBackwardDerection")
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
	printArduinoMsg("roverLeftDerection")
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
	printArduinoMsg("roverRightDerection")
	printPiMsg("work done")
	return

print("\t\t\tscript is loading\t\t\t")

try:
    raspberryPi = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    raspberryPi.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
    raspberryPi.bind((PI_IP, PI_PORT))
    raspberryPi.listen(1)
    
except Exception as e:
    printErrorMsg(e)
else:
    printPiMsg("connection opened")
    while 1:
        try:
                arduino = pyfirmata.Arduino(PORT)
        except Exception as e:
                printErrorMsg(e)
        else:
                printPiMsg("arduino connected")
                while 1:
                        try:
                                guiClient, guiClientAddress = raspberryPi.accept()
                                printPiMsg(guiClientAddress)
                        except Exception as e:
                                printPiMsg(e)
                        else:
                                while 1:
                                        try:
                                                command = guiClient.recv(BUFFER_SIZE)
                                                printGuiClientMsg(command)
                                                if command == 'w':
                                                        roverForwardDerection()
                                                        guiClient.send("command excuated")
                                                elif command == 'a':
                                                        roverLeftDerection()
                                                        guiClient.send("command excuated")
                                                elif command == 'd':
                                                        roverRightDerection()
                                                        guiClient.send("command excuated")
                                                elif command == 's':
                                                        roverBackwardDerection()
                                                        guiClient.send("command excuated")
                                                elif command == 'x':
                                                        printPiMsg("arduino disconnected")
                                                        arduino.close()
                                                        printClientMsg("command excuacted")
                                                        break
                                                else:
                                                        printPiMsg("wrong command")
                                                        guiClient.send("wrong command")
                                        except Exception as e:
                                                print e
                        finally:
                                pass
        finally:
                printPiMsg("arduino communication shutdown")
                break
    printPiMsg("connection closed")
    raspberryPi.close()
finally:
        printPiMsg("server going down")
            
