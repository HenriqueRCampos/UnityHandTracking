import cv2
import cvzone
from cvzone.HandTrackingModule import HandDetector
from cvzone.ColorModule import ColorFinder
import socket
import time

width, height = 1280, 720

cap = cv2.VideoCapture(0)
cap.set(3, width)
cap.set(4, height)
pTime = 0

myColorFinder = ColorFinder(False)
detector = HandDetector(maxHands=1, detectionCon=0.5, minTrackCon=0.5)

hsvVals = {'hmin': 69, 'smin': 0, 'vmin': 239, 'hmax': 111, 'smax': 54, 'vmax': 255}
sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
serverAddressPort = ("127.0.0.1", 9999)

while True:
    success, img = cap.read()
    imgColor, mask = myColorFinder.update(img, hsvVals)
    hands, img = detector.findHands(img)

    dataList = []

    if hands:
        hand = hands[0]
        lmList = hand['lmList']
        bbox = hand['bbox']
        fingers = detector.fingersUp(hand)       
        for lm in lmList:
           dataList.extend([lm[0], height - lm[1], lm[2]])
        dataList.extend([bbox[2], bbox[3]])       
        dataList.extend([fingers[0], fingers[1], fingers[2], fingers[3], fingers[4]])
        sock.sendto(str.encode(str(dataList)), serverAddressPort)
              
    imgRGB = cv2.cvtColor(img, cv2.COLOR_BGR2RGB)  
    cTime = time.time()
    fps = 1 / (cTime - pTime)
    pTime = cTime
    cv2.putText(img, f'FPS:{int(fps)}', (20, 70), cv2.FONT_HERSHEY_SIMPLEX, 1, (0, 255, 0), 2)
     
    imgStack = cvzone.stackImages([img, imgColor, mask], 2, 0.5)
    cv2.imshow("Image", imgStack)
    #img = cv2.resize(img, (0, 0), None, 0.5, 0.5)
    cv2.waitKey(1)
