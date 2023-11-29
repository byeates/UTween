using UnityEngine;

namespace Code.Common.Tween
{
	public class UTweenTransformRunTo : UTweenTransform
	{
		public UTweenTransformRunTo(Transform t, float time, float delay) : base(t, time, delay)
		{
			
		}
		
		/// <inheritdoc/>
		protected override void ApplyEasing()
		{
			// does nothing
		}
	}
}