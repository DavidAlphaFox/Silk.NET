﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#if NET5_0_OR_GREATER

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Jobs;
using System.Runtime.Intrinsics;


namespace Silk.NET.Maths.Benchmark
{
    [SimpleJob(RuntimeMoniker.Net50, launchCount: 1, warmupCount: 3, targetCount: 3)]
    [DisassemblyDiagnoser(exportHtml: true)]
    public unsafe class SimdBenchmarks
    {
        const int IterCount = 30;
        void* a;
        void* b;
        void* c;
        
        [GlobalSetup]
        public void Setup()
        {
            // native memory is not a thing on .net 5
            var byteCount = 256/*bits*/ / 8 * IterCount;
            a = (void*)Marshal.AllocHGlobal(byteCount);
            b = (void*)Marshal.AllocHGlobal(byteCount);
            c = (void*)Marshal.AllocHGlobal(byteCount);
            var rand = new Random();
            for (int i = 0; i < byteCount; i++)
            {
                *(byte*)a = (byte)rand.Next(1, 255);
                *(byte*)b = (byte)rand.Next(1, 255);
            }
        }


#region Vector x Vector -> Vector 64-bit byte

        [Benchmark]
        public void Simd64GreaterThan_byte()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<byte>*)c + i) = Simd64.GreaterThan(*((Vector64<byte>*)a + i), *((Vector64<byte>*)b + i)); 
        }
        [Benchmark]
        public void Simd64LessThan_byte()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<byte>*)c + i) = Simd64.LessThan(*((Vector64<byte>*)a + i), *((Vector64<byte>*)b + i)); 
        }
        [Benchmark]
        public void Simd64GreaterThanOrEqual_byte()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<byte>*)c + i) = Simd64.GreaterThanOrEqual(*((Vector64<byte>*)a + i), *((Vector64<byte>*)b + i)); 
        }
        [Benchmark]
        public void Simd64LessThanOrEqual_byte()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<byte>*)c + i) = Simd64.LessThanOrEqual(*((Vector64<byte>*)a + i), *((Vector64<byte>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Add_byte()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<byte>*)c + i) = Simd64.Add(*((Vector64<byte>*)a + i), *((Vector64<byte>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Subtract_byte()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<byte>*)c + i) = Simd64.Subtract(*((Vector64<byte>*)a + i), *((Vector64<byte>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Multiply_byte()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<byte>*)c + i) = Simd64.Multiply(*((Vector64<byte>*)a + i), *((Vector64<byte>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Divide_byte()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<byte>*)c + i) = Simd64.Divide(*((Vector64<byte>*)a + i), *((Vector64<byte>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Min_byte()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<byte>*)c + i) = Simd64.Min(*((Vector64<byte>*)a + i), *((Vector64<byte>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Max_byte()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<byte>*)c + i) = Simd64.Max(*((Vector64<byte>*)a + i), *((Vector64<byte>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Equal_byte()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<byte>*)c + i) = Simd64.Equal(*((Vector64<byte>*)a + i), *((Vector64<byte>*)b + i)); 
        }
        [Benchmark]
        public void Simd64NotEqual_byte()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<byte>*)c + i) = Simd64.NotEqual(*((Vector64<byte>*)a + i), *((Vector64<byte>*)b + i)); 
        }
        [Benchmark]
        public void Simd64And_byte()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<byte>*)c + i) = Simd64.And(*((Vector64<byte>*)a + i), *((Vector64<byte>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Xor_byte()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<byte>*)c + i) = Simd64.Xor(*((Vector64<byte>*)a + i), *((Vector64<byte>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Or_byte()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<byte>*)c + i) = Simd64.Or(*((Vector64<byte>*)a + i), *((Vector64<byte>*)b + i)); 
        }

#endregion

#region Vector -> Vector 64-bit byte

        [Benchmark]
        public void Simd64Not_byte()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<byte>*)c + i) = Simd64.Not(*((Vector64<byte>*)a + i)); 
        }
        [Benchmark]
        public void Simd64Abs_byte()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<byte>*)c + i) = Simd64.Abs(*((Vector64<byte>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsFinite_byte()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<byte>*)c + i) = Simd64.IsFinite(*((Vector64<byte>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsInfinity_byte()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<byte>*)c + i) = Simd64.IsInfinity(*((Vector64<byte>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsNaN_byte()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<byte>*)c + i) = Simd64.IsNaN(*((Vector64<byte>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsNegative_byte()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<byte>*)c + i) = Simd64.IsNegative(*((Vector64<byte>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsNegativeInfinity_byte()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<byte>*)c + i) = Simd64.IsNegativeInfinity(*((Vector64<byte>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsNormal_byte()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<byte>*)c + i) = Simd64.IsNormal(*((Vector64<byte>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsPositiveInfinity_byte()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<byte>*)c + i) = Simd64.IsPositiveInfinity(*((Vector64<byte>*)a + i)); 
        }
        [Benchmark]
        public void Simd64Sign_byte()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<byte>*)c + i) = Simd64.Sign(*((Vector64<byte>*)a + i)); 
        }

#endregion


#region Vector x Vector -> Vector 128-bit byte

        [Benchmark]
        public void Simd128GreaterThan_byte()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<byte>*)c + i) = Simd128.GreaterThan(*((Vector128<byte>*)a + i), *((Vector128<byte>*)b + i)); 
        }
        [Benchmark]
        public void Simd128LessThan_byte()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<byte>*)c + i) = Simd128.LessThan(*((Vector128<byte>*)a + i), *((Vector128<byte>*)b + i)); 
        }
        [Benchmark]
        public void Simd128GreaterThanOrEqual_byte()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<byte>*)c + i) = Simd128.GreaterThanOrEqual(*((Vector128<byte>*)a + i), *((Vector128<byte>*)b + i)); 
        }
        [Benchmark]
        public void Simd128LessThanOrEqual_byte()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<byte>*)c + i) = Simd128.LessThanOrEqual(*((Vector128<byte>*)a + i), *((Vector128<byte>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Add_byte()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<byte>*)c + i) = Simd128.Add(*((Vector128<byte>*)a + i), *((Vector128<byte>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Subtract_byte()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<byte>*)c + i) = Simd128.Subtract(*((Vector128<byte>*)a + i), *((Vector128<byte>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Multiply_byte()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<byte>*)c + i) = Simd128.Multiply(*((Vector128<byte>*)a + i), *((Vector128<byte>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Divide_byte()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<byte>*)c + i) = Simd128.Divide(*((Vector128<byte>*)a + i), *((Vector128<byte>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Min_byte()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<byte>*)c + i) = Simd128.Min(*((Vector128<byte>*)a + i), *((Vector128<byte>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Max_byte()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<byte>*)c + i) = Simd128.Max(*((Vector128<byte>*)a + i), *((Vector128<byte>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Equal_byte()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<byte>*)c + i) = Simd128.Equal(*((Vector128<byte>*)a + i), *((Vector128<byte>*)b + i)); 
        }
        [Benchmark]
        public void Simd128NotEqual_byte()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<byte>*)c + i) = Simd128.NotEqual(*((Vector128<byte>*)a + i), *((Vector128<byte>*)b + i)); 
        }
        [Benchmark]
        public void Simd128And_byte()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<byte>*)c + i) = Simd128.And(*((Vector128<byte>*)a + i), *((Vector128<byte>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Xor_byte()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<byte>*)c + i) = Simd128.Xor(*((Vector128<byte>*)a + i), *((Vector128<byte>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Or_byte()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<byte>*)c + i) = Simd128.Or(*((Vector128<byte>*)a + i), *((Vector128<byte>*)b + i)); 
        }

#endregion

#region Vector -> Vector 128-bit byte

        [Benchmark]
        public void Simd128Not_byte()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<byte>*)c + i) = Simd128.Not(*((Vector128<byte>*)a + i)); 
        }
        [Benchmark]
        public void Simd128Abs_byte()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<byte>*)c + i) = Simd128.Abs(*((Vector128<byte>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsFinite_byte()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<byte>*)c + i) = Simd128.IsFinite(*((Vector128<byte>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsInfinity_byte()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<byte>*)c + i) = Simd128.IsInfinity(*((Vector128<byte>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsNaN_byte()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<byte>*)c + i) = Simd128.IsNaN(*((Vector128<byte>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsNegative_byte()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<byte>*)c + i) = Simd128.IsNegative(*((Vector128<byte>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsNegativeInfinity_byte()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<byte>*)c + i) = Simd128.IsNegativeInfinity(*((Vector128<byte>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsNormal_byte()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<byte>*)c + i) = Simd128.IsNormal(*((Vector128<byte>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsPositiveInfinity_byte()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<byte>*)c + i) = Simd128.IsPositiveInfinity(*((Vector128<byte>*)a + i)); 
        }
        [Benchmark]
        public void Simd128Sign_byte()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<byte>*)c + i) = Simd128.Sign(*((Vector128<byte>*)a + i)); 
        }

#endregion


#region Vector x Vector -> Vector 256-bit byte

        [Benchmark]
        public void Simd256GreaterThan_byte()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<byte>*)c + i) = Simd256.GreaterThan(*((Vector256<byte>*)a + i), *((Vector256<byte>*)b + i)); 
        }
        [Benchmark]
        public void Simd256LessThan_byte()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<byte>*)c + i) = Simd256.LessThan(*((Vector256<byte>*)a + i), *((Vector256<byte>*)b + i)); 
        }
        [Benchmark]
        public void Simd256GreaterThanOrEqual_byte()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<byte>*)c + i) = Simd256.GreaterThanOrEqual(*((Vector256<byte>*)a + i), *((Vector256<byte>*)b + i)); 
        }
        [Benchmark]
        public void Simd256LessThanOrEqual_byte()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<byte>*)c + i) = Simd256.LessThanOrEqual(*((Vector256<byte>*)a + i), *((Vector256<byte>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Add_byte()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<byte>*)c + i) = Simd256.Add(*((Vector256<byte>*)a + i), *((Vector256<byte>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Subtract_byte()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<byte>*)c + i) = Simd256.Subtract(*((Vector256<byte>*)a + i), *((Vector256<byte>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Multiply_byte()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<byte>*)c + i) = Simd256.Multiply(*((Vector256<byte>*)a + i), *((Vector256<byte>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Divide_byte()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<byte>*)c + i) = Simd256.Divide(*((Vector256<byte>*)a + i), *((Vector256<byte>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Min_byte()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<byte>*)c + i) = Simd256.Min(*((Vector256<byte>*)a + i), *((Vector256<byte>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Max_byte()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<byte>*)c + i) = Simd256.Max(*((Vector256<byte>*)a + i), *((Vector256<byte>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Equal_byte()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<byte>*)c + i) = Simd256.Equal(*((Vector256<byte>*)a + i), *((Vector256<byte>*)b + i)); 
        }
        [Benchmark]
        public void Simd256NotEqual_byte()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<byte>*)c + i) = Simd256.NotEqual(*((Vector256<byte>*)a + i), *((Vector256<byte>*)b + i)); 
        }
        [Benchmark]
        public void Simd256And_byte()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<byte>*)c + i) = Simd256.And(*((Vector256<byte>*)a + i), *((Vector256<byte>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Xor_byte()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<byte>*)c + i) = Simd256.Xor(*((Vector256<byte>*)a + i), *((Vector256<byte>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Or_byte()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<byte>*)c + i) = Simd256.Or(*((Vector256<byte>*)a + i), *((Vector256<byte>*)b + i)); 
        }

#endregion

#region Vector -> Vector 256-bit byte

        [Benchmark]
        public void Simd256Not_byte()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<byte>*)c + i) = Simd256.Not(*((Vector256<byte>*)a + i)); 
        }
        [Benchmark]
        public void Simd256Abs_byte()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<byte>*)c + i) = Simd256.Abs(*((Vector256<byte>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsFinite_byte()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<byte>*)c + i) = Simd256.IsFinite(*((Vector256<byte>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsInfinity_byte()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<byte>*)c + i) = Simd256.IsInfinity(*((Vector256<byte>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsNaN_byte()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<byte>*)c + i) = Simd256.IsNaN(*((Vector256<byte>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsNegative_byte()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<byte>*)c + i) = Simd256.IsNegative(*((Vector256<byte>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsNegativeInfinity_byte()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<byte>*)c + i) = Simd256.IsNegativeInfinity(*((Vector256<byte>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsNormal_byte()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<byte>*)c + i) = Simd256.IsNormal(*((Vector256<byte>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsPositiveInfinity_byte()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<byte>*)c + i) = Simd256.IsPositiveInfinity(*((Vector256<byte>*)a + i)); 
        }
        [Benchmark]
        public void Simd256Sign_byte()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<byte>*)c + i) = Simd256.Sign(*((Vector256<byte>*)a + i)); 
        }

#endregion


#region Vector x Vector -> Vector 64-bit sbyte

        [Benchmark]
        public void Simd64GreaterThan_sbyte()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<sbyte>*)c + i) = Simd64.GreaterThan(*((Vector64<sbyte>*)a + i), *((Vector64<sbyte>*)b + i)); 
        }
        [Benchmark]
        public void Simd64LessThan_sbyte()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<sbyte>*)c + i) = Simd64.LessThan(*((Vector64<sbyte>*)a + i), *((Vector64<sbyte>*)b + i)); 
        }
        [Benchmark]
        public void Simd64GreaterThanOrEqual_sbyte()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<sbyte>*)c + i) = Simd64.GreaterThanOrEqual(*((Vector64<sbyte>*)a + i), *((Vector64<sbyte>*)b + i)); 
        }
        [Benchmark]
        public void Simd64LessThanOrEqual_sbyte()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<sbyte>*)c + i) = Simd64.LessThanOrEqual(*((Vector64<sbyte>*)a + i), *((Vector64<sbyte>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Add_sbyte()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<sbyte>*)c + i) = Simd64.Add(*((Vector64<sbyte>*)a + i), *((Vector64<sbyte>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Subtract_sbyte()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<sbyte>*)c + i) = Simd64.Subtract(*((Vector64<sbyte>*)a + i), *((Vector64<sbyte>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Multiply_sbyte()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<sbyte>*)c + i) = Simd64.Multiply(*((Vector64<sbyte>*)a + i), *((Vector64<sbyte>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Divide_sbyte()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<sbyte>*)c + i) = Simd64.Divide(*((Vector64<sbyte>*)a + i), *((Vector64<sbyte>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Min_sbyte()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<sbyte>*)c + i) = Simd64.Min(*((Vector64<sbyte>*)a + i), *((Vector64<sbyte>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Max_sbyte()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<sbyte>*)c + i) = Simd64.Max(*((Vector64<sbyte>*)a + i), *((Vector64<sbyte>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Equal_sbyte()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<sbyte>*)c + i) = Simd64.Equal(*((Vector64<sbyte>*)a + i), *((Vector64<sbyte>*)b + i)); 
        }
        [Benchmark]
        public void Simd64NotEqual_sbyte()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<sbyte>*)c + i) = Simd64.NotEqual(*((Vector64<sbyte>*)a + i), *((Vector64<sbyte>*)b + i)); 
        }
        [Benchmark]
        public void Simd64And_sbyte()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<sbyte>*)c + i) = Simd64.And(*((Vector64<sbyte>*)a + i), *((Vector64<sbyte>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Xor_sbyte()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<sbyte>*)c + i) = Simd64.Xor(*((Vector64<sbyte>*)a + i), *((Vector64<sbyte>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Or_sbyte()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<sbyte>*)c + i) = Simd64.Or(*((Vector64<sbyte>*)a + i), *((Vector64<sbyte>*)b + i)); 
        }

#endregion

#region Vector -> Vector 64-bit sbyte

        [Benchmark]
        public void Simd64Not_sbyte()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<sbyte>*)c + i) = Simd64.Not(*((Vector64<sbyte>*)a + i)); 
        }
        [Benchmark]
        public void Simd64Abs_sbyte()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<sbyte>*)c + i) = Simd64.Abs(*((Vector64<sbyte>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsFinite_sbyte()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<sbyte>*)c + i) = Simd64.IsFinite(*((Vector64<sbyte>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsInfinity_sbyte()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<sbyte>*)c + i) = Simd64.IsInfinity(*((Vector64<sbyte>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsNaN_sbyte()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<sbyte>*)c + i) = Simd64.IsNaN(*((Vector64<sbyte>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsNegative_sbyte()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<sbyte>*)c + i) = Simd64.IsNegative(*((Vector64<sbyte>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsNegativeInfinity_sbyte()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<sbyte>*)c + i) = Simd64.IsNegativeInfinity(*((Vector64<sbyte>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsNormal_sbyte()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<sbyte>*)c + i) = Simd64.IsNormal(*((Vector64<sbyte>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsPositiveInfinity_sbyte()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<sbyte>*)c + i) = Simd64.IsPositiveInfinity(*((Vector64<sbyte>*)a + i)); 
        }
        [Benchmark]
        public void Simd64Sign_sbyte()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<sbyte>*)c + i) = Simd64.Sign(*((Vector64<sbyte>*)a + i)); 
        }

#endregion


#region Vector x Vector -> Vector 128-bit sbyte

        [Benchmark]
        public void Simd128GreaterThan_sbyte()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<sbyte>*)c + i) = Simd128.GreaterThan(*((Vector128<sbyte>*)a + i), *((Vector128<sbyte>*)b + i)); 
        }
        [Benchmark]
        public void Simd128LessThan_sbyte()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<sbyte>*)c + i) = Simd128.LessThan(*((Vector128<sbyte>*)a + i), *((Vector128<sbyte>*)b + i)); 
        }
        [Benchmark]
        public void Simd128GreaterThanOrEqual_sbyte()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<sbyte>*)c + i) = Simd128.GreaterThanOrEqual(*((Vector128<sbyte>*)a + i), *((Vector128<sbyte>*)b + i)); 
        }
        [Benchmark]
        public void Simd128LessThanOrEqual_sbyte()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<sbyte>*)c + i) = Simd128.LessThanOrEqual(*((Vector128<sbyte>*)a + i), *((Vector128<sbyte>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Add_sbyte()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<sbyte>*)c + i) = Simd128.Add(*((Vector128<sbyte>*)a + i), *((Vector128<sbyte>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Subtract_sbyte()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<sbyte>*)c + i) = Simd128.Subtract(*((Vector128<sbyte>*)a + i), *((Vector128<sbyte>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Multiply_sbyte()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<sbyte>*)c + i) = Simd128.Multiply(*((Vector128<sbyte>*)a + i), *((Vector128<sbyte>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Divide_sbyte()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<sbyte>*)c + i) = Simd128.Divide(*((Vector128<sbyte>*)a + i), *((Vector128<sbyte>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Min_sbyte()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<sbyte>*)c + i) = Simd128.Min(*((Vector128<sbyte>*)a + i), *((Vector128<sbyte>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Max_sbyte()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<sbyte>*)c + i) = Simd128.Max(*((Vector128<sbyte>*)a + i), *((Vector128<sbyte>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Equal_sbyte()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<sbyte>*)c + i) = Simd128.Equal(*((Vector128<sbyte>*)a + i), *((Vector128<sbyte>*)b + i)); 
        }
        [Benchmark]
        public void Simd128NotEqual_sbyte()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<sbyte>*)c + i) = Simd128.NotEqual(*((Vector128<sbyte>*)a + i), *((Vector128<sbyte>*)b + i)); 
        }
        [Benchmark]
        public void Simd128And_sbyte()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<sbyte>*)c + i) = Simd128.And(*((Vector128<sbyte>*)a + i), *((Vector128<sbyte>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Xor_sbyte()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<sbyte>*)c + i) = Simd128.Xor(*((Vector128<sbyte>*)a + i), *((Vector128<sbyte>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Or_sbyte()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<sbyte>*)c + i) = Simd128.Or(*((Vector128<sbyte>*)a + i), *((Vector128<sbyte>*)b + i)); 
        }

#endregion

#region Vector -> Vector 128-bit sbyte

        [Benchmark]
        public void Simd128Not_sbyte()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<sbyte>*)c + i) = Simd128.Not(*((Vector128<sbyte>*)a + i)); 
        }
        [Benchmark]
        public void Simd128Abs_sbyte()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<sbyte>*)c + i) = Simd128.Abs(*((Vector128<sbyte>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsFinite_sbyte()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<sbyte>*)c + i) = Simd128.IsFinite(*((Vector128<sbyte>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsInfinity_sbyte()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<sbyte>*)c + i) = Simd128.IsInfinity(*((Vector128<sbyte>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsNaN_sbyte()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<sbyte>*)c + i) = Simd128.IsNaN(*((Vector128<sbyte>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsNegative_sbyte()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<sbyte>*)c + i) = Simd128.IsNegative(*((Vector128<sbyte>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsNegativeInfinity_sbyte()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<sbyte>*)c + i) = Simd128.IsNegativeInfinity(*((Vector128<sbyte>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsNormal_sbyte()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<sbyte>*)c + i) = Simd128.IsNormal(*((Vector128<sbyte>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsPositiveInfinity_sbyte()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<sbyte>*)c + i) = Simd128.IsPositiveInfinity(*((Vector128<sbyte>*)a + i)); 
        }
        [Benchmark]
        public void Simd128Sign_sbyte()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<sbyte>*)c + i) = Simd128.Sign(*((Vector128<sbyte>*)a + i)); 
        }

#endregion


#region Vector x Vector -> Vector 256-bit sbyte

        [Benchmark]
        public void Simd256GreaterThan_sbyte()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<sbyte>*)c + i) = Simd256.GreaterThan(*((Vector256<sbyte>*)a + i), *((Vector256<sbyte>*)b + i)); 
        }
        [Benchmark]
        public void Simd256LessThan_sbyte()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<sbyte>*)c + i) = Simd256.LessThan(*((Vector256<sbyte>*)a + i), *((Vector256<sbyte>*)b + i)); 
        }
        [Benchmark]
        public void Simd256GreaterThanOrEqual_sbyte()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<sbyte>*)c + i) = Simd256.GreaterThanOrEqual(*((Vector256<sbyte>*)a + i), *((Vector256<sbyte>*)b + i)); 
        }
        [Benchmark]
        public void Simd256LessThanOrEqual_sbyte()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<sbyte>*)c + i) = Simd256.LessThanOrEqual(*((Vector256<sbyte>*)a + i), *((Vector256<sbyte>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Add_sbyte()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<sbyte>*)c + i) = Simd256.Add(*((Vector256<sbyte>*)a + i), *((Vector256<sbyte>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Subtract_sbyte()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<sbyte>*)c + i) = Simd256.Subtract(*((Vector256<sbyte>*)a + i), *((Vector256<sbyte>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Multiply_sbyte()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<sbyte>*)c + i) = Simd256.Multiply(*((Vector256<sbyte>*)a + i), *((Vector256<sbyte>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Divide_sbyte()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<sbyte>*)c + i) = Simd256.Divide(*((Vector256<sbyte>*)a + i), *((Vector256<sbyte>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Min_sbyte()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<sbyte>*)c + i) = Simd256.Min(*((Vector256<sbyte>*)a + i), *((Vector256<sbyte>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Max_sbyte()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<sbyte>*)c + i) = Simd256.Max(*((Vector256<sbyte>*)a + i), *((Vector256<sbyte>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Equal_sbyte()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<sbyte>*)c + i) = Simd256.Equal(*((Vector256<sbyte>*)a + i), *((Vector256<sbyte>*)b + i)); 
        }
        [Benchmark]
        public void Simd256NotEqual_sbyte()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<sbyte>*)c + i) = Simd256.NotEqual(*((Vector256<sbyte>*)a + i), *((Vector256<sbyte>*)b + i)); 
        }
        [Benchmark]
        public void Simd256And_sbyte()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<sbyte>*)c + i) = Simd256.And(*((Vector256<sbyte>*)a + i), *((Vector256<sbyte>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Xor_sbyte()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<sbyte>*)c + i) = Simd256.Xor(*((Vector256<sbyte>*)a + i), *((Vector256<sbyte>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Or_sbyte()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<sbyte>*)c + i) = Simd256.Or(*((Vector256<sbyte>*)a + i), *((Vector256<sbyte>*)b + i)); 
        }

#endregion

#region Vector -> Vector 256-bit sbyte

        [Benchmark]
        public void Simd256Not_sbyte()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<sbyte>*)c + i) = Simd256.Not(*((Vector256<sbyte>*)a + i)); 
        }
        [Benchmark]
        public void Simd256Abs_sbyte()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<sbyte>*)c + i) = Simd256.Abs(*((Vector256<sbyte>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsFinite_sbyte()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<sbyte>*)c + i) = Simd256.IsFinite(*((Vector256<sbyte>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsInfinity_sbyte()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<sbyte>*)c + i) = Simd256.IsInfinity(*((Vector256<sbyte>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsNaN_sbyte()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<sbyte>*)c + i) = Simd256.IsNaN(*((Vector256<sbyte>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsNegative_sbyte()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<sbyte>*)c + i) = Simd256.IsNegative(*((Vector256<sbyte>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsNegativeInfinity_sbyte()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<sbyte>*)c + i) = Simd256.IsNegativeInfinity(*((Vector256<sbyte>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsNormal_sbyte()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<sbyte>*)c + i) = Simd256.IsNormal(*((Vector256<sbyte>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsPositiveInfinity_sbyte()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<sbyte>*)c + i) = Simd256.IsPositiveInfinity(*((Vector256<sbyte>*)a + i)); 
        }
        [Benchmark]
        public void Simd256Sign_sbyte()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<sbyte>*)c + i) = Simd256.Sign(*((Vector256<sbyte>*)a + i)); 
        }

#endregion


#region Vector x Vector -> Vector 64-bit ushort

        [Benchmark]
        public void Simd64GreaterThan_ushort()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<ushort>*)c + i) = Simd64.GreaterThan(*((Vector64<ushort>*)a + i), *((Vector64<ushort>*)b + i)); 
        }
        [Benchmark]
        public void Simd64LessThan_ushort()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<ushort>*)c + i) = Simd64.LessThan(*((Vector64<ushort>*)a + i), *((Vector64<ushort>*)b + i)); 
        }
        [Benchmark]
        public void Simd64GreaterThanOrEqual_ushort()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<ushort>*)c + i) = Simd64.GreaterThanOrEqual(*((Vector64<ushort>*)a + i), *((Vector64<ushort>*)b + i)); 
        }
        [Benchmark]
        public void Simd64LessThanOrEqual_ushort()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<ushort>*)c + i) = Simd64.LessThanOrEqual(*((Vector64<ushort>*)a + i), *((Vector64<ushort>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Add_ushort()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<ushort>*)c + i) = Simd64.Add(*((Vector64<ushort>*)a + i), *((Vector64<ushort>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Subtract_ushort()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<ushort>*)c + i) = Simd64.Subtract(*((Vector64<ushort>*)a + i), *((Vector64<ushort>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Multiply_ushort()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<ushort>*)c + i) = Simd64.Multiply(*((Vector64<ushort>*)a + i), *((Vector64<ushort>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Divide_ushort()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<ushort>*)c + i) = Simd64.Divide(*((Vector64<ushort>*)a + i), *((Vector64<ushort>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Min_ushort()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<ushort>*)c + i) = Simd64.Min(*((Vector64<ushort>*)a + i), *((Vector64<ushort>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Max_ushort()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<ushort>*)c + i) = Simd64.Max(*((Vector64<ushort>*)a + i), *((Vector64<ushort>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Equal_ushort()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<ushort>*)c + i) = Simd64.Equal(*((Vector64<ushort>*)a + i), *((Vector64<ushort>*)b + i)); 
        }
        [Benchmark]
        public void Simd64NotEqual_ushort()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<ushort>*)c + i) = Simd64.NotEqual(*((Vector64<ushort>*)a + i), *((Vector64<ushort>*)b + i)); 
        }
        [Benchmark]
        public void Simd64And_ushort()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<ushort>*)c + i) = Simd64.And(*((Vector64<ushort>*)a + i), *((Vector64<ushort>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Xor_ushort()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<ushort>*)c + i) = Simd64.Xor(*((Vector64<ushort>*)a + i), *((Vector64<ushort>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Or_ushort()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<ushort>*)c + i) = Simd64.Or(*((Vector64<ushort>*)a + i), *((Vector64<ushort>*)b + i)); 
        }

#endregion

#region Vector -> Vector 64-bit ushort

        [Benchmark]
        public void Simd64Not_ushort()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<ushort>*)c + i) = Simd64.Not(*((Vector64<ushort>*)a + i)); 
        }
        [Benchmark]
        public void Simd64Abs_ushort()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<ushort>*)c + i) = Simd64.Abs(*((Vector64<ushort>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsFinite_ushort()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<ushort>*)c + i) = Simd64.IsFinite(*((Vector64<ushort>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsInfinity_ushort()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<ushort>*)c + i) = Simd64.IsInfinity(*((Vector64<ushort>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsNaN_ushort()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<ushort>*)c + i) = Simd64.IsNaN(*((Vector64<ushort>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsNegative_ushort()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<ushort>*)c + i) = Simd64.IsNegative(*((Vector64<ushort>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsNegativeInfinity_ushort()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<ushort>*)c + i) = Simd64.IsNegativeInfinity(*((Vector64<ushort>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsNormal_ushort()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<ushort>*)c + i) = Simd64.IsNormal(*((Vector64<ushort>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsPositiveInfinity_ushort()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<ushort>*)c + i) = Simd64.IsPositiveInfinity(*((Vector64<ushort>*)a + i)); 
        }
        [Benchmark]
        public void Simd64Sign_ushort()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<ushort>*)c + i) = Simd64.Sign(*((Vector64<ushort>*)a + i)); 
        }

#endregion


#region Vector x Vector -> Vector 128-bit ushort

        [Benchmark]
        public void Simd128GreaterThan_ushort()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<ushort>*)c + i) = Simd128.GreaterThan(*((Vector128<ushort>*)a + i), *((Vector128<ushort>*)b + i)); 
        }
        [Benchmark]
        public void Simd128LessThan_ushort()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<ushort>*)c + i) = Simd128.LessThan(*((Vector128<ushort>*)a + i), *((Vector128<ushort>*)b + i)); 
        }
        [Benchmark]
        public void Simd128GreaterThanOrEqual_ushort()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<ushort>*)c + i) = Simd128.GreaterThanOrEqual(*((Vector128<ushort>*)a + i), *((Vector128<ushort>*)b + i)); 
        }
        [Benchmark]
        public void Simd128LessThanOrEqual_ushort()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<ushort>*)c + i) = Simd128.LessThanOrEqual(*((Vector128<ushort>*)a + i), *((Vector128<ushort>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Add_ushort()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<ushort>*)c + i) = Simd128.Add(*((Vector128<ushort>*)a + i), *((Vector128<ushort>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Subtract_ushort()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<ushort>*)c + i) = Simd128.Subtract(*((Vector128<ushort>*)a + i), *((Vector128<ushort>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Multiply_ushort()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<ushort>*)c + i) = Simd128.Multiply(*((Vector128<ushort>*)a + i), *((Vector128<ushort>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Divide_ushort()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<ushort>*)c + i) = Simd128.Divide(*((Vector128<ushort>*)a + i), *((Vector128<ushort>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Min_ushort()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<ushort>*)c + i) = Simd128.Min(*((Vector128<ushort>*)a + i), *((Vector128<ushort>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Max_ushort()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<ushort>*)c + i) = Simd128.Max(*((Vector128<ushort>*)a + i), *((Vector128<ushort>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Equal_ushort()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<ushort>*)c + i) = Simd128.Equal(*((Vector128<ushort>*)a + i), *((Vector128<ushort>*)b + i)); 
        }
        [Benchmark]
        public void Simd128NotEqual_ushort()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<ushort>*)c + i) = Simd128.NotEqual(*((Vector128<ushort>*)a + i), *((Vector128<ushort>*)b + i)); 
        }
        [Benchmark]
        public void Simd128And_ushort()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<ushort>*)c + i) = Simd128.And(*((Vector128<ushort>*)a + i), *((Vector128<ushort>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Xor_ushort()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<ushort>*)c + i) = Simd128.Xor(*((Vector128<ushort>*)a + i), *((Vector128<ushort>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Or_ushort()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<ushort>*)c + i) = Simd128.Or(*((Vector128<ushort>*)a + i), *((Vector128<ushort>*)b + i)); 
        }

#endregion

#region Vector -> Vector 128-bit ushort

        [Benchmark]
        public void Simd128Not_ushort()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<ushort>*)c + i) = Simd128.Not(*((Vector128<ushort>*)a + i)); 
        }
        [Benchmark]
        public void Simd128Abs_ushort()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<ushort>*)c + i) = Simd128.Abs(*((Vector128<ushort>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsFinite_ushort()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<ushort>*)c + i) = Simd128.IsFinite(*((Vector128<ushort>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsInfinity_ushort()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<ushort>*)c + i) = Simd128.IsInfinity(*((Vector128<ushort>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsNaN_ushort()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<ushort>*)c + i) = Simd128.IsNaN(*((Vector128<ushort>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsNegative_ushort()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<ushort>*)c + i) = Simd128.IsNegative(*((Vector128<ushort>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsNegativeInfinity_ushort()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<ushort>*)c + i) = Simd128.IsNegativeInfinity(*((Vector128<ushort>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsNormal_ushort()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<ushort>*)c + i) = Simd128.IsNormal(*((Vector128<ushort>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsPositiveInfinity_ushort()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<ushort>*)c + i) = Simd128.IsPositiveInfinity(*((Vector128<ushort>*)a + i)); 
        }
        [Benchmark]
        public void Simd128Sign_ushort()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<ushort>*)c + i) = Simd128.Sign(*((Vector128<ushort>*)a + i)); 
        }

#endregion


#region Vector x Vector -> Vector 256-bit ushort

        [Benchmark]
        public void Simd256GreaterThan_ushort()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<ushort>*)c + i) = Simd256.GreaterThan(*((Vector256<ushort>*)a + i), *((Vector256<ushort>*)b + i)); 
        }
        [Benchmark]
        public void Simd256LessThan_ushort()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<ushort>*)c + i) = Simd256.LessThan(*((Vector256<ushort>*)a + i), *((Vector256<ushort>*)b + i)); 
        }
        [Benchmark]
        public void Simd256GreaterThanOrEqual_ushort()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<ushort>*)c + i) = Simd256.GreaterThanOrEqual(*((Vector256<ushort>*)a + i), *((Vector256<ushort>*)b + i)); 
        }
        [Benchmark]
        public void Simd256LessThanOrEqual_ushort()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<ushort>*)c + i) = Simd256.LessThanOrEqual(*((Vector256<ushort>*)a + i), *((Vector256<ushort>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Add_ushort()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<ushort>*)c + i) = Simd256.Add(*((Vector256<ushort>*)a + i), *((Vector256<ushort>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Subtract_ushort()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<ushort>*)c + i) = Simd256.Subtract(*((Vector256<ushort>*)a + i), *((Vector256<ushort>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Multiply_ushort()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<ushort>*)c + i) = Simd256.Multiply(*((Vector256<ushort>*)a + i), *((Vector256<ushort>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Divide_ushort()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<ushort>*)c + i) = Simd256.Divide(*((Vector256<ushort>*)a + i), *((Vector256<ushort>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Min_ushort()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<ushort>*)c + i) = Simd256.Min(*((Vector256<ushort>*)a + i), *((Vector256<ushort>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Max_ushort()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<ushort>*)c + i) = Simd256.Max(*((Vector256<ushort>*)a + i), *((Vector256<ushort>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Equal_ushort()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<ushort>*)c + i) = Simd256.Equal(*((Vector256<ushort>*)a + i), *((Vector256<ushort>*)b + i)); 
        }
        [Benchmark]
        public void Simd256NotEqual_ushort()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<ushort>*)c + i) = Simd256.NotEqual(*((Vector256<ushort>*)a + i), *((Vector256<ushort>*)b + i)); 
        }
        [Benchmark]
        public void Simd256And_ushort()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<ushort>*)c + i) = Simd256.And(*((Vector256<ushort>*)a + i), *((Vector256<ushort>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Xor_ushort()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<ushort>*)c + i) = Simd256.Xor(*((Vector256<ushort>*)a + i), *((Vector256<ushort>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Or_ushort()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<ushort>*)c + i) = Simd256.Or(*((Vector256<ushort>*)a + i), *((Vector256<ushort>*)b + i)); 
        }

#endregion

#region Vector -> Vector 256-bit ushort

        [Benchmark]
        public void Simd256Not_ushort()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<ushort>*)c + i) = Simd256.Not(*((Vector256<ushort>*)a + i)); 
        }
        [Benchmark]
        public void Simd256Abs_ushort()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<ushort>*)c + i) = Simd256.Abs(*((Vector256<ushort>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsFinite_ushort()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<ushort>*)c + i) = Simd256.IsFinite(*((Vector256<ushort>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsInfinity_ushort()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<ushort>*)c + i) = Simd256.IsInfinity(*((Vector256<ushort>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsNaN_ushort()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<ushort>*)c + i) = Simd256.IsNaN(*((Vector256<ushort>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsNegative_ushort()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<ushort>*)c + i) = Simd256.IsNegative(*((Vector256<ushort>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsNegativeInfinity_ushort()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<ushort>*)c + i) = Simd256.IsNegativeInfinity(*((Vector256<ushort>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsNormal_ushort()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<ushort>*)c + i) = Simd256.IsNormal(*((Vector256<ushort>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsPositiveInfinity_ushort()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<ushort>*)c + i) = Simd256.IsPositiveInfinity(*((Vector256<ushort>*)a + i)); 
        }
        [Benchmark]
        public void Simd256Sign_ushort()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<ushort>*)c + i) = Simd256.Sign(*((Vector256<ushort>*)a + i)); 
        }

#endregion


#region Vector x Vector -> Vector 64-bit short

        [Benchmark]
        public void Simd64GreaterThan_short()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<short>*)c + i) = Simd64.GreaterThan(*((Vector64<short>*)a + i), *((Vector64<short>*)b + i)); 
        }
        [Benchmark]
        public void Simd64LessThan_short()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<short>*)c + i) = Simd64.LessThan(*((Vector64<short>*)a + i), *((Vector64<short>*)b + i)); 
        }
        [Benchmark]
        public void Simd64GreaterThanOrEqual_short()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<short>*)c + i) = Simd64.GreaterThanOrEqual(*((Vector64<short>*)a + i), *((Vector64<short>*)b + i)); 
        }
        [Benchmark]
        public void Simd64LessThanOrEqual_short()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<short>*)c + i) = Simd64.LessThanOrEqual(*((Vector64<short>*)a + i), *((Vector64<short>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Add_short()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<short>*)c + i) = Simd64.Add(*((Vector64<short>*)a + i), *((Vector64<short>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Subtract_short()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<short>*)c + i) = Simd64.Subtract(*((Vector64<short>*)a + i), *((Vector64<short>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Multiply_short()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<short>*)c + i) = Simd64.Multiply(*((Vector64<short>*)a + i), *((Vector64<short>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Divide_short()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<short>*)c + i) = Simd64.Divide(*((Vector64<short>*)a + i), *((Vector64<short>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Min_short()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<short>*)c + i) = Simd64.Min(*((Vector64<short>*)a + i), *((Vector64<short>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Max_short()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<short>*)c + i) = Simd64.Max(*((Vector64<short>*)a + i), *((Vector64<short>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Equal_short()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<short>*)c + i) = Simd64.Equal(*((Vector64<short>*)a + i), *((Vector64<short>*)b + i)); 
        }
        [Benchmark]
        public void Simd64NotEqual_short()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<short>*)c + i) = Simd64.NotEqual(*((Vector64<short>*)a + i), *((Vector64<short>*)b + i)); 
        }
        [Benchmark]
        public void Simd64And_short()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<short>*)c + i) = Simd64.And(*((Vector64<short>*)a + i), *((Vector64<short>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Xor_short()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<short>*)c + i) = Simd64.Xor(*((Vector64<short>*)a + i), *((Vector64<short>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Or_short()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<short>*)c + i) = Simd64.Or(*((Vector64<short>*)a + i), *((Vector64<short>*)b + i)); 
        }

#endregion

#region Vector -> Vector 64-bit short

        [Benchmark]
        public void Simd64Not_short()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<short>*)c + i) = Simd64.Not(*((Vector64<short>*)a + i)); 
        }
        [Benchmark]
        public void Simd64Abs_short()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<short>*)c + i) = Simd64.Abs(*((Vector64<short>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsFinite_short()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<short>*)c + i) = Simd64.IsFinite(*((Vector64<short>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsInfinity_short()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<short>*)c + i) = Simd64.IsInfinity(*((Vector64<short>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsNaN_short()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<short>*)c + i) = Simd64.IsNaN(*((Vector64<short>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsNegative_short()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<short>*)c + i) = Simd64.IsNegative(*((Vector64<short>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsNegativeInfinity_short()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<short>*)c + i) = Simd64.IsNegativeInfinity(*((Vector64<short>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsNormal_short()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<short>*)c + i) = Simd64.IsNormal(*((Vector64<short>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsPositiveInfinity_short()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<short>*)c + i) = Simd64.IsPositiveInfinity(*((Vector64<short>*)a + i)); 
        }
        [Benchmark]
        public void Simd64Sign_short()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<short>*)c + i) = Simd64.Sign(*((Vector64<short>*)a + i)); 
        }

#endregion


#region Vector x Vector -> Vector 128-bit short

        [Benchmark]
        public void Simd128GreaterThan_short()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<short>*)c + i) = Simd128.GreaterThan(*((Vector128<short>*)a + i), *((Vector128<short>*)b + i)); 
        }
        [Benchmark]
        public void Simd128LessThan_short()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<short>*)c + i) = Simd128.LessThan(*((Vector128<short>*)a + i), *((Vector128<short>*)b + i)); 
        }
        [Benchmark]
        public void Simd128GreaterThanOrEqual_short()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<short>*)c + i) = Simd128.GreaterThanOrEqual(*((Vector128<short>*)a + i), *((Vector128<short>*)b + i)); 
        }
        [Benchmark]
        public void Simd128LessThanOrEqual_short()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<short>*)c + i) = Simd128.LessThanOrEqual(*((Vector128<short>*)a + i), *((Vector128<short>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Add_short()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<short>*)c + i) = Simd128.Add(*((Vector128<short>*)a + i), *((Vector128<short>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Subtract_short()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<short>*)c + i) = Simd128.Subtract(*((Vector128<short>*)a + i), *((Vector128<short>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Multiply_short()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<short>*)c + i) = Simd128.Multiply(*((Vector128<short>*)a + i), *((Vector128<short>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Divide_short()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<short>*)c + i) = Simd128.Divide(*((Vector128<short>*)a + i), *((Vector128<short>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Min_short()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<short>*)c + i) = Simd128.Min(*((Vector128<short>*)a + i), *((Vector128<short>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Max_short()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<short>*)c + i) = Simd128.Max(*((Vector128<short>*)a + i), *((Vector128<short>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Equal_short()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<short>*)c + i) = Simd128.Equal(*((Vector128<short>*)a + i), *((Vector128<short>*)b + i)); 
        }
        [Benchmark]
        public void Simd128NotEqual_short()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<short>*)c + i) = Simd128.NotEqual(*((Vector128<short>*)a + i), *((Vector128<short>*)b + i)); 
        }
        [Benchmark]
        public void Simd128And_short()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<short>*)c + i) = Simd128.And(*((Vector128<short>*)a + i), *((Vector128<short>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Xor_short()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<short>*)c + i) = Simd128.Xor(*((Vector128<short>*)a + i), *((Vector128<short>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Or_short()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<short>*)c + i) = Simd128.Or(*((Vector128<short>*)a + i), *((Vector128<short>*)b + i)); 
        }

#endregion

#region Vector -> Vector 128-bit short

        [Benchmark]
        public void Simd128Not_short()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<short>*)c + i) = Simd128.Not(*((Vector128<short>*)a + i)); 
        }
        [Benchmark]
        public void Simd128Abs_short()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<short>*)c + i) = Simd128.Abs(*((Vector128<short>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsFinite_short()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<short>*)c + i) = Simd128.IsFinite(*((Vector128<short>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsInfinity_short()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<short>*)c + i) = Simd128.IsInfinity(*((Vector128<short>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsNaN_short()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<short>*)c + i) = Simd128.IsNaN(*((Vector128<short>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsNegative_short()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<short>*)c + i) = Simd128.IsNegative(*((Vector128<short>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsNegativeInfinity_short()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<short>*)c + i) = Simd128.IsNegativeInfinity(*((Vector128<short>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsNormal_short()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<short>*)c + i) = Simd128.IsNormal(*((Vector128<short>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsPositiveInfinity_short()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<short>*)c + i) = Simd128.IsPositiveInfinity(*((Vector128<short>*)a + i)); 
        }
        [Benchmark]
        public void Simd128Sign_short()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<short>*)c + i) = Simd128.Sign(*((Vector128<short>*)a + i)); 
        }

#endregion


#region Vector x Vector -> Vector 256-bit short

        [Benchmark]
        public void Simd256GreaterThan_short()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<short>*)c + i) = Simd256.GreaterThan(*((Vector256<short>*)a + i), *((Vector256<short>*)b + i)); 
        }
        [Benchmark]
        public void Simd256LessThan_short()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<short>*)c + i) = Simd256.LessThan(*((Vector256<short>*)a + i), *((Vector256<short>*)b + i)); 
        }
        [Benchmark]
        public void Simd256GreaterThanOrEqual_short()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<short>*)c + i) = Simd256.GreaterThanOrEqual(*((Vector256<short>*)a + i), *((Vector256<short>*)b + i)); 
        }
        [Benchmark]
        public void Simd256LessThanOrEqual_short()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<short>*)c + i) = Simd256.LessThanOrEqual(*((Vector256<short>*)a + i), *((Vector256<short>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Add_short()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<short>*)c + i) = Simd256.Add(*((Vector256<short>*)a + i), *((Vector256<short>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Subtract_short()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<short>*)c + i) = Simd256.Subtract(*((Vector256<short>*)a + i), *((Vector256<short>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Multiply_short()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<short>*)c + i) = Simd256.Multiply(*((Vector256<short>*)a + i), *((Vector256<short>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Divide_short()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<short>*)c + i) = Simd256.Divide(*((Vector256<short>*)a + i), *((Vector256<short>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Min_short()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<short>*)c + i) = Simd256.Min(*((Vector256<short>*)a + i), *((Vector256<short>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Max_short()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<short>*)c + i) = Simd256.Max(*((Vector256<short>*)a + i), *((Vector256<short>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Equal_short()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<short>*)c + i) = Simd256.Equal(*((Vector256<short>*)a + i), *((Vector256<short>*)b + i)); 
        }
        [Benchmark]
        public void Simd256NotEqual_short()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<short>*)c + i) = Simd256.NotEqual(*((Vector256<short>*)a + i), *((Vector256<short>*)b + i)); 
        }
        [Benchmark]
        public void Simd256And_short()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<short>*)c + i) = Simd256.And(*((Vector256<short>*)a + i), *((Vector256<short>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Xor_short()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<short>*)c + i) = Simd256.Xor(*((Vector256<short>*)a + i), *((Vector256<short>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Or_short()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<short>*)c + i) = Simd256.Or(*((Vector256<short>*)a + i), *((Vector256<short>*)b + i)); 
        }

#endregion

#region Vector -> Vector 256-bit short

        [Benchmark]
        public void Simd256Not_short()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<short>*)c + i) = Simd256.Not(*((Vector256<short>*)a + i)); 
        }
        [Benchmark]
        public void Simd256Abs_short()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<short>*)c + i) = Simd256.Abs(*((Vector256<short>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsFinite_short()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<short>*)c + i) = Simd256.IsFinite(*((Vector256<short>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsInfinity_short()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<short>*)c + i) = Simd256.IsInfinity(*((Vector256<short>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsNaN_short()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<short>*)c + i) = Simd256.IsNaN(*((Vector256<short>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsNegative_short()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<short>*)c + i) = Simd256.IsNegative(*((Vector256<short>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsNegativeInfinity_short()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<short>*)c + i) = Simd256.IsNegativeInfinity(*((Vector256<short>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsNormal_short()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<short>*)c + i) = Simd256.IsNormal(*((Vector256<short>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsPositiveInfinity_short()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<short>*)c + i) = Simd256.IsPositiveInfinity(*((Vector256<short>*)a + i)); 
        }
        [Benchmark]
        public void Simd256Sign_short()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<short>*)c + i) = Simd256.Sign(*((Vector256<short>*)a + i)); 
        }

#endregion


#region Vector x Vector -> Vector 64-bit uint

        [Benchmark]
        public void Simd64GreaterThan_uint()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<uint>*)c + i) = Simd64.GreaterThan(*((Vector64<uint>*)a + i), *((Vector64<uint>*)b + i)); 
        }
        [Benchmark]
        public void Simd64LessThan_uint()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<uint>*)c + i) = Simd64.LessThan(*((Vector64<uint>*)a + i), *((Vector64<uint>*)b + i)); 
        }
        [Benchmark]
        public void Simd64GreaterThanOrEqual_uint()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<uint>*)c + i) = Simd64.GreaterThanOrEqual(*((Vector64<uint>*)a + i), *((Vector64<uint>*)b + i)); 
        }
        [Benchmark]
        public void Simd64LessThanOrEqual_uint()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<uint>*)c + i) = Simd64.LessThanOrEqual(*((Vector64<uint>*)a + i), *((Vector64<uint>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Add_uint()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<uint>*)c + i) = Simd64.Add(*((Vector64<uint>*)a + i), *((Vector64<uint>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Subtract_uint()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<uint>*)c + i) = Simd64.Subtract(*((Vector64<uint>*)a + i), *((Vector64<uint>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Multiply_uint()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<uint>*)c + i) = Simd64.Multiply(*((Vector64<uint>*)a + i), *((Vector64<uint>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Divide_uint()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<uint>*)c + i) = Simd64.Divide(*((Vector64<uint>*)a + i), *((Vector64<uint>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Min_uint()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<uint>*)c + i) = Simd64.Min(*((Vector64<uint>*)a + i), *((Vector64<uint>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Max_uint()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<uint>*)c + i) = Simd64.Max(*((Vector64<uint>*)a + i), *((Vector64<uint>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Equal_uint()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<uint>*)c + i) = Simd64.Equal(*((Vector64<uint>*)a + i), *((Vector64<uint>*)b + i)); 
        }
        [Benchmark]
        public void Simd64NotEqual_uint()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<uint>*)c + i) = Simd64.NotEqual(*((Vector64<uint>*)a + i), *((Vector64<uint>*)b + i)); 
        }
        [Benchmark]
        public void Simd64And_uint()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<uint>*)c + i) = Simd64.And(*((Vector64<uint>*)a + i), *((Vector64<uint>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Xor_uint()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<uint>*)c + i) = Simd64.Xor(*((Vector64<uint>*)a + i), *((Vector64<uint>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Or_uint()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<uint>*)c + i) = Simd64.Or(*((Vector64<uint>*)a + i), *((Vector64<uint>*)b + i)); 
        }

#endregion

#region Vector -> Vector 64-bit uint

        [Benchmark]
        public void Simd64Not_uint()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<uint>*)c + i) = Simd64.Not(*((Vector64<uint>*)a + i)); 
        }
        [Benchmark]
        public void Simd64Abs_uint()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<uint>*)c + i) = Simd64.Abs(*((Vector64<uint>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsFinite_uint()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<uint>*)c + i) = Simd64.IsFinite(*((Vector64<uint>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsInfinity_uint()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<uint>*)c + i) = Simd64.IsInfinity(*((Vector64<uint>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsNaN_uint()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<uint>*)c + i) = Simd64.IsNaN(*((Vector64<uint>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsNegative_uint()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<uint>*)c + i) = Simd64.IsNegative(*((Vector64<uint>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsNegativeInfinity_uint()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<uint>*)c + i) = Simd64.IsNegativeInfinity(*((Vector64<uint>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsNormal_uint()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<uint>*)c + i) = Simd64.IsNormal(*((Vector64<uint>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsPositiveInfinity_uint()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<uint>*)c + i) = Simd64.IsPositiveInfinity(*((Vector64<uint>*)a + i)); 
        }
        [Benchmark]
        public void Simd64Sign_uint()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<uint>*)c + i) = Simd64.Sign(*((Vector64<uint>*)a + i)); 
        }

#endregion


#region Vector x Vector -> Vector 128-bit uint

        [Benchmark]
        public void Simd128GreaterThan_uint()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<uint>*)c + i) = Simd128.GreaterThan(*((Vector128<uint>*)a + i), *((Vector128<uint>*)b + i)); 
        }
        [Benchmark]
        public void Simd128LessThan_uint()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<uint>*)c + i) = Simd128.LessThan(*((Vector128<uint>*)a + i), *((Vector128<uint>*)b + i)); 
        }
        [Benchmark]
        public void Simd128GreaterThanOrEqual_uint()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<uint>*)c + i) = Simd128.GreaterThanOrEqual(*((Vector128<uint>*)a + i), *((Vector128<uint>*)b + i)); 
        }
        [Benchmark]
        public void Simd128LessThanOrEqual_uint()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<uint>*)c + i) = Simd128.LessThanOrEqual(*((Vector128<uint>*)a + i), *((Vector128<uint>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Add_uint()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<uint>*)c + i) = Simd128.Add(*((Vector128<uint>*)a + i), *((Vector128<uint>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Subtract_uint()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<uint>*)c + i) = Simd128.Subtract(*((Vector128<uint>*)a + i), *((Vector128<uint>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Multiply_uint()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<uint>*)c + i) = Simd128.Multiply(*((Vector128<uint>*)a + i), *((Vector128<uint>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Divide_uint()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<uint>*)c + i) = Simd128.Divide(*((Vector128<uint>*)a + i), *((Vector128<uint>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Min_uint()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<uint>*)c + i) = Simd128.Min(*((Vector128<uint>*)a + i), *((Vector128<uint>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Max_uint()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<uint>*)c + i) = Simd128.Max(*((Vector128<uint>*)a + i), *((Vector128<uint>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Equal_uint()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<uint>*)c + i) = Simd128.Equal(*((Vector128<uint>*)a + i), *((Vector128<uint>*)b + i)); 
        }
        [Benchmark]
        public void Simd128NotEqual_uint()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<uint>*)c + i) = Simd128.NotEqual(*((Vector128<uint>*)a + i), *((Vector128<uint>*)b + i)); 
        }
        [Benchmark]
        public void Simd128And_uint()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<uint>*)c + i) = Simd128.And(*((Vector128<uint>*)a + i), *((Vector128<uint>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Xor_uint()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<uint>*)c + i) = Simd128.Xor(*((Vector128<uint>*)a + i), *((Vector128<uint>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Or_uint()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<uint>*)c + i) = Simd128.Or(*((Vector128<uint>*)a + i), *((Vector128<uint>*)b + i)); 
        }

#endregion

#region Vector -> Vector 128-bit uint

        [Benchmark]
        public void Simd128Not_uint()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<uint>*)c + i) = Simd128.Not(*((Vector128<uint>*)a + i)); 
        }
        [Benchmark]
        public void Simd128Abs_uint()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<uint>*)c + i) = Simd128.Abs(*((Vector128<uint>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsFinite_uint()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<uint>*)c + i) = Simd128.IsFinite(*((Vector128<uint>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsInfinity_uint()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<uint>*)c + i) = Simd128.IsInfinity(*((Vector128<uint>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsNaN_uint()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<uint>*)c + i) = Simd128.IsNaN(*((Vector128<uint>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsNegative_uint()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<uint>*)c + i) = Simd128.IsNegative(*((Vector128<uint>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsNegativeInfinity_uint()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<uint>*)c + i) = Simd128.IsNegativeInfinity(*((Vector128<uint>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsNormal_uint()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<uint>*)c + i) = Simd128.IsNormal(*((Vector128<uint>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsPositiveInfinity_uint()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<uint>*)c + i) = Simd128.IsPositiveInfinity(*((Vector128<uint>*)a + i)); 
        }
        [Benchmark]
        public void Simd128Sign_uint()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<uint>*)c + i) = Simd128.Sign(*((Vector128<uint>*)a + i)); 
        }

#endregion


#region Vector x Vector -> Vector 256-bit uint

        [Benchmark]
        public void Simd256GreaterThan_uint()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<uint>*)c + i) = Simd256.GreaterThan(*((Vector256<uint>*)a + i), *((Vector256<uint>*)b + i)); 
        }
        [Benchmark]
        public void Simd256LessThan_uint()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<uint>*)c + i) = Simd256.LessThan(*((Vector256<uint>*)a + i), *((Vector256<uint>*)b + i)); 
        }
        [Benchmark]
        public void Simd256GreaterThanOrEqual_uint()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<uint>*)c + i) = Simd256.GreaterThanOrEqual(*((Vector256<uint>*)a + i), *((Vector256<uint>*)b + i)); 
        }
        [Benchmark]
        public void Simd256LessThanOrEqual_uint()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<uint>*)c + i) = Simd256.LessThanOrEqual(*((Vector256<uint>*)a + i), *((Vector256<uint>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Add_uint()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<uint>*)c + i) = Simd256.Add(*((Vector256<uint>*)a + i), *((Vector256<uint>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Subtract_uint()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<uint>*)c + i) = Simd256.Subtract(*((Vector256<uint>*)a + i), *((Vector256<uint>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Multiply_uint()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<uint>*)c + i) = Simd256.Multiply(*((Vector256<uint>*)a + i), *((Vector256<uint>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Divide_uint()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<uint>*)c + i) = Simd256.Divide(*((Vector256<uint>*)a + i), *((Vector256<uint>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Min_uint()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<uint>*)c + i) = Simd256.Min(*((Vector256<uint>*)a + i), *((Vector256<uint>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Max_uint()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<uint>*)c + i) = Simd256.Max(*((Vector256<uint>*)a + i), *((Vector256<uint>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Equal_uint()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<uint>*)c + i) = Simd256.Equal(*((Vector256<uint>*)a + i), *((Vector256<uint>*)b + i)); 
        }
        [Benchmark]
        public void Simd256NotEqual_uint()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<uint>*)c + i) = Simd256.NotEqual(*((Vector256<uint>*)a + i), *((Vector256<uint>*)b + i)); 
        }
        [Benchmark]
        public void Simd256And_uint()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<uint>*)c + i) = Simd256.And(*((Vector256<uint>*)a + i), *((Vector256<uint>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Xor_uint()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<uint>*)c + i) = Simd256.Xor(*((Vector256<uint>*)a + i), *((Vector256<uint>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Or_uint()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<uint>*)c + i) = Simd256.Or(*((Vector256<uint>*)a + i), *((Vector256<uint>*)b + i)); 
        }

#endregion

#region Vector -> Vector 256-bit uint

        [Benchmark]
        public void Simd256Not_uint()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<uint>*)c + i) = Simd256.Not(*((Vector256<uint>*)a + i)); 
        }
        [Benchmark]
        public void Simd256Abs_uint()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<uint>*)c + i) = Simd256.Abs(*((Vector256<uint>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsFinite_uint()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<uint>*)c + i) = Simd256.IsFinite(*((Vector256<uint>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsInfinity_uint()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<uint>*)c + i) = Simd256.IsInfinity(*((Vector256<uint>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsNaN_uint()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<uint>*)c + i) = Simd256.IsNaN(*((Vector256<uint>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsNegative_uint()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<uint>*)c + i) = Simd256.IsNegative(*((Vector256<uint>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsNegativeInfinity_uint()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<uint>*)c + i) = Simd256.IsNegativeInfinity(*((Vector256<uint>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsNormal_uint()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<uint>*)c + i) = Simd256.IsNormal(*((Vector256<uint>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsPositiveInfinity_uint()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<uint>*)c + i) = Simd256.IsPositiveInfinity(*((Vector256<uint>*)a + i)); 
        }
        [Benchmark]
        public void Simd256Sign_uint()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<uint>*)c + i) = Simd256.Sign(*((Vector256<uint>*)a + i)); 
        }

#endregion


#region Vector x Vector -> Vector 64-bit int

        [Benchmark]
        public void Simd64GreaterThan_int()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<int>*)c + i) = Simd64.GreaterThan(*((Vector64<int>*)a + i), *((Vector64<int>*)b + i)); 
        }
        [Benchmark]
        public void Simd64LessThan_int()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<int>*)c + i) = Simd64.LessThan(*((Vector64<int>*)a + i), *((Vector64<int>*)b + i)); 
        }
        [Benchmark]
        public void Simd64GreaterThanOrEqual_int()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<int>*)c + i) = Simd64.GreaterThanOrEqual(*((Vector64<int>*)a + i), *((Vector64<int>*)b + i)); 
        }
        [Benchmark]
        public void Simd64LessThanOrEqual_int()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<int>*)c + i) = Simd64.LessThanOrEqual(*((Vector64<int>*)a + i), *((Vector64<int>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Add_int()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<int>*)c + i) = Simd64.Add(*((Vector64<int>*)a + i), *((Vector64<int>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Subtract_int()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<int>*)c + i) = Simd64.Subtract(*((Vector64<int>*)a + i), *((Vector64<int>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Multiply_int()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<int>*)c + i) = Simd64.Multiply(*((Vector64<int>*)a + i), *((Vector64<int>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Divide_int()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<int>*)c + i) = Simd64.Divide(*((Vector64<int>*)a + i), *((Vector64<int>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Min_int()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<int>*)c + i) = Simd64.Min(*((Vector64<int>*)a + i), *((Vector64<int>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Max_int()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<int>*)c + i) = Simd64.Max(*((Vector64<int>*)a + i), *((Vector64<int>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Equal_int()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<int>*)c + i) = Simd64.Equal(*((Vector64<int>*)a + i), *((Vector64<int>*)b + i)); 
        }
        [Benchmark]
        public void Simd64NotEqual_int()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<int>*)c + i) = Simd64.NotEqual(*((Vector64<int>*)a + i), *((Vector64<int>*)b + i)); 
        }
        [Benchmark]
        public void Simd64And_int()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<int>*)c + i) = Simd64.And(*((Vector64<int>*)a + i), *((Vector64<int>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Xor_int()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<int>*)c + i) = Simd64.Xor(*((Vector64<int>*)a + i), *((Vector64<int>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Or_int()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<int>*)c + i) = Simd64.Or(*((Vector64<int>*)a + i), *((Vector64<int>*)b + i)); 
        }

#endregion

#region Vector -> Vector 64-bit int

        [Benchmark]
        public void Simd64Not_int()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<int>*)c + i) = Simd64.Not(*((Vector64<int>*)a + i)); 
        }
        [Benchmark]
        public void Simd64Abs_int()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<int>*)c + i) = Simd64.Abs(*((Vector64<int>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsFinite_int()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<int>*)c + i) = Simd64.IsFinite(*((Vector64<int>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsInfinity_int()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<int>*)c + i) = Simd64.IsInfinity(*((Vector64<int>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsNaN_int()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<int>*)c + i) = Simd64.IsNaN(*((Vector64<int>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsNegative_int()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<int>*)c + i) = Simd64.IsNegative(*((Vector64<int>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsNegativeInfinity_int()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<int>*)c + i) = Simd64.IsNegativeInfinity(*((Vector64<int>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsNormal_int()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<int>*)c + i) = Simd64.IsNormal(*((Vector64<int>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsPositiveInfinity_int()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<int>*)c + i) = Simd64.IsPositiveInfinity(*((Vector64<int>*)a + i)); 
        }
        [Benchmark]
        public void Simd64Sign_int()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<int>*)c + i) = Simd64.Sign(*((Vector64<int>*)a + i)); 
        }

#endregion


#region Vector x Vector -> Vector 128-bit int

        [Benchmark]
        public void Simd128GreaterThan_int()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<int>*)c + i) = Simd128.GreaterThan(*((Vector128<int>*)a + i), *((Vector128<int>*)b + i)); 
        }
        [Benchmark]
        public void Simd128LessThan_int()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<int>*)c + i) = Simd128.LessThan(*((Vector128<int>*)a + i), *((Vector128<int>*)b + i)); 
        }
        [Benchmark]
        public void Simd128GreaterThanOrEqual_int()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<int>*)c + i) = Simd128.GreaterThanOrEqual(*((Vector128<int>*)a + i), *((Vector128<int>*)b + i)); 
        }
        [Benchmark]
        public void Simd128LessThanOrEqual_int()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<int>*)c + i) = Simd128.LessThanOrEqual(*((Vector128<int>*)a + i), *((Vector128<int>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Add_int()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<int>*)c + i) = Simd128.Add(*((Vector128<int>*)a + i), *((Vector128<int>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Subtract_int()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<int>*)c + i) = Simd128.Subtract(*((Vector128<int>*)a + i), *((Vector128<int>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Multiply_int()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<int>*)c + i) = Simd128.Multiply(*((Vector128<int>*)a + i), *((Vector128<int>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Divide_int()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<int>*)c + i) = Simd128.Divide(*((Vector128<int>*)a + i), *((Vector128<int>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Min_int()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<int>*)c + i) = Simd128.Min(*((Vector128<int>*)a + i), *((Vector128<int>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Max_int()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<int>*)c + i) = Simd128.Max(*((Vector128<int>*)a + i), *((Vector128<int>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Equal_int()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<int>*)c + i) = Simd128.Equal(*((Vector128<int>*)a + i), *((Vector128<int>*)b + i)); 
        }
        [Benchmark]
        public void Simd128NotEqual_int()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<int>*)c + i) = Simd128.NotEqual(*((Vector128<int>*)a + i), *((Vector128<int>*)b + i)); 
        }
        [Benchmark]
        public void Simd128And_int()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<int>*)c + i) = Simd128.And(*((Vector128<int>*)a + i), *((Vector128<int>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Xor_int()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<int>*)c + i) = Simd128.Xor(*((Vector128<int>*)a + i), *((Vector128<int>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Or_int()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<int>*)c + i) = Simd128.Or(*((Vector128<int>*)a + i), *((Vector128<int>*)b + i)); 
        }

#endregion

#region Vector -> Vector 128-bit int

        [Benchmark]
        public void Simd128Not_int()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<int>*)c + i) = Simd128.Not(*((Vector128<int>*)a + i)); 
        }
        [Benchmark]
        public void Simd128Abs_int()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<int>*)c + i) = Simd128.Abs(*((Vector128<int>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsFinite_int()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<int>*)c + i) = Simd128.IsFinite(*((Vector128<int>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsInfinity_int()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<int>*)c + i) = Simd128.IsInfinity(*((Vector128<int>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsNaN_int()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<int>*)c + i) = Simd128.IsNaN(*((Vector128<int>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsNegative_int()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<int>*)c + i) = Simd128.IsNegative(*((Vector128<int>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsNegativeInfinity_int()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<int>*)c + i) = Simd128.IsNegativeInfinity(*((Vector128<int>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsNormal_int()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<int>*)c + i) = Simd128.IsNormal(*((Vector128<int>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsPositiveInfinity_int()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<int>*)c + i) = Simd128.IsPositiveInfinity(*((Vector128<int>*)a + i)); 
        }
        [Benchmark]
        public void Simd128Sign_int()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<int>*)c + i) = Simd128.Sign(*((Vector128<int>*)a + i)); 
        }

#endregion


#region Vector x Vector -> Vector 256-bit int

        [Benchmark]
        public void Simd256GreaterThan_int()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<int>*)c + i) = Simd256.GreaterThan(*((Vector256<int>*)a + i), *((Vector256<int>*)b + i)); 
        }
        [Benchmark]
        public void Simd256LessThan_int()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<int>*)c + i) = Simd256.LessThan(*((Vector256<int>*)a + i), *((Vector256<int>*)b + i)); 
        }
        [Benchmark]
        public void Simd256GreaterThanOrEqual_int()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<int>*)c + i) = Simd256.GreaterThanOrEqual(*((Vector256<int>*)a + i), *((Vector256<int>*)b + i)); 
        }
        [Benchmark]
        public void Simd256LessThanOrEqual_int()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<int>*)c + i) = Simd256.LessThanOrEqual(*((Vector256<int>*)a + i), *((Vector256<int>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Add_int()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<int>*)c + i) = Simd256.Add(*((Vector256<int>*)a + i), *((Vector256<int>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Subtract_int()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<int>*)c + i) = Simd256.Subtract(*((Vector256<int>*)a + i), *((Vector256<int>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Multiply_int()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<int>*)c + i) = Simd256.Multiply(*((Vector256<int>*)a + i), *((Vector256<int>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Divide_int()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<int>*)c + i) = Simd256.Divide(*((Vector256<int>*)a + i), *((Vector256<int>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Min_int()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<int>*)c + i) = Simd256.Min(*((Vector256<int>*)a + i), *((Vector256<int>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Max_int()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<int>*)c + i) = Simd256.Max(*((Vector256<int>*)a + i), *((Vector256<int>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Equal_int()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<int>*)c + i) = Simd256.Equal(*((Vector256<int>*)a + i), *((Vector256<int>*)b + i)); 
        }
        [Benchmark]
        public void Simd256NotEqual_int()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<int>*)c + i) = Simd256.NotEqual(*((Vector256<int>*)a + i), *((Vector256<int>*)b + i)); 
        }
        [Benchmark]
        public void Simd256And_int()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<int>*)c + i) = Simd256.And(*((Vector256<int>*)a + i), *((Vector256<int>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Xor_int()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<int>*)c + i) = Simd256.Xor(*((Vector256<int>*)a + i), *((Vector256<int>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Or_int()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<int>*)c + i) = Simd256.Or(*((Vector256<int>*)a + i), *((Vector256<int>*)b + i)); 
        }

#endregion

#region Vector -> Vector 256-bit int

        [Benchmark]
        public void Simd256Not_int()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<int>*)c + i) = Simd256.Not(*((Vector256<int>*)a + i)); 
        }
        [Benchmark]
        public void Simd256Abs_int()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<int>*)c + i) = Simd256.Abs(*((Vector256<int>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsFinite_int()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<int>*)c + i) = Simd256.IsFinite(*((Vector256<int>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsInfinity_int()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<int>*)c + i) = Simd256.IsInfinity(*((Vector256<int>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsNaN_int()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<int>*)c + i) = Simd256.IsNaN(*((Vector256<int>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsNegative_int()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<int>*)c + i) = Simd256.IsNegative(*((Vector256<int>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsNegativeInfinity_int()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<int>*)c + i) = Simd256.IsNegativeInfinity(*((Vector256<int>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsNormal_int()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<int>*)c + i) = Simd256.IsNormal(*((Vector256<int>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsPositiveInfinity_int()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<int>*)c + i) = Simd256.IsPositiveInfinity(*((Vector256<int>*)a + i)); 
        }
        [Benchmark]
        public void Simd256Sign_int()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<int>*)c + i) = Simd256.Sign(*((Vector256<int>*)a + i)); 
        }

#endregion


#region Vector x Vector -> Vector 64-bit ulong

        [Benchmark]
        public void Simd64GreaterThan_ulong()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<ulong>*)c + i) = Simd64.GreaterThan(*((Vector64<ulong>*)a + i), *((Vector64<ulong>*)b + i)); 
        }
        [Benchmark]
        public void Simd64LessThan_ulong()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<ulong>*)c + i) = Simd64.LessThan(*((Vector64<ulong>*)a + i), *((Vector64<ulong>*)b + i)); 
        }
        [Benchmark]
        public void Simd64GreaterThanOrEqual_ulong()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<ulong>*)c + i) = Simd64.GreaterThanOrEqual(*((Vector64<ulong>*)a + i), *((Vector64<ulong>*)b + i)); 
        }
        [Benchmark]
        public void Simd64LessThanOrEqual_ulong()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<ulong>*)c + i) = Simd64.LessThanOrEqual(*((Vector64<ulong>*)a + i), *((Vector64<ulong>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Add_ulong()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<ulong>*)c + i) = Simd64.Add(*((Vector64<ulong>*)a + i), *((Vector64<ulong>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Subtract_ulong()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<ulong>*)c + i) = Simd64.Subtract(*((Vector64<ulong>*)a + i), *((Vector64<ulong>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Multiply_ulong()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<ulong>*)c + i) = Simd64.Multiply(*((Vector64<ulong>*)a + i), *((Vector64<ulong>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Divide_ulong()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<ulong>*)c + i) = Simd64.Divide(*((Vector64<ulong>*)a + i), *((Vector64<ulong>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Min_ulong()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<ulong>*)c + i) = Simd64.Min(*((Vector64<ulong>*)a + i), *((Vector64<ulong>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Max_ulong()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<ulong>*)c + i) = Simd64.Max(*((Vector64<ulong>*)a + i), *((Vector64<ulong>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Equal_ulong()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<ulong>*)c + i) = Simd64.Equal(*((Vector64<ulong>*)a + i), *((Vector64<ulong>*)b + i)); 
        }
        [Benchmark]
        public void Simd64NotEqual_ulong()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<ulong>*)c + i) = Simd64.NotEqual(*((Vector64<ulong>*)a + i), *((Vector64<ulong>*)b + i)); 
        }
        [Benchmark]
        public void Simd64And_ulong()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<ulong>*)c + i) = Simd64.And(*((Vector64<ulong>*)a + i), *((Vector64<ulong>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Xor_ulong()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<ulong>*)c + i) = Simd64.Xor(*((Vector64<ulong>*)a + i), *((Vector64<ulong>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Or_ulong()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<ulong>*)c + i) = Simd64.Or(*((Vector64<ulong>*)a + i), *((Vector64<ulong>*)b + i)); 
        }

#endregion

#region Vector -> Vector 64-bit ulong

        [Benchmark]
        public void Simd64Not_ulong()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<ulong>*)c + i) = Simd64.Not(*((Vector64<ulong>*)a + i)); 
        }
        [Benchmark]
        public void Simd64Abs_ulong()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<ulong>*)c + i) = Simd64.Abs(*((Vector64<ulong>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsFinite_ulong()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<ulong>*)c + i) = Simd64.IsFinite(*((Vector64<ulong>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsInfinity_ulong()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<ulong>*)c + i) = Simd64.IsInfinity(*((Vector64<ulong>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsNaN_ulong()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<ulong>*)c + i) = Simd64.IsNaN(*((Vector64<ulong>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsNegative_ulong()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<ulong>*)c + i) = Simd64.IsNegative(*((Vector64<ulong>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsNegativeInfinity_ulong()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<ulong>*)c + i) = Simd64.IsNegativeInfinity(*((Vector64<ulong>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsNormal_ulong()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<ulong>*)c + i) = Simd64.IsNormal(*((Vector64<ulong>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsPositiveInfinity_ulong()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<ulong>*)c + i) = Simd64.IsPositiveInfinity(*((Vector64<ulong>*)a + i)); 
        }
        [Benchmark]
        public void Simd64Sign_ulong()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<ulong>*)c + i) = Simd64.Sign(*((Vector64<ulong>*)a + i)); 
        }

#endregion


#region Vector x Vector -> Vector 128-bit ulong

        [Benchmark]
        public void Simd128GreaterThan_ulong()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<ulong>*)c + i) = Simd128.GreaterThan(*((Vector128<ulong>*)a + i), *((Vector128<ulong>*)b + i)); 
        }
        [Benchmark]
        public void Simd128LessThan_ulong()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<ulong>*)c + i) = Simd128.LessThan(*((Vector128<ulong>*)a + i), *((Vector128<ulong>*)b + i)); 
        }
        [Benchmark]
        public void Simd128GreaterThanOrEqual_ulong()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<ulong>*)c + i) = Simd128.GreaterThanOrEqual(*((Vector128<ulong>*)a + i), *((Vector128<ulong>*)b + i)); 
        }
        [Benchmark]
        public void Simd128LessThanOrEqual_ulong()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<ulong>*)c + i) = Simd128.LessThanOrEqual(*((Vector128<ulong>*)a + i), *((Vector128<ulong>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Add_ulong()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<ulong>*)c + i) = Simd128.Add(*((Vector128<ulong>*)a + i), *((Vector128<ulong>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Subtract_ulong()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<ulong>*)c + i) = Simd128.Subtract(*((Vector128<ulong>*)a + i), *((Vector128<ulong>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Multiply_ulong()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<ulong>*)c + i) = Simd128.Multiply(*((Vector128<ulong>*)a + i), *((Vector128<ulong>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Divide_ulong()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<ulong>*)c + i) = Simd128.Divide(*((Vector128<ulong>*)a + i), *((Vector128<ulong>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Min_ulong()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<ulong>*)c + i) = Simd128.Min(*((Vector128<ulong>*)a + i), *((Vector128<ulong>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Max_ulong()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<ulong>*)c + i) = Simd128.Max(*((Vector128<ulong>*)a + i), *((Vector128<ulong>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Equal_ulong()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<ulong>*)c + i) = Simd128.Equal(*((Vector128<ulong>*)a + i), *((Vector128<ulong>*)b + i)); 
        }
        [Benchmark]
        public void Simd128NotEqual_ulong()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<ulong>*)c + i) = Simd128.NotEqual(*((Vector128<ulong>*)a + i), *((Vector128<ulong>*)b + i)); 
        }
        [Benchmark]
        public void Simd128And_ulong()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<ulong>*)c + i) = Simd128.And(*((Vector128<ulong>*)a + i), *((Vector128<ulong>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Xor_ulong()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<ulong>*)c + i) = Simd128.Xor(*((Vector128<ulong>*)a + i), *((Vector128<ulong>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Or_ulong()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<ulong>*)c + i) = Simd128.Or(*((Vector128<ulong>*)a + i), *((Vector128<ulong>*)b + i)); 
        }

#endregion

#region Vector -> Vector 128-bit ulong

        [Benchmark]
        public void Simd128Not_ulong()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<ulong>*)c + i) = Simd128.Not(*((Vector128<ulong>*)a + i)); 
        }
        [Benchmark]
        public void Simd128Abs_ulong()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<ulong>*)c + i) = Simd128.Abs(*((Vector128<ulong>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsFinite_ulong()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<ulong>*)c + i) = Simd128.IsFinite(*((Vector128<ulong>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsInfinity_ulong()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<ulong>*)c + i) = Simd128.IsInfinity(*((Vector128<ulong>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsNaN_ulong()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<ulong>*)c + i) = Simd128.IsNaN(*((Vector128<ulong>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsNegative_ulong()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<ulong>*)c + i) = Simd128.IsNegative(*((Vector128<ulong>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsNegativeInfinity_ulong()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<ulong>*)c + i) = Simd128.IsNegativeInfinity(*((Vector128<ulong>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsNormal_ulong()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<ulong>*)c + i) = Simd128.IsNormal(*((Vector128<ulong>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsPositiveInfinity_ulong()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<ulong>*)c + i) = Simd128.IsPositiveInfinity(*((Vector128<ulong>*)a + i)); 
        }
        [Benchmark]
        public void Simd128Sign_ulong()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<ulong>*)c + i) = Simd128.Sign(*((Vector128<ulong>*)a + i)); 
        }

#endregion


#region Vector x Vector -> Vector 256-bit ulong

        [Benchmark]
        public void Simd256GreaterThan_ulong()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<ulong>*)c + i) = Simd256.GreaterThan(*((Vector256<ulong>*)a + i), *((Vector256<ulong>*)b + i)); 
        }
        [Benchmark]
        public void Simd256LessThan_ulong()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<ulong>*)c + i) = Simd256.LessThan(*((Vector256<ulong>*)a + i), *((Vector256<ulong>*)b + i)); 
        }
        [Benchmark]
        public void Simd256GreaterThanOrEqual_ulong()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<ulong>*)c + i) = Simd256.GreaterThanOrEqual(*((Vector256<ulong>*)a + i), *((Vector256<ulong>*)b + i)); 
        }
        [Benchmark]
        public void Simd256LessThanOrEqual_ulong()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<ulong>*)c + i) = Simd256.LessThanOrEqual(*((Vector256<ulong>*)a + i), *((Vector256<ulong>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Add_ulong()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<ulong>*)c + i) = Simd256.Add(*((Vector256<ulong>*)a + i), *((Vector256<ulong>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Subtract_ulong()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<ulong>*)c + i) = Simd256.Subtract(*((Vector256<ulong>*)a + i), *((Vector256<ulong>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Multiply_ulong()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<ulong>*)c + i) = Simd256.Multiply(*((Vector256<ulong>*)a + i), *((Vector256<ulong>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Divide_ulong()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<ulong>*)c + i) = Simd256.Divide(*((Vector256<ulong>*)a + i), *((Vector256<ulong>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Min_ulong()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<ulong>*)c + i) = Simd256.Min(*((Vector256<ulong>*)a + i), *((Vector256<ulong>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Max_ulong()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<ulong>*)c + i) = Simd256.Max(*((Vector256<ulong>*)a + i), *((Vector256<ulong>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Equal_ulong()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<ulong>*)c + i) = Simd256.Equal(*((Vector256<ulong>*)a + i), *((Vector256<ulong>*)b + i)); 
        }
        [Benchmark]
        public void Simd256NotEqual_ulong()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<ulong>*)c + i) = Simd256.NotEqual(*((Vector256<ulong>*)a + i), *((Vector256<ulong>*)b + i)); 
        }
        [Benchmark]
        public void Simd256And_ulong()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<ulong>*)c + i) = Simd256.And(*((Vector256<ulong>*)a + i), *((Vector256<ulong>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Xor_ulong()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<ulong>*)c + i) = Simd256.Xor(*((Vector256<ulong>*)a + i), *((Vector256<ulong>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Or_ulong()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<ulong>*)c + i) = Simd256.Or(*((Vector256<ulong>*)a + i), *((Vector256<ulong>*)b + i)); 
        }

#endregion

#region Vector -> Vector 256-bit ulong

        [Benchmark]
        public void Simd256Not_ulong()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<ulong>*)c + i) = Simd256.Not(*((Vector256<ulong>*)a + i)); 
        }
        [Benchmark]
        public void Simd256Abs_ulong()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<ulong>*)c + i) = Simd256.Abs(*((Vector256<ulong>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsFinite_ulong()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<ulong>*)c + i) = Simd256.IsFinite(*((Vector256<ulong>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsInfinity_ulong()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<ulong>*)c + i) = Simd256.IsInfinity(*((Vector256<ulong>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsNaN_ulong()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<ulong>*)c + i) = Simd256.IsNaN(*((Vector256<ulong>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsNegative_ulong()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<ulong>*)c + i) = Simd256.IsNegative(*((Vector256<ulong>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsNegativeInfinity_ulong()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<ulong>*)c + i) = Simd256.IsNegativeInfinity(*((Vector256<ulong>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsNormal_ulong()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<ulong>*)c + i) = Simd256.IsNormal(*((Vector256<ulong>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsPositiveInfinity_ulong()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<ulong>*)c + i) = Simd256.IsPositiveInfinity(*((Vector256<ulong>*)a + i)); 
        }
        [Benchmark]
        public void Simd256Sign_ulong()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<ulong>*)c + i) = Simd256.Sign(*((Vector256<ulong>*)a + i)); 
        }

#endregion


#region Vector x Vector -> Vector 64-bit long

        [Benchmark]
        public void Simd64GreaterThan_long()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<long>*)c + i) = Simd64.GreaterThan(*((Vector64<long>*)a + i), *((Vector64<long>*)b + i)); 
        }
        [Benchmark]
        public void Simd64LessThan_long()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<long>*)c + i) = Simd64.LessThan(*((Vector64<long>*)a + i), *((Vector64<long>*)b + i)); 
        }
        [Benchmark]
        public void Simd64GreaterThanOrEqual_long()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<long>*)c + i) = Simd64.GreaterThanOrEqual(*((Vector64<long>*)a + i), *((Vector64<long>*)b + i)); 
        }
        [Benchmark]
        public void Simd64LessThanOrEqual_long()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<long>*)c + i) = Simd64.LessThanOrEqual(*((Vector64<long>*)a + i), *((Vector64<long>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Add_long()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<long>*)c + i) = Simd64.Add(*((Vector64<long>*)a + i), *((Vector64<long>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Subtract_long()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<long>*)c + i) = Simd64.Subtract(*((Vector64<long>*)a + i), *((Vector64<long>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Multiply_long()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<long>*)c + i) = Simd64.Multiply(*((Vector64<long>*)a + i), *((Vector64<long>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Divide_long()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<long>*)c + i) = Simd64.Divide(*((Vector64<long>*)a + i), *((Vector64<long>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Min_long()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<long>*)c + i) = Simd64.Min(*((Vector64<long>*)a + i), *((Vector64<long>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Max_long()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<long>*)c + i) = Simd64.Max(*((Vector64<long>*)a + i), *((Vector64<long>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Equal_long()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<long>*)c + i) = Simd64.Equal(*((Vector64<long>*)a + i), *((Vector64<long>*)b + i)); 
        }
        [Benchmark]
        public void Simd64NotEqual_long()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<long>*)c + i) = Simd64.NotEqual(*((Vector64<long>*)a + i), *((Vector64<long>*)b + i)); 
        }
        [Benchmark]
        public void Simd64And_long()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<long>*)c + i) = Simd64.And(*((Vector64<long>*)a + i), *((Vector64<long>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Xor_long()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<long>*)c + i) = Simd64.Xor(*((Vector64<long>*)a + i), *((Vector64<long>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Or_long()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<long>*)c + i) = Simd64.Or(*((Vector64<long>*)a + i), *((Vector64<long>*)b + i)); 
        }

#endregion

#region Vector -> Vector 64-bit long

        [Benchmark]
        public void Simd64Not_long()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<long>*)c + i) = Simd64.Not(*((Vector64<long>*)a + i)); 
        }
        [Benchmark]
        public void Simd64Abs_long()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<long>*)c + i) = Simd64.Abs(*((Vector64<long>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsFinite_long()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<long>*)c + i) = Simd64.IsFinite(*((Vector64<long>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsInfinity_long()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<long>*)c + i) = Simd64.IsInfinity(*((Vector64<long>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsNaN_long()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<long>*)c + i) = Simd64.IsNaN(*((Vector64<long>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsNegative_long()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<long>*)c + i) = Simd64.IsNegative(*((Vector64<long>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsNegativeInfinity_long()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<long>*)c + i) = Simd64.IsNegativeInfinity(*((Vector64<long>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsNormal_long()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<long>*)c + i) = Simd64.IsNormal(*((Vector64<long>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsPositiveInfinity_long()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<long>*)c + i) = Simd64.IsPositiveInfinity(*((Vector64<long>*)a + i)); 
        }
        [Benchmark]
        public void Simd64Sign_long()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<long>*)c + i) = Simd64.Sign(*((Vector64<long>*)a + i)); 
        }

#endregion


#region Vector x Vector -> Vector 128-bit long

        [Benchmark]
        public void Simd128GreaterThan_long()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<long>*)c + i) = Simd128.GreaterThan(*((Vector128<long>*)a + i), *((Vector128<long>*)b + i)); 
        }
        [Benchmark]
        public void Simd128LessThan_long()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<long>*)c + i) = Simd128.LessThan(*((Vector128<long>*)a + i), *((Vector128<long>*)b + i)); 
        }
        [Benchmark]
        public void Simd128GreaterThanOrEqual_long()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<long>*)c + i) = Simd128.GreaterThanOrEqual(*((Vector128<long>*)a + i), *((Vector128<long>*)b + i)); 
        }
        [Benchmark]
        public void Simd128LessThanOrEqual_long()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<long>*)c + i) = Simd128.LessThanOrEqual(*((Vector128<long>*)a + i), *((Vector128<long>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Add_long()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<long>*)c + i) = Simd128.Add(*((Vector128<long>*)a + i), *((Vector128<long>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Subtract_long()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<long>*)c + i) = Simd128.Subtract(*((Vector128<long>*)a + i), *((Vector128<long>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Multiply_long()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<long>*)c + i) = Simd128.Multiply(*((Vector128<long>*)a + i), *((Vector128<long>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Divide_long()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<long>*)c + i) = Simd128.Divide(*((Vector128<long>*)a + i), *((Vector128<long>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Min_long()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<long>*)c + i) = Simd128.Min(*((Vector128<long>*)a + i), *((Vector128<long>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Max_long()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<long>*)c + i) = Simd128.Max(*((Vector128<long>*)a + i), *((Vector128<long>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Equal_long()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<long>*)c + i) = Simd128.Equal(*((Vector128<long>*)a + i), *((Vector128<long>*)b + i)); 
        }
        [Benchmark]
        public void Simd128NotEqual_long()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<long>*)c + i) = Simd128.NotEqual(*((Vector128<long>*)a + i), *((Vector128<long>*)b + i)); 
        }
        [Benchmark]
        public void Simd128And_long()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<long>*)c + i) = Simd128.And(*((Vector128<long>*)a + i), *((Vector128<long>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Xor_long()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<long>*)c + i) = Simd128.Xor(*((Vector128<long>*)a + i), *((Vector128<long>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Or_long()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<long>*)c + i) = Simd128.Or(*((Vector128<long>*)a + i), *((Vector128<long>*)b + i)); 
        }

#endregion

#region Vector -> Vector 128-bit long

        [Benchmark]
        public void Simd128Not_long()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<long>*)c + i) = Simd128.Not(*((Vector128<long>*)a + i)); 
        }
        [Benchmark]
        public void Simd128Abs_long()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<long>*)c + i) = Simd128.Abs(*((Vector128<long>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsFinite_long()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<long>*)c + i) = Simd128.IsFinite(*((Vector128<long>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsInfinity_long()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<long>*)c + i) = Simd128.IsInfinity(*((Vector128<long>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsNaN_long()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<long>*)c + i) = Simd128.IsNaN(*((Vector128<long>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsNegative_long()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<long>*)c + i) = Simd128.IsNegative(*((Vector128<long>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsNegativeInfinity_long()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<long>*)c + i) = Simd128.IsNegativeInfinity(*((Vector128<long>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsNormal_long()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<long>*)c + i) = Simd128.IsNormal(*((Vector128<long>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsPositiveInfinity_long()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<long>*)c + i) = Simd128.IsPositiveInfinity(*((Vector128<long>*)a + i)); 
        }
        [Benchmark]
        public void Simd128Sign_long()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<long>*)c + i) = Simd128.Sign(*((Vector128<long>*)a + i)); 
        }

#endregion


#region Vector x Vector -> Vector 256-bit long

        [Benchmark]
        public void Simd256GreaterThan_long()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<long>*)c + i) = Simd256.GreaterThan(*((Vector256<long>*)a + i), *((Vector256<long>*)b + i)); 
        }
        [Benchmark]
        public void Simd256LessThan_long()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<long>*)c + i) = Simd256.LessThan(*((Vector256<long>*)a + i), *((Vector256<long>*)b + i)); 
        }
        [Benchmark]
        public void Simd256GreaterThanOrEqual_long()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<long>*)c + i) = Simd256.GreaterThanOrEqual(*((Vector256<long>*)a + i), *((Vector256<long>*)b + i)); 
        }
        [Benchmark]
        public void Simd256LessThanOrEqual_long()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<long>*)c + i) = Simd256.LessThanOrEqual(*((Vector256<long>*)a + i), *((Vector256<long>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Add_long()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<long>*)c + i) = Simd256.Add(*((Vector256<long>*)a + i), *((Vector256<long>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Subtract_long()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<long>*)c + i) = Simd256.Subtract(*((Vector256<long>*)a + i), *((Vector256<long>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Multiply_long()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<long>*)c + i) = Simd256.Multiply(*((Vector256<long>*)a + i), *((Vector256<long>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Divide_long()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<long>*)c + i) = Simd256.Divide(*((Vector256<long>*)a + i), *((Vector256<long>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Min_long()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<long>*)c + i) = Simd256.Min(*((Vector256<long>*)a + i), *((Vector256<long>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Max_long()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<long>*)c + i) = Simd256.Max(*((Vector256<long>*)a + i), *((Vector256<long>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Equal_long()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<long>*)c + i) = Simd256.Equal(*((Vector256<long>*)a + i), *((Vector256<long>*)b + i)); 
        }
        [Benchmark]
        public void Simd256NotEqual_long()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<long>*)c + i) = Simd256.NotEqual(*((Vector256<long>*)a + i), *((Vector256<long>*)b + i)); 
        }
        [Benchmark]
        public void Simd256And_long()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<long>*)c + i) = Simd256.And(*((Vector256<long>*)a + i), *((Vector256<long>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Xor_long()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<long>*)c + i) = Simd256.Xor(*((Vector256<long>*)a + i), *((Vector256<long>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Or_long()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<long>*)c + i) = Simd256.Or(*((Vector256<long>*)a + i), *((Vector256<long>*)b + i)); 
        }

#endregion

#region Vector -> Vector 256-bit long

        [Benchmark]
        public void Simd256Not_long()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<long>*)c + i) = Simd256.Not(*((Vector256<long>*)a + i)); 
        }
        [Benchmark]
        public void Simd256Abs_long()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<long>*)c + i) = Simd256.Abs(*((Vector256<long>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsFinite_long()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<long>*)c + i) = Simd256.IsFinite(*((Vector256<long>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsInfinity_long()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<long>*)c + i) = Simd256.IsInfinity(*((Vector256<long>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsNaN_long()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<long>*)c + i) = Simd256.IsNaN(*((Vector256<long>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsNegative_long()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<long>*)c + i) = Simd256.IsNegative(*((Vector256<long>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsNegativeInfinity_long()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<long>*)c + i) = Simd256.IsNegativeInfinity(*((Vector256<long>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsNormal_long()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<long>*)c + i) = Simd256.IsNormal(*((Vector256<long>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsPositiveInfinity_long()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<long>*)c + i) = Simd256.IsPositiveInfinity(*((Vector256<long>*)a + i)); 
        }
        [Benchmark]
        public void Simd256Sign_long()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<long>*)c + i) = Simd256.Sign(*((Vector256<long>*)a + i)); 
        }

#endregion


#region Vector x Vector -> Vector 64-bit float

        [Benchmark]
        public void Simd64GreaterThan_float()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<float>*)c + i) = Simd64.GreaterThan(*((Vector64<float>*)a + i), *((Vector64<float>*)b + i)); 
        }
        [Benchmark]
        public void Simd64LessThan_float()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<float>*)c + i) = Simd64.LessThan(*((Vector64<float>*)a + i), *((Vector64<float>*)b + i)); 
        }
        [Benchmark]
        public void Simd64GreaterThanOrEqual_float()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<float>*)c + i) = Simd64.GreaterThanOrEqual(*((Vector64<float>*)a + i), *((Vector64<float>*)b + i)); 
        }
        [Benchmark]
        public void Simd64LessThanOrEqual_float()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<float>*)c + i) = Simd64.LessThanOrEqual(*((Vector64<float>*)a + i), *((Vector64<float>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Add_float()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<float>*)c + i) = Simd64.Add(*((Vector64<float>*)a + i), *((Vector64<float>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Subtract_float()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<float>*)c + i) = Simd64.Subtract(*((Vector64<float>*)a + i), *((Vector64<float>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Multiply_float()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<float>*)c + i) = Simd64.Multiply(*((Vector64<float>*)a + i), *((Vector64<float>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Divide_float()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<float>*)c + i) = Simd64.Divide(*((Vector64<float>*)a + i), *((Vector64<float>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Min_float()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<float>*)c + i) = Simd64.Min(*((Vector64<float>*)a + i), *((Vector64<float>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Max_float()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<float>*)c + i) = Simd64.Max(*((Vector64<float>*)a + i), *((Vector64<float>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Equal_float()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<float>*)c + i) = Simd64.Equal(*((Vector64<float>*)a + i), *((Vector64<float>*)b + i)); 
        }
        [Benchmark]
        public void Simd64NotEqual_float()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<float>*)c + i) = Simd64.NotEqual(*((Vector64<float>*)a + i), *((Vector64<float>*)b + i)); 
        }
        [Benchmark]
        public void Simd64And_float()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<float>*)c + i) = Simd64.And(*((Vector64<float>*)a + i), *((Vector64<float>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Xor_float()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<float>*)c + i) = Simd64.Xor(*((Vector64<float>*)a + i), *((Vector64<float>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Or_float()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<float>*)c + i) = Simd64.Or(*((Vector64<float>*)a + i), *((Vector64<float>*)b + i)); 
        }

#endregion

#region Vector -> Vector 64-bit float

        [Benchmark]
        public void Simd64Not_float()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<float>*)c + i) = Simd64.Not(*((Vector64<float>*)a + i)); 
        }
        [Benchmark]
        public void Simd64Abs_float()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<float>*)c + i) = Simd64.Abs(*((Vector64<float>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsFinite_float()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<float>*)c + i) = Simd64.IsFinite(*((Vector64<float>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsInfinity_float()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<float>*)c + i) = Simd64.IsInfinity(*((Vector64<float>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsNaN_float()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<float>*)c + i) = Simd64.IsNaN(*((Vector64<float>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsNegative_float()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<float>*)c + i) = Simd64.IsNegative(*((Vector64<float>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsNegativeInfinity_float()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<float>*)c + i) = Simd64.IsNegativeInfinity(*((Vector64<float>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsNormal_float()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<float>*)c + i) = Simd64.IsNormal(*((Vector64<float>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsPositiveInfinity_float()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<float>*)c + i) = Simd64.IsPositiveInfinity(*((Vector64<float>*)a + i)); 
        }
        [Benchmark]
        public void Simd64Sign_float()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<float>*)c + i) = Simd64.Sign(*((Vector64<float>*)a + i)); 
        }

#endregion


#region Vector x Vector -> Vector 128-bit float

        [Benchmark]
        public void Simd128GreaterThan_float()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<float>*)c + i) = Simd128.GreaterThan(*((Vector128<float>*)a + i), *((Vector128<float>*)b + i)); 
        }
        [Benchmark]
        public void Simd128LessThan_float()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<float>*)c + i) = Simd128.LessThan(*((Vector128<float>*)a + i), *((Vector128<float>*)b + i)); 
        }
        [Benchmark]
        public void Simd128GreaterThanOrEqual_float()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<float>*)c + i) = Simd128.GreaterThanOrEqual(*((Vector128<float>*)a + i), *((Vector128<float>*)b + i)); 
        }
        [Benchmark]
        public void Simd128LessThanOrEqual_float()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<float>*)c + i) = Simd128.LessThanOrEqual(*((Vector128<float>*)a + i), *((Vector128<float>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Add_float()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<float>*)c + i) = Simd128.Add(*((Vector128<float>*)a + i), *((Vector128<float>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Subtract_float()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<float>*)c + i) = Simd128.Subtract(*((Vector128<float>*)a + i), *((Vector128<float>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Multiply_float()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<float>*)c + i) = Simd128.Multiply(*((Vector128<float>*)a + i), *((Vector128<float>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Divide_float()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<float>*)c + i) = Simd128.Divide(*((Vector128<float>*)a + i), *((Vector128<float>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Min_float()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<float>*)c + i) = Simd128.Min(*((Vector128<float>*)a + i), *((Vector128<float>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Max_float()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<float>*)c + i) = Simd128.Max(*((Vector128<float>*)a + i), *((Vector128<float>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Equal_float()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<float>*)c + i) = Simd128.Equal(*((Vector128<float>*)a + i), *((Vector128<float>*)b + i)); 
        }
        [Benchmark]
        public void Simd128NotEqual_float()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<float>*)c + i) = Simd128.NotEqual(*((Vector128<float>*)a + i), *((Vector128<float>*)b + i)); 
        }
        [Benchmark]
        public void Simd128And_float()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<float>*)c + i) = Simd128.And(*((Vector128<float>*)a + i), *((Vector128<float>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Xor_float()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<float>*)c + i) = Simd128.Xor(*((Vector128<float>*)a + i), *((Vector128<float>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Or_float()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<float>*)c + i) = Simd128.Or(*((Vector128<float>*)a + i), *((Vector128<float>*)b + i)); 
        }

#endregion

#region Vector -> Vector 128-bit float

        [Benchmark]
        public void Simd128Not_float()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<float>*)c + i) = Simd128.Not(*((Vector128<float>*)a + i)); 
        }
        [Benchmark]
        public void Simd128Abs_float()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<float>*)c + i) = Simd128.Abs(*((Vector128<float>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsFinite_float()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<float>*)c + i) = Simd128.IsFinite(*((Vector128<float>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsInfinity_float()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<float>*)c + i) = Simd128.IsInfinity(*((Vector128<float>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsNaN_float()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<float>*)c + i) = Simd128.IsNaN(*((Vector128<float>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsNegative_float()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<float>*)c + i) = Simd128.IsNegative(*((Vector128<float>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsNegativeInfinity_float()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<float>*)c + i) = Simd128.IsNegativeInfinity(*((Vector128<float>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsNormal_float()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<float>*)c + i) = Simd128.IsNormal(*((Vector128<float>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsPositiveInfinity_float()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<float>*)c + i) = Simd128.IsPositiveInfinity(*((Vector128<float>*)a + i)); 
        }
        [Benchmark]
        public void Simd128Sign_float()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<float>*)c + i) = Simd128.Sign(*((Vector128<float>*)a + i)); 
        }

#endregion


#region Vector x Vector -> Vector 256-bit float

        [Benchmark]
        public void Simd256GreaterThan_float()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<float>*)c + i) = Simd256.GreaterThan(*((Vector256<float>*)a + i), *((Vector256<float>*)b + i)); 
        }
        [Benchmark]
        public void Simd256LessThan_float()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<float>*)c + i) = Simd256.LessThan(*((Vector256<float>*)a + i), *((Vector256<float>*)b + i)); 
        }
        [Benchmark]
        public void Simd256GreaterThanOrEqual_float()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<float>*)c + i) = Simd256.GreaterThanOrEqual(*((Vector256<float>*)a + i), *((Vector256<float>*)b + i)); 
        }
        [Benchmark]
        public void Simd256LessThanOrEqual_float()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<float>*)c + i) = Simd256.LessThanOrEqual(*((Vector256<float>*)a + i), *((Vector256<float>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Add_float()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<float>*)c + i) = Simd256.Add(*((Vector256<float>*)a + i), *((Vector256<float>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Subtract_float()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<float>*)c + i) = Simd256.Subtract(*((Vector256<float>*)a + i), *((Vector256<float>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Multiply_float()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<float>*)c + i) = Simd256.Multiply(*((Vector256<float>*)a + i), *((Vector256<float>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Divide_float()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<float>*)c + i) = Simd256.Divide(*((Vector256<float>*)a + i), *((Vector256<float>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Min_float()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<float>*)c + i) = Simd256.Min(*((Vector256<float>*)a + i), *((Vector256<float>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Max_float()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<float>*)c + i) = Simd256.Max(*((Vector256<float>*)a + i), *((Vector256<float>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Equal_float()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<float>*)c + i) = Simd256.Equal(*((Vector256<float>*)a + i), *((Vector256<float>*)b + i)); 
        }
        [Benchmark]
        public void Simd256NotEqual_float()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<float>*)c + i) = Simd256.NotEqual(*((Vector256<float>*)a + i), *((Vector256<float>*)b + i)); 
        }
        [Benchmark]
        public void Simd256And_float()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<float>*)c + i) = Simd256.And(*((Vector256<float>*)a + i), *((Vector256<float>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Xor_float()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<float>*)c + i) = Simd256.Xor(*((Vector256<float>*)a + i), *((Vector256<float>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Or_float()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<float>*)c + i) = Simd256.Or(*((Vector256<float>*)a + i), *((Vector256<float>*)b + i)); 
        }

#endregion

#region Vector -> Vector 256-bit float

        [Benchmark]
        public void Simd256Not_float()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<float>*)c + i) = Simd256.Not(*((Vector256<float>*)a + i)); 
        }
        [Benchmark]
        public void Simd256Abs_float()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<float>*)c + i) = Simd256.Abs(*((Vector256<float>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsFinite_float()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<float>*)c + i) = Simd256.IsFinite(*((Vector256<float>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsInfinity_float()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<float>*)c + i) = Simd256.IsInfinity(*((Vector256<float>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsNaN_float()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<float>*)c + i) = Simd256.IsNaN(*((Vector256<float>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsNegative_float()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<float>*)c + i) = Simd256.IsNegative(*((Vector256<float>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsNegativeInfinity_float()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<float>*)c + i) = Simd256.IsNegativeInfinity(*((Vector256<float>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsNormal_float()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<float>*)c + i) = Simd256.IsNormal(*((Vector256<float>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsPositiveInfinity_float()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<float>*)c + i) = Simd256.IsPositiveInfinity(*((Vector256<float>*)a + i)); 
        }
        [Benchmark]
        public void Simd256Sign_float()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<float>*)c + i) = Simd256.Sign(*((Vector256<float>*)a + i)); 
        }

#endregion


#region Vector x Vector -> Vector 64-bit double

        [Benchmark]
        public void Simd64GreaterThan_double()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<double>*)c + i) = Simd64.GreaterThan(*((Vector64<double>*)a + i), *((Vector64<double>*)b + i)); 
        }
        [Benchmark]
        public void Simd64LessThan_double()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<double>*)c + i) = Simd64.LessThan(*((Vector64<double>*)a + i), *((Vector64<double>*)b + i)); 
        }
        [Benchmark]
        public void Simd64GreaterThanOrEqual_double()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<double>*)c + i) = Simd64.GreaterThanOrEqual(*((Vector64<double>*)a + i), *((Vector64<double>*)b + i)); 
        }
        [Benchmark]
        public void Simd64LessThanOrEqual_double()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<double>*)c + i) = Simd64.LessThanOrEqual(*((Vector64<double>*)a + i), *((Vector64<double>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Add_double()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<double>*)c + i) = Simd64.Add(*((Vector64<double>*)a + i), *((Vector64<double>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Subtract_double()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<double>*)c + i) = Simd64.Subtract(*((Vector64<double>*)a + i), *((Vector64<double>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Multiply_double()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<double>*)c + i) = Simd64.Multiply(*((Vector64<double>*)a + i), *((Vector64<double>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Divide_double()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<double>*)c + i) = Simd64.Divide(*((Vector64<double>*)a + i), *((Vector64<double>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Min_double()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<double>*)c + i) = Simd64.Min(*((Vector64<double>*)a + i), *((Vector64<double>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Max_double()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<double>*)c + i) = Simd64.Max(*((Vector64<double>*)a + i), *((Vector64<double>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Equal_double()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<double>*)c + i) = Simd64.Equal(*((Vector64<double>*)a + i), *((Vector64<double>*)b + i)); 
        }
        [Benchmark]
        public void Simd64NotEqual_double()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<double>*)c + i) = Simd64.NotEqual(*((Vector64<double>*)a + i), *((Vector64<double>*)b + i)); 
        }
        [Benchmark]
        public void Simd64And_double()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<double>*)c + i) = Simd64.And(*((Vector64<double>*)a + i), *((Vector64<double>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Xor_double()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<double>*)c + i) = Simd64.Xor(*((Vector64<double>*)a + i), *((Vector64<double>*)b + i)); 
        }
        [Benchmark]
        public void Simd64Or_double()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<double>*)c + i) = Simd64.Or(*((Vector64<double>*)a + i), *((Vector64<double>*)b + i)); 
        }

#endregion

#region Vector -> Vector 64-bit double

        [Benchmark]
        public void Simd64Not_double()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<double>*)c + i) = Simd64.Not(*((Vector64<double>*)a + i)); 
        }
        [Benchmark]
        public void Simd64Abs_double()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<double>*)c + i) = Simd64.Abs(*((Vector64<double>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsFinite_double()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<double>*)c + i) = Simd64.IsFinite(*((Vector64<double>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsInfinity_double()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<double>*)c + i) = Simd64.IsInfinity(*((Vector64<double>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsNaN_double()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<double>*)c + i) = Simd64.IsNaN(*((Vector64<double>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsNegative_double()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<double>*)c + i) = Simd64.IsNegative(*((Vector64<double>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsNegativeInfinity_double()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<double>*)c + i) = Simd64.IsNegativeInfinity(*((Vector64<double>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsNormal_double()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<double>*)c + i) = Simd64.IsNormal(*((Vector64<double>*)a + i)); 
        }
        [Benchmark]
        public void Simd64IsPositiveInfinity_double()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<double>*)c + i) = Simd64.IsPositiveInfinity(*((Vector64<double>*)a + i)); 
        }
        [Benchmark]
        public void Simd64Sign_double()
        {
            for (int i = 0; i < IterCount * (4); i++)
                *((Vector64<double>*)c + i) = Simd64.Sign(*((Vector64<double>*)a + i)); 
        }

#endregion


#region Vector x Vector -> Vector 128-bit double

        [Benchmark]
        public void Simd128GreaterThan_double()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<double>*)c + i) = Simd128.GreaterThan(*((Vector128<double>*)a + i), *((Vector128<double>*)b + i)); 
        }
        [Benchmark]
        public void Simd128LessThan_double()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<double>*)c + i) = Simd128.LessThan(*((Vector128<double>*)a + i), *((Vector128<double>*)b + i)); 
        }
        [Benchmark]
        public void Simd128GreaterThanOrEqual_double()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<double>*)c + i) = Simd128.GreaterThanOrEqual(*((Vector128<double>*)a + i), *((Vector128<double>*)b + i)); 
        }
        [Benchmark]
        public void Simd128LessThanOrEqual_double()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<double>*)c + i) = Simd128.LessThanOrEqual(*((Vector128<double>*)a + i), *((Vector128<double>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Add_double()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<double>*)c + i) = Simd128.Add(*((Vector128<double>*)a + i), *((Vector128<double>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Subtract_double()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<double>*)c + i) = Simd128.Subtract(*((Vector128<double>*)a + i), *((Vector128<double>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Multiply_double()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<double>*)c + i) = Simd128.Multiply(*((Vector128<double>*)a + i), *((Vector128<double>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Divide_double()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<double>*)c + i) = Simd128.Divide(*((Vector128<double>*)a + i), *((Vector128<double>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Min_double()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<double>*)c + i) = Simd128.Min(*((Vector128<double>*)a + i), *((Vector128<double>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Max_double()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<double>*)c + i) = Simd128.Max(*((Vector128<double>*)a + i), *((Vector128<double>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Equal_double()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<double>*)c + i) = Simd128.Equal(*((Vector128<double>*)a + i), *((Vector128<double>*)b + i)); 
        }
        [Benchmark]
        public void Simd128NotEqual_double()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<double>*)c + i) = Simd128.NotEqual(*((Vector128<double>*)a + i), *((Vector128<double>*)b + i)); 
        }
        [Benchmark]
        public void Simd128And_double()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<double>*)c + i) = Simd128.And(*((Vector128<double>*)a + i), *((Vector128<double>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Xor_double()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<double>*)c + i) = Simd128.Xor(*((Vector128<double>*)a + i), *((Vector128<double>*)b + i)); 
        }
        [Benchmark]
        public void Simd128Or_double()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<double>*)c + i) = Simd128.Or(*((Vector128<double>*)a + i), *((Vector128<double>*)b + i)); 
        }

#endregion

#region Vector -> Vector 128-bit double

        [Benchmark]
        public void Simd128Not_double()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<double>*)c + i) = Simd128.Not(*((Vector128<double>*)a + i)); 
        }
        [Benchmark]
        public void Simd128Abs_double()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<double>*)c + i) = Simd128.Abs(*((Vector128<double>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsFinite_double()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<double>*)c + i) = Simd128.IsFinite(*((Vector128<double>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsInfinity_double()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<double>*)c + i) = Simd128.IsInfinity(*((Vector128<double>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsNaN_double()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<double>*)c + i) = Simd128.IsNaN(*((Vector128<double>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsNegative_double()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<double>*)c + i) = Simd128.IsNegative(*((Vector128<double>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsNegativeInfinity_double()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<double>*)c + i) = Simd128.IsNegativeInfinity(*((Vector128<double>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsNormal_double()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<double>*)c + i) = Simd128.IsNormal(*((Vector128<double>*)a + i)); 
        }
        [Benchmark]
        public void Simd128IsPositiveInfinity_double()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<double>*)c + i) = Simd128.IsPositiveInfinity(*((Vector128<double>*)a + i)); 
        }
        [Benchmark]
        public void Simd128Sign_double()
        {
            for (int i = 0; i < IterCount * (2); i++)
                *((Vector128<double>*)c + i) = Simd128.Sign(*((Vector128<double>*)a + i)); 
        }

#endregion


#region Vector x Vector -> Vector 256-bit double

        [Benchmark]
        public void Simd256GreaterThan_double()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<double>*)c + i) = Simd256.GreaterThan(*((Vector256<double>*)a + i), *((Vector256<double>*)b + i)); 
        }
        [Benchmark]
        public void Simd256LessThan_double()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<double>*)c + i) = Simd256.LessThan(*((Vector256<double>*)a + i), *((Vector256<double>*)b + i)); 
        }
        [Benchmark]
        public void Simd256GreaterThanOrEqual_double()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<double>*)c + i) = Simd256.GreaterThanOrEqual(*((Vector256<double>*)a + i), *((Vector256<double>*)b + i)); 
        }
        [Benchmark]
        public void Simd256LessThanOrEqual_double()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<double>*)c + i) = Simd256.LessThanOrEqual(*((Vector256<double>*)a + i), *((Vector256<double>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Add_double()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<double>*)c + i) = Simd256.Add(*((Vector256<double>*)a + i), *((Vector256<double>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Subtract_double()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<double>*)c + i) = Simd256.Subtract(*((Vector256<double>*)a + i), *((Vector256<double>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Multiply_double()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<double>*)c + i) = Simd256.Multiply(*((Vector256<double>*)a + i), *((Vector256<double>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Divide_double()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<double>*)c + i) = Simd256.Divide(*((Vector256<double>*)a + i), *((Vector256<double>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Min_double()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<double>*)c + i) = Simd256.Min(*((Vector256<double>*)a + i), *((Vector256<double>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Max_double()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<double>*)c + i) = Simd256.Max(*((Vector256<double>*)a + i), *((Vector256<double>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Equal_double()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<double>*)c + i) = Simd256.Equal(*((Vector256<double>*)a + i), *((Vector256<double>*)b + i)); 
        }
        [Benchmark]
        public void Simd256NotEqual_double()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<double>*)c + i) = Simd256.NotEqual(*((Vector256<double>*)a + i), *((Vector256<double>*)b + i)); 
        }
        [Benchmark]
        public void Simd256And_double()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<double>*)c + i) = Simd256.And(*((Vector256<double>*)a + i), *((Vector256<double>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Xor_double()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<double>*)c + i) = Simd256.Xor(*((Vector256<double>*)a + i), *((Vector256<double>*)b + i)); 
        }
        [Benchmark]
        public void Simd256Or_double()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<double>*)c + i) = Simd256.Or(*((Vector256<double>*)a + i), *((Vector256<double>*)b + i)); 
        }

#endregion

#region Vector -> Vector 256-bit double

        [Benchmark]
        public void Simd256Not_double()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<double>*)c + i) = Simd256.Not(*((Vector256<double>*)a + i)); 
        }
        [Benchmark]
        public void Simd256Abs_double()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<double>*)c + i) = Simd256.Abs(*((Vector256<double>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsFinite_double()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<double>*)c + i) = Simd256.IsFinite(*((Vector256<double>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsInfinity_double()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<double>*)c + i) = Simd256.IsInfinity(*((Vector256<double>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsNaN_double()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<double>*)c + i) = Simd256.IsNaN(*((Vector256<double>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsNegative_double()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<double>*)c + i) = Simd256.IsNegative(*((Vector256<double>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsNegativeInfinity_double()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<double>*)c + i) = Simd256.IsNegativeInfinity(*((Vector256<double>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsNormal_double()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<double>*)c + i) = Simd256.IsNormal(*((Vector256<double>*)a + i)); 
        }
        [Benchmark]
        public void Simd256IsPositiveInfinity_double()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<double>*)c + i) = Simd256.IsPositiveInfinity(*((Vector256<double>*)a + i)); 
        }
        [Benchmark]
        public void Simd256Sign_double()
        {
            for (int i = 0; i < IterCount * (1); i++)
                *((Vector256<double>*)c + i) = Simd256.Sign(*((Vector256<double>*)a + i)); 
        }

#endregion

    }
}
#endif