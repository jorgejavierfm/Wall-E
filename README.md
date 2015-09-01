# Wall-E
Wall-E is a robot located in a rectangular terrain. He can advance forward, backward, left or right. The terrain in which he is located can have different obstacles, some can be pushed and others can be picked.

Wall-E has a processing unit capable of executing different instructions. Moreover, he is equipped with different sensors tasked with the detection of various characteristic of the environment where he is located. For example, Wall-E has an ultrasonic sensor capable of determining the distance to an object in front of him, he also has a webcam to identify the color of every object he encounter. This sensors will allow Wall-E to make decisions based on the information he is getting from the environment.

**INSTRUCTIONS**

An instruction is the basic command that Wall-E can execute. Every instruction is followed by another until the special instruction End (red dot).

Some basic instructions work with Wall-E (Go Forward, Go Backwards, Turn Right, Turn Left), others allow Wall-E to make decisions based on a conditional. The execution of these instructions begin with the special instruction Begin (green dot).

**ACTIVITIES**

A set of instructions can be grouped into an Activity, this activity can also be used as an instruction. Every time we want to execute this set of instructions we just need to call the Activity by the name assigned during their creation. 

Activities can´t receive parameters. To receive data and return results global variables will be used, so they can be used in any context.

**MEMORY**

Wall-E can store the main program, auxiliary activities and variables. Variables have a name to identify them and are all Integer or Boolean. These variables do not have to be declared but once its value is assigned it cannot be changed to another type.

**ARRAYS**

An important resource in the programming of Wall-E are the arrays. These arrays are similar to variables but their indexer will be part of their name. For example, a[2,1] = 4 is fine but b = a fails because "a" does not exist as a variable.

Arrays do not have an specific size and the type of elements they hold is determined in the first assignment to any element of the array. For example, move[2] = true is fine but move[1] = 3 fails because the elements of the array will be Booleans. Other peculiar characteristic of these array will be that they can be indexed in negative values. For example, a[4,-3] is valid. If the value of an array is asked before their type is declared an error will be produced, if not, their default value will be returned. For example map[x,y] = true, map[x+1,y] will be false because false is the default value for the boolean type.

Any type of expresion can be indexed. For example, a[3,2]; map[GPS.X,GPS.Y]; marks[amount].

**EXPRESSIONS**

There are instructions that involves values. The programming of Wall-E could involve numeric constants (-3,0,100,20) or booleans (true,false). Variables are another type of expression because they have a value.

There is a set of operands that can be used to form more complex expression (+,-,/,*,%,&&,||,>,>=,<,<=,==,!=).

Example of Expressions:
- amount + 1
- amount >=0 || Ultrasonic.Distance < 3
- (a[3,1+cantidad] +4) * 10

Another type of expression could be the values of Wall-E sensors. This can be done invoking the name of the sensor and then his property. For example, Ultrasonic.Distance return the distance to the nearest object in front of Wall-E.

**ENVIRONMENT**

The environment in which Wall-E is located will be a rectangular field divided into sections (the environment can be designed with the Map Designer). These sections can have objects or not. These objects have different properties that determine if Wall-E can operate with them. For example, the weight can indicate whether the object can be pushed by the robot or not. The size indicates whether the robot can carry the object or not.

Another aspect is that the field does not have to be regular. For example, there may be squares with water, holes, lava, etc. This allows a wider range of actions by Wall-E. For example, push a box into a hole with the objective of passing over.

**OBJECTS**

Every object has characteristics such as color, weight, size, shape. A heavy object will prevent Wall-E from advance,but a light one can be pushed in the direction Wall-E is moving. Wall-E can push various consecutive objects as long as his power (property of Wall-E) is greater than the sum of the weight of every object he is pushing.

When an object moves it may fall into a hole, lava or water. This can be used by Wall-E to avoid some hazardous conditions like a hole in the ground. Some objects can be picked as long as Wall-E can lift them up. Wall-E has a limited amount of space, so the weight and the volume of the object have to be lower than the power and capacity of Wall-E.







