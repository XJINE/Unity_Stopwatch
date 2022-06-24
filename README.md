# Unity_Stopwatch

Utility to measure performance of small action/function or continuous codes.

NOTE:
This is not depends on Unity. Main codes is able to works on native C#.

## Importing

You can use Package Manager or import it directly.

```
https://github.com/XJINE/Unity_Stopwatch.git?path=Assets/Packages/Stopwatch
```

## How to Use

``MeasureAction`` method is the easiest way to measure action.
Pass an action and the iteration count, it will returns the time of the action.

```csharp
Debug.Log(Stopwatch.MeasureAction(delegate ()
{
    var transform = base.transform;
},
loopCount).TotalMilliseconds);
```
If you pass ``true`` as third argument, the result will shows average time.


You can use 3 methods to get more strict time. ``Start``, ``Stop`` and ``Restart``.

```csharp

Stopwatch.Restart();

for (int i = 0; i < loopCount; i++)
{
    var transform = base.transform;
}

Stopwatch.Stop();

Debug.Log(Stopwatch.Ellapsed.TotalMilliseconds);
```