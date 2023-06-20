using System.Threading;

public class FizzBuzz
{

    private int _n;

    AutoResetEvent _autoResetEventFizz;
    AutoResetEvent _autoResetEventBuzz;
    AutoResetEvent _autoResetEventFizzBuzz;
    AutoResetEvent _autoResetEventNumber;

    public FizzBuzz(int n)
    {
        _n = n;
        _autoResetEventFizz = new AutoResetEvent(false);
        _autoResetEventBuzz = new AutoResetEvent(false);
        _autoResetEventFizzBuzz = new AutoResetEvent(false);
        _autoResetEventNumber = new AutoResetEvent(false);
    }

    // printFizz() outputs "fizz".
    public void Fizz(Action printFizz)
    {
        for (var i = 1; i <= _n; i++)
        {
            _autoResetEventFizz.WaitOne();
            if (i % 3 == 0 && i % 5 != 0) printFizz();
            _autoResetEventBuzz.Set();
        }
    }

    // printBuzz() outputs "buzz".
    public void Buzz(Action printBuzz)
    {
        for (var i = 1; i <= _n; i++)
        {
            _autoResetEventBuzz.WaitOne();
            if (i % 3 != 0 && i % 5 == 0) printBuzz();
            _autoResetEventFizzBuzz.Set();
        }
    }

    // printFizzBuzz() outputs "fizzbuzz".
    public void Fizzbuzz(Action printFizzBuzz)
    {
        for (var i = 1; i <= _n; i++)
        {
            _autoResetEventFizzBuzz.WaitOne();
            if (i % 3 == 0 && i % 5 == 0) printFizzBuzz();
            _autoResetEventNumber.Set();
        }
    }

    // printNumber(x) outputs "x", where x is an integer.
    public void Number(Action<int> printNumber)
    {
        for (var i = 1; i < _n; i++)
        {
            if (i % 3 != 0 && i % 5 != 0) printNumber(i);
            _autoResetEventFizz.Set();
            _autoResetEventNumber.WaitOne();
        }
    }
}