using System;
using System.Text;
using System.Threading;

namespace LongRunningTasks
{
	public class CalculatePI
	{
		/*
		 * 
		 * http://omegacoder.com/?p=91
		 * 
     * Computation of the n'th decimal digit of \pi with very little memory.
     * Written by Fabrice Bellard on January 8, 1997.
     * 
     * We use a slightly modified version of the method described by Simon
     * Plouffe in "On the Computation of the n'th decimal digit of various
     * transcendental numbers" (November 1996). We have modified the algorithm
     * to get a running time of O(n^2) instead of O(n^3log(n)^3).
     * 
     * This program uses mostly integer arithmetic. It may be slow on some
     * hardwares where integer multiplications and divisons must be done
     * by software. We have supposed that 'int' has a size of 32 bits. If
     * your compiler supports 'long long' integers of 64 bits, you may use
     * the integer version of 'mul_mod' (see HAS_LONG_LONG).  
     */

		// Call this static to use.
		public static string Process(int digits, Action<string> piCallback, CancellationToken token)
		{
			StringBuilder result = new StringBuilder();
			result.Append("3.");
			piCallback (result.ToString ());

			DateTime StartTime = DateTime.Now;

			if (digits > 0)
			{
				for (int i = 0; i < digits; i += 9)
				{
					String ds = CalculatePiDigits(i + 1);
					int digitCount = Math.Min(digits - i, 9);

					if (ds.Length < 9)
						ds = string.Format("{0:D9}", int.Parse(ds));

					piCallback (ds.Substring(0, digitCount));
					if (token.IsCancellationRequested)
					{
						break;
					}
				}
			}

			return result.ToString ();
		}


		private static int mul_mod(int a, int b, int m)
		{
			return (int)(((long)a * (long)b) % m);
		}

		/* return the inverse of x mod y */
		private static int inv_mod(int x, int y)
		{
			int q, u, v, a, c, t;

			u = x;
			v = y;
			c = 1;
			a = 0;

			do
			{
				q = v / u;

				t = c;
				c = a - q * c;
				a = t;

				t = u;
				u = v - q * u;
				v = t;
			} while (u != 0);

			a = a % y;

			if (a < 0)
			{
				a = y + a;
			}

			return a;
		}

		/* return (a^b) mod m */
		private static int pow_mod(int a, int b, int m)
		{
			int r, aa;

			r = 1;
			aa = a;

			while (true)
			{
				if ((b & 1) != 0)
				{
					r = mul_mod(r, aa, m);
				}

				b = b >> 1;

				if (b == 0)
				{
					break;
				}

				aa = mul_mod(aa, aa, m);
			}

			return r;
		}

		/* return true if n is prime */
		private static bool is_prime(int n)
		{
			if ((n % 2) == 0)
			{
				return false;
			}

			int r = (int)Math.Sqrt(n);

			for (int i = 3; i <= r; i += 2)
			{
				if ((n % i) == 0)
				{
					return false;
				}
			}

			return true;
		}

		/* return the prime number immediatly after n */
		private static int next_prime(int n)
		{
			do
			{
				n++;
			} while (!is_prime(n));

			return n;
		}

		private static String CalculatePiDigits(int n)
		{
			int av, vmax, num, den, s, t;

			int N = (int)((n + 20) * Math.Log(10) / Math.Log(2));

			double sum = 0;

			for (int a = 3; a <= (2 * N); a = next_prime(a))
			{
				vmax = (int)(Math.Log(2 * N) / Math.Log(a));

				av = 1;

				for (int i = 0; i < vmax; i++)
				{
					av = av * a;
				}

				s = 0;
				num = 1;
				den = 1;
				int v = 0;
				int kq = 1;
				int kq2 = 1;

				for (int k = 1; k <= N; k++)
				{

					t = k;

					if (kq >= a)
					{
						do
						{
							t = t / a;
							v--;
						} while ((t % a) == 0);

						kq = 0;
					}
					kq++;
					num = mul_mod(num, t, av);

					t = 2 * k - 1;

					if (kq2 >= a)
					{
						if (kq2 == a)
						{
							do
							{
								t = t / a;
								v++;
							} while ((t % a) == 0);
						}
						kq2 -= a;
					}
					den = mul_mod(den, t, av);
					kq2 += 2;

					if (v > 0)
					{
						t = inv_mod(den, av);
						t = mul_mod(t, num, av);
						t = mul_mod(t, k, av);

						for (int i = v; i < vmax; i++)
						{
							t = mul_mod(t, a, av);
						}

						s += t;

						if (s >= av)
						{
							s -= av;
						}
					}

				}

				t = pow_mod(10, n - 1, av);
				s = mul_mod(s, t, av);
				sum = (sum + (double)s / (double)av) % 1.0;
			}

			int Result = (int)(sum * 1e9);

			String StringResult = String.Format("{0:D9}", Result);

			return StringResult;
		}

		// Put a space between every group of 10 digits.

		private static String breakDigitsIntoGroupsOf10(String digits)
		{
			String result = "";

			while (digits.Length > 10)
			{
				result += digits.Substring(0, 10) + " ";
				digits = digits.Substring(10, digits.Length - 10);
			}

			result += digits;

			return result;
		}

	}
}

