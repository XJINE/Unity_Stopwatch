using System;
using System.Diagnostics;

public static class StopWatch
{
    #region Field

    private static Stopwatch stopWatch = new Stopwatch();

    #endregion Field

    #region Property

    public static TimeSpan Ellapsed
    {
        get
        {
            return StopWatch.stopWatch.Elapsed;
        }
    }

    public static bool IsRunning
    {
        get
        {
            return StopWatch.stopWatch.IsRunning;
        }
    }

    #endregion Property

    #region Method

    public static void Start()
    {
        StopWatch.stopWatch.Start();
    }

    public static void Stop()
    {
        StopWatch.stopWatch.Stop();
    }

    public static void Reset()
    {
        StopWatch.stopWatch.Reset();
    }

    public static void Restart()
    {
        Reset();
        Start();
    }

    public static TimeSpan MeasureAction(Action action, int iteration = 1, bool average = false)
    {
        // NOTE:
        // It is able to set 'delegate()=>{}' to 'action'
        // to check method performance which has some arguments or continuous codes.
        // Because of using 'delegate', the result is more slower than accurate way.
        // However, it is enough for performance comparison.

        TimeSpan result = TimeSpan.Zero;

        if (StopWatch.stopWatch.IsRunning)
        {
            return result;
        }

        if (average)
        {
            StopWatch.stopWatch.Reset();

            TimeSpan total = TimeSpan.Zero;

            for (int i = 0; i < iteration; i++)
            {
                StopWatch.stopWatch.Start();
                action();
                total += StopWatch.stopWatch.Elapsed;
                StopWatch.stopWatch.Reset();
            }

            result = new TimeSpan(total.Ticks / iteration);
        }
        else
        {
            StopWatch.stopWatch.Reset();
            StopWatch.stopWatch.Start();

            for (int i = 0; i < iteration; i++)
            {
                action();
            }

            result = StopWatch.stopWatch.Elapsed;
        }

        StopWatch.stopWatch.Stop();
        StopWatch.stopWatch.Reset();

        return result;
    }

    #endregion Method
}