<h1 align="center">Sign It or Miss It</h1>
<p align="center">
</p>
<a href="https://weekendofcode.computercodingclub.in/"> <img src="https://i.postimg.cc/njCM24kx/woc.jpg" height=30px> </a>

## Download:
<a href="https://github.com/4SumMNNIT/SIMI/releases"> <img src="https://i.ibb.co/zT7dVswt/CITYPNG-COM-Download-Red-Web-Button-HD-PNG-3000x3000.png" width=200px> </a>

## Introduction:
**Sign It or Miss It** is an interactive Unity game that use computer vision and hand tracking to provide an immersive experience. The game uses **OpenCV** and **MediaPipe** to track hand movements and generate a corresponding 3D hand in Unity. Players must pass their virtual hand through walls with cutout shapes to progress through the game.

## Table of Contents
- [Technology Stack](#technologies-used)
- [Features](#features)
- [Installation & Setup](#installation--setup)
  - [Prerequisites](#prerequisites)
  - [Steps to Run](#steps-to-run)
- [Contributers](#contributors)

## Technologies Used

- **Python**
  - OpenCV
  - MediaPipe
  - cvzone
- **Unity** 
  - C#
- **Blender**
## Features

- **Hand Tracking with OpenCV & MediaPipe**: Real-time hand landmark detection for accurate gesture recognition.
- **Dynamic Wall Cutouts**: Walls with varying hand-shaped cutouts challenge the player's precision and reaction time.
- **UDP Communication**: Hand tracking data is sent from Python to Unity using **UDP sockets**.
- **Engaging Gameplay**: The game gets progressively challenging with different wall patterns and speeds.

  
## Installation & Setup

### Prerequisites
- Python 3.11.x
- Unity (2023+ recommended)
- A webcam or external camera for hand tracking

### Steps to Run

1. **Clone the Repository**
   ```sh
   git clone https://github.com/4SumMNNIT/SIMI.git
   cd SIMI
   ```

2. **Set Up Python Environment**
   ```sh
   cd backend
   python -m venv myenv
   ./myenv/Scripts/activate
   pip install -r requirements.txt
   ```

3. **Run the Hand Tracking Script**
   ```sh
   python main.py
   ```

4. **Open the Unity Project**
   - Open Unity and load the `Unity` project.
   - Open the `Scenes` folder and drag and drop the `Menu` scene to heirarchy window.
   - Unity will prompt to install `TextMesh Pro Essentials` and `Examples & Extras` modules.
   - Install both of these.
   - Run the game in Unity while keeping the Python script running.

5. **Play the Game!**
   - Move your hand in front of the camera.
   - Try to match your hand with the cutout shape in the walls.
   - Advance through the level and test your precision!

## Contributors:

Team Name: 4Sum

* [Manish Sharma](https://github.com/manish-sharma26)
* [Sanyam Goel](https://github.com/hexwhiz)
* [Chinmay Borah](https://github.com/chinmay17-bot)
* [Shubham Gupta](https://github.com/kanha321)
### Made at:



<a href="https://weekendofcode.computercodingclub.in/"> <img src="https://i.postimg.cc/Z9fC676j/devjam.jpg" height=30px> </a>
