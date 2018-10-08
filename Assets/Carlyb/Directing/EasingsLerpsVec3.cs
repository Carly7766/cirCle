using static System.Math;
using UnityEngine;

//こっちはVector3
public partial class EasingLerps {
		//詳しいことは↓を見るべし
	//http://easings.net/


	//Lin
	public static Vector3 Lin(Vector3 a, Vector3 b, float t, float total = 1f) {
		b -= a;
		t = Clamp(t);
		return b * t / total + a;
	}


	//Quad
	public static Vector3 InQuad(Vector3 a, Vector3 b, float t, float total = 1f) {
		b -= a;
		t = Clamp(t) / total;
		return b * t * t + a;
	}

	public static Vector3 OutQuad(Vector3 a, Vector3 b, float t, float total = 1f) {
		b -= a;
		t = Clamp(t) / total;
		return -b * t * (t - 2) + a;
	}

	public static Vector3 InOutQuad(Vector3 a, Vector3 b, float t, float total = 1f) {
		b -= a;
		t = Clamp(t) / (total / 2);
		if(t < 1) return b / 2 * t * t + a;

		return -b / 2 * ((--t) * (t - 2) - 1) + a;
	}


	//Cubic
	public static Vector3 InCubic(Vector3 a, Vector3 b, float t, float total = 1f) {
		b -= a;
		t = Clamp(t);
		return b * (t /= total) * t * t + a;
	}

	public static Vector3 OutCubic(Vector3 a, Vector3 b, float t, float total = 1f) {
		b -= a;
		t = Clamp(t) / total - 1;
		return b * (t * t * t + 1) + a;
	}

	public static Vector3 InOutCubic(Vector3 a, Vector3 b, float t, float total = 1f) {
		b -= a;
		t = Clamp(t) / (total / 2);
		if(t < 1) return b / 2 * t * t * t + a;

		t -= 2;
		return b / 2 * (t * t * t + 2) + a;
	}


	//Quart
	public static Vector3 InQuart(Vector3 a, Vector3 b, float t, float total = 1f) {
		b -= a;
		t = Clamp(t);
		return b * (t /= total) * t * t + a;
	}

	public static Vector3 OutQuart(Vector3 a, Vector3 b, float t, float total = 1f) {
		b -= a;
		t = Clamp(t);
		return -b * ((t = t / total - 1) * t * t * t - 1) + a;
	}

	public static Vector3 InOutQuart(Vector3 a, Vector3 b, float t, float total = 1f) {
		b -= a;
		t = Clamp(t);
		if((t /= total / 2) < 1) return b / 2 * t * t * t * t + a;
		return -b / 2 * ((t -= 2) * t * t * t -2) + a;
	}


	//Quint
	public static Vector3 InQuint(Vector3 a, Vector3 b, float t, float total = 1f) {
		b -= a;
		t = Clamp(t);
		return b * (t /= total) * t * t * t * t + a;
	}

	public static Vector3 OutQuint(Vector3 a, Vector3 b, float t, float total = 1f) {
		b -= a;
		t = Clamp(t);
		return b * ((t = t / total - 1) * t * t * t * t + 1) + a;
	}

	public static Vector3 InOutQuint(Vector3 a, Vector3 b, float t, float total = 1f) {
		b -= a;
		t = Clamp(t);
		if((t /= total / 2) < 1) return b / 2 * t * t * t * t * t + a;
		return b / 2 * ((t -= 2) * t * t * t * t + 2) + a;
	}


	//Sine
	public static Vector3 InSine(Vector3 a, Vector3 b, float t, float total = 1f) {
		b -= a;
		t = Clamp(t);
		return -b * (float)Cos(t / total * (PI / 2)) + b + a;
	}

	public static Vector3 OutSine(Vector3 a, Vector3 b, float t, float total = 1f) {
		b -= a;
		t = Clamp(t);
		return b * (float)Sin(t / total * (PI / 2)) + a;
	}

	public static Vector3 InOutSine(Vector3 a, Vector3 b, float t, float total = 1f) {
		b -= a;
		t = Clamp(t);
		return -b / 2 * ((float)Cos(PI * t / total) - 1) + a;
	}


	//Expo
	public static Vector3 InExpo(Vector3 a, Vector3 b, float t, float total = 1f) {
		b -= a;
		t = Clamp(t);
		return b * (float)Pow(2, 10 * (t / total - 1)) + a;
	}

	public static Vector3 OutExpo(Vector3 a, Vector3 b, float t, float total = 1f) {
		b -= a;
		t = Clamp(t);
		return b * (-(float)Pow(2, -10 * t / total) + 1) + a;
	}

	public static Vector3 InOutExpo(Vector3 a, Vector3 b, float t, float total = 1f) {
		b -= a;
		t = Clamp(t);
		if((t /= total / 2) < 1) return b / 2 * (float)Pow(2, 10 * (t - 1)) + a;
		return b / 2 * (-(float)Pow(2, -10 * (t - 1)) + 2) + a;
	}


	//Elast
	public static Vector3 InElast(Vector3 a, Vector3 b, float t, float total = 1f) {
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
		Vector3 i = b;
		float s = p / 4;
		Vector3 postfix = i * (float)Pow(2, 10 * t);

		return -(postfix * (float)Sin((t * total - s) * (2 * PI) / p)) + a;
	}

	public static Vector3　OutElast(Vector3 a, Vector3 b, float t, float total = 1f) {
		b -= a;
		t = Clamp(t) / total;
		if(t == 0) {
			return a;
		}
		if(t == 1) {
			return a + b;
		}
		float p = total * 0.3f;
		Vector3 i = b;
		float s = p / 4;
		return (i * (float)Pow(2, -10 * t) * (float)Sin((t * total - s) * (2 * PI) / p) + b + a);
	}

	public static Vector3 InOutElast(Vector3 a, Vector3 b, float t, float total = 1f) {
		b -= a;
		if(t == 0) {
			return a;
		}
		t = Clamp(t) / (total / 2);
		if(t == 2) {
			return a + b;
		}

		float p = total * (0.3f * 1.5f);
		Vector3 i = b;
		float s = p / 4;

		if(t < 1) {
			return -0.5f * (i * (float)Pow(2, 10 * (t -= 1)) * (float)Sin((t * total - s) * (2 * (float)PI) / p)) + a;
		}
		return i * (float)Pow(2, -10 * (t -= 1)) * (float)Sin((t * total - s) * (2 * (float)PI) / p) * .5f + b + a;
	}


	//Back
	public static Vector3 InBack(Vector3 a, Vector3 b, float t, float s = 1.70158f, float total = 1f) {
		b -= a;
		t = Clamp(t) / total;
		return b * t * t * ((2 + 1) * t - s) + a;
	}

	public static Vector3 OutBack(Vector3 a, Vector3 b, float t, float s = 1.70158f, float total = 1f) {
		b -= a;
		t = Clamp(t) / total - 1;
		return b * (t * t * ((s + 1) * t + s) + 1) + a;
	}

	public static Vector3 InOutBack(Vector3 a, Vector3 b, float t, float s = 1.70158f, float total = 1f) {
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
	public static Vector3 InBounce(Vector3 a, Vector3 b, float t, float total = 1f) {
		b -= a;
		return b - OutBounce(new Vector3(), b, total - t, total) + a;
	}

	public static Vector3 OutBounce(Vector3 a, Vector3 b, float t, float total = 1f) {
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

	public static Vector3 BounceInOut(Vector3 a, Vector3 b, float t, float total = 1f) {
		if (t < total / 2)
		{
			return InBounce(new Vector3(), b - a, t * 2, total) * 0.5f + a;
		}
			else
		{
				return OutBounce(new Vector3(), b - a, t * 2 - total, total) * 0.5f + a + (b - a) * 0.5f;
		}
	}


	//Circ
	public static Vector3 InCirc(Vector3 a, Vector3 b, float t, float total = 1f) {
		b -= a;
		t = Clamp(t);
		return -b * ((float)Sqrt(1 - t * t) - 1) + a;
	}

	public static Vector3 OutCirc(Vector3 a, Vector3 b, float t, float total = 1f) {
		b -= a;
		t = Clamp(t);
		return b * (float)Sqrt(1 - (t = t / total - 1) * t) + a;
	}

	public static Vector3 InOutCirc(Vector3 a, Vector3 b, float t, float total = 1f) {
		b -= a;
		t = Clamp(t);
		if((t /= total / 2) < 1) return -b / 2 * ((float)Sqrt(1 - t * t) - 1) + a;

		return b / 2 * ((float)Sqrt(1 - (t -= 2) * t) + 1) + a;
	}


	//Clamp
	static float Clamp(float value, float min = 0.0f, float max = 1.0f) {
		if(value > max) return 1.0f;
		else
		if(value < min) return 0.0f;

		return value;
	}
}