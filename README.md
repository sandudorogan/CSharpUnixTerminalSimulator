# Unix Terminal Simulator

## C#
------
As the name implies it, the repository contains a *simplist* terminal simulator which supports the abridged versions of the following commands:
* `Echo` message
* `Echo` message > file
* `Cd` path
* `Ls` 
* `Touch` file name
* `Mkdir` file name
* `Tree`
* `Pwd`
* `Rm` file name
* `Rmdir` file name

_Note:_ 
- Commands with no target work in/with the current directory.
- Only the `cd` command takes a slighlty more complex path (as it should). The rest of them, do work only in the current directory.