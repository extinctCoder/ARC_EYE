import cv2
import numpy as np

cap = cv2.VideoCapture(0)
cx1, cx2 = 0, 640


def direction(dir):
    print(dir)


def setupFrame(thisframe, center):
    # print(max_loc[0])
    if(center is 0):
        L, F, R = 100, 255, 100
        direction('F')
    elif(center < 280):
        L, F, R = 255, 100, 100
        direction('L')
    elif(center > 360):
        L, F, R = 100, 100, 255
        direction('R')
    else:
        L, F, R = 100, 255, 100
        direction('F')

    font = cv2.FONT_HERSHEY_SIMPLEX
    #cv2.putText(img, text, org, fontFace, fontScale, color)
    cv2.putText(thisframe, "<-", (0, 460), font,
                2, (100, L, 100), 2, cv2.LINE_AA)
    cv2.putText(thisframe, "|", (320, 460), font,
                2, (100, F, 100), 2, cv2.LINE_AA)
    cv2.putText(thisframe, "->", (540, 460), font,
                2, (100, R, 100), 2, cv2.LINE_AA)


while True:
    _, frame = cap.read()
    try:
        # median = cv2.medianBlur(frame, 25)
        hsv = cv2.cvtColor(frame, cv2.COLOR_BGR2HSV)

        lower_red = np.array([30, 50, 0])
        upper_red = np.array([50, 255, 255])

        mask = cv2.inRange(hsv, lower_red, upper_red)
        result = cv2.bitwise_and(frame, frame, mask=mask)

        kernel = np.ones((5, 5), np.uint8)
        opening = cv2.morphologyEx(result, cv2.MORPH_OPEN, kernel)
        opening = cv2.medianBlur(opening, 35)

        framegray = cv2.cvtColor(opening, cv2.COLOR_BGR2GRAY)
        ret, threshold = cv2.threshold(framegray, 20, 255, cv2.THRESH_BINARY)
        framecontours, contours, hierarchy = cv2.findContours(
            threshold, 1, cv2.CHAIN_APPROX_SIMPLE)
        cv2.drawContours(threshold, contours, -1, (0, 255, 255), 1)

        cnt = contours
        cnt.sort(key=cv2.contourArea)
        '''
		if(len(cnt) > 2):
			one, two, three = cnt[2], cnt[1], cnt[0]

			(cx1,cy1), radius1 = cv2.minEnclosingCircle(one)
			cv2.circle(frame, (int(cx1), int(cy1)), int(radius1), (0,255,0), 2)

			(cx2,cy2), radius2 = cv2.minEnclosingCircle(two)
			cv2.circle(frame, (int(cx2), int(cy2)), int(radius2), (0,0,255), 2)

			(cx3,cy3), radius3 = cv2.minEnclosingCircle(three)
			cv2.circle(frame, (int(cx3), int(cy3)), int(radius3), (255,0,0), 2)
		'''
        if(len(cnt) > 1):
            one, two = cnt[1], cnt[0]

            (cx1, cy1), radius1 = cv2.minEnclosingCircle(one)
            cv2.circle(frame, (int(cx1), int(cy1)),
                       int(radius1), (0, 255, 0), 2)

            (cx2, cy2), radius2 = cv2.minEnclosingCircle(two)
            cv2.circle(frame, (int(cx2), int(cy2)),
                       int(radius2), (0, 0, 255), 2)

        # elif(len(cnt) > 0):

        if(len(cnt) > 0):
            one = max(cnt, key=cv2.contourArea)

            (cx1, cy1), radius1 = cv2.minEnclosingCircle(one)
            cv2.circle(frame, (int(cx1), int(cy1)),
                       int(radius1), (0, 255, 0), 2)

        else:
            pass

        c = int((cx1 + cx2) / 2)
        setupFrame(frame, c)
        cv2.imshow("Final", frame)

        if cv2.waitKey(1) & 0xFF == 27:
            break
    except:
        pass
cap.release()
cv2.destroyAllWindows()
