import cv2
from cvzone.HandTrackingModule import HandDetector
import socket

# dimensions
height = 720
width = 1280

# python to unity mapping
x_axis_py_min = 0
x_axis_py_max = width
x_axis_unity_min = 10 
x_axis_unity_max = -10
y_axis_py_min = 0
y_axis_py_max = height
y_axis_unity_min = -0.7 
y_axis_unity_max = 10.7

cap = cv2.VideoCapture(0)
cap.set(3,width)
cap.set(4,height)

#  hand detector
detector = HandDetector(maxHands=1, detectionCon=0.9)

# communication
sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
serverAddPort = ("127.0.0.1", 5500)

def map_value(x, in_min, in_max, out_min, out_max):
    return (x - in_min) / (in_max - in_min) * (out_max - out_min) + out_min

# Using the webcam
while True:
    success, img = cap.read()
    hands, img = detector.findHands(img)

    # # for testing: touch left edge of screen with index finger to close
    # if hands and hands[0]['lmList'][8][0] < 0:
    #   exit(0)

    # # show camera output with tracking
    # cv2.imshow("Image", img)
    cv2.waitKey(1)

    # generating landmark data
    if hands:
        data = []
        hand = hands[0]
        lmList = hand['lmList']
        
        for lm in lmList:
            x = map_value(lm[0], in_min=x_axis_py_min, in_max=x_axis_py_max, out_min=x_axis_unity_min, out_max=x_axis_unity_max)
            y = map_value(height - lm[1], in_min=y_axis_py_min, in_max=y_axis_py_max, out_min=y_axis_unity_min, out_max=y_axis_unity_max)
            data.extend([x, y, lm[2]])
        
        # sending data to udp server
        sock.sendto(str.encode(str(data)), serverAddPort)

        # # Log data to console
        # print(data)