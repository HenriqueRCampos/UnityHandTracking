# HandTracking
This was my first completed project.
Made for the company Pormade Portas, with the objective of using it in exhibitions at fairs.
But above all, done as a study project, as it was done during a learning program within the company.

<div align="center">
<img src="https://user-images.githubusercontent.com/107483658/229909099-e4a19ace-8470-487b-bb5e-086caf1beefe.png" width=px />
</div>

## What was used?
- Unity;
- Python;
- cvzone.HandTrackingModule, Python's library;
- Tutorial on Youtube [3d Hand Tracking in Virtual Environment | Computer Vision](https://youtu.be/RQ-2JWzNc6k)

## How it works?
With the use of a webcam, the script [HandTracking.py](HandTracking.py) tracks your hand through HandDetector. The 21 coordinates landmarks of your hand are stored in a list,
together another list, that store how much fingers of your hand are rise up.
All is passed to a server made with python, then Unity can acess this data.

> By script [UDPReceive.cs](HandTracking/Assets/Scripts/UDPReceive.cs) Unity receive the coordinates of list in python.

In Unity, the 21 landmarks are separetad at 21 objects, each object receive the position of one landmark of coordinates, this make the objects accompany your hand movement in real time.
<br>
<div align="center">
<img src="https://user-images.githubusercontent.com/107483658/229907275-334c27a9-7636-4ea0-8afe-19a341d76606.png" width=200px />
</div>

After acess all data, other scripts at Unity check each movment and fingers rise up, to capture diferent gesture.

Exemple: closed hand, opened hand. One, two, tree fingers rise up.

One scene at Unity, has various variations of doors, and with each gesture the person can interact making the door:

- Open;✋
- Close;🖖
- Separate each part contained in the door frame;✌️
- Put together each part;☝️
- Spin around the door;✊
- Apply zoom;🤏
- Decrease zoom.🤏
- Next door;👋
- Previus door.👋

![HTscene](https://user-images.githubusercontent.com/107483658/230400348-71677e03-5b2c-4c5f-b740-0b98e24d0328.gif)

## About
- The 3D objects and textures from ambient weren't made by me. All are Unity assets;
- The doors and logo were made by another Pormade Portas collaborator's;
- The texture on the wall picture is here: [imagem](https://aeasjc.org.br/wp-content/uploads/2021/10/fabrica-pormade-portas-uniao-da-vitoria-pr_1.jpg)
