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
With the use of a webcam, the script [HandTracking.py](HandTracking.py) tracks your hand through HandDetector. The coordenadas de 21 pontos da sua mão são armazenadas em uma lista,
junto com outra lista, que armazena quantos dedos da sua mão estão levantados.
Tudo é passado para um servidor local criado pelo python, para que a Unity3D consiga acessar esses dados.

> Pelo script [UDPReceive.cs](HandTracking/Assets/Scripts/UDPReceive.cs) da Unity3D é possivel receber as coordenadas da lista gerada pelo Python.

Na Unity3D, os 21 pontos da sua mão são separados em 21 objetos, e cada objeto recebe a posição de 1 ponto da coordenada. Fazendo com que os objetos
acompanhem o movimento da sua mão em tempo real. A partir disso todos os movimentos da sua mão são mostrados com os objetos na cena da Unity3D.
<br>
<div align="center">
<img src="https://user-images.githubusercontent.com/107483658/229907275-334c27a9-7636-4ea0-8afe-19a341d76606.png" width=200px />
</div>

Após conseguir acessar todos os dados, outros scripts criados na Unity3D verificam cada movimeto e quantos dedos da sua mão estão levantados, para conseguir capturar
diferentes gestos. 
Ex: mão fechada, mão aberta, um, dois, três dedos levantados.

Um cenário criado na Unity, possui várias variações de portas, (os modelos fabricados pela empresa Pormade Portas), e com cada gesto 
a pessoa consegue interagir fazendo ela:

- Abrir;✋
- Fechar;🖖
- Separar cada peça contida na estrutura da porta;✌️
- Juntar essas peças;☝️
- Girar em torno da porta;✊
- Aplicar zoom, para ver detalhes;🤏
- Diminuir zoom.👌
- Passar para ver a próxima porta;👋
- Voltar para ver a porta anterior.👋

![HTscene](https://user-images.githubusercontent.com/107483658/230400348-71677e03-5b2c-4c5f-b740-0b98e24d0328.gif)

## Sobre
- As estruturas e texturas do ambiente não foram feitas por mim. Todas são assets da Unity;
- As portas e a logo foram feitas por outro colaborador da empresa Pormade Portas;
- A textura do quadro na parede está na internet: [imagem](https://aeasjc.org.br/wp-content/uploads/2021/10/fabrica-pormade-portas-uniao-da-vitoria-pr_1.jpg)

## Requisitos
- Computador Desktop/Notebook com windows 10 ou maior;
- É necessario ter o python instalado no seu computador;
- Uma webcam;
- Uma tela com resolução 1080 x 1920;
> O projeto só possui uma resolução: 1080 x 1920 :no_mouth:

OBS: Este repositório tem como objetivo apenas demonstrar o projeto, mas a [Build](Build.zip) está disponivel, caso queira e atenda aos requisitos
