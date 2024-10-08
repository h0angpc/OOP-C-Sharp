﻿using System;
using System.Collections;
public class Person
{
    public Person(string fName, string lName)
    {
        this.firstName = fName;
        this.lastName = lName;
    }
    public string firstName;
    public string lastName;
}
public class People : IEnumerable
{
    private Person[] _people;
    public People(Person[] pArray)
    {
        _people = new Person[pArray.Length];
        for (int i = 0; i< pArray.Length; i++)
        {
            _people[i] = pArray[i];
        }
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return (IEnumerator)GetEnumerator();
    }
    public PeopleEnum GetEnumerator()
    {
        return new PeopleEnum(_people);
    }
}

public class PeopleEnum : IEnumerator
{
    public Person[] _people;
    int position = -1;
    public PeopleEnum(Person[] list)
    {
        _people = list;
    }
    public bool MoveNext()
    {
        position++;
        return (position < _people.Length);
    }
    public void Reset()
    {
        position = -1;
    }
    object IEnumerator.Current
    {
        get
        {
            return Current;
        }
    }
    public Person Current
    {
        get
        {
            try
            {
                return _people[position];
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
class Program
{
    static void Main()
    {
        Person[] peopleArray = new Person[3]
        {
            new Person("John", "Smith"),
            new Person("Jim", "Johnson"),
            new Person("Sue", "Rabon"),
        };
        People peopleList = new People(peopleArray);
        foreach (Person p in peopleList)
            Console.WriteLine(p.firstName + " " + p.lastName);
        PeopleEnum peopleEnum = peopleList.GetEnumerator();
        peopleEnum.Reset();
        peopleEnum.MoveNext();
        Person firstPerson = peopleEnum.Current;
        Console.WriteLine("First Person: {0} {1}", firstPerson.firstName, firstPerson.lastName);
    }
}