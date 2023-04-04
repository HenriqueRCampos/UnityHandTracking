# HandTracking
Este foi o meu primeiro projeto finalizado.
Feito para a empresa Pormade Portas, com o objetivo de utilizar em exposições de feiras.
Mas acima de tudo, feito como projeto de estudo, pois foi feito durante um Programa de aprendizagem dentro da empresa.
> O projeto só possui uma resolução: 1080 x 1920 :no_mouth:
<div align="center">
<img src="https://user-images.githubusercontent.com/107483658/229909099-e4a19ace-8470-487b-bb5e-086caf1beefe.png" width=px />
</div>

## O que foi utilizado?
- cvzone.HandTrackingModule, uma biblioteca do Python.
- Unity3D.

- Tutorial no youtube [3d Hand Tracking in Virtual Environment | Computer Vision](https://youtu.be/RQ-2JWzNc6k)

## Como funciona?
Com a utilização de uma webcam, o script `HandTracking.py` rastreia a sua mão atravez do HandDetector. As coordenadas de 21 pontos da sua mão são armazenadas em uma lista,
junto com outra lista, que armazena quantos dedos da sua mão estão levantados.
Tudo é passado para um servidor local criado pelo python, para que a Unity3D consiga acessar esses dados.

> Pelo script `UDPReceive.cs` da Unity3D é possivel receber as coordenadas da lista gerada pelo Python.

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
- Passar para ver a proxima porta;👋
- Voltar para ver a porta anterior.👋
