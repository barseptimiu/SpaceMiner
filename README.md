# SpaceMiner
2D game in C#

The idea of the game is to collect some keys at each level in order to open a
gate in the maze so you can reach the next level. The maze is going to be
represented as a matrix of picture boxes. I decided to read each level from a file
and then print it to the screen. The file will contain a matrix of numbers and each
of the number will represent the type of the walls, keys, or other pictures that will
appear in the maze. Also there will be a picture for the character.
After reading the file and showing it on the screen, the character should be
able to move in the maze. In order to do that, I will make an event for each arrow
key, testing if the movement in the corresponding direction is possible and if it is I
move the character’s picture in the next picture box adding some points if that’s
the case (collecting keys or other items with points).
Also for opening the gate, I will store in a variable the number of keys
collected and when the number of keys required to open the gate is reached, the
picture box where the gate is will automatically change with the open gate’s
picture.
At the beginning of the game you will have the option to choose which level
you would like to play. Also, after passing a level you will be able to choose
between going to the next level or choosing another level from the list.
