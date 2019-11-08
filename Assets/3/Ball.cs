using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong3
{
	public class Ball : MonoBehaviour
	{
		public GameManager gameManager;
		public new Rigidbody2D rigidbody2D;

		public ScoreUI score1;
		public ScoreUI score2;

		public float speed;

		public void NewGame()
		{
			gameObject.transform.position = Vector2.zero;

			Vector2 direction = Random.onUnitSphere.normalized;
			direction.Normalize();
			while (Mathf.Abs(direction.x) < 0.2f)
			{
				direction = Random.onUnitSphere.normalized;
				direction.Normalize();
			}

			rigidbody2D.velocity = Vector2.zero;
			rigidbody2D.AddForce(direction * speed);
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.gameObject.layer == LayerMask.NameToLayer("Wall"))
			{
				Vector2 tmpVelocity = rigidbody2D.velocity;
				tmpVelocity.y *= -1;
				rigidbody2D.velocity = tmpVelocity;
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
				Vector2 tmpVelocity = rigidbody2D.velocity;
				tmpVelocity.x *= -1;
				rigidbody2D.velocity = tmpVelocity;
			}
		}
	}
}
