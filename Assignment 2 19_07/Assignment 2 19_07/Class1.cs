using System;[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]public class SimplexAttribute : Attribute{    public SimplexAttribute()    {
        Console.WriteLine("This is custom Attribute");
    }}