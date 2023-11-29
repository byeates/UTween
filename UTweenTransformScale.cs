using UnityEngine;

namespace Code.Common.Tween
{
	/// <summary>
	/// Move utween transform
	/// </summary>
	public class UTweenTransformTransformScale : UTweenTransform
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
		/// Creates a new utween
		/// </summary>
		/// <param name="target"></param>
		/// <param name="endValue"></param>
		/// <param name="time">duration of the tween</param> 
		/// <param name="easeType"></param>
		/// <param name="isLocal"><see cref="local"/></param>
		/// <param name="delay"><see cref="delay"/></param>
		public UTweenTransformTransformScale
		(
			Transform target,
			Vector3 endValue,
			float time,
			EaseType easeType = EaseType.EaseLinear,
			float delay = 0f
		) : base(target, time, delay)
		{
			target = target;
			current = target.localScale;
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

			target.localScale = result;
		}
	}
}