# Unity_StopWatch

Utility to measure performance of small action/function or continuous codes.

NOTE:
This is not depends on Unity. Main codes is able to works on native C#.

## Import to Your Project

You can import this asset from UnityPackage.

- [StopWatch.unitypackage](https://github.com/XJINE/Unity_StopWatch/blob/master/StopWatch.unitypackage)


## How to Use

``MeasureAction`` method is the easiest way to measure action.
Pass an action and the iteration count, it will returns the time of the action.

```csharp
Debug.Log(StopWatch.MeasureAction(delegate ()
{
    Transform transform = base.transform;
},
this.loopCount).TotalMilliseconds);
```
If you pass ``true`` as third argument, the result will shows average time.


You can use 3 methods to get more strict time. ``Start``, ``Stop`` and ``Restart``.

```csharp

StopWatch.Restart();

for (int i = 0; i < this.loopCount; i++)
{
    Transform transform = base.transform;
}

StopWatch.Stop();

Debug.Log(StopWatch.Ellapsed.TotalMilliseconds);
```

