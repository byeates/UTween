using System;
using UnityEngine;

namespace Code.Common.Tween
{
	public class UTweenTransformValueTo : UTweenTransform
	{
		/// <summary>
		/// Value tween from
		/// </summary>
		protected float fromValue;
		
		/// <summary>
		/// Value tween to
		/// </summary>
		protected float toValue;

		/// <summary>
		/// Delta between <see cref="toValue"/> and <see cref="fromValue"/>
		/// </summary>
		protected float deltaValue;

		/// <summary>
		/// Current value based on the tween easing/update
		/// </summary>
		protected float currentValue;
		
		public UTweenTransformValueTo(Transform t, float from, float to, float time, float delay, EaseType easeType = EaseType.EaseLinear) : base(t, time, delay)
		{
			fromValue = from;
			toValue = to;
			deltaValue = to - from;
			easeMethod = easeMap[easeType];
		}
		
		/// <inheritdoc/>
		protected override void ApplyEasing()
		{
			if (target == null)
			{
				Destroy();
				return;
			}
			
			currentValue = easeMethod.Invoke(time, fromValue, deltaValue, duration);
		}

		/// <summary>
		/// Returns the current value we are at as a result of tween
		/// </summary>
		public float GetCurrentValue => currentValue;
	}
}