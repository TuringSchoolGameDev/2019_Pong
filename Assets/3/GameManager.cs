using UnityEngine;
using UnityEngine.UI;

namespace Pong3
{
	//we can convert simple integers to predefined enums. Enum is number which can have a name. For example 0 is StartState. It is easies to read code this way
	public enum GameState
	{
		StartState = 0,
		GameState = 1
	}
	public class GameManager : MonoBehaviour
	{
		public GameState gameState;
		public GameObject startScreen;
		public Ball ball;

		void Update()
		{
			if (gameState == GameState.StartState)
			{
				if (Input.anyKey)
				{
					gameState = GameState.GameState;
					startScreen.SetActive(false);
					ball.NewGame();
				}
			}
		}

		//we will pass both scores here from ball.cs
		public void EndGame(ScoreUI score1, ScoreUI score2)
		{
			gameState = GameState.StartState;
			startScreen.SetActive(true);

			//if at least one score is greater or equal than 7 then we should restart all game, not just round. In this case it means just reseting scores
			if (score1.score >= 7 || score2.score >= 7)
			{
				score1.score = 0;
				score2.score = 0;
			}
		}
	}
}
