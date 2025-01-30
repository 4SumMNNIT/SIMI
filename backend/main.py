import cv2

# dimensions
height = 720
width = 1280

cap = cv2.VideoCapture(0)
cap.set(3,width)
cap.set(4,height)
# Using the webcam
while True:
    success, img = cap.read()
    cv2.imshow("Image", img)
    cv2.waitKey(1)