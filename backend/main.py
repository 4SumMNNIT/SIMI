import cv2
from cvzone.HandTrackingModule import HandDetector
# dimensions
height = 720
width = 1280

cap = cv2.VideoCapture(0)
cap.set(3,width)
cap.set(4,height)

#  hand detector
detector = HandDetector(maxHands=1, detectionCon=0.9)

# Using the webcam
data = []
while True:
    success, img = cap.read()
    hands, img = detector.findHands(img)
    cv2.imshow("Image", img)
    cv2.waitKey(1)

    #Generating landmark data
    if hands:
        hand = hands[0]
        lmList = hand['lmList']
        for lm in lmList:
            data.extend([lm[0],height - lm[1],lm[2]])
      
        print(data)