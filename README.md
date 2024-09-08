# SmiteUnit.Unity
Adds extensions to help with using SmiteUnit in Unity.

Available on [NuGet](https://www.nuget.org/packages/Linkoid.SmiteUnit.Unity/).

See [SmiteUnit](https://github.com/linkoid/SmiteUnit) for more info.

## Examples

```cs
using System.Threading.Tasks;
using UnityEngine;
using SmiteUnit.Framework;
using SmiteUnit.Unity;
```

```cs
[SmiteTest]
public static async Task MySmiteTest()
{
  await MyGameManager.Instance.StartCoroutineTask(MyLocalCoroutine());
  IEnumerator MyLocalCoroutine()
  {
    // Async test logic goes here
    yield return new WaitForSeconds(1);
  }
}
```
