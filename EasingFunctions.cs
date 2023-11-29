/*
	TERMS OF USE - EASING EQUATIONS
	---------------------------------------------------------------------------------
	Open source under the BSD License.
	Copyright © 2001 Robert Penner All rights reserved.
	Redistribution and use in source and binary forms, with or without
	modification, are permitted provided that the following conditions are met:
	Redistributions of source code must retain the above copyright notice, this
	list of conditions and the following disclaimer. Redistributions in binary
	form must reproduce the above copyright notice, this list of conditions and
	the following disclaimer in the documentation and/or other materials provided
	with the distribution. Neither the name of the author nor the names of
	contributors may be used to endorse or promote products derived from this
	software without specific prior written permission.
	THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
	AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
	IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
	DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE
	FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
	DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
	SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
	CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
	OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
	OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
	---------------------------------------------------------------------------------
*/

using UnityEngine;

namespace Code.Common.Tween
{
	/// <summary>
	/// Easing functions ported from rober penner's easing library. Methods take 4 parameters:
	/// t = time, b = starting value, c = change in values, d = duration
	/// time = current time into the tween
	/// b = starting value, e.g. starting at position "50"
	/// c = change in values, e.g. ending at position 200, so c is equal to 150 (200 - b) = (200 - 50) = 150)
	/// d = duration, total run time
	/// </summary>
	public class EasingFunctions
	{
		//====================
		// CONST
		//====================
		private const float PI_M2 = Mathf.PI*2;
		private const float PI_D2 = Mathf.PI/2;
		
		/*================================================================================
		Linear		
		=================================================================================*/
		public static float EaseLinear(float t, float b, float c, float d)
		{
			return c*t/d + b;
		}
	
		/*================================================================================
		Sine		
		=================================================================================*/
		public static float EaseInSine(float t, float b, float c, float d)
		{
			return -c * Mathf.Cos(t/d * PI_D2) + c + b;
		}
		
		public static float EaseOutSine(float t, float b, float c, float d)
		{
			return c * Mathf.Sin(t/d * PI_D2) + b;
		}
		
		public static float EaseInOutSine(float t, float b, float c, float d)
		{
			return -c/2 * (Mathf.Cos(Mathf.PI*t/d) - 1) + b;
		}

		/*================================================================================
		Quintic		
		=================================================================================*/
		public static float EaseInQuint(float t, float b, float c, float d)
		{
			return c*(t/=d)*t*t*t*t + b;
		}
		
		public static float EaseOutQuint(float t, float b, float c, float d)
		{
			return c*((t=t/d-1)*t*t*t*t + 1) + b;
		}
		
		public static float EaseInOutQuint(float t, float b, float c, float d)
		{
			if ((t/=d/2) < 1) return c/2*t*t*t*t*t + b;
			return c/2*((t-=2)*t*t*t*t + 2) + b;
		}

		/*================================================================================
		Quartic		
		=================================================================================*/
		public static float EaseInQuart(float t, float b, float c, float d)
		{
			return c*(t/=d)*t*t*t + b;
		}
		
		public static float EaseOutQuart(float t, float b, float c, float d)
		{
			return -c * ((t=t/d-1)*t*t*t - 1) + b;
		}
		
		public static float EaseInOutQuart(float t, float b, float c, float d)
		{
			if ((t/=d/2) < 1) return c/2*t*t*t*t + b;
			return -c/2 * ((t-=2)*t*t*t - 2) + b;
		}

		/*================================================================================
		Quadratic		
		=================================================================================*/
		public static float EaseInQuad(float t, float b, float c, float d)
		{
			return c*(t/=d)*t + b;
		}
		
		public static float EaseOutQuad(float t, float b, float c, float d)
		{
			return -c *(t/=d)*(t-2) + b;
		}
		
		public static float EaseInOutQuad(float t, float b, float c, float d)
		{
			if ((t/=d/2) < 1) return c/2*t*t + b;
			return -c/2 * ((--t)*(t-2) - 1) + b;
		}

		/*================================================================================
		Exponential		
		=================================================================================*/
		public static float EaseInExpo(float t, float b, float c, float d)
		{
			return (t==0) ? b : c * Mathf.Pow(2, 10 * (t/d - 1)) + b;
		}
		
		public static float EaseOutExpo(float t, float b, float c, float d)
		{
			return (t==d) ? b+c : c * (-Mathf.Pow(2, -10 * t/d) + 1) + b;
		}
		
		public static float EaseInOutExpo(float t, float b, float c, float d)
		{
			if (t==0) return b;
			if (t==d) return b+c;
			if ((t/=d/2) < 1) return c/2 * Mathf.Pow(2, 10 * (t - 1)) + b;
			return c/2 * (-Mathf.Pow(2, -10 * --t) + 2) + b;
		}

		/*================================================================================
		Elastic		
		=================================================================================*/
		public static float EaseInElastic(float t, float b, float c, float d)
		{
			float s = 0f;
			float a = 0f;
			float p = d*0.3f;

			if (t == 0) { return b; }
			if ((t /= d) == 1f) { return b+c; }
			if (a == 0f || a < Mathf.Abs(c)) { a=c; s=p/4; }
			else { s = p/PI_M2 * Mathf.Asin (c/a); }
			
			return -(a*Mathf.Pow(2,10*(t-=1)) * Mathf.Sin( (t*d-s)*PI_M2/p )) + b;
		}
		
		public static float EaseOutElastic(float t, float b, float c, float d)
		{
			float s = 0f;
			float a = 0f;
			float p = d*0.3f;
			
			if (t==0) { return b; }
			if ((t/=d)==1f) { return b+c; }
			if (a == 0f || a < Mathf.Abs(c)) { a=c; s=p/4; }
			else { s = p/PI_M2 * Mathf.Asin (c/a); }
			
			return (a*Mathf.Pow(2,-10*t) * Mathf.Sin( (t*d-s)*PI_M2/p ) + c + b);
		}
		
		public static float EaseInOutElastic(float t, float b, float c, float d)
		{
			float s = 0f;
			float a = 0f;
			float p = d*(0.3f*1.5f);
			
			if (t==0) { return b; }
			if ((t/=d/2f)==2f) { return b+c; }
			if (a == 0f || a < Mathf.Abs(c)) { a=c; s=p/4; }
			else { s = p/PI_M2 * Mathf.Asin (c/a); }
			if (t < 1) { return -.5f*(a*Mathf.Pow(2f,10*(t-=1)) * Mathf.Sin( (t*d-s)*PI_M2/p )) + b; }
			
			return a*Mathf.Pow(2f,-10*(t-=1f)) * Mathf.Sin( (t*d-s)*PI_M2/p )*.5f + c + b;
		}

		/*================================================================================
		Circular		
		=================================================================================*/
		public static float EaseInCircular(float t, float b, float c, float d)
		{
			return -c * (Mathf.Sqrt(1 - (t/=d)*t) - 1) + b;
		}
		public static float EaseOutCircular(float t, float b, float c, float d)
		{
			return c * Mathf.Sqrt(1 - (t=t/d-1)*t) + b;
		}
		public static float EaseInOutCircular(float t, float b, float c, float d)
		{
			if ((t/=d/2) < 1) return -c/2 * (Mathf.Sqrt(1 - t*t) - 1) + b;
			return c/2 * (Mathf.Sqrt(1 - (t-=2)*t) + 1) + b;
		}

		/*================================================================================
		Back		
		=================================================================================*/
		public static float EaseInBack(float t, float b, float c, float d)
		{
			const float s = 1.70158f;
			return c*(t/=d)*t*((s+1)*t - s) + b;
		}
		public static float EaseOutBack(float t, float b, float c, float d)
		{
			const float s = 1.70158f;
			return c*((t=t/d-1)*t*((s+1)*t + s) + 1) + b;
		}
		public static float EaseInOutBack(float t, float b, float c, float d)
		{
			float s = 1.70158f;
			if ((t/=d/2) < 1) return c/2*(t*t*(((s*=(1.525f))+1)*t - s)) + b;
			return c/2*((t-=2)*t*(((s*=(1.525f))+1)*t + s) + 2) + b;
		}

		/*================================================================================
		Bounce		
		=================================================================================*/
		public static float EaseInBounce(float t, float b, float c, float d)
		{
			return c - EaseOutBounce (d-t, 0, c, d) + b;
		}
		public static float EaseOutBounce(float t, float b, float c, float d)
		{
			if ((t/=d) < (1/2.75f)) 
			{
				return c*(7.5625f*t*t) + b;
			}
			if (t < (2/2.75)) 
			{
				return c*(7.5625f*(t-=(1.5f/2.75f))*t + 0.75f) + b;
			} 
			if (t < (2.5/2.75)) 
			{
				return c*(7.5625f*(t-=(2.25f/2.75f))*t + 0.9375f) + b;
			}
			
			return c*(7.5625f*(t-=(2.625f/2.75f))*t + 0.984375f) + b;
		}
		public static float EaseInOutBounce(float t, float b, float c, float d)
		{
			if (t < d/2) return EaseInBounce (t*2f, 0f, c, d) * 0.5f + b;
			
			return EaseOutBounce (t*2f-d, 0f, c, d) * .5f + c*0.5f + b;
		}

		/*================================================================================
		Cubic		
		=================================================================================*/
		public static float EaseInCubic(float t, float b, float c, float d)
		{
			return c*(t/=d)*t*t + b;
		}
		public static float EaseOutCubic(float t, float b, float c, float d)
		{
			return c*((t=t/d-1)*t*t + 1) + b;
		}
		public static float EaseInOutCubic(float t, float b, float c, float d)
		{
			if ((t/=d/2) < 1) return c/2*t*t*t + b;
			return c/2*((t-=2)*t*t + 2) + b;
		}
		
		/*================================================================================
		JIGGLE		
		=================================================================================*/
		public static float EaseJiggle(float t, float b, float c, float d)
		{
			// Jiggle factor controls how much of a jiggle effect to add
			const float jiggleFactor = 0.1f;
  
			// Calculate the easing value using a standard easing function (e.g. linear, quadratic, etc.)
			float easeValue = c * t / d + b;
  
			// Add a jiggle effect by calculating a sine wave and multiplying it by the jiggle factor
			float jiggle = Mathf.Sin(t * 20f) * (1f - t / d) * jiggleFactor;
  
			// Add the jiggle effect to the easing value
			float result = easeValue + jiggle;
  
			return result;
		}

		/*================================================================================
		ARBITRARY POWER EASE		
		=================================================================================*/
		public static float EasePower(float t, float b, float c, float d, float exponent)
		{
			t /= d;
			return c * Mathf.Pow(t, exponent) + b;
		}
		
		/*================================================================================
		SMOOTH STEP	
		=================================================================================*/
		public static float EaseSmoothStep(float t, float b, float c, float d)
		{
			t /= d;
			return c * t * t * (3f - 2f * t) + b;
		}
		
		/*================================================================================
		DECAYING SINE EASE		
		=================================================================================*/
		public static float EaseDecayingSine(float t, float b, float c, float d)
		{
			t /= d;
			return -c * Mathf.Pow(2f, -10f * t) * Mathf.Sin((t - 0.3f) * (2f * Mathf.PI) / 0.7f) + c + b;
		}
		
		/*================================================================================
		BEZIER EASE		
		=================================================================================*/
		public static float EaseBezier(float t, float b, float c, float d, float p0, float p1, float p2, float p3)
		{
			t /= d;
			float t2 = t * t;
			float t3 = t2 * t;
			float mt = 1f - t;
			float mt2 = mt * mt;
			float mt3 = mt2 * mt;
			return b + c * (mt3 * p0 + 3f * mt2 * t * p1 + 3f * mt * t2 * p2 + t3 * p3);
		}
	}
}