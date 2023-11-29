using UnityEngine;

namespace Code.Common.Tween
{
	/// <summary>
	/// Move utween transform
	/// </summary>
	public class UTweenTransformTransformScaleZ : UTweenTransform
	{
		//====================
		// PROTECTED
		//====================
		/// <summary>
		/// Ending vector3 values
		/// </summary>
		protected float end;
		
		/// <summary>
		/// Starting vector3 values
		/// </summary>
		protected float current;
		
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
		public UTweenTransformTransformScaleZ
		(
			Transform target, 
			float endValue, 
			float time,
			EaseType easeType = EaseType.EaseLinear,
			float delay = 0f
		) : base(target,time, delay)
		{
			target = target;
			current = target.localScale.y;
			end = endValue - current;
			easeMethod = easeMap[easeType];
			Init();
		}
		
		/// <inheritdoc/>
		protected override void Init()
		{
			base.Init();
			result = new Vector3(target.localScale.x, target.localScale.y, target.localScale.z);
		}

		/// <inheritdoc/>
		protected override void ApplyEasing()
		{
			if (target == null)
			{
				Destroy();
				return;
			}
			
			result.z = easeMethod.Invoke(time, current, end, duration);
			target.localScale = result;
		}
	}
}