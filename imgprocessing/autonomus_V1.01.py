import serial, time
arduino = serial.Serial('COM15', 9600, timeout=.1)
while True:
    try:
        data = arduino.readline()
        data = str(data)
        lat, lng, mph, feet= data.split(',')
        print(lat)
        print(lng)
        print(mph)
        print(feet)
    except Exception as ex:
        print(ex)
