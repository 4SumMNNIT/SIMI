# Sign It or Miss It

**Sign It or Miss It** is an interactive Unity game that use computer vision and hand tracking to provide an immersive experience. The game uses **OpenCV** and **MediaPipe** to track hand movements and generate a corresponding 3D hand in Unity. Players must pass their virtual hand through walls with cutout shapes to progress through the game.

## Table of Contents
- [Features](#features)
- [Technologies Used](#technologies-used)
- [Installation & Setup](#installation--setup)
  - [Prerequisites](#prerequisites)
  - [Steps to Run](#steps-to-run)
- [Contributing](#contributing)
- [License](#license)

## Features

- **Hand Tracking with OpenCV & MediaPipe**: Real-time hand landmark detection for accurate gesture recognition.
- **Dynamic Wall Cutouts**: Walls with varying hand-shaped cutouts challenge the player's precision and reaction time.
- **UDP Communication**: Hand tracking data is sent from Python to Unity using **UDP sockets**.
- **Engaging Gameplay**: The game gets progressively challenging with different wall patterns and speeds.

## Technologies Used

- **Python**
  - OpenCV
  - MediaPipe
  - cvzone
- **Unity** 
  - C#
  
## Installation & Setup

### Prerequisites
- Python 3.x
- Unity (2021+ recommended)
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

## Contributing
Contributions are welcome! Feel free to fork the project, make improvements, and submit a pull request.

   - Fork the project.
   - Create a new branch for your feature: git checkout -b feature/new-feature.
   - Commit your changes: git commit -m 'Add new feature'.
   - Push to the branch: git push origin feature/new-feature.
   - Open a pull request.

## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.