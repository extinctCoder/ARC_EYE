from collections import deque
import cv2
import numpy as np
import argparse
import imutils
from imutils import contours

cap = cv2.VideoCapture(0)
center = None
radiousList = []

greenLower = (29, 86, 6)
greenUpper = (64, 255, 255)

font = cv2.FONT_HERSHEY_SIMPLEX


def smallest(numbers):
    smallNumber = float('inf')
    smallCenter = None
    for (i, c) in numbers:
        if i <= smallNumber:
            smallNumber = i
            smallCenter = c
    (smallx, smally) = smallCenter
    return (smallNumber, smallx, smally)


while(1):
    retval, frame = cap.read()
    if not retval:
        print "Cannot capture frame device | CODE TERMINATION :( "
        exit()
    hsv = cv2.cvtColor(frame, cv2.COLOR_BGR2HSV)
    mask = cv2.inRange(hsv, greenLower, greenUpper)
    mask = cv2.erode(mask, None, iterations=2)
    mask = cv2.dilate(mask, None, iterations=2)
    res = cv2.bitwise_and(frame, frame, mask=mask)

    cnts = cv2.findContours(mask.copy(), cv2.RETR_EXTERNAL,
                            cv2.CHAIN_APPROX_SIMPLE)
    cnts.sort(key=cv2.contourArea)
    cnts = cnts[0] if imutils.is_cv2() else cnts[1]
    for (i, c) in enumerate(cnts):
        ((x, y), radius) = cv2.minEnclosingCircle(c)
        M = cv2.moments(c)
        center = (int(M["m10"] / M["m00"]), int(M["m01"] / M["m00"]))
        if radius > 20:
            cv2.circle(frame, (int(x), int(y)), int(radius),
                       (0, 255, 255), 2)
            cv2.circle(frame, center, 5, (0, 0, 255), -1)
            radiousList.append((radius, center))
    try:
        (a, b, c) = smallest(radiousList)

        cv2.circle(frame, (int(b), int(c)), int(a),
                   (255, 0, 255), 2)
        cv2.circle(frame, (b, c), 5, (0, 0, 255), -1)
        if b <= 220:
            text = "Right Turn"
            y0, dy = 50, 4
            for i, line in enumerate(text.split('\n')):
                y = y0 + i * dy
                cv2.putText(frame, line, (50, y),
                            cv2.FONT_HERSHEY_SIMPLEX, 1, 2)
        if b >= 420:
            text = "Left Turn"
            y0, dy = 50, 4
            for i, line in enumerate(text.split('\n')):
                y = y0 + i * dy
                cv2.putText(frame, line, (50, y),
                            cv2.FONT_HERSHEY_SIMPLEX, 1, 2)
        if b >= 220 and b <= 420:
            text = "Forward Movement"
            y0, dy = 50, 4
            for i, line in enumerate(text.split('\n')):
                y = y0 + i * dy
                cv2.putText(frame, line, (50, y),
                            cv2.FONT_HERSHEY_SIMPLEX, 1, 2)
        radiousList = []
    except:
        pass
    cv2.imshow('frame', frame)
    cv2.imshow('hsv', hsv)
    cv2.imshow('mask', mask)
    cv2.imshow('res', res)

    key = cv2.waitKey(1) & 0xFF

    if key == 27:
        break

cv2.destroyAllWindows()
cap.release()
