using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong2
{
	public class Ball : MonoBehaviour
	{
		public GameManager gameManager;

		public ScoreUI score1;
		public ScoreUI score2;

		public Vector2 direction;
		public float speed;

		public void NewGame()
		{
			gameObject.transform.position = Vector2.zero;

			//it is not the best error proove code, but it will be good enough for now.
			//we dont waht have situation then ball is moving just vertically, speed should always be between 0.3 and 1 (because 0 multiplied by any speed will be 0)
			direction.x = Random.Range(0.3f, 1f);
			//but this size is always possitive and ball will move just in one direction (right). We want to do random one more time to choose left or right
			float randomDirection = Random.Range(0f, 1f);
			//if value is in lesser half, then move left
			if (randomDirection <= 0.5f)
			{
				//this line does nothing. it would be awoided in normal cases but i will write it for clarification
				direction.x *= 1;
			}
			else
			{
				//else move right
				direction.x *= -1;
			}
			
			//we want to have +- same speed in all rounds. Mathf.abs will return value without sign. -2 is 2 and 2 is also 2
			float remainingVelocity = 1f - Mathf.Abs(direction.x);

			//and same with direction
			float yDirection = Random.Range(0f, 1f);
			if (yDirection <= 0.5f)
			{
				direction.y = remainingVelocity;
			}
			else
			{
				direction.y = -1 * remainingVelocity;
			}
		}

		void Update()
		{
			Vector3 tmpPosition = gameObject.transform.position;
			tmpPosition.x += direction.x * speed * Time.deltaTime;
			tmpPosition.y += direction.y * speed * Time.deltaTime;
			gameObject.transform.position = tmpPosition;
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.gameObject.layer == LayerMask.NameToLayer("Wall"))
			{
				direction.y *= -1;
			}

			if (other.gameObject.layer == LayerMask.NameToLayer("GameOver"))
			{
				if (gameObject.transform.position.x < 0)
				{
					score1.score += 1;
				}
				else
				{
					score2.score += 1;
				}

				//we will pass score because we want to end game eventualy
				gameManager.EndGame(score1, score2);
			}

			if (other.gameObject.layer == LayerMask.NameToLayer("Paddle"))
			{
				direction.x *= -1;
			}
		}
	}
}
