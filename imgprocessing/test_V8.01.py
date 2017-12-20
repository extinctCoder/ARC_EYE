# libary include
import cv2
import argparse as ap
import sys
import numpy as np

# variable alocation


# main function


# def run(source=0):

# initializing capture device
cam = cv2.VideoCapture(0)
print('image processing scrept is starting')
# starting infinity loop for the process
while True:

    # taking data from cam
    retval, frame = cam.read()
    try:
        '''if not retval:
            print ('unable to allocate the device')
            sys.exit()'''

        lowerGreen = np.array([30, 50, 0])
        upperGreen = np.array([50, 255, 255])

        # processing video
        hsv = cv2.cvtColor(frame, cv2.COLOR_BGR2HSV)
        mask = cv2.inRange(hsv, lowerGreen, upperGreen)

        # removing background
        backgroundRemoved = cv2.bitwise_and(frame, frame, mask=mask)

        # removing extra objects
        karnel = np.ones((5, 5), np.uint8)
        morphology_open = cv2.morphologyEx(
            backgroundRemoved, cv2.MORPH_OPEN, karnel)

        # clearing image
        morphology_open = cv2.medianBlur(morphology_open, 35)

        # converting image into gray
        gray_frame = cv2.cvtColor(morphology_open, cv2.COLOR_BGR2GRAY)
        _, frame_threshold = cv2 = cv2.threshold(
            gray_frame, 20, 255, cv2.THRESH_BINARY)

        # finding the desired objects
        frame_contour, contour, hierarchy = cv2.findContours(
            frame_threshold, 1, cv2.CHAIN_APPROX_SIMPLE)
        cv2.drawContours(frame_threshold, contour, -1, (0, 255, 255), 1)
        # video viewer
        cv2.imshow('frame', frame)

        # loop breaker
        if cv2.waitKey(1) == 27:
            break
    except:
        pass

'''if __name__ == "__main__":

    # Command line commands
    parser = ap.ArgumentParser()
    group = parser.add_mutually_exclusive_group(required=True)
    group.add_argument('-d', "--deviceId", help="Device ID")
    group.add_argument('-v', "--videoFile", help="Video File")
    args = vars(parser.parse_args())

    # Get the source of the file
    if args["videoFile"]:
        source = args["videoFile"]
    else:
        source = int(args["deviceId"])

    # jumping to the main file
    run(source)'''
