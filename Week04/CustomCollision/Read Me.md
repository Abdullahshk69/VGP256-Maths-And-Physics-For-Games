Go to _Scenes -> Live -> Level01 OR Level02 to play the game.

Use WASD / Controller left Stick to move the character.

Collect keys to open doors.



Added circle to circle, circle to rectangle and rectangle to rectangle collisions.

Made the collision logics modular to make it easier to add more custom colliders in the future.

It also made bug fixing easier as my code was split into parts.



The biggest challenge for me was to work with the modular way I created in the first place. I did not have enough time to add the logics I initially planned.

I was hoping to achieve similar level of implementation of collisions as unity has, for example I wanted to add "OnCollisionEnter, OnCollisionStay, OnCollisionExit, OnTriggerEnter, OnTriggerStay, OnTriggerExit" in my game.

There is an on going bug in the game where only certain keys and certain doors will teleport a player on a very specific part of the map. I do not know what is causing this and unfortunately it is very hellish to fix it. IT SHOULD NOT OCCUR IN THE FIRST PLACE!!