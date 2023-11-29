using System;
using System.Collections.Generic;
using Code.Common.Dispatchers;
using UnityEngine;

namespace Code.Common.Tween
{
	public abstract class UTweenTransform : UTween<Transform>
	{
		/// <summary>
		/// All tweens are created with a duration, and an optional delay
		/// </summary>
		/// <param name="duration"></param>
		/// <param name="delay">delay before tween begins</param>
		public UTweenTransform(Transform target, float duration, float delay = 0f) : base(target, duration, delay)
		{
			
		}
	}
}