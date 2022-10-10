import cv2
from cvzone.HandTrackingModule import HandDetector
import socket
import time

width, height = 1280, 720

cap = cv2.VideoCapture(0)
cap.set(3, width)
cap.set(4, height)
pTime = 0

detector = HandDetector(maxHands=1, detectionCon=0.5, minTrackCon=0.5)

sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
serverAddressPort = ("127.0.0.1", 9999)
serverAddressPort2 = ("127.0.0.1", 8888)

while True:
    success, img = cap.read()
    hands, img = detector.findHands(img)

    data = []
    bboxData = []

    if hands:
        hand = hands[0]
        lmList = hand['lmList']
        bbox = hand["bbox"]
        for lm in lmList:
            data.extend([lm[0], height - lm[1], lm[2]])
        sock.sendto(str.encode(str(data)), serverAddressPort)
        bboxData.extend([bbox[2], bbox[3]])
        sock.sendto(str.encode(str(bboxData)), serverAddressPort2)
    
        
    imgRGB = cv2.cvtColor(img, cv2.COLOR_BGR2RGB)
    cTime = time.time()
    fps = 1 / (cTime - pTime)
    pTime = cTime
    cv2.putText(img, f'FPS:{int(fps)}', (20, 70), cv2.FONT_HERSHEY_SIMPLEX, 1, (0, 255, 0), 2)
    
    img = cv2.resize(img, (0, 0), None, 0.5, 0.5)
    cv2.imshow("Image", img)
    cv2.waitKey(1)
