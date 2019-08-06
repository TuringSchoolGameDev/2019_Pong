using UnityEngine;
using UnityEngine.UI;

namespace Pong1
{
	public class GameManager : MonoBehaviour
	{
		//game state can be 0 or 1 in our case.
		//0 if game is stopped (menu) or 1 if running
		public int gameState = 0;
		//reference to object to enable or disable "start"
		public GameObject startScreen;
		//reference to ball. we want to teleport ball at start
		public Ball ball;

		//called each frame
		void Update()
		{
			//if gamestate is 0 then we want to press any key to start game
			if (gameState == 0)
			{
				if (Input.anyKey)
				{
					//changing state to 1, disable start screen and tell ball to teleport/move
					gameState = 1;
					startScreen.SetActive(false);
					ball.NewGame();
				}
			}
		}

		//this is called from our ball.cs. we will set state to 0 and enable back start screen
		public void EndGame()
		{
			gameState = 0;
			startScreen.SetActive(true);
		}
	}
}
