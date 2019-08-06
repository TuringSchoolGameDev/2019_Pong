using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong1
{
	public class Ball : MonoBehaviour
	{
		//reference to gameManager. for easier understanding we name it the same as class name but with small leter
		public GameManager gameManager;

		//we store both our scores here
		public ScoreUI score1;
		public ScoreUI score2;

		//direction of ball movement
		public Vector2 direction;
		//speed per second in meters
		public float speed;

		//we will call this function at start of each round from gamemanager.cs script
		public void NewGame()
		{
			//in the start of each round we want to place this game object (ball) in the center. Zero coordinates
			gameObject.transform.position = Vector2.zero;

			//Random rande function will give value beetween [0.0 and 1.0]. F means that this value is decimal type number. It can contain numbers after point. ex.: 0.152, 0.16, etc ...
			//we are choosing random direction both in x and y axis
			direction.x = Random.Range(-1f, 1f);
			direction.y = Random.Range(-1f, 1f);
		}
		void Update()
		{
			//doing the same as with paddles movement gere
			Vector3 tmpPosition = gameObject.transform.position;
			//calculating spped of both axis separately
			tmpPosition.x += direction.x * speed * Time.deltaTime;
			tmpPosition.y += direction.y * speed * Time.deltaTime;
			gameObject.transform.position = tmpPosition;
		}

		//this function is triggered if gameobject contains 2d collider and 2d rigidbody
		private void OnTriggerEnter2D(Collider2D other)
		{
			Debug.Log("Trigger Entered");

			//if object we collided are in layer called wall then do this code
			if (other.gameObject.layer == LayerMask.NameToLayer("Wall"))
			{
				//change vcertical direction
				direction.y *= -1;
			}

			//if we callide with gameobject in left or right
			if (other.gameObject.layer == LayerMask.NameToLayer("GameOver"))
			{
				//then add score accordingly to score1 or 2
				if (gameObject.transform.position.x < 0)
				{
					score1.score += 1;
				}
				else
				{
					score2.score += 1;
				}

				//and end this round
				gameManager.EndGame();
			}

			//if collided with paddle change direction x
			if (other.gameObject.layer == LayerMask.NameToLayer("Paddle"))
			{
				direction.x *= -1;
			}
		}
	}
}
