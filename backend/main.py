import cv2
import time
from cvzone.HandTrackingModule import HandDetector
import socket

# dimensions
height = 720
width = 1280

# Python to Unity mapping
x_axis_py_min = 0
x_axis_py_max = width
x_axis_unity_min = 10
x_axis_unity_max = -10
y_axis_py_min = 0
y_axis_py_max = height
y_axis_unity_min = -0.7
y_axis_unity_max = 10.7

# # Boundary Limits in Unity Space
# x_min_boundary = -5.2  # Left wall
# x_max_boundary = 5.2    # Right wall
# y_min_boundary = 0    # Bottom wall
# y_max_boundary = 12   # Top wall

cap = cv2.VideoCapture(0)
cap.set(3, width)
cap.set(4, height)

# Hand detector
detector = HandDetector(maxHands=1, detectionCon=0.9)

# Communication
sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
serverAddPort = ("127.0.0.1", 5500)

def map_value(x, in_min, in_max, out_min, out_max):
    return (x - in_min) / (in_max - in_min) * (out_max - out_min) + out_min

frame_delay = 0.05  # Adjust delay for stability

# Using the webcam
while True:
    start_time = time.time()

    success, img = cap.read()
    hands, img = detector.findHands(img)

    if hands:
        data = []
        hand = hands[0]
        lmList = hand['lmList']

        for lm in lmList:
            x = map_value(lm[0], x_axis_py_min, x_axis_py_max, x_axis_unity_min, x_axis_unity_max)
            y = map_value(height - lm[1], y_axis_py_min, y_axis_py_max, y_axis_unity_min, y_axis_unity_max)

            # Apply boundary constraints
            # x = max(x_min_boundary, min(x, x_max_boundary))
            # y = max(y_min_boundary, min(y, y_max_boundary))

            data.extend([x, y, lm[2]])

        # Sending data to UDP server
        sock.sendto(str.encode(str(data)), serverAddPort)

    elapsed_time = time.time() - start_time
    sleep_time = max(0, frame_delay - elapsed_time)
    time.sleep(sleep_time)
