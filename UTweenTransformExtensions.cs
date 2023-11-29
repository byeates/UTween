using Code.Common.Tween.UI;
using UnityEngine;

namespace Code.Common.Tween
{
	public static class UTweenTransformExtensions
	{
		/*================================================================================
		MOVE METHODS/EXTENSIONS		
		=================================================================================*/
		/// <summary>
		/// Creates a move utween using anchored position, starts the animation, and returns the tween object
		/// </summary>
		/// <param name="transform"></param>
		/// <param name="position"></param>
		/// <param name="time"></param>
		/// <param name="easeType"></param>
		/// <param name="delay"></param>
		/// <returns></returns>
		public static UTweenTransform MoveAnchored
		(
			this Transform transform,
			Vector3 position,
			float time,
			UTweenTransform.EaseType easeType = UTweenTransform.EaseType.EaseLinear,
			float delay = 0f
		)
		{
			UTweenAnchorMove transformMove = new UTweenAnchorMove(transform, position, time, easeType, delay);
			transformMove.Start();
			return transformMove;
		}
		
		/// <summary>
		/// Creates a move utween, starts the animation, and returns the tween object
		/// </summary>
		/// <param name="transform"></param>
		/// <param name="position"></param>
		/// <param name="time"></param>
		/// <param name="easeType"></param>
		/// <param name="isLocal"></param>
		/// <param name="delay"></param>
		/// <returns></returns>
		public static UTweenTransform Move
		(
			this Transform transform,
			Vector3 position,
			float time,
			UTweenTransform.EaseType easeType = UTweenTransform.EaseType.EaseLinear,
			bool isLocal = true,
			float delay = 0f
		)
		{
			UTweenTransformTransformMove transformMove = new UTweenTransformTransformMove(transform, position, time, easeType, isLocal, delay);
			transformMove.Start();
			return transformMove;
		}
		
		/// <summary>
		/// Creates a moveX utween, starts the animation, and returns the tween object
		/// </summary>
		/// <param name="transform"></param>
		/// <param name="position"></param>
		/// <param name="time"></param>
		/// <param name="easeType"></param>
		/// <param name="isLocal"></param>
		/// <param name="delay"></param>
		/// <returns></returns>
		public static UTweenTransform MoveX
		(
			this Transform transform,
			float position,
			float time,
			UTweenTransform.EaseType easeType = UTweenTransform.EaseType.EaseLinear,
			bool isLocal = true,
			float delay = 0f
		)
		{
			UTweenTransformTransformMoveX transformMove = new UTweenTransformTransformMoveX(transform, position, time, easeType, isLocal, delay);
			transformMove.Start();
			return transformMove;
		}
		
		/// <summary>
		/// Creates a moveY utween, starts the animation, and returns the tween object
		/// </summary>
		/// <param name="transform"></param>
		/// <param name="position"></param>
		/// <param name="time"></param>
		/// <param name="easeType"></param>
		/// <param name="isLocal"></param>
		/// <param name="delay"></param>
		/// <returns></returns>
		public static UTweenTransform MoveY
		(
			this Transform transform,
			float position,
			float time,
			UTweenTransform.EaseType easeType = UTweenTransform.EaseType.EaseLinear,
			bool isLocal = true,
			float delay = 0f
		)
		{
			UTweenTransformTransformMoveY transformMove = new UTweenTransformTransformMoveY(transform, position, time, easeType, isLocal, delay);
			transformMove.Start();
			return transformMove;
		}
		
		/// <summary>
		/// Creates a moveZ utween, starts the animation, and returns the tween object
		/// </summary>
		/// <param name="transform"></param>
		/// <param name="position"></param>
		/// <param name="time"></param>
		/// <param name="easeType"></param>
		/// <param name="isLocal"></param>
		/// <param name="delay"></param>
		/// <returns></returns>
		public static UTweenTransform MoveZ
		(
			this Transform transform,
			float position,
			float time,
			UTweenTransform.EaseType easeType = UTweenTransform.EaseType.EaseLinear,
			bool isLocal = true,
			float delay = 0f
		)
		{
			UTweenTransformTransformMoveZ transformMove = new UTweenTransformTransformMoveZ(transform, position, time, easeType, isLocal, delay);
			transformMove.Start();
			return transformMove;
		}
		
		/*================================================================================
		SCALE METHODS/EXTENSIONS		
		=================================================================================*/
		/// <summary>
		/// Creates a scale utween, starts the animation, and returns the tween object
		/// </summary>
		/// <param name="transform"></param>
		/// <param name="scale"></param>
		/// <param name="time"></param>
		/// <param name="easeType"></param>
		/// <param name="delay"><see cref="delay"/></param>
		/// <returns></returns>
		public static UTweenTransform Scale
		(
			this Transform transform,
			Vector3 scale,
			float time,
			UTweenTransform.EaseType easeType = UTweenTransform.EaseType.EaseLinear,
			float delay = 0f
		)
		{
			UTweenTransformTransformScale move = new UTweenTransformTransformScale(transform, scale, time, easeType, delay);
			move.Start();
			return move;
		}
		
		/// <summary>
		/// Creates a scaleX utween, starts the animation, and returns the tween object
		/// </summary>
		/// <param name="transform"></param>
		/// <param name="scale"></param>
		/// <param name="time"></param>
		/// <param name="easeType"></param>
		/// <param name="delay"><see cref="delay"/></param>
		/// <returns></returns>
		public static UTweenTransform ScaleX
		(
			this Transform transform,
			float scale,
			float time,
			UTweenTransform.EaseType easeType = UTweenTransform.EaseType.EaseLinear,
			float delay = 0f
		)
		{
			UTweenTransformTransformScaleX move = new UTweenTransformTransformScaleX(transform, scale, time, easeType, delay);
			move.Start();
			return move;
		}
		
		/// <summary>
		/// Creates a scaleY utween, starts the animation, and returns the tween object
		/// </summary>
		/// <param name="transform"></param>
		/// <param name="scale"></param>
		/// <param name="time"></param>
		/// <param name="easeType"></param>
		/// <param name="delay"><see cref="delay"/></param>
		/// <returns></returns>
		public static UTweenTransform ScaleY
		(
			this Transform transform,
			float scale,
			float time,
			UTweenTransform.EaseType easeType = UTweenTransform.EaseType.EaseLinear,
			float delay = 0f
		)
		{
			UTweenTransformTransformScaleY move = new UTweenTransformTransformScaleY(transform, scale, time, easeType, delay);
			move.Start();
			return move;
		}
		
		/// <summary>
		/// Creates a scaleZ utween, starts the animation, and returns the tween object
		/// </summary>
		/// <param name="transform"></param>
		/// <param name="scale"></param>
		/// <param name="time"></param>
		/// <param name="easeType"></param>
		/// <param name="delay"><see cref="delay"/></param>
		/// <returns></returns>
		public static UTweenTransform ScaleZ
		(
			this Transform transform,
			float scale,
			float time,
			UTweenTransform.EaseType easeType = UTweenTransform.EaseType.EaseLinear,
			float delay = 0f
		)
		{
			UTweenTransformTransformScaleZ move = new UTweenTransformTransformScaleZ(transform, scale, time, easeType, delay);
			move.Start();
			return move;
		}
		
		/*================================================================================
		RectTransform Size		
		=================================================================================*/
		/// <summary>
		/// Creates a scaleZ utween, starts the animation, and returns the tween object
		/// </summary>
		/// <param name="transform"></param>
		/// <param name="endSize"></param>
		/// <param name="time"></param>
		/// <param name="easeType"></param>
		/// <param name="delay"><see cref="delay"/></param>
		/// <returns></returns>
		public static UTweenTransform SizeTo
		(
			this RectTransform transform,
			Vector2 endSize,
			float time,
			UTweenTransform.EaseType easeType = UTweenTransform.EaseType.EaseLinear,
			float delay = 0f
		)
		{
			UTweenTransformTransformSizeTo move = new UTweenTransformTransformSizeTo(transform, endSize, time, easeType, delay);
			move.Start();
			return move;
		}
		
		/// <summary>
		/// A simple utween instance that runs for some duration. Best for use with <see cref="UTweenTransform.OnComplete"/>
		/// </summary>
		/// <param name="transform"></param>
		/// <param name="time"></param>
		/// <param name="delay"></param>
		/// <returns></returns>
		public static UTweenTransform RunTo(this Transform transform, float time, float delay = 0.0f)
		{
			UTweenTransformRunTo tweenTransform = new UTweenTransformRunTo(transform, time, delay);
			tweenTransform.Start();
			return tweenTransform;
		}
		
		/// <summary>
		/// A simple utween instance that runs for some duration, and moves between to values.
		/// </summary>
		/// <param name="transform"></param>
		/// <param name="from"></param>
		/// <param name="to"></param>
		/// <param name="time"></param>
		/// <param name="delay"></param>
		/// <returns></returns>
		public static UTweenTransform ValueTo(this Transform transform, float from, float to, float time, float delay = 0.0f)
		{
			UTweenTransformValueTo tweenTransform = new UTweenTransformValueTo(transform, from, to, time, delay);
			tweenTransform.Start();
			return tweenTransform;
		}

		/// <summary>
		/// Stop all tweens on this transform
		/// </summary>
		/// <param name="transform"></param>
		public static void StopTweens(this Transform transform)
		{
			UTweenTransform.StopAll(transform);
		}

		/// <summary>
		/// Removes all running tweens from the transform
		/// </summary>
		/// <param name="transform"></param>
		public static void RemoveTweens(this Transform transform)
		{
			UTweenTransform.RemoveAllTWeens(transform);
		}
		
		/*================================================================================
		ROTATE METHODS/EXTENSIONS		
		=================================================================================*/
		/// <summary>
		/// A quaternion rotation tween
		/// </summary>
		/// <param name="transform"></param>
		/// <param name="end">euler angle inputs</param>
		/// <param name="time"></param>
		/// <param name="isLocal"></param>
		/// <param name="easeType"></param>
		/// <param name="delay"></param>
		/// <returns></returns>
		public static UTweenTransform RotateTo
		(
			this Transform transform,
			Vector3 end,
			float time,
			bool isLocal = true,
			UTweenTransform.EaseType easeType = UTweenTransform.EaseType.EaseLinear,
			float delay = 0f
		)
		{
			UTweenTransformTransformRotate transformRotate = new UTweenTransformTransformRotate(transform, end, time, easeType, isLocal, delay);
			transformRotate.Start();
			return transformRotate;
		}
	}
}