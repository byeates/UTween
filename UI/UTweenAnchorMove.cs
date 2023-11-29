using UnityEngine;

namespace Code.Common.Tween.UI
{
	/// <summary>
	/// Move utween transform
	/// </summary>
	public class UTweenAnchorMove : UTweenTransform
	{
		//====================
		// PROTECTED
		//====================
		/// <summary>
		/// Ending vector3 values
		/// </summary>
		protected Vector3 end;
		
		/// <summary>
		/// Starting vector3 values
		/// </summary>
		protected Vector3 current;

		/// <summary>
		/// Output from easing methods
		/// </summary>
		protected Vector3 result;

		/// <summary>
		/// Target casted to rect transform
		/// </summary>
		protected RectTransform rectTransformTarget;

		/// <summary>
		/// Creates a new utween transform 3d
		/// </summary>
		/// <param name="target"></param>
		/// <param name="endValue"></param>
		/// <param name="time">duration of the tween</param>
		/// <param name="easeType"></param>
		/// <param name="delay"><see cref="delay"/></param>
		public UTweenAnchorMove
		(
			Transform target,
			Vector3 endValue,
			float time,
			EaseType easeType = EaseType.EaseLinear,
			float delay = 0f
		) : base(target, time, delay)
		{
			this.target = target;
			rectTransformTarget = (RectTransform)target;
			current = rectTransformTarget.anchoredPosition;
			end = endValue - current;
			easeMethod = easeMap[easeType];
			Init();
		}
		
		/// <inheritdoc/>
		protected override void Init()
		{
			base.Init();
			result = new Vector3();
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
			result.z = easeMethod.Invoke(time, current.z, end.z, duration);

			rectTransformTarget.anchoredPosition = result;
		}
	}
}