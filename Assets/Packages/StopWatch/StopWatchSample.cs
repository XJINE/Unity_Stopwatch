using UnityEngine;

public class StopWatchSample : MonoBehaviour
{
    public int iterationCount = 1000;

    private void Awake()
    {
        Debug.Log(Stopwatch.MeasureAction(delegate ()
        {
            var transform = base.transform;
        },
        iterationCount).TotalMilliseconds);

        Debug.Log(Stopwatch.MeasureAction(delegate ()
        {
            var gameObject = base.gameObject;
        },
        iterationCount).TotalMilliseconds);

        // If you need accuracy.

        Stopwatch.Restart();

        for (int i = 0; i < iterationCount; i++)
        {
            var transform = base.transform;
        }

        Stopwatch.Stop();

        Debug.Log(Stopwatch.Elapsed.TotalMilliseconds);

        Stopwatch.Restart();

        for (int i = 0; i < iterationCount; i++)
        {
            var gameObject = base.gameObject;
        }

        Stopwatch.Stop();

        Debug.Log(Stopwatch.Elapsed.TotalMilliseconds);
    }
}