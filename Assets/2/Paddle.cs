using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong2
{
	public class Paddle : MonoBehaviour
	{
		public GameObject paddle;

		//we will expose enumerator here in editor. We can choose that keys are needed to move paddle
		public KeyCode upKey;
		public KeyCode downKey;
		
		public float paddleSpeed;

		public float maxHeight;
		public float minHeight;

		void Update()
		{
			Vector3 tmpPosition = paddle.transform.position;

			//a lot less code. because one script can move each paddle separately. We want to reuse as much code as possible! Always!
			if (Input.GetKey(upKey))
			{
				tmpPosition.y += paddleSpeed * Time.deltaTime;
			}
			else if (Input.GetKey(downKey))
			{
				tmpPosition.y -= paddleSpeed * Time.deltaTime;
			}

			if (tmpPosition.y < minHeight)
			{
				tmpPosition.y = minHeight;
			}
			else if (tmpPosition.y > maxHeight)
			{
				tmpPosition.y = maxHeight;
			}

			paddle.transform.position = tmpPosition;
		}
	}
}