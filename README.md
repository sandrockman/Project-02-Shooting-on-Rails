# Project-02-Shooting-on-Rails
Project 02 – Shooting on Rails
##Pull Request Name: Project 02 Shooting on Rails <team name>
In this project you will be created a rail shooter game that only incorporates the movement of a rail shooter. 

The designer will need to be able to create game objects and set them up as waypoints, and then the character will need to navigate the waypoints throughout the level. 

The designer will be able to place the waypoints in any order they desire, and the character should follow the waypoints in the order the designer sets. When the game starts, waypoints should be hidden so they do not appear during gameplay.


###Types of Movement (Pick 4: 5 points each)

1.	Straight Line Movement – The level designer (LD) will designate two points on the map, and the character will move in a straight line between the two points. The designer should be able to specify how long it will take for the character to move between the two points. 
2.	Bezier Curve Movement – The level designer (LD) will designate three points: the source, the target, and the control point. This will create a basic Bezier curve movement for the character to follow.
3.	Look and Return – Look and Return will rotate the camera to a specific point (the time it takes for the camera to focus should be designer editable), stay on that point for a specified amount of time, and then rotate back to the original position of the camera before the forced look (the time it takes for the camera to focus should be designer editable). 
4.	Look Chain – This is the same as Look and Return, except instead of going back to the original location before the forced look, the camera will move on to the next look location. There can be as many objects in the look chain as the designer requires.
5.	Wait – The character stays at the waypoint for a specified number of seconds.


###Types of Facings (Pick 2: 3 points each)

Each movement will be accompanied by camera facing, giving the designer the option to change the way the character can look during each movement.

1.	Free movement - The character can look wherever they desire.
2.	Look and Return – Look and Return will rotate the camera to a specific point (the time it takes for the camera to focus should be designer editable), stay on that point for a specified amount of time, and then rotate back to the original position of the camera before the forced look (the time it takes for the camera to focus should be designer editable). 
3.	Look Chain – This is the same as Look and Return, except instead of going back to the original location before the forced look, the camera will move on to the next look location. There can be as many objects in the look chain as the designer requires.
4.	Forced Location –The character is forced to look at a specific location for the entire movement, and then gains control of the camera again after the movement is complete.

###Types of Effects (All required: 1 point each)

There should be a second system in place for camera effects. These should be separate from movement and facing, requiring the use of a new tool to plan the effects.

1.	Camera Shake – This will shake the camera with a specified intensity for a specified number of seconds. 
2.	Splatter – A splatter effect will appear on the screen. The designer will determine how long the effect will last. The designer should also get the option to cause the splatter to fade in and out. If the designer chooses this option, then they need to be able to say how fast the splatter fades.
3.	Fade – The screen should either fade-in (go from black screen to the game) or fade-out (go from the game to a black screen) in the specified amount of time.

###UGC

####Text Files - (7 points)

The user should be able to create waypoints outside of the unity engine. This means that the user will input the required information into a text file, and you will need to read and parse the text file. Associate the information with the systems you defined above, and it should work. If the user does not include a file, use a default fallback file that is bundled within your unity game (not exposed to the user).

You will need to have two types of movement, one effect, and two facing options using the text file. 

####Logging and Comments - (2 points)

You should also include a format for logging information into a text file, as well as comment support in the user-generated file. 

####Visual Display - (4 points)

Lastly, you should include visual displays for the level creator to be able to visualize the path of the character. 

####Tips:

1.	Start with the simplest movement first, then do effects, do facing last.
2.	Make a superclass named Waypoint, and subclass for each type of waypoint there can be. 
3.	Make a custom editor drawer for each type of waypoint with the appropriate options.
4.	Utilize co-routines for (almost) everything.
5.	Include assessors in each waypoint for the UGC portion of the lab. 
6.	Include one “main” script that will store all of the waypoints using parallel arrays, in order, and actually complete the tasks of each waypoint.
7.	Draw gizmos in the “main” script, all at once by going through your parallel arrays.
8.	Keep in mind that you could have three waypoints running at once! (Movement, facing, and camera effect). Make sure your algorithms can accomplish this task.
9.	Create a separate class to store enums used in the game, which can hold the various settings that the design can utilize in any dropdowns.
10.	Use custom array displays to hide the Size, instead include the buttons shown in the screenshot. This will protect your arrays from designer whoopsies.

