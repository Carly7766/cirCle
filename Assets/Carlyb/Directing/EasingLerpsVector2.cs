using static System.Math;
using UnityEngine;

//こっちはVector2
public partial class EasingLerps {
		//詳しいことは↓を見るべし
	//http://easings.net/


	//Lin
	public static Vector2 Lin(Vector2 a, Vector2 b, float t, float total = 1f) {
		b -= a;
		t = Clamp(t);
		return b * t / total + a;
	}


	//Quad
	public static Vector2 InQuad(Vector2 a, Vector2 b, float t, float total = 1f) {
		b -= a;
		t = Clamp(t) / total;
		return b * t * t + a;
	}

	public static Vector2 OutQuad(Vector2 a, Vector2 b, float t, float total = 1f) {
		b -= a;
		t = Clamp(t) / total;
		return -b * t * (t - 2) + a;
	}

	public static Vector2 InOutQuad(Vector2 a, Vector2 b, float t, float total = 1f) {
		b -= a;
		t = Clamp(t) / (total / 2);
		if(t < 1) return b / 2 * t * t + a;

		return -b / 2 * ((--t) * (t - 2) - 1) + a;
	}


	//Cubic
	public static Vector2 InCubic(Vector2 a, Vector2 b, float t, float total = 1f) {
		b -= a;
		t = Clamp(t);
		return b * (t /= total) * t * t + a;
	}

	public static Vector2 OutCubic(Vector2 a, Vector2 b, float t, float total = 1f) {
		b -= a;
		t = Clamp(t) / total - 1;
		return b * (t * t * t + 1) + a;
	}

	public static Vector2 InOutCubic(Vector2 a, Vector2 b, float t, float total = 1f) {
		b -= a;
		t = Clamp(t) / (total / 2);
		if(t < 1) return b / 2 * t * t * t + a;

		t -= 2;
		return b / 2 * (t * t * t + 2) + a;
	}


	//Quart
	public static Vector2 InQuart(Vector2 a, Vector2 b, float t, float total = 1f) {
		b -= a;
		t = Clamp(t);
		return b * (t /= total) * t * t + a;
	}

	public static Vector2 OutQuart(Vector2 a, Vector2 b, float t, float total = 1f) {
		b -= a;
		t = Clamp(t);
		return -b * ((t = t / total - 1) * t * t * t - 1) + a;
	}

	public static Vector2 InOutQuart(Vector2 a, Vector2 b, float t, float total = 1f) {
		b -= a;
		t = Clamp(t);
		if((t /= total / 2) < 1) return b / 2 * t * t * t * t + a;
		return -b / 2 * ((t -= 2) * t * t * t -2) + a;
	}


	//Quint
	public static Vector2 InQuint(Vector2 a, Vector2 b, float t, float total = 1f) {
		b -= a;
		t = Clamp(t);
		return b * (t /= total) * t * t * t * t + a;
	}

	public static Vector2 OutQuint(Vector2 a, Vector2 b, float t, float total = 1f) {
		b -= a;
		t = Clamp(t);
		return b * ((t = t / total - 1) * t * t * t * t + 1) + a;
	}

	public static Vector2 InOutQuint(Vector2 a, Vector2 b, float t, float total = 1f) {
		b -= a;
		t = Clamp(t);
		if((t /= total / 2) < 1) return b / 2 * t * t * t * t * t + a;
		return b / 2 * ((t -= 2) * t * t * t * t + 2) + a;
	}


	//Sine
	public static Vector2 InSine(Vector2 a, Vector2 b, float t, float total = 1f) {
		b -= a;
		t = Clamp(t);
		return -b * (float)Cos(t / total * (PI / 2)) + b + a;
	}

	public static Vector2 OutSine(Vector2 a, Vector2 b, float t, float total = 1f) {
		b -= a;
		t = Clamp(t);
		return b * (float)Sin(t / total * (PI / 2)) + a;
	}

	public static Vector2 InOutSine(Vector2 a, Vector2 b, float t, float total = 1f) {
		b -= a;
		t = Clamp(t);
		return -b / 2 * ((float)Cos(PI * t / total) - 1) + a;
	}


	//Expo
	public static Vector2 InExpo(Vector2 a, Vector2 b, float t, float total = 1f) {
		b -= a;
		t = Clamp(t);
		return b * (float)Pow(2, 10 * (t / total - 1)) + a;
	}

	public static Vector2 OutExpo(Vector2 a, Vector2 b, float t, float total = 1f) {
		b -= a;
		t = Clamp(t);
		return b * (-(float)Pow(2, -10 * t / total) + 1) + a;
	}

	public static Vector2 InOutExpo(Vector2 a, Vector2 b, float t, float total = 1f) {
		b -= a;
		t = Clamp(t);
		if((t /= total / 2) < 1) return b / 2 * (float)Pow(2, 10 * (t - 1)) + a;
		return b / 2 * (-(float)Pow(2, -10 * (t - 1)) + 2) + a;
	}


	//Elast
	public static Vector2 InElast(Vector2 a, Vector2 b, float t, float total = 1f) {
		b -= a;
		t = Clamp(t) / total;
		if(t == 0) {
			return a;
		}
		if(t == 1) {
			return a + b;
		}
		t--;

		float p = total * 0.3f;
		Vector2 i = b;
		float s = p / 4;
		Vector2 postfix = i * (float)Pow(2, 10 * t);

		return -(postfix * (float)Sin((t * total - s) * (2 * PI) / p)) + a;
	}

	public static Vector2　OutElast(Vector2 a, Vector2 b, float t, float total = 1f) {
		b -= a;
		t = Clamp(t) / total;
		if(t == 0) {
			return a;
		}
		if(t == 1) {
			return a + b;
		}
		float p = total * 0.3f;
		Vector2 i = b;
		float s = p / 4;
		return (i * (float)Pow(2, -10 * t) * (float)Sin((t * total - s) * (2 * PI) / p) + b + a);
	}

	public static Vector2 InOutElast(Vector2 a, Vector2 b, float t, float total = 1f) {
		b -= a;
		if(t == 0) {
			return a;
		}
		t = Clamp(t) / (total / 2);
		if(t == 2) {
			return a + b;
		}

		float p = total * (0.3f * 1.5f);
		Vector2 i = b;
		float s = p / 4;

		if(t < 1) {
			return -0.5f * (i * (float)Pow(2, 10 * (t -= 1)) * (float)Sin((t * total - s) * (2 * (float)PI) / p)) + a;
		}
		return i * (float)Pow(2, -10 * (t -= 1)) * (float)Sin((t * total - s) * (2 * (float)PI) / p) * .5f + b + a;
	}


	//Back
	public static Vector2 InBack(Vector2 a, Vector2 b, float t, float s = 1.70158f, float total = 1f) {
		b -= a;
		t = Clamp(t) / total;
		return b * t * t * ((2 + 1) * t - s) + a;
	}

	public static Vector2 OutBack(Vector2 a, Vector2 b, float t, float s = 1.70158f, float total = 1f) {
		b -= a;
		t = Clamp(t) / total - 1;
		return b * (t * t * ((s + 1) * t + s) + 1) + a;
	}

	public static Vector2 InOutBack(Vector2 a, Vector2 b, float t, float s = 1.70158f, float total = 1f) {
		b -= a;
		s *= 1.525f;
		t = Clamp(t) / (total / 2);
		if(t < 1)
		{
			return b / 2 * (t * t * ((s + 1) * t - s)) + a;
		}
		t -= 2;
		return b / 2 * (t * t * ((s + 1) * t + s) + 2) + a;
	}


	//Bounce
	public static Vector2 InBounce(Vector2 a, Vector2 b, float t, float total = 1f) {
		b -= a;
		return b - OutBounce(new Vector2(), b, total - t, total) + a;
	}

	public static Vector2 OutBounce(Vector2 a, Vector2 b, float t, float total = 1f) {
		b -= a;
		t = Clamp(t) / total;
		if ((t) < (1 / 2.75f))
		{
			return b * (7.5625f * t * t) + a;
		}
		else if (t < (2 / 2.75f))
		{
			return b * (7.5625f * (t -= (1.5f / 2.75f)) * t + .75f) + a;
		}
		else if (t < (2.5 / 2.75))
		{
			return b * (7.5625f * (t -= (2.25f / 2.75f)) * t + .9375f) + a;
		}
		else
		{
			return b * (7.5625f * (t -= (2.625f / 2.75f)) * t + .984375f) + a;
		}
	}

	public static Vector2 BounceInOut(Vector2 a, Vector2 b, float t, float total = 1f) {
		if (t < total / 2)
		{
			return InBounce(new Vector2(), b - a, t * 2, total) * 0.5f + a;
		}
			else
		{
				return OutBounce(new Vector2(), b - a, t * 2 - total, total) * 0.5f + a + (b - a) * 0.5f;
		}
	}


	//Circ
	public static Vector2 InCirc(Vector2 a, Vector2 b, float t, float total = 1f) {
		b -= a;
		t = Clamp(t);
		return -b * ((float)Sqrt(1 - t * t) - 1) + a;
	}

	public static Vector2 OutCirc(Vector2 a, Vector2 b, float t, float total = 1f) {
		b -= a;
		t = Clamp(t);
		return b * (float)Sqrt(1 - (t = t / total - 1) * t) + a;
	}

	public static Vector2 InOutCirc(Vector2 a, Vector2 b, float t, float total = 1f) {
		b -= a;
		t = Clamp(t);
		if((t /= total / 2) < 1) return -b / 2 * ((float)Sqrt(1 - t * t) - 1) + a;

		return b / 2 * ((float)Sqrt(1 - (t -= 2) * t) + 1) + a;
	}
}