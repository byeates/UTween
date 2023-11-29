using UnityEngine;
using UnityEngine.UI;

namespace Code.Common.Tween.UI
{
	public static class UTweenImageExtensions
	{
		/// <summary>
		/// A simple color tween
		/// </summary>
		/// <param name="image"></param>
		/// <param name="fromColor"></param>
		/// <param name="toColor"></param>
		/// <param name="time"></param>
		/// <param name="delay"></param>
		/// <returns></returns>
		public static UTweenImageColor ColorTo(this Image image, Color fromColor, Color toColor, float time, UTweenImageColor.EaseType easeType = UTweenImageColor.EaseType.EaseLinear, float delay = 0.0f)
		{
			UTweenImageColor tweenTransform = new UTweenImageColor(image, fromColor, toColor, time, easeType, delay);
			tweenTransform.Start();
			return tweenTransform;
		}
	}
}