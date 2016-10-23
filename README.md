# AsciiGame

#### Short Description
I develop a fantasy rpg that is only using a simple terminal as graphical interface.
This simple GUI is perfect for my project, because I don't want to spend too much time on making fancy graphics,
and more time on implementing my ideas and (trying) to improve my coding skills.
Without this decision I wouldn't be able to make any progress, and the simple style doesn't really bother me.

#### Used Technologies
* C#
* [OpenTK](https://github.com/opentk/opentk)
* [Sunshine Console](https://github.com/derrickcreamer/SunshineConsole)

#### Screenshots
![Image of the main menu](http://stoaser.bplaced.net/asciigame/scrMainMenu.png "Look at those buttons!")  
The Main Menu, where I currently test control elements!  
The Buttons you see can have different states like disabled and hovered,  
which have their own appearance (see the "Options" or "Exit" buttons).
You can also see a dialogue box on the right, and a selection in the middle.
With all those elements I can easly create new Screens.

![Gradients in action](http://stoaser.bplaced.net/asciigame/scrGradients.png "Look at those gradients!")  
Here is a new feature that I implemented recently.
You can create strings and give them a gradient as text or background color.
```c#
ColoredString.AddGradient(color1, color2, changeText, changeBackground);
```

#### Code Examples
Creating a button:
```c#
// Creating and adding a button to the screen is simple.
var button = new Button(Console, 1, 1, 3, "New Game");

// Subscribing a handler to the Click event that gets fired when the button is clicked.
button.Click += (source, args) => {
  Console.Write(0, 0, "Button clicked!");
};

// Adding the button to the screen.
screen.Add(button);
```
Creating a selection:
```c#
// Creating and adding a selection to the screen is also simple.
var selection = new Selection(Console, 1, 1, 0, 2, 2);

// Adding items to the selection.
selection.AddItem("Item 1");
selection.AddItem("Item 2");
selection.AddItem("Item 3");

// Subscribing a handler to the Valid event that gets fired when the selection is valid.
selection.Valid += (source, args) => {
  Console.Write(0, 0, "The selection is valid!");
};

// Subscribing a handler to the MouseEnter event that gets fired when the mouse hovers over a item.
pathSelection.MouseEnter += (source, args) => {
    // args.ItemList is a list of event relevant strings.
    // In this case the hovered item text is at the first position of the list.
    // In the Valid event the list holds the text of every selected item.
    var hoveredItemText = args.ItemList[0];
    
    Console.Write(0, 0, "The item '" + hoveredItemText + "' is currently hovered.");
};

// Adding the selection to the screen.
screen.Add(selection);
```
