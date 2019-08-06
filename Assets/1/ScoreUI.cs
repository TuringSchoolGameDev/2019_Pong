using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Pong1
{
	//File name should be the same as the name here..
	//All standart scripts in Unity are MonoBehaviours. For now lets just think that everything is monobehaviours and leter we will try to understand more about this.
	public class ScoreUI : MonoBehaviour
	{
		//public fields are visible inside of unity editor and they can be accessed from other scripts.
		//int is numbers. For example 1, 2, 3, -5, -1000, 0 etc.
		public int score = 0;
		//this is recognized just if UnityEngine.UI is included!
		//this is variable of type Text and it is called textField
		public Text textField;

		//all monobehaviours scripts have Update function. It is called every frame then the game is running
		public void Update()
		{
			//we call textField variable every frame and we are trying to change text field in that text to our score
			textField.text = score + "";
		}
	}
}