import cv2
from cvzone.HandTrackingModule import HandDetector
import socket

# dimensions
height = 720
width = 1280

cap = cv2.VideoCapture(0)
cap.set(3,width)
cap.set(4,height)

#  hand detector
detector = HandDetector(maxHands=1, detectionCon=0.9)

# communication
sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
serverAddPort = ("127.0.0.1", 5020)

# Using the webcam
data = []
while True:
    success, img = cap.read()
    hands, img = detector.findHands(img)
    # if hands and hands[0]['lmList'][8][0] < 0:
    # exit(0)

    # show camera output with tracking
    # cv2.imshow("Image", img)
    cv2.waitKey(1)

    # generating landmark data
    if hands:
        hand = hands[0]
        lmList = hand['lmList']
        for lm in lmList:
            data.extend([lm[0],height - lm[1],lm[2]])
        
        # sending data to udp server
        sock.sendto(str.encode(str(data)), serverAddPort)
        print(data)