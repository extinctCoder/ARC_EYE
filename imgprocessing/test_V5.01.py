import sys
import cv2
import numpy as np
import imutils

# cam allocation
cap = cv2.VideoCapture(0)

# color range
lower_green = (29, 86, 100)
upper_green = (64, 200, 255)

#lower_green = (29, 21, 240)
#upper_green = (90, 160, 255)

# variable
center = None
radiousList = []


# small radious


def smallest(numbers):
    smallNumber = float('inf')
    smallCenter = None
    for (i, c) in numbers:
        if i <= smallNumber:
            smallNumber = i
            smallCenter = c
    (smallx, smally) = smallCenter
    return (smallNumber, smallx, smally)


# main loop
while (cap.isOpened()):
    # camera reading
    _, frame = cap.read()
    # if cam not found
    if not _:
        print "unable to run the code"
        sys.exit()
    hsv = cv2.cvtColor(frame, cv2.COLOR_BGR2HSV)
    # detect color
    mask = cv2.inRange(hsv, lower_green, upper_green)
    mask = cv2.erode(mask, None, iterations=2)
    mask = cv2.dilate(mask, None, iterations=2)
    res = cv2.bitwise_and(frame, frame, mask=mask)

    cnts = cv2.findContours(mask.copy(), cv2.RETR_EXTERNAL,
                            cv2.CHAIN_APPROX_SIMPLE)
    cnts = cnts[0] if imutils.is_cv2() else cnts[1]
    for (i, c) in enumerate(cnts):
        ((x, y), radius) = cv2.minEnclosingCircle(c)
        M = cv2.moments(c)
        center = (int(M["m10"] / M["m00"]), int(M["m01"] / M["m00"]))
        if radius > 10:
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
            print "Right Turn"
        if b >= 420:
            text = "Left Turn"
            print "Left Turn"
        if b >= 220 and b <= 420:
            text = "Forward Movement"
            print "Forward Movement"
        y0, dy = 50, 4
        for i, line in enumerate(text.split('\n')):
            y = y0 + i * dy
            cv2.putText(frame, line, (50, y),
                        cv2.FONT_HERSHEY_SIMPLEX, 1, 2)
        radiousList = []
    except:
        pass
    # display frames
    cv2.imshow("frame", frame)
    cv2.imshow("res", res)
    cv2.imshow("mask", mask)
    # exit func
    if cv2.waitKey(1) & 0xFF == 27:
        break
