using System;
using System.Collections.Generic;

namespace Memoization
{
	#region Memoizable Delegates
	
	public delegate Func<A, R> Memoizable<A, R>(Func<A, R> f);
	public delegate Func<A1, A2, R> Memoizable<A1, A2, R>(Func<A1, A2, R> f);
	public delegate Func<A1, A2, A3, R> Memoizable<A1, A2, A3, R>(Func<A1, A2, A3, R> f);
	public delegate Func<A1, A2, A3, A4, R> Memoizable<A1, A2, A3, A4, R>(Func<A1, A2, A3, A4, R> f);
	public delegate Func<A1, A2, A3, A4, A5, R> Memoizable<A1, A2, A3, A4, A5, R>(Func<A1, A2, A3, A4, A5, R> f);
	public delegate Func<A1, A2, A3, A4, A5, A6, R> Memoizable<A1, A2, A3, A4, A5, A6, R>(Func<A1, A2, A3, A4, A5, A6, R> f);
	public delegate Func<A1, A2, A3, A4, A5, A6, A7, R> Memoizable<A1, A2, A3, A4, A5, A6, A7, R>(Func<A1, A2, A3, A4, A5, A6, A7, R> f);
	public delegate Func<A1, A2, A3, A4, A5, A6, A7, A8, R> Memoizable<A1, A2, A3, A4, A5, A6, A7, A8, R>(Func<A1, A2, A3, A4, A5, A6, A7, A8, R> f);
	public delegate Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, R> Memoizable<A1, A2, A3, A4, A5, A6, A7, A8, A9, R>(Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, R> f);
	public delegate Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, R> Memoizable<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, R>(Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, R> f);
	public delegate Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, R> Memoizable<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, R>(Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, R> f);
	public delegate Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, R> Memoizable<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, R>(Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, R> f);
	public delegate Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, R> Memoizable<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, R>(Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, R> f);
	public delegate Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, R> Memoizable<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, R>(Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, R> f);
	public delegate Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, R> Memoizable<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, R>(Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, R> f);
	public delegate Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, A16, R> Memoizable<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, A16, R>(Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, A16, R> f);
	
	#endregion

	public static class Memoizable
	{
		#region Normal() overloads
		
		public static Func<A, R> Normal<A, R>(this Memoizable<A, R> f)
		{
			Func<A, R> g = null;
			g = f(input => g(input));
			return g;
		}
		
		public static Func<A1, A2, R> Normal<A1, A2, R>(this Memoizable<A1, A2, R> f)
		{
			Func<(A1, A2), R> g = null;
			g = tuple => f((a1, a2) => g((a1, a2)))(tuple.Item1, tuple.Item2);
			return (a1, a2) => g((a1, a2));
		}
		
		public static Func<A1, A2, A3, R> Normal<A1, A2, A3, R>(this Memoizable<A1, A2, A3, R> f)
		{
			Func<(A1, A2, A3), R> g = null;
			g = tuple => f((a1, a2, a3) => g((a1, a2, a3)))(tuple.Item1, tuple.Item2, tuple.Item3);
			return (a1, a2, a3) => g((a1, a2, a3));
		}
		
		public static Func<A1, A2, A3, A4, R> Normal<A1, A2, A3, A4, R>(this Memoizable<A1, A2, A3, A4, R> f)
		{
			Func<(A1, A2, A3, A4), R> g = null;
			g = tuple => f((a1, a2, a3, a4) => g((a1, a2, a3, a4)))(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4);
			return (a1, a2, a3, a4) => g((a1, a2, a3, a4));
		}
		
		public static Func<A1, A2, A3, A4, A5, R> Normal<A1, A2, A3, A4, A5, R>(this Memoizable<A1, A2, A3, A4, A5, R> f)
		{
			Func<(A1, A2, A3, A4, A5), R> g = null;
			g = tuple => f((a1, a2, a3, a4, a5) => g((a1, a2, a3, a4, a5)))(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5);
			return (a1, a2, a3, a4, a5) => g((a1, a2, a3, a4, a5));
		}
		
		public static Func<A1, A2, A3, A4, A5, A6, R> Normal<A1, A2, A3, A4, A5, A6, R>(this Memoizable<A1, A2, A3, A4, A5, A6, R> f)
		{
			Func<(A1, A2, A3, A4, A5, A6), R> g = null;
			g = tuple => f((a1, a2, a3, a4, a5, a6) => g((a1, a2, a3, a4, a5, a6)))(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6);
			return (a1, a2, a3, a4, a5, a6) => g((a1, a2, a3, a4, a5, a6));
		}
		
		public static Func<A1, A2, A3, A4, A5, A6, A7, R> Normal<A1, A2, A3, A4, A5, A6, A7, R>(this Memoizable<A1, A2, A3, A4, A5, A6, A7, R> f)
		{
			Func<(A1, A2, A3, A4, A5, A6, A7), R> g = null;
			g = tuple => f((a1, a2, a3, a4, a5, a6, a7) => g((a1, a2, a3, a4, a5, a6, a7)))(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6, tuple.Item7);
			return (a1, a2, a3, a4, a5, a6, a7) => g((a1, a2, a3, a4, a5, a6, a7));
		}
		
		public static Func<A1, A2, A3, A4, A5, A6, A7, A8, R> Normal<A1, A2, A3, A4, A5, A6, A7, A8, R>(this Memoizable<A1, A2, A3, A4, A5, A6, A7, A8, R> f)
		{
			Func<(A1, A2, A3, A4, A5, A6, A7, A8), R> g = null;
			g = tuple => f((a1, a2, a3, a4, a5, a6, a7, a8) => g((a1, a2, a3, a4, a5, a6, a7, a8)))(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6, tuple.Item7, tuple.Item8);
			return (a1, a2, a3, a4, a5, a6, a7, a8) => g((a1, a2, a3, a4, a5, a6, a7, a8));
		}
		
		public static Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, R> Normal<A1, A2, A3, A4, A5, A6, A7, A8, A9, R>(this Memoizable<A1, A2, A3, A4, A5, A6, A7, A8, A9, R> f)
		{
			Func<(A1, A2, A3, A4, A5, A6, A7, A8, A9), R> g = null;
			g = tuple => f((a1, a2, a3, a4, a5, a6, a7, a8, a9) => g((a1, a2, a3, a4, a5, a6, a7, a8, a9)))(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6, tuple.Item7, tuple.Item8, tuple.Item9);
			return (a1, a2, a3, a4, a5, a6, a7, a8, a9) => g((a1, a2, a3, a4, a5, a6, a7, a8, a9));
		}
		
		public static Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, R> Normal<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, R>(this Memoizable<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, R> f)
		{
			Func<(A1, A2, A3, A4, A5, A6, A7, A8, A9, A10), R> g = null;
			g = tuple => f((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10) => g((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10)))(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6, tuple.Item7, tuple.Item8, tuple.Item9, tuple.Item10);
			return (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10) => g((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10));
		}
		
		public static Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, R> Normal<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, R>(this Memoizable<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, R> f)
		{
			Func<(A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11), R> g = null;
			g = tuple => f((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11) => g((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11)))(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6, tuple.Item7, tuple.Item8, tuple.Item9, tuple.Item10, tuple.Item11);
			return (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11) => g((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11));
		}
		
		public static Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, R> Normal<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, R>(this Memoizable<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, R> f)
		{
			Func<(A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12), R> g = null;
			g = tuple => f((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12) => g((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12)))(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6, tuple.Item7, tuple.Item8, tuple.Item9, tuple.Item10, tuple.Item11, tuple.Item12);
			return (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12) => g((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12));
		}
		
		public static Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, R> Normal<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, R>(this Memoizable<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, R> f)
		{
			Func<(A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13), R> g = null;
			g = tuple => f((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13) => g((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13)))(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6, tuple.Item7, tuple.Item8, tuple.Item9, tuple.Item10, tuple.Item11, tuple.Item12, tuple.Item13);
			return (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13) => g((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13));
		}
		
		public static Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, R> Normal<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, R>(this Memoizable<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, R> f)
		{
			Func<(A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14), R> g = null;
			g = tuple => f((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14) => g((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14)))(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6, tuple.Item7, tuple.Item8, tuple.Item9, tuple.Item10, tuple.Item11, tuple.Item12, tuple.Item13, tuple.Item14);
			return (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14) => g((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14));
		}
		
		public static Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, R> Normal<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, R>(this Memoizable<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, R> f)
		{
			Func<(A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15), R> g = null;
			g = tuple => f((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15) => g((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15)))(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6, tuple.Item7, tuple.Item8, tuple.Item9, tuple.Item10, tuple.Item11, tuple.Item12, tuple.Item13, tuple.Item14, tuple.Item15);
			return (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15) => g((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15));
		}
		
		public static Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, A16, R> Normal<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, A16, R>(this Memoizable<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, A16, R> f)
		{
			Func<(A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, A16), R> g = null;
			g = tuple => f((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16) => g((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16)))(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6, tuple.Item7, tuple.Item8, tuple.Item9, tuple.Item10, tuple.Item11, tuple.Item12, tuple.Item13, tuple.Item14, tuple.Item15, tuple.Item16);
			return (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16) => g((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16));
		}

		#endregion
		
		#region Memoized() overloads

		public static Func<A, R> Memoized<A, R>(this Memoizable<A, R> f, int? maxSize=null)
		{
			var map = DictFactory<A, R>(maxSize);
			Func<A, R> memoized = null;
			Func<A, R> g = f(input => memoized(input));

			memoized = MemoizeFunc(g, map);

			return memoized;
		}

		public static Func<A1, A2, R> Memoized<A1, A2, R>(this Memoizable<A1, A2, R> f, int? maxSize=null)
		{
			var map = DictFactory<(A1, A2), R>(maxSize);
			Func<(A1, A2), R> memoized = null;
			Func<(A1, A2), R> g = tuple => f((a1, a2) => memoized((a1, a2)))(tuple.Item1, tuple.Item2);

			memoized = MemoizeFunc(g, map);
			
			return (a1, a2) => memoized((a1, a2));
		}
		
		public static Func<A1, A2, A3, R> Memoized<A1, A2, A3, R>(this Memoizable<A1, A2, A3, R> f, int? maxSize=null)
		{
			var map = DictFactory<(A1, A2, A3), R>(maxSize);
			Func<(A1, A2, A3), R> memoized = null;
			Func<(A1, A2, A3), R> g = tuple => f((a1, a2, a3) => memoized((a1, a2, a3)))(tuple.Item1, tuple.Item2, tuple.Item3);

			memoized = MemoizeFunc(g, map);
			
			return (a1, a2, a3) => memoized((a1, a2, a3));
		}
		
		public static Func<A1, A2, A3, A4, R> Memoized<A1, A2, A3, A4, R>(this Memoizable<A1, A2, A3, A4, R> f, int? maxSize=null)
		{
			var map = DictFactory<(A1, A2, A3, A4), R>(maxSize);
			Func<(A1, A2, A3, A4), R> memoized = null;
			Func<(A1, A2, A3, A4), R> g = tuple => f((a1, a2, a3, a4) => memoized((a1, a2, a3, a4)))(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4);

			memoized = MemoizeFunc(g, map);
			
			return (a1, a2, a3, a4) => memoized((a1, a2, a3, a4));
		}
		
		public static Func<A1, A2, A3, A4, A5, R> Memoized<A1, A2, A3, A4, A5, R>(this Memoizable<A1, A2, A3, A4, A5, R> f, int? maxSize=null)
		{
			var map = DictFactory<(A1, A2, A3, A4, A5), R>(maxSize);
			Func<(A1, A2, A3, A4, A5), R> memoized = null;
			Func<(A1, A2, A3, A4, A5), R> g = tuple => f((a1, a2, a3, a4, a5) => memoized((a1, a2, a3, a4, a5)))(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5);

			memoized = MemoizeFunc(g, map);
			
			return (a1, a2, a3, a4, a5) => memoized((a1, a2, a3, a4, a5));
		}
		
		public static Func<A1, A2, A3, A4, A5, A6, R> Memoized<A1, A2, A3, A4, A5, A6, R>(this Memoizable<A1, A2, A3, A4, A5, A6, R> f, int? maxSize=null)
		{
			var map = DictFactory<(A1, A2, A3, A4, A5, A6), R>(maxSize);
			Func<(A1, A2, A3, A4, A5, A6), R> memoized = null;
			Func<(A1, A2, A3, A4, A5, A6), R> g = tuple => f((a1, a2, a3, a4, a5, a6) => memoized((a1, a2, a3, a4, a5, a6)))(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6);

			memoized = MemoizeFunc(g, map);
			
			return (a1, a2, a3, a4, a5, a6) => memoized((a1, a2, a3, a4, a5, a6));
		}
		
		public static Func<A1, A2, A3, A4, A5, A6, A7, R> Memoized<A1, A2, A3, A4, A5, A6, A7, R>(this Memoizable<A1, A2, A3, A4, A5, A6, A7, R> f, int? maxSize=null)
		{
			var map = DictFactory<(A1, A2, A3, A4, A5, A6, A7), R>(maxSize);
			Func<(A1, A2, A3, A4, A5, A6, A7), R> memoized = null;
			Func<(A1, A2, A3, A4, A5, A6, A7), R> g = tuple => f((a1, a2, a3, a4, a5, a6, a7) => memoized((a1, a2, a3, a4, a5, a6, a7)))(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6, tuple.Item7);

			memoized = MemoizeFunc(g, map);
			
			return (a1, a2, a3, a4, a5, a6, a7) => memoized((a1, a2, a3, a4, a5, a6, a7));
		}
		
		public static Func<A1, A2, A3, A4, A5, A6, A7, A8, R> Memoized<A1, A2, A3, A4, A5, A6, A7, A8, R>(this Memoizable<A1, A2, A3, A4, A5, A6, A7, A8, R> f, int? maxSize=null)
		{
			var map = DictFactory<(A1, A2, A3, A4, A5, A6, A7, A8), R>(maxSize);
			Func<(A1, A2, A3, A4, A5, A6, A7, A8), R> memoized = null;
			Func<(A1, A2, A3, A4, A5, A6, A7, A8), R> g = tuple => f((a1, a2, a3, a4, a5, a6, a7, a8) => memoized((a1, a2, a3, a4, a5, a6, a7, a8)))(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6, tuple.Item7, tuple.Item8);

			memoized = MemoizeFunc(g, map);
			
			return (a1, a2, a3, a4, a5, a6, a7, a8) => memoized((a1, a2, a3, a4, a5, a6, a7, a8));
		}
		
		public static Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, R> Memoized<A1, A2, A3, A4, A5, A6, A7, A8, A9, R>(this Memoizable<A1, A2, A3, A4, A5, A6, A7, A8, A9, R> f, int? maxSize=null)
		{
			var map = DictFactory<(A1, A2, A3, A4, A5, A6, A7, A8, A9), R>(maxSize);
			Func<(A1, A2, A3, A4, A5, A6, A7, A8, A9), R> memoized = null;
			Func<(A1, A2, A3, A4, A5, A6, A7, A8, A9), R> g = tuple => f((a1, a2, a3, a4, a5, a6, a7, a8, a9) => memoized((a1, a2, a3, a4, a5, a6, a7, a8, a9)))(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6, tuple.Item7, tuple.Item8, tuple.Item9);

			memoized = MemoizeFunc(g, map);
			
			return (a1, a2, a3, a4, a5, a6, a7, a8, a9) => memoized((a1, a2, a3, a4, a5, a6, a7, a8, a9));
		}
		
		public static Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, R> Memoized<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, R>(this Memoizable<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, R> f, int? maxSize=null)
		{
			var map = DictFactory<(A1, A2, A3, A4, A5, A6, A7, A8, A9, A10), R>(maxSize);
			Func<(A1, A2, A3, A4, A5, A6, A7, A8, A9, A10), R> memoized = null;
			Func<(A1, A2, A3, A4, A5, A6, A7, A8, A9, A10), R> g = tuple => f((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10) => memoized((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10)))(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6, tuple.Item7, tuple.Item8, tuple.Item9, tuple.Item10);

			memoized = MemoizeFunc(g, map);
			
			return (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10) => memoized((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10));
		}
		
		public static Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, R> Memoized<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, R>(this Memoizable<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, R> f, int? maxSize=null)
		{
			var map = DictFactory<(A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11), R>(maxSize);
			Func<(A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11), R> memoized = null;
			Func<(A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11), R> g = tuple => f((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11) => memoized((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11)))(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6, tuple.Item7, tuple.Item8, tuple.Item9, tuple.Item10, tuple.Item11);

			memoized = MemoizeFunc(g, map);
			
			return (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11) => memoized((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11));
		}
		
		public static Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, R> Memoized<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, R>(this Memoizable<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, R> f, int? maxSize=null)
		{
			var map = DictFactory<(A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12), R>(maxSize);
			Func<(A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12), R> memoized = null;
			Func<(A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12), R> g = tuple => f((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12) => memoized((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12)))(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6, tuple.Item7, tuple.Item8, tuple.Item9, tuple.Item10, tuple.Item11, tuple.Item12);

			memoized = MemoizeFunc(g, map);
			
			return (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12) => memoized((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12));
		}
		
		public static Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, R> Memoized<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, R>(this Memoizable<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, R> f, int? maxSize=null)
		{
			var map = DictFactory<(A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13), R>(maxSize);
			Func<(A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13), R> memoized = null;
			Func<(A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13), R> g = tuple => f((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13) => memoized((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13)))(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6, tuple.Item7, tuple.Item8, tuple.Item9, tuple.Item10, tuple.Item11, tuple.Item12, tuple.Item13);

			memoized = MemoizeFunc(g, map);
			
			return (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13) => memoized((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13));
		}
		
		public static Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, R> Memoized<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, R>(this Memoizable<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, R> f, int? maxSize=null)
		{
			var map = DictFactory<(A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14), R>(maxSize);
			Func<(A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14), R> memoized = null;
			Func<(A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14), R> g = tuple => f((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14) => memoized((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14)))(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6, tuple.Item7, tuple.Item8, tuple.Item9, tuple.Item10, tuple.Item11, tuple.Item12, tuple.Item13, tuple.Item14);

			memoized = MemoizeFunc(g, map);
			
			return (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14) => memoized((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14));
		}
		
		public static Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, R> Memoized<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, R>(this Memoizable<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, R> f, int? maxSize=null)
		{
			var map = DictFactory<(A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15), R>(maxSize);
			Func<(A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15), R> memoized = null;
			Func<(A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15), R> g = tuple => f((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15) => memoized((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15)))(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6, tuple.Item7, tuple.Item8, tuple.Item9, tuple.Item10, tuple.Item11, tuple.Item12, tuple.Item13, tuple.Item14, tuple.Item15);

			memoized = MemoizeFunc(g, map);
			
			return (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15) => memoized((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15));
		}
		
		public static Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, A16, R> Memoized<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, A16, R>(this Memoizable<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, A16, R> f, int? maxSize=null)
		{
			var map = DictFactory<(A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, A16), R>(maxSize);
			Func<(A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, A16), R> memoized = null;
			Func<(A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, A16), R> g = tuple => f((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16) => memoized((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16)))(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6, tuple.Item7, tuple.Item8, tuple.Item9, tuple.Item10, tuple.Item11, tuple.Item12, tuple.Item13, tuple.Item14, tuple.Item15, tuple.Item16);

			memoized = MemoizeFunc(g, map);
			
			return (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16) => memoized((a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16));
		}
		
		#endregion
		
		private static Func<A, R> MemoizeFunc<A, R>(Func<A, R> f, IDictionary<A, R> map)
		{
			return input => {
				if (map.TryGetValue(input, out var value))
					return value;

				value = f(input);
				map.Add(input, value);
				return value;
			};
		}

		private static IDictionary<A, R> DictFactory<A, R>(int? maxSize)
		{
			if (maxSize.HasValue)
				return new LruDict<A, R>(maxSize.Value);

			return new Dictionary<A, R>();
		}
	}
}
