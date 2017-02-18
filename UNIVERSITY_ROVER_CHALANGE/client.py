#import socket

#host = '192.168.0.101'
#port = 5560


#while(1):
#	try:
#		print("trying to connect to the server")
#		s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
#		s.connect((host, port))
#		s.sendall(str.encode('comm'))
#		s.sendall(str.encode("connected"))
#		print("connection successfull")
#    	s.sendall(str.encode("msg sended"))
#    	replay = s.recv(1024)
#    	print(replay.decode('utf-8'))
#    	s.close()
#	except socket.error as msg:
#		print(msg)



import socket
 
TCP_IP = '192.168.0.103'
TCP_PORT = 5005
BUFFER_SIZE = 1024
try:
	s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
	s.connect((TCP_IP, TCP_PORT))
	print("server conneected")
	while 1:
		try:		
			MESSAGE = raw_input("please enter your msg: ")
			s.send(MESSAGE)
			data = s.recv(BUFFER_SIZE)
			print "received data:", data
			if (data == "closing connection"):
				print("connection closed")
				break
			elif (data == "closing server"):
				break
		except:
			print("data transfer problem")
			break
except:
	print("connection problem")
finally:
	s.close()
	print("connection closed")
