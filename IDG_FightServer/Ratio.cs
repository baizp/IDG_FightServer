﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDG
{
    public struct Ratio
    {
        public static int Fix_Fracbits = 16;
        public static Ratio Zero = new Ratio(0);
        internal Int64 m_Bits;
        public Ratio(int x)
        {
            m_Bits = (x << Fix_Fracbits);
        }
        public Ratio(float x)
        {
            m_Bits = (Int64)((x) * (1 << Fix_Fracbits));
            //x*(((Int64)(1)<<Fix_Fracbits))
        }
        public Ratio(Int64 x)
        {
            m_Bits = ((x) * (1 << Fix_Fracbits));
        }
        public Int64 GetValue()
        {
            return m_Bits;
        }
        public Ratio SetValue(Int64 i)
        {
            m_Bits = i;
            return this;
        }
        public static Ratio Lerp(Ratio a, Ratio b, float t)
        {
            return a + (b - a) * t;
        }
        public static Ratio Lerp(Ratio a, Ratio b, Ratio t)
        {
            return a + (b - a) * t;
        }
        public Ratio Abs()
        {

            return Ratio.Abs(this);
        }
        public Ratio Sqrt()
        {
            return Ratio.Sqrt(this);
        }
        //******************* +  **************************
        public static Ratio operator +(Ratio p1, Ratio p2)
        {
            Ratio tmp;
            tmp.m_Bits = p1.m_Bits + p2.m_Bits;
            return tmp;
        }
        public static Ratio operator +(Ratio p1, int p2)
        {
            Ratio tmp;
            tmp.m_Bits = p1.m_Bits + (Int64)(p2 << Fix_Fracbits);
            return tmp;
        }
        public static Ratio operator +(int p1, Ratio p2)
        {
            return p2 + p1;
        }
        public static Ratio operator +(Ratio p1, Int64 p2)
        {
            Ratio tmp;
            tmp.m_Bits = p1.m_Bits + p2 << Fix_Fracbits;
            return tmp;
        }
        public static Ratio operator +(Int64 p1, Ratio p2)
        {
            return p2 + p1;
        }

        public static Ratio operator +(Ratio p1, float p2)
        {
            Ratio tmp;
            tmp.m_Bits = p1.m_Bits + (Int64)(p2 * (1 << Fix_Fracbits));
            return tmp;
        }
        public static Ratio operator +(float p1, Ratio p2)
        {
            Ratio tmp = p2 + p1;
            return tmp;
        }
        //*******************  -  **************************
        public static Ratio operator -(Ratio p1, Ratio p2)
        {
            Ratio tmp;
            tmp.m_Bits = p1.m_Bits - p2.m_Bits;
            return tmp;
        }

        public static Ratio operator -(Ratio p1, int p2)
        {
            Ratio tmp;
            tmp.m_Bits = p1.m_Bits - (Int64)(p2 << Fix_Fracbits);
            return tmp;
        }

        public static Ratio operator -(int p1, Ratio p2)
        {
            Ratio tmp;
            tmp.m_Bits = (p1 << Fix_Fracbits) - p2.m_Bits;
            return tmp;
        }
        public static Ratio operator -(Ratio p1, Int64 p2)
        {
            Ratio tmp;
            tmp.m_Bits = p1.m_Bits - (p2 << Fix_Fracbits);
            return tmp;
        }
        public static Ratio operator -(Int64 p1, Ratio p2)
        {
            Ratio tmp;
            tmp.m_Bits = (p1 << Fix_Fracbits) - p2.m_Bits;
            return tmp;
        }

        public static Ratio operator -(float p1, Ratio p2)
        {
            Ratio tmp;
            tmp.m_Bits = (Int64)(p1 * (1 << Fix_Fracbits)) - p2.m_Bits;
            return tmp;
        }
        public static Ratio operator -(Ratio p1, float p2)
        {
            Ratio tmp;
            tmp.m_Bits = p1.m_Bits - (Int64)(p2 * (1 << Fix_Fracbits));
            return tmp;
        }

        //******************* * **************************
        public static Ratio operator *(Ratio p1, Ratio p2)
        {
            Ratio tmp;
            tmp.m_Bits = ((p1.m_Bits) * (p2.m_Bits)) >> (Fix_Fracbits);
            return tmp;
        }

        public static Ratio operator *(int p1, Ratio p2)
        {
            Ratio tmp;
            tmp.m_Bits = p1 * p2.m_Bits;
            return tmp;
        }
        public static Ratio operator *(Ratio p1, int p2)
        {
            return p2 * p1;
        }
        public static Ratio operator *(Ratio p1, float p2)
        {
            Ratio tmp;
            tmp.m_Bits = (Int64)(p1.m_Bits * p2);
            return tmp;
        }
        public static Ratio operator *(float p1, Ratio p2)
        {
            Ratio tmp;
            tmp.m_Bits = (Int64)(p1 * p2.m_Bits);
            return tmp;
        }
        //******************* / **************************
        public static Ratio operator /(Ratio p1, Ratio p2)
        {
            Ratio tmp;
            if (p2 == Ratio.Zero)
            {
               // UnityEngine.Debug.LogError("/0");
                tmp.m_Bits = Zero.m_Bits;
            }
            else
            {
                tmp.m_Bits = (p1.m_Bits) * (1 << Fix_Fracbits) / (p2.m_Bits);
            }
            return tmp;
        }
        public static Ratio operator /(Ratio p1, int p2)
        {
            Ratio tmp;
            if (p2 == 0)
            {
                //UnityEngine.Debug.LogError("/0");
                tmp.m_Bits = Zero.m_Bits;
            }
            else
            {
                tmp.m_Bits = p1.m_Bits / (p2);
            }
            return tmp;
        }
        public static Ratio operator %(Ratio p1, int p2)
        {
            Ratio tmp;
            if (p2 == 0)
            {
                //UnityEngine.Debug.LogError("/0");
                tmp.m_Bits = Zero.m_Bits;
            }
            else
            {
                tmp.m_Bits = (p1.m_Bits % (p2 << Fix_Fracbits));
            }
            return tmp;
        }
        public static Ratio operator /(int p1, Ratio p2)
        {
            Ratio tmp;
            if (p2 == Zero)
            {
               // UnityEngine.Debug.LogError("/0");
                tmp.m_Bits = Zero.m_Bits;
            }
            else
            {
                Int64 tmp2 = ((Int64)p1 << Fix_Fracbits << Fix_Fracbits);
                tmp.m_Bits = tmp2 / (p2.m_Bits);
            }
            return tmp;
        }
        public static Ratio operator /(Ratio p1, Int64 p2)
        {
            Ratio tmp;
            if (p2 == 0)
            {
                //UnityEngine.Debug.LogError("/0");
                tmp.m_Bits = Zero.m_Bits;
            }
            else
            {
                tmp.m_Bits = p1.m_Bits / (p2);
            }
            return tmp;
        }
        public static Ratio operator /(Int64 p1, Ratio p2)
        {
            Ratio tmp;
            if (p2 == Zero)
            {
               // UnityEngine.Debug.LogError("/0");
                tmp.m_Bits = Zero.m_Bits;
            }
            else
            {
                if (p1 > Int32.MaxValue || p1 < Int32.MinValue)
                {
                    tmp.m_Bits = 0;
                    return tmp;
                }
                tmp.m_Bits = (p1 << Fix_Fracbits) / (p2.m_Bits);
            }
            return tmp;
        }
        public static Ratio operator /(float p1, Ratio p2)
        {
            Ratio tmp;
            if (p2 == Zero)
            {
                //UnityEngine.Debug.LogError("/0");
                tmp.m_Bits = Zero.m_Bits;
            }
            else
            {
                Int64 tmp1 = (Int64)p1 * ((Int64)1 << Fix_Fracbits << Fix_Fracbits);
                tmp.m_Bits = (tmp1) / (p2.m_Bits);
            }
            return tmp;
        }
        public static Ratio operator /(Ratio p1, float p2)
        {
            Ratio tmp;
            if (p2 > -0.000001f && p2 < 0.000001f)
            {
               // UnityEngine.Debug.LogError("/0");
                tmp.m_Bits = Zero.m_Bits;
            }
            else
            {
                tmp.m_Bits = (p1.m_Bits << Fix_Fracbits) / ((Int64)(p2 * (1 << Fix_Fracbits)));
            }
            return tmp;
        }
        public static Ratio Sqrt(Ratio p1)
        {
            Ratio tmp;
            Int64 ltmp = p1.m_Bits * (1 << Fix_Fracbits);
            tmp.m_Bits = (Int64)Math.Sqrt(ltmp);
            return tmp;
        }
        public static bool operator >(Ratio p1, Ratio p2)
        {
            return (p1.m_Bits > p2.m_Bits) ? true : false;
        }
        public static bool operator <(Ratio p1, Ratio p2)
        {
            return (p1.m_Bits < p2.m_Bits) ? true : false;
        }
        public static bool operator <=(Ratio p1, Ratio p2)
        {
            return (p1.m_Bits <= p2.m_Bits) ? true : false;
        }
        public static bool operator >=(Ratio p1, Ratio p2)
        {
            return (p1.m_Bits >= p2.m_Bits) ? true : false;
        }
        public static bool operator !=(Ratio p1, Ratio p2)
        {
            return (p1.m_Bits != p2.m_Bits) ? true : false;
        }
        public static bool operator ==(Ratio p1, Ratio p2)
        {
            return (p1.m_Bits == p2.m_Bits) ? true : false;
        }

        public static bool Equals(Ratio p1, Ratio p2)
        {
            return (p1.m_Bits == p2.m_Bits) ? true : false;
        }

        public bool Equals(Ratio right)
        {
            if (m_Bits == right.m_Bits)
            {
                return true;
            }
            return false;
        }

        public static bool operator >(Ratio p1, float p2)
        {
            return (p1.m_Bits > (p2 * (1 << Fix_Fracbits))) ? true : false;
        }
        public static bool operator <(Ratio p1, float p2)
        {
            return (p1.m_Bits < (p2 * (1 << Fix_Fracbits))) ? true : false;
        }
        public static bool operator <=(Ratio p1, float p2)
        {
            return (p1.m_Bits <= p2 * (1 << Fix_Fracbits)) ? true : false;
        }
        public static bool operator >=(Ratio p1, float p2)
        {
            return (p1.m_Bits >= p2 * (1 << Fix_Fracbits)) ? true : false;
        }
        public static bool operator !=(Ratio p1, float p2)
        {
            return (p1.m_Bits != p2 * (1 << Fix_Fracbits)) ? true : false;
        }
        public static bool operator ==(Ratio p1, float p2)
        {
            return (p1.m_Bits == p2 * (1 << Fix_Fracbits)) ? true : false;
        }

        //public static FPoint Cos(FPoint p1)
        //{
        //    return FP.TrigonometricFunction.Cos(p1);
        //}
        //public static FPoint Sin(FPoint p1)
        //{
        //    return FP.TrigonometricFunction.Sin(p1);
        //}

        public static Ratio Max()
        {
            Ratio tmp;
            tmp.m_Bits = Int64.MaxValue;
            return tmp;
        }

        public static Ratio Max(Ratio p1, Ratio p2)
        {
            return p1.m_Bits > p2.m_Bits ? p1 : p2;
        }
        public static Ratio Min(Ratio p1, Ratio p2)
        {
            return p1.m_Bits < p2.m_Bits ? p1 : p2;
        }

        public static Ratio Precision()
        {
            Ratio tmp;
            tmp.m_Bits = 1;
            return tmp;
        }

        public static Ratio MaxValue()
        {
            Ratio tmp;
            tmp.m_Bits = Int64.MaxValue;
            return tmp;
        }
        public static Ratio Abs(Ratio P1)
        {
            Ratio tmp;
            tmp.m_Bits = Math.Abs(P1.m_Bits);
            return tmp;
        }
        public static Ratio operator -(Ratio p1)
        {
            Ratio tmp;
            tmp.m_Bits = -p1.m_Bits;
            return tmp;
        }

        public float ToFloat()
        {
            return m_Bits / (float)(1 << Fix_Fracbits);
        }

        public int ToInt()
        {
            return (int)(m_Bits >> (Fix_Fracbits));
        }
        public override string ToString()
        {
            double tmp = (double)m_Bits / (double)(1 << Fix_Fracbits);
            return tmp.ToString();
        }
    }

}
namespace IDG.TrueRatio
{
    public struct Ratio
    {
        private int _u;//分子
        public int u
        {
            get { return _u; }
            private set { _u = value; }
        }
        private int _d;//分母 
        public int d
        {
            get { return _d; }
            private set
            {
                if (value == 0) { throw new InvalidOperationException("分母不能为零"); }
                else if (value > 0) { _d = value; }
                else { _d = -value; u = -u; }
            }
        }
        //private static Ratio temp = new Ratio(0);
        //public static Ratio Add(Ratio a,Ratio b)
        //{
        //    temp.Reset(0);
        //    temp.Add(a);
        //    temp.Add(b);
        //    return temp;
        //}
        //public static Ratio GetRatio(int up, int down = 1)
        //{
        //    return new Ratio(up, down);
        //}
        public Ratio(int up, int down = 1)
        {
            _u = 0;
            _d = 1;
            u = up;
            d = down;
            Reduction();
        }
        private void Reset(int up, int down = 1)
        {
            u = up;
            d = down;
            Reduction();
        }
        public override string ToString()
        {
            return u + "/" + d;
        }
        private void Reduction()//约分
        {
            int gcd = GCD(u, d);
            u /= gcd;
            d /= gcd;
        }
        private int GCD(int a, int b)
        {
            int temp = 1;
            while (b != 0)
            {
                temp = a % b;
                a = b;
                b = temp;
            }
            return a;
        }
        public static Ratio operator +(Ratio a, Ratio b)
        {
            return new Ratio(a.u * b.d + b.u * a.d, a.d * b.d);
        }
        public static Ratio operator -(Ratio a, Ratio b)
        {
            return new Ratio(a.u * b.d - b.u * a.d, a.d * b.d);
        }
        public static Ratio operator *(Ratio a, Ratio b)
        {
            return new Ratio(a.u * b.u, a.d * b.d);
        }

        public static Ratio operator /(Ratio a, Ratio b)
        {
            return a * !b;
        }
        public static Ratio operator !(Ratio a)
        {
            return new Ratio(a.d, a.u);
        }
        public float ToFloat()
        {
            return u * 1.0f / d;
        }

    }
}
