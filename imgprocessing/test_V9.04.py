# libary include
import sys
import cv2
import socket
import imutils
import numpy as np
import argparse as ap
from matplotlib import pyplot as plt
# variable initialization
tcp_ip = '192.168.0.222'
tcp_port = 8888
buffer_size = 1024
server_client = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
lower_green = np.array([30, 50, 0])
upper_green = np.array([50, 255, 255])
# small ball finder func


def smallest_circle_finder(temp_circle_list):
    try:
        temp_small_radious = float('inf')
        temp_small_center = []
        for (xtemp_small_center, xtemp_small_radious) in temp_circle_list:
            if xtemp_small_radious <= temp_small_radious:
                temp_small_radious = xtemp_small_radious
                temp_small_center = xtemp_small_center
        (temp_x_axis, temp_y_axis) = temp_small_center
        return(temp_x_axis, temp_y_axis, temp_small_radious)
    except Exception as ex:
        return (0, 0, 0)
# derection decider


def get_direction(temp_x_axis, temp_y_axis,
                  temp_small_radious, frame):
    if temp_x_axis > 0 and temp_x_axis <= 100:
        text = "Right Turn"
        data = "03,60"
        print ('Right Turn          >>>>>')

        # byte_data = bytes("04,30", 'utf-8')
    if temp_x_axis >= 540 and temp_x_axis < 640:
        text = "Left Turn"
        data = "02,60"
        print ('Left Turn           <<<<<')

        # byte_data = bytes("02,20", 'utf-8')
    if temp_x_axis >= 100 and temp_x_axis <= 540:
        text = "Forward Movement"
        data = "00,60"
        print ('Forward Movement    ^^^^^')

        # byte_data = bytes("00,20", 'utf-8')
    if temp_x_axis == 0 and temp_y_axis == 0 and temp_small_radious == 0:
        text = "Rover Stop"
        data = "04,00"
        print ('Stop Movement       |||||')

    cv2.putText(frame, text, (30, 400), cv2.FONT_HERSHEY_SIMPLEX,
                2, (99, 255, 155), 3, cv2.LINE_AA)
    return data
# runImageProccessing func


def runImageProccessing(source=0, dispLoc=False):
    # main func is starting
    print('image processing screcpt is starting')
    cam = cv2.VideoCapture(source)
    if not cam.isOpened():
        print("devide or source file is unable to alocate")
        sys.exit()
    else:
        print("device or source allocation successful")
    print("waiting for the rover control screcpt server")
    print("tcp_ip :", str(tcp_ip))
    print("tcp_port :", str(tcp_port))
    while True:
        try:

            server_client.connect((tcp_ip, tcp_port))
            print("connected to the rover control screcpt server")
        except Exception as e:
            print (e)
        else:
            # starting the imageprocessing loop
            while True:
                # start read data from source
                retval, frame = cam.read()
                if not retval:
                    print ('unable to read the data')
                    sys.exit()
                # converting BGR to HSV
                hsv = cv2.cvtColor(frame, cv2.COLOR_BGR2HSV)
                # finding desired color
                mask = cv2.inRange(hsv, lower_green, upper_green)
                mask = cv2.erode(mask, None, iterations=2)
                mask = cv2.dilate(mask, None, iterations=2)
                # removing background
                res = cv2.bitwise_and(frame, frame, mask=mask)
                # cleaning the image removing little objects
                kernel = np.ones((5, 5), np.uint8)
                morphology_open = cv2.morphologyEx(
                    res, cv2.MORPH_OPEN, kernel)
                morphology_open = cv2.medianBlur(morphology_open, 35)
                # converting into gray color
                gray_frame = cv2.cvtColor(
                    morphology_open, cv2.COLOR_BGR2GRAY)
                ret, threshold = cv2.threshold(
                    gray_frame, 20, 255, cv2.THRESH_BINARY)
                # finding deseared objects
                frame_contours, contours, hierarchy = cv2.findContours(
                    threshold, 1, cv2.CHAIN_APPROX_SIMPLE)
                cv2.drawContours(frame, contours, -1, (0, 0, 255), 1)
                # sorting the objects
                contours.sort(key=cv2.contourArea)
                circle_list = []
                # drawing all found objects
                for(imageI, imageC)in enumerate(contours):
                    ((imageX, imageY), imageRadius) = cv2.minEnclosingCircle(imageC)
                    if imageRadius > 10:
                        cv2.circle(frame, (int(imageX), int(imageY)), int(imageRadius),
                                   (255, 0, 38), 1)
                        cv2.putText(frame, "[" + str(imageX) + "," + str(imageY) + "]", (int(
                            imageX), int(imageY)), cv2.FONT_HERSHEY_SIMPLEX, 0.5, (255, 0, 38), 1)
                # drawing specific two object (ball)
                if(len(contours) > 1):
                    one, two = contours[1], contours[0]
                    (imageX, imageY), imageRadius = cv2.minEnclosingCircle(one)
                    cv2.circle(frame, (int(imageX), int(imageY)),
                               int(imageRadius), (99, 255, 0), 2)
                    (imageX, imageY), radius2 = cv2.minEnclosingCircle(two)
                    cv2.circle(frame, (int(imageX), int(imageY)),
                               int(imageRadius), (99, 0, 255), 2)
                    circle_list.append(((imageX, imageY), imageRadius))
                # drawing specific one object (ball)
                if(len(contours) > 0):
                    one = max(contours, key=cv2.contourArea)
                    (imageX, imageY), imageRadius = cv2.minEnclosingCircle(one)
                    cv2.circle(frame, (int(imageX), int(imageY)),
                               int(imageRadius), (99, 255, 0), 2)
                    circle_list.append(((imageX, imageY), imageRadius))
                # print(circle_list)
                # find the small object
                (temp_x_axis, temp_y_axis,
                    temp_small_radious) = smallest_circle_finder(circle_list)
                # print ("postion of the farest ball is :[x_axis : {}, y_axis : {}, radious : {}]".format(temp_x_axis, temp_y_axis, temp_small_radious))
                # draw the small object
                cv2.circle(frame, (int(temp_x_axis), int(temp_y_axis)),
                           int(temp_small_radious), (255, 0, 255), 2)
                cv2.circle(frame, (int(temp_x_axis), int(
                    temp_y_axis)), 5, (0, 0, 255), -1)
                data = get_direction(temp_x_axis, temp_y_axis,
                                     temp_small_radious, frame)
                try:
                    # uploading data to the rover
                    server_client.send(data.encode("utf8"))
                    pass
                except:
                    pass
                # image preview
                cv2.imshow("Image Processing", frame)
            # sending command to the rover
                if cv2.waitKey(1) & 0xFF == 27:
                    sys.exit()
                    # closeing the server connection
                    server_client.close()
        finally:
            pass
    # exits to the main func
    cam.release()
    cv2.destroyAllWindows()


# main func
if __name__ == "__main__":
    # command line commands
    parser = ap.ArgumentParser()
    group = parser.add_mutually_exclusive_group(required=True)
    group.add_argument('-d', "--deviceId", help="Device ID")
    group.add_argument('-v', "--videoFile", help="Video File")
    parser.add_argument('-l', "--dispLoc", dest="dispLoc", action="store_true")
    args = vars(parser.parse_args())
    # get the source of the file
    if args["videoFile"]:
        source = args["videoFile"]
    else:
        source = int(args["deviceId"])
    # jumping to main func
    runImageProccessing(source, args["dispLoc"])
