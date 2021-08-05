# Battleship

Battleship Console Game built in C#

![Preview](https://user-images.githubusercontent.com/84479635/128300474-c565446a-7132-4487-b182-a4f5a88e06df.JPG)

## Installation

To use the battleship console application:

1.  Fork this repository, which makes a copy of this repository and stores it to your repository.

2.  Clone your repository to your local machine using the command line: [Git Clone](https://git-scm.com/docs/git-clone). This allows you to make changes to the battleship app and     save those changes to your repository.  Cloning the app directly from this repository will not let you freely push changes to the app.

3.  Navigate to the root directory of the app.  i.e. If you navigated to C:\Users\{YOUR ACCOUNT NAME}\Documents when you ran 'git clone', then there will now be a directory at         C:\Users\{YOUR ACCOUNT NAME}\Documents\Battleship.  Navigate to that folder and find 'Battleship.csproj', and open that file with your preferred IDE.  This will allow you to       view, modify, or run the code.

4.  If you only wish to run the program, navigate to C:\Users\{YOUR ACCOUNT NAME}\Battleship\bin\Debug\net5.0 to find Battleship.exe. Open the exe file to launch the application       without viewing the code.

## Summary

This was my introduction to C# application.  I utilized class based object orientated programing to define a class for the game board and the player's shot at the ship.  I used a constructor function in both class objects; in the player shot class, the constructor function takes the input from the user: a string containing an alpha numeric, and turns it into an array of two integers: the x value and y value corresponding to a location on the game board. This location is saved in a class property, and is used in the program logic to determine if the player hit the ship.  The board class utilizes a constructor function to 'set' the values in the board array to the default value of '-' which indicates no shot was fired at that location. Methods defined on the board class include the display of game messages, ship placement, and shot placement.


#### Author
Nathan McCraw -- Software Developer [LinkedIn](https://www.linkedin.com/in/nathan-mccraw-5291535b/) [Personal Website - In Production]
