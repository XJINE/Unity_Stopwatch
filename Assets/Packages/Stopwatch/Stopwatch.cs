using System;

public static class Stopwatch
{
    #region Field

    private static readonly System.Diagnostics.Stopwatch stopwatch = new ();

    #endregion Field

    #region Property

    public static TimeSpan Elapsed   => stopwatch.Elapsed;
    public static bool     IsRunning => stopwatch.IsRunning;

    #endregion Property

    #region Method

    public static void Start()
    {
        stopwatch.Start();
    }

    public static void Stop()
    {
        stopwatch.Stop();
    }

    public static void Reset()
    {
        stopwatch.Reset();
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

        var result = TimeSpan.Zero;

        if (stopwatch.IsRunning)
        {
            return result;
        }

        if (average)
        {
            stopwatch.Reset();

            var total = TimeSpan.Zero;

            for (var i = 0; i < iteration; i++)
            {
                stopwatch.Start();
                action();
                total += stopwatch.Elapsed;
                stopwatch.Reset();
            }

            result = new TimeSpan(total.Ticks / iteration);
        }
        else
        {
            stopwatch.Reset();
            stopwatch.Start();

            for (var i = 0; i < iteration; i++)
            {
                action();
            }

            result = stopwatch.Elapsed;
        }

        stopwatch.Stop();
        stopwatch.Reset();

        return result;
    }

    #endregion Method
}