# LittlePics
Little Pics is a small project that I'm working on when i get some free time (which is kinda rare lately :c ). The goal of this project is to try stuff and tools that I didn't had the chance to experiment for the moment in Unity and C#. For instance, procedural animation, Finate State Machine, Observer Pattern etc...
The end result that I have in mind is a little cute/horror game where you'll have to take pictures of certain objects in order to win. I'm trying my best to not overscope and keep just some clear objectives in mind. Here's a little preview of what I've done for the moment:

https://github.com/user-attachments/assets/75758c2e-e52b-4781-a4b7-b3192e1128f0


## Code Logic
- **Observer Pattern:** I wanted to try a code system that I had in mind for a while. I want all visuals to be separated from gameplay logic. This is where the obesrevr pattern comes in handy. This allows me for easy changes. For instance if there's a bug related to a certain ability I know if it's related to the logic or to the visual script, and changing it won't really affect the other since it's all based on events triggers.
- **Singleton:** I chose for the first time to create a Singleton for my player components since I found myself to reference multiple times stuff like Animator, Player Inputs etc.. However sometimes a component or a script was not yet initialized, and calling it from elsewhere resulted in a null ref error. To solve this, in the project settings, I set the script executing order earlier than the rest so I'm sure that everything is initialized. 
- **FSM:** I implemented a Finite State Machine to better script the different interactions the player can do based on the object he is holding. This system is pretty simple to setup and makes it clear to transition between one logic to another.

## Gameplay
- **Climbing** : Using the Animation Rigging package I implemented a procedural climbing animation that will adapt based on the height of any obstacle. The player jump height and the player hands position will procedurally adapt for any obstacle.
- **Combat System** : In order to avoid boring fights with enemies I implemented the ability of shooting system and I also added a melee combo system. Both attacks can push enemies away.
- **Sprinting:** : I want in the future to make the player correctly manage his stamina when running from dangers so I added the ability to sprint.

## Visuals
- **Cell Shading**: For the moment I just implemented a simple cell shading made in hlsl and shader graph. I know that I want to push this further in the future but for the moment I wanted to just have a little preview of my end idea.
- **Outline** : Full screen pass to make evry object have a thin outline. The logic is based on normals and blit source(color) difference between objects.

## TODO:
- ~~Implement outline shader~~
- Update showcase video
- Finish torch ability Logic
- Implement camera ability logic
- Implement assets credits (I have them in another machine, they'll be up soon)

  









 
