﻿using System.Text;

public class Fraction
{
    public Fraction(int numerator, int denominator)
    {
        this.numerator = numerator;
        this.denominator = denominator;
    }
    public override string ToString()
    {
        StringBuilder s = new StringBuilder();
        s.AppendFormat("{ 0}/{ 1}",numerator, denominator);
        return s.ToString();
    }
    internal class FractionArtist { }
    private int numerator;
    private int denominator;
}
internal class FractionArtist
{
    public void Draw(Fraction f)
    {
        Console.WriteLine("Drawing the numerator { 0}", f.numerator);
        Console.WriteLine("Drawing the denominator { 0}",f.denominator);
    }
}
public class Tester
{
    static void Main()
    {
        Fraction f1 = new Fraction(3, 4);
        Console.WriteLine("f1: { 0}", f1.ToString());
        Fraction.FractionArtist fa = new
        Fraction.FractionArtist();
        fa.Draw(f1);
    }
}