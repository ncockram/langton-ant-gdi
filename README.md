# Langton's Ant (GDI)

A C# implementation of [Langton’s Ant](https://en.wikipedia.org/wiki/Langton%27s_ant), a two-dimensional Turing machine with simple rules but complex emergent behavior, rendered using Windows GDI graphics.

## Features

- Fast, real-time visualization of Langton’s Ant
- Adjustable grid size and simulation speed
- Simple, easy-to-understand code structure
- Written entirely in C# using Windows Forms and GDI for rendering

## Getting Started

### Prerequisites

- [.NET Framework](https://dotnet.microsoft.com/download) (typically 4.5 or above)
- Windows OS

### Running the Project

1. **Clone the repository**  
   ```bash
   git clone https://github.com/ncockram/langton-ant-gdi.git
   ```
2. **Open the solution in Visual Studio**
3. **Build and Run**

The main window displays the Langton’s Ant simulation. Use available controls to start, pause, or reset the simulation if provided.

## About Langton’s Ant

Langton's Ant is a cellular automaton invented by Chris Langton in 1986. It consists of an “ant” moving on a grid of black and white cells according to these rules:

1. At a white square, turn 90° right, flip the color of the square, move forward one unit.
2. At a black square, turn 90° left, flip the color of the square, move forward one unit.

Despite the simplicity, the ant’s path leads to complex, emergent patterns over time.

## Screenshot

![Screenshot](screenshot.png)  
*Add a screenshot of your application here.*

## License

This repository is licensed under the MIT License. See [LICENSE](LICENSE) for details.

## Credits

Created by [ncockram](https://github.com/ncockram).
