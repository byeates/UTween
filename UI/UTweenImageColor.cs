using UnityEngine;
using UnityEngine.UI;

namespace Code.Common.Tween.UI
{
	/// <summary>
	/// Simple image color tween
	/// </summary>
	public class UTweenImageColor : UTween<Image>
	{
		private Color startColor;
		private Color endColor;
		private Color deltaColor;
		
		/// <summary>
		/// Creates a new utween transform 3d
		/// </summary>
		/// <param name="target"></param>
		/// <param name="fromColor"></param>
		/// <param name="toColor"></param>
		/// <param name="time">duration of the tween</param>
		/// <param name="easeType"></param>
		/// <param name="delay"><see cref="delay"/></param>
		public UTweenImageColor
		(
			Image target,
			Color fromColor,
			Color toColor,
			float time,
			EaseType easeType = EaseType.EaseLinear,
			float delay = 0f
		) : base(target, time, delay)
		{
			startColor = fromColor;
			endColor = toColor;
			deltaColor = toColor - startColor;
			easeMethod = easeMap[easeType];
			Init();
		}

		/// <inheritdoc/>
		protected override void ApplyEasing()
		{
			if (target == null)
			{
				Destroy();
				return;
			}
			
			float currentRed = easeMethod.Invoke(time, startColor.r, deltaColor.r, duration);
			float currentGreen = easeMethod.Invoke(time, startColor.g, deltaColor.g, duration);
			float currentBlue = easeMethod.Invoke(time, startColor.b, deltaColor.b, duration);
			float currentAlpha = easeMethod.Invoke(time, startColor.a, deltaColor.a, duration);

			target.color = new Color(currentRed, currentGreen, currentBlue, currentAlpha);
		}
	}
}