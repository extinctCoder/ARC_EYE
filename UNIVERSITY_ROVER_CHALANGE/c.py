import socket

HOST, PORT = "192.168.0.103", 5000
ctrl_cyc="1234567"
data = ""
data += str(ctrl_cyc)

    # Create a socket (SOCK_STREAM means a TCP socket)
sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

try:

    # Connect to server and send data
    sock.connect((HOST, PORT))
    
    sock.sendall(bytes(data + "\n"))
    data = sock.recv(1024)
    print"data recived: ",data

finally:
    sock.close()