# Edge-Detection
Implement image edge detection using either the Sobel or Prewitt operator, based on user input.

# Installation
This project uses .NET 9.0 as the framework.

`System.Drawing.Common(v9.0.1)` and  `xunit(v2.9.3)` should already be installed when the repository is cloned.

If you encounter missing package errors, use "**Manage NuGet Packages**" under the Project tab to install the required dependencies.

# Set-up
The Edge-Detection solution contains an input folder (`AugmentusAssignment\Edge_Detection\Edge_Detection\input`), where you should place the images (`.png` and `.jpg`) to apply the edge detection filter. The processed images will be saved in the output folder(`AugmentusAssignment\Edge_Detection\Edge_Detection\output`).

# Launch
To run the program
1. Press F5 to start the program.
2. Select 1 for Sobel or 2 for Prewitt.
3. Wait for the message "filter applied".

# Unit test
To run the unit test:
1. Right-click UnitTest project in the Soultion Explorer.
2. Select "Run Tests".
