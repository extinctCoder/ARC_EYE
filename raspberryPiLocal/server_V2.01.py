import socket
TCP_IP = '192.168.0.101'
TCP_PORT = 8888
BUFFER_SIZE = 1024

s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
s.bind((TCP_IP, TCP_PORT))
print("server started")
print("TCP_IP :", str(TCP_IP))
print("TCP_PORT :", str(TCP_PORT))
s.listen(5)
while 1:
    try:
        conn, addr = s.accept()
        print('client connected, address: ', addr)
        while 1:
            try:
                print("waiting for command")
                data = conn.recv(BUFFER_SIZE)
            except:
                print("data transfer problem")
                break
    except Exception as ex:
        print(ex)
    finally:
        print("wating for another connection")
s.close()
print("server closed")
