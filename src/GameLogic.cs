
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
//using System.Data;
using System.Diagnostics;
using SwinGameSDK;
static class GameLogic
{
	public static void Main()
	{
		//Opens a new Graphics Window
		SwinGame.OpenGraphicsWindow("Battle Ships", 800, 600);

		//Load Resources
		GameResources.LoadResources();

		SwinGame.PlayMusic(GameResources.GameMusic("Background"));

		//Game Loop
		do {
			GameController.HandleUserInput();
			GameController.DrawScreen();
			//Changging Screen Resoultion
			if (SwinGame.KeyTyped(KeyCode.vk_f)){
              SwinGame.ChangeScreenSize(1920,1080);
                }
            else if(SwinGame.KeyTyped(KeyCode.vk_c)){
                SwinGame.ChangeScreenSize(800,600);
                }
			//Pausing and Resuming Music/Sound	
             if (SwinGame.KeyTyped(KeyCode.vk_m)){
              SwinGame.PauseMusic();

                }
            else if(SwinGame.KeyTyped(KeyCode.vk_p)){
                SwinGame.ResumeMusic();
                } 
		} while (!(SwinGame.WindowCloseRequested() == true | GameController.CurrentState == GameState.Quitting));

		SwinGame.StopMusic();

		//Free Resources and Close Audio, to end the program.
		GameResources.FreeResources();
	}
}