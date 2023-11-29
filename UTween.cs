using System;
using System.Collections.Generic;
using Code.Common.Dispatchers;
using UnityEngine;

namespace Code.Common.Tween
{
	public abstract class UTween<T>
	{
		//====================
		// PUBLIC
		//====================
		public enum EaseType
		{
			EaseLinear,
			EaseInSine,
			EaseOutSine,
			EaseInOutSine,
			EaseInQuint,
			EaseOutQuint,
			EaseInOutQuint,
			EaseInQuart,
			EaseOutQuart,
			EaseInOutQuart,
			EaseInQuad,
			EaseOutQuad,
			EaseInOutQuad,
			EaseInExpo,
			EaseOutExpo,
			EaseInOutExpo,
			EaseInElastic,
			EaseOutElastic,
			EaseInOutElastic,
			EaseInCircular,
			EaseOutCircular,
			EaseInOutCircular,
			EaseInBack,
			EaseOutBack,
			EaseInOutBack,
			EaseInBounce,
			EaseOutBounce,
			EaseInOutBounce,
			EaseInCubic,
			EaseOutCubic,
			EaseInOutCubic,
			EaseJiggle,
			EaseSmoothStep,
			EaseDecayingSine
		}

		/// <summary>
		/// Action called when tween has started
		/// </summary>
		public Action OnStart;
		
		/// <summary>
		/// Action called when tween has ended
		/// </summary>
		public Action OnComplete;
		
		/// <summary>
		/// Action called when tween has ended with the tween that expired passed in
		/// </summary>
		public Action<UTween<T>> OnCompleteWithTween;
		
		/// <summary>
		/// Action called during tween updates. Returns current utween instance, and the time percentage the tween has been running for
		/// </summary>
		public Action<UTween<T>, float> OnUpdate;
		
		//====================
		// PROTECTED
		//====================
		/// <summary>
		/// Easing method to apply
		/// </summary>
		public delegate float EaseDelegate(float t, float b, float c, float d);
		
		protected EaseDelegate easeMethod;
		protected T target;

		/// <summary>
		/// Current time into the animation
		/// </summary>
		protected float time;

		/// <summary>
		/// Delay before the tween begins
		/// </summary>
		protected float delay;

		/// <summary>
		/// Total duration for the tween
		/// </summary>
		protected float duration;

		/// <summary>
		/// FSM
		/// </summary>
		protected StateMachine stateMachine;

		public static Dictionary<EaseType, EaseDelegate> easeMap = new Dictionary<EaseType, EaseDelegate>()
		{
			{ EaseType.EaseLinear,			EasingFunctions.EaseLinear },
			{ EaseType.EaseInSine,			EasingFunctions.EaseInSine },
			{ EaseType.EaseOutSine,			EasingFunctions.EaseOutSine },
			{ EaseType.EaseInOutSine,		EasingFunctions.EaseInOutSine },
			{ EaseType.EaseInQuint,			EasingFunctions.EaseInQuint },
			{ EaseType.EaseOutQuint,		EasingFunctions.EaseOutQuint },
			{ EaseType.EaseInOutQuint,		EasingFunctions.EaseInOutQuint },
			{ EaseType.EaseInQuart,			EasingFunctions.EaseInQuart },
			{ EaseType.EaseOutQuart,		EasingFunctions.EaseOutQuart },
			{ EaseType.EaseInOutQuart,		EasingFunctions.EaseInOutQuart },
			{ EaseType.EaseInQuad,			EasingFunctions.EaseInQuad },
			{ EaseType.EaseOutQuad,			EasingFunctions.EaseOutQuad },
			{ EaseType.EaseInOutQuad,		EasingFunctions.EaseInOutQuad },
			{ EaseType.EaseInExpo,			EasingFunctions.EaseInExpo },
			{ EaseType.EaseOutExpo,			EasingFunctions.EaseOutExpo },
			{ EaseType.EaseInOutExpo,		EasingFunctions.EaseInOutExpo },
			{ EaseType.EaseInElastic,		EasingFunctions.EaseInElastic },
			{ EaseType.EaseOutElastic,		EasingFunctions.EaseOutElastic },
			{ EaseType.EaseInOutElastic,	EasingFunctions.EaseInOutElastic },
			{ EaseType.EaseInCircular,		EasingFunctions.EaseInCircular },
			{ EaseType.EaseOutCircular,		EasingFunctions.EaseOutCircular },
			{ EaseType.EaseInOutCircular,	EasingFunctions.EaseInOutCircular },
			{ EaseType.EaseInBack,			EasingFunctions.EaseInBack },
			{ EaseType.EaseOutBack,			EasingFunctions.EaseOutBack },
			{ EaseType.EaseInOutBack,		EasingFunctions.EaseInOutBack },
			{ EaseType.EaseInBounce,		EasingFunctions.EaseInBounce },
			{ EaseType.EaseOutBounce,		EasingFunctions.EaseOutBounce },
			{ EaseType.EaseInOutBounce,		EasingFunctions.EaseInOutBounce },
			{ EaseType.EaseInCubic,			EasingFunctions.EaseInCubic },
			{ EaseType.EaseOutCubic,		EasingFunctions.EaseOutCubic },
			{ EaseType.EaseInOutCubic,		EasingFunctions.EaseInOutCubic },
			{ EaseType.EaseJiggle,			EasingFunctions.EaseJiggle },
			{ EaseType.EaseSmoothStep,		EasingFunctions.EaseSmoothStep },
			{ EaseType.EaseDecayingSine,	EasingFunctions.EaseDecayingSine },
		};

		private static Dictionary<T, List<UTween<T>>> targetTweenMap = new Dictionary<T, List<UTween<T>>>();

		/// <summary>
		/// All tweens are created with a duration, and an optional delay
		/// </summary>
		/// <param name="duration"></param>
		/// <param name="delay">delay before tween begins</param>
		public UTween(T target, float duration, float delay = 0f)
		{
			this.target = target;
			this.duration = duration;
			this.delay = delay;
			time -= delay;

			targetTweenMap ??= new Dictionary<T, List<UTween<T>>>();
			
			if (targetTweenMap.ContainsKey(target))
			{
				targetTweenMap[target].Add(this);
			}
			else
			{
				targetTweenMap.Add(target, new List<UTween<T>>{this});
			}
		}

		/// <summary>
		/// Initialization
		/// </summary>
		protected virtual void Init()
		{
			stateMachine = new StateMachine("utween");
			stateMachine.AddState(GameState.States.RUNNING);
			stateMachine.AddState(GameState.States.STOPPED);
			stateMachine.AddState(GameState.States.READY);
			stateMachine.AddState(GameState.States.DONE);
			stateMachine.UpdateState(GameState.States.READY);
		}

		/// <summary>
		/// Start the update and animation process
		/// </summary>
		public virtual void Start()
		{
			if (stateMachine == null)
			{
				Init();
			}

			if (stateMachine.isState(GameState.States.RUNNING))
			{
				return;
			}
			
			stateMachine.UpdateState(GameState.States.RUNNING);
			HeartbeatDispatcher.AddHandler(Update);
		}

		/// <summary>
		/// Stop the tween
		/// </summary>
		public virtual void Stop()
		{
			if (stateMachine == null || !stateMachine.isState(GameState.States.RUNNING))
			{
				return;
			}
			
			stateMachine.UpdateState(GameState.States.STOPPED);
			HeartbeatDispatcher.RemoveHandler(Update);
		}

		/// <summary>
		/// Stop all running utweens on a transform
		/// </summary>
		internal static void StopAll(T t)
		{
			if (targetTweenMap != null && targetTweenMap.ContainsKey(t))
			{
				foreach (var tween in targetTweenMap[t])
				{
					tween.Stop();
				}
			}
		}
		
		/// <summary>
		/// Stops and destroys all running utweens on a transform
		/// </summary>
		internal static void RemoveAllTWeens(T t)
		{
			StopAll(t);
			
			if (targetTweenMap == null || !targetTweenMap.ContainsKey(t)) { return; }
			
			foreach (var tween in targetTweenMap[t])
			{
				HeartbeatDispatcher.RemoveHandler(tween.Update);
				tween.OnStart = null;
				tween.OnComplete = null;
				tween.OnCompleteWithTween = null;
				tween.OnUpdate = null;
			}
			targetTweenMap?.Remove(t);
		}

		/// <summary>
		/// Destroy the tween.
		/// </summary>
		public virtual void Destroy()
		{
			HeartbeatDispatcher.RemoveHandler(Update);
			
			if (targetTweenMap != null && targetTweenMap.ContainsKey(target))
			{
				targetTweenMap[target].Remove(this);
			}

			OnStart = null;
			OnComplete = null;
			OnCompleteWithTween = null;
			OnUpdate = null;
		}

		/// <summary>
		/// Called when the animation time is finished
		/// </summary>
		protected virtual void Finish()
		{
			OnComplete?.Invoke();
			OnCompleteWithTween?.Invoke(this);
			Destroy();
		}

		/// <summary>
		/// Update method
		/// </summary>
		protected virtual void Update()
		{
			if (target == null)
			{
				Destroy();
				return;
			}

			if (stateMachine == null || stateMachine.isState(GameState.States.STOPPED))
			{
				return;
			}
			
			time += Time.deltaTime;
			
			if (time > duration)
			{
				time = duration;
			}

			if (time >= 0)
			{
				if (target != null)
				{
					ApplyEasing();
				}
				
				OnUpdate?.Invoke(this, DeltaTime);

				if (time >= duration)
				{
					Finish();
				}
			}
		}

		/// <summary>
		/// Apply the easing method
		/// </summary>
		protected abstract void ApplyEasing();
		
		/*================================================================================
		ANCILLARY		
		=================================================================================*/
		/// <summary>
		/// Normalized execution time of the tween
		/// </summary>
		public float DeltaTime => Mathf.Clamp01(time / duration);

		/// <summary>
		/// Returns the transform being operated on
		/// </summary>
		public T Target => target;

		/// <summary>
		/// Total run duration of the tween
		/// </summary>
		public float Duration => duration;
	}
}