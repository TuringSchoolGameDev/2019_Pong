using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Pong3
{
	public class ScoreUI : MonoBehaviour
	{
		public int score = 0;
		public Text textField;

		public void Update()
		{
			//we can convert almost everything to string with method .ToString(). It has same effect as "" + score in this case. but can be used in many more ways. we will leave it for future topics
			textField.text = score.ToString();
		}
	}
}