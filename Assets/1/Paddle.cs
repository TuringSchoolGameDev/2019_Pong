using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong1
{
	public class Paddle : MonoBehaviour
	{
		//GameObjects are all objects which are in Hierarchy window. Almost everything in Unity is GameObjects.
		public GameObject paddle1;
		public GameObject paddle2;

		//Speed value of paddles
		public float paddleSpeed;

		//we cannot go further up than this value
		public float maxHeight;
		public float minHeight;

		//update is called every frame in unitty monobehaviours
		void Update()
		{
			//Every frame we will check if "W" was pressed. If yes, then do somethig
			if (Input.GetKey(KeyCode.W))
			{
				//If W was pressed, then:

				//get position and store it in temporary value of type Vector3 - it is tree numbers in one variable. Used for coordinate system calculations. (x, y, z);
				Vector3 tmpPosition = paddle1.transform.position;
				//we wiil increase y value. Time.delta time is amount of time which was passed from previous frame. So if we multiply speed per second with amount of time, we will get preciselly how far paddle should move in that frame.
				tmpPosition.y += paddleSpeed * Time.deltaTime;
				//if paddle is to hight, then we should'nt update
				if (tmpPosition.y > maxHeight)
				{
					tmpPosition.y = maxHeight;
				}
				paddle1.transform.position = tmpPosition;
			}

			//same goes with down direction
			if (Input.GetKey(KeyCode.S))
			{
				Vector3 tmpPosition = paddle1.transform.position;
				tmpPosition.y -= paddleSpeed * Time.deltaTime;
				if (tmpPosition.y < minHeight)
				{
					tmpPosition.y = minHeight;
				}
				paddle1.transform.position = tmpPosition;
			}


			//this can be simplified a lot. we will see it in pong2
			if (Input.GetKey(KeyCode.UpArrow))
			{
				Vector3 tmpPosition = paddle2.transform.position;
				tmpPosition.y += paddleSpeed * Time.deltaTime;
				if (tmpPosition.y > maxHeight)
				{
					tmpPosition.y = maxHeight;
				}
				paddle2.transform.position = tmpPosition;
			}

			if (Input.GetKey(KeyCode.DownArrow))
			{
				Vector3 tmpPosition = paddle2.transform.position;
				tmpPosition.y -= paddleSpeed * Time.deltaTime;
				if (tmpPosition.y < minHeight)
				{
					tmpPosition.y = minHeight;
				}
				paddle2.transform.position = tmpPosition;
			}
		}
	}
}