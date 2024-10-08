﻿using System;

delegate void FunctionToCall(ref int x);
class Delegate2
{
    public static void Add2(ref int x)
    {
        x += 2;
    }
    public static void Add3(ref int x)
    {
        x += 3;
    }
    static void Main(string[] args)
    {
        FunctionToCall functionDelegate = Add2;
        functionDelegate += Add3;
        functionDelegate += Add2;
        functionDelegate += Add2;
        int x = 5;
        functionDelegate(ref x);
        Console.WriteLine("Value: {0}", x);
        int y = 5;
        functionDelegate = Add2;
        functionDelegate += Add3;
        functionDelegate -= Add2;
        functionDelegate(ref y);
        Console.WriteLine("Value: {0}", y);
        Console.ReadLine();
    }
}