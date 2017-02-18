#import socket

#host = '192.168.0.101'
#port = 5560

#storedValue = "msg"

#def setupServer():
#    s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
#    print("SOCKET CREATED")
#    try:
#        s.bind((host,port))
#    except socket.error as msg:
#        print(msg)
#    print("Socket bind complete")
#    return s

#def setupConnection():
#    s.listen(1)
#    conn, addresss = s.accept()
#    print("Connected to: "+ address[0] + " : " + str(sddress[1]))
#    return conn

#def dataTransfer(conn):
#    while(1):
#        data = conn.recv(1024)
#        data = data.decode('utf-8')
#        print(data)
#       conn.sendall(str.encode(data))
#        s.close()
#        conn.close()
#        break

#s = setupServer()

#while(1):
#    try:
#       conn = setupConnection()
#       dataTransfer(conn)
#    except:
#        break
    

import socket
import serial
TCP_IP = '192.168.0.101'
TCP_PORT = 5005
BUFFER_SIZE = 1024
ser = serial.Serial('/dev/ttyACM0', 9600, timeout=0)
 
s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
s.bind((TCP_IP, TCP_PORT))
print("server started")
s.listen(1)
while 1:
    try:
        conn, addr = s.accept()
        print 'client connected, address: ', addr    
        while 1:
            try:
                print("waiting for command")
                data = conn.recv(BUFFER_SIZE)
                print "received command: ", data
                if(data == '1'):
                    data = "turning led on"
                    ser.write('1')
                elif(data == '0'):
                    data = "turning led off"
                    ser.write('0')
                elif(data == '3'):
                    data = "closing connection"
                elif(data == '4'):
                    data = "closing server"   
                else:
                    data = "wrong command"
                print(data)
                conn.send(data)
                if (data == "closing connection"):
                    conn.close()
                    print("connection colsed")
                    break 
                elif(data == "closing server"):
                    break
            except:
                print("data transfer problem")
                break
    except:
        if (data == "closing connection"):
            conn.close()
            print("waiting for client")
        else:
         print("connection problem")
    finally:
        if (data == "closing server"):
            conn.close()
            print("connection colsed")
            break         
s.close()
print("server closed")