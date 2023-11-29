using UnityEngine;

namespace Code.Common.Tween
{
	/// <summary>
	/// Move utween transform
	/// </summary>
	public class UTweenTransformTransformMoveY : UTweenTransform
	{
		//====================
		// PROTECTED
		//====================
		/// <summary>
		/// Ending float values
		/// </summary>
		protected float end;
		
		/// <summary>
		/// Starting float values
		/// </summary>
		protected float current;

		/// <summary>
		/// Mark true for local transformations
		/// </summary>
		protected bool local;

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
		public UTweenTransformTransformMoveY
		(
			Transform target,
			float endValue,
			float time,
			EaseType easeType = EaseType.EaseLinear,
			bool isLocal = true,
			float delay = 0f
		) : base(target, time, delay)
		{
			target = target;
			local = isLocal;
			current = local ? target.localPosition.y : target.position.y;
			end = endValue - current;
			easeMethod = easeMap[easeType];
			Init();
		}

		/// <inheritdoc/>
		protected override void Init()
		{
			base.Init();
			result = new Vector3();

			if (local)
			{
				result.x = target.localPosition.x;
				result.z = target.localPosition.z;
			}
			else
			{
				result.x = target.position.x;
				result.z = target.position.z;
			}
		}

		/// <inheritdoc/>
		protected override void ApplyEasing()
		{
			if (target == null)
			{
				Destroy();
				return;
			}
			
			result.y = easeMethod.Invoke(time, current, end, duration);

			if (local)
			{
				target.localPosition = result;
			}
			else
			{
				target.position = result;
			}
		}
	}
}