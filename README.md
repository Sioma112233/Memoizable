# Memoizable
Memoizable is .Net library that helps create [memoizable](https://en.wikipedia.org/wiki/Memoization) functions as easily as possible.

NuGet Package: https://www.nuget.org/packages/Memoizable/

## What is Memoization?
From [Wikipedia](https://en.wikipedia.org/wiki/Memoization):
>> In computing, memoization or memoisation is an optimization technique used primarily to speed up computer programs by storing the results of expensive function calls and returning the cached result when the same inputs occur again

or simply put, caching functions that have no side-effects.

## Why Use Memoizable?
having a generalized solution for all functions (including recursive functions) means that you can write your functions almost as if they were regular functions without any regard to caching which keeps your code clean and simple

# Quick Usage
basically you define a function that returns a `Memoizable<>` type like so:
``` csharp
static Memoizable<int, int> Fibonacci() => self => n => {
    if (n < 2)
        return 1;

    return self(n - 1) + self(n - 2);
};
```

and invoke it like this:
``` csharp
var memoizedFibo = Fibonacci().Memoized(); // returns a memoized version of the function
var normalFibo = Fibonacci().Normal(); // returns a basic version of the function

// invoking
memoizedFibo(1);
memoizedFibo(5);
memoizedFibo(7);

normalFibo(1);
normalFibo(5);
normalFibo(7);
```


# Explained Examples
## Iterating Fibonacci (recursive function)
Iterating a recursively implemented Fibonacci function is considered slow.
Such code will look like this:

``` csharp
using System;

class Program {
    static void Main() {
        for (int i = 0; i < 40; i++)
            Console.WriteLine(Fibonacci(i));
    }

    static int Fibonacci(int n) {
        if (n < 2)
            return 1;

        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }
}

```

This case can be hugely optimized if we were to memoize the Fibonacci function.
Using this library, the optimized code will look like this:

``` csharp
using System;
using Memoization;

class Program {
    static void Main() {
        var fibo = Fibonacci().Memoized();
        
        for (int i = 0; i < 40; i++)
            Console.WriteLine(fibo(i));
    }

    static Memoizable<int, int> Fibonacci() => self => n => {
        if (n < 2)
            return 1;

        return self(n - 1) + self(n - 2);
    };
}
```

note that all calls to `fibo` will use a shared cache that inherits the lifetime of `fibo`, so here:

``` csharp
var fibo1 = Fibonacci().Memoized();
var fibo2 = Fibonacci().Memoized();
```

calls to `fibo1` and `fibo2` will use separate caches

## Recursive function with several parameters
For the sake of the example I created a recursive function that takes 3 input parameters:
``` csharp
static Memoizable<int, int, int, long> Example() => self => (a, b, c) => {
	if (a == 0)
		return 0;

	return self(a - 1, b, c) + b + c;
};
```

This example is similar to the single-param "Fibonacci" implementation, the only big change is that now, our return type for the `Example` function is `Memoizable<int, int, int, long>`
where, similarly to `Func<>`, the last type is the return-type.

## Non-Recursive function
This is just the same, you can keep the `self` reference or replace it with `_`
``` csharp
static Memoizable<int, int, int> Add() => _ => (a, b) => a + b;
```


# Prerequisites for memoizing a function
Behind the scenes a memoized function will use some `Dictionary<>` for caching, and in order for the dictionary to work properly, it's key type has to properly implement `Equals()` and `GetHashCode()`.

For your function that means that all the input parameter's types should properly implement `Equals()` and `GetHashCode()`. 
This is true for basic types, but when working with custom types make sure that it's true, or implement those properly for your own classes.
