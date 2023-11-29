using UnityEngine;

namespace Code.Common.Tween
{
	/// <summary>
	/// Move utween transform
	/// </summary>
	public class UTweenTransformTransformSizeTo : UTweenTransform
	{
		//====================
		// PROTECTED
		//====================
		/// <summary>
		/// Ending vector3 values
		/// </summary>
		protected Vector2 end;
		
		/// <summary>
		/// Starting vector3 values
		/// </summary>
		protected Vector2 current;

		/// <summary>
		/// Output from easing
		/// </summary>
		protected Vector2 result;

		/// <summary>
		/// Creates a new utween
		/// </summary>
		/// <param name="target"></param>
		/// <param name="endValue"></param>
		/// <param name="time">duration of the tween</param> 
		/// <param name="easeType"></param>
		/// <param name="delay"><see cref="delay"/></param>
		public UTweenTransformTransformSizeTo
		(
			RectTransform target,
			Vector2 endValue,
			float time,
			EaseType easeType = EaseType.EaseLinear,
			float delay = 0f
		) : base(target, time, delay)
		{
			current = target.sizeDelta;
			end = endValue - current;
			easeMethod = easeMap[easeType];
			Init();
		}

		/// <inheritdoc/>
		protected override void Init()
		{
			base.Init();
			result = new Vector2();
		}

		/// <inheritdoc/>
		protected override void ApplyEasing()
		{
			if (target == null)
			{
				Destroy();
				return;
			}
			
			result.x = easeMethod.Invoke(time, current.x, end.x, duration);
			result.y = easeMethod.Invoke(time, current.y, end.y, duration);

			((RectTransform)target).sizeDelta = result;
		}
	}
}