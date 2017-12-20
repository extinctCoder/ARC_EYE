import numpy as np
import cv2
import numpy
import time
import argparse
import imutils
from imutils import contours
from collections import deque
from threading import Thread
# variables
videoCaptureDevice = cv2.VideoCapture(0)
videoCenter = None
radiousList = []
font = cv2.FONT_HERSHEY_SIMPLEX
# color range
greenLowerColourLimit = (29, 86, 100)
greenUpperColourLimit = (64, 200, 255)

# SmallestFinder


def SmallestFinder(tempRadiousList):
    tempSmallRadious = float('inf')
    tempSmallCenter = None
    for (xTempSmallRadious, xTempSmallCenter) in tempRadiousList:
        if xTempSmallRadious <= tempSmallRadious:
            tempSmallRadious = xTempSmallRadious
            tempSmallCenter = xTempSmallCenter
    (tempXaxis, tempYaxis) = tempSmallCenter
    return(tempXaxis, tempYaxis, tempSmallRadious)


# main app
while(videoCaptureDevice.isOpened()):
    captureRetval, videoFrame = videoCaptureDevice.read()
    if not captureRetval:
        #print "Unable to recive stram from device please cheack the system again."
        exit()

    videoHsv = cv2.cvtColor(videoFrame, cv2.COLOR_BGR2HSV)
    videoMask = cv2.inRange(
        videoHsv, greenLowerColourLimit, greenUpperColourLimit)
    videoMask = cv2.erode(videoMask, None, iterations=2)
    videoMask = cv2.dilate(videoMask, None, iterations=2)
    videoRes = cv2.bitwise_and(videoFrame, videoFrame, mask=videoMask)

    videoCnts = cv2.findContours(videoMask.copy(), cv2.RETR_EXTERNAL,
                                 cv2.CHAIN_APPROX_SIMPLE)

    videoCnts = videoCnts[0] if imutils.is_cv2() else videoCnts[1]

    for(imageI, imageC)in enumerate(videoCnts):
        ((imageX, imageY), imageRadius) = cv2.minEnclosingCircle(imageC)
        videoM = cv2.moments(imageC)
        videoCenter = (int(videoM["m10"] / videoM["m00"]),
                       int(videoM["m01"] / videoM["m00"]))
        if imageRadius > 10:
            cv2.circle(videoFrame, (int(imageX), int(imageY)), int(imageRadius),
                       (0, 255, 255), 2)
            cv2.circle(videoRes, videoCenter, 5, (255, 255, 255), - 1)
            cv2.putText(videoRes, "[" + str(imageX) + "," + str(imageY) + "]", (int(
                imageX), int(imageY)), cv2.FONT_HERSHEY_SIMPLEX, 0.5, (255, 255, 255), 1)
            radiousList.append((imageRadius, imageC))
    try:
        (tempXaxis, tempYaxis, tempSmallRadious) = SmallestFinder(radiousList)
        cv2.circle(videoFrame, (int(tempXaxis), int(tempYaxis)), int(tempSmallRadious),
                   (133, 99, 245), 2)
        cv2.circle(videoFrame, (tempXaxis, tempYaxis), 5, (47, 88, 255), -1)
        if tempXaxis <= 220:
            text = "LEFT TURN"
            #print "LEFT TURN"
        elif tempXaxis >= 420:
            text = "RIGHT TURN"
            #print "RIGHT TURN"
        elif tempXaxis >= 220 and tempXaxis <= 420:
            text = "FORWARD DERECTION"
            #print "FORWARD DERECTION"
        cv.putText(videoFrame, text, (230, 50), font,
                   0.8, (0, 255, 0), 2, cv2.LINE_AA)
        radiousList = []
    except Exception as ex:
        #print ex
    cv2.imshow('webcam_output', videoFrame)
    cv2.imshow('video_res', videoRes)
    cv2.imshow('videoHsv', videoHsv)
    cv2.imshow('videoMask', videoMask)
    intruptKey = cv2.waitKey(1) & 0xFF
    if intruptKey == 27:
        break
# exit task
cv2.destroyAllWindows()
videoCaptureDevice.release()
