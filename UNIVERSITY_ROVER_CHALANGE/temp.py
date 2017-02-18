import serial
ser = serial.Serial("/dev/ttyACM0", 9600)            
while 1:
    ser.write("turjo vai khli boka dai ador o kore")
    print(ser.readline())
