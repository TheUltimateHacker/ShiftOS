Cleanup
=======
This branch is home to the fresh refactored and rewritten code of ShiftOS, aiming to be more maintainable.

Please don't double-push stuff both in master and this branch, I will take care of it and make sure it doesn't break stuff on my end.

"Lead developer" of this branch: AlphaBeta0110

Why?
----
The ShiftOS code is literally messed to the point it's hard to make a change in some of the more used code, like window code, as it's repeated and repeated in almost every file. 
Refactoring and rewritting the code will result in a code that is better maintainable and where it isn't required to change a single constant manually in all files to change something.

Roadmap
-------
1. Rewrite and refactoring of the windows code - IN PROGRESS
2. Replace hard coded paths
2. Rewrite the skinning code to be more self-describing
3. Rewrite the code behind Shiftorium and Installer and moving it to API classes the applications will use
4. Document the API
5. Make ShiftOS modular, which makes mods possible

The branch will sync with the latest code on the completion of each goal, as long as the changes don't conflict with the changes I've already done.

Current status
--------------
* ShiftOS.API.ShiftWindow - 40% done // We need to talk about the organization of the classes inside the EXE
* Modifying all windows to use the ShiftWindow API - 0% done
* Making custom classes for buttons and other common controls - 0% done
* Did I mention documentation? Documentation - 0% done
