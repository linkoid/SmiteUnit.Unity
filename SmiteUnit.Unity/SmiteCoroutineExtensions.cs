using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

namespace SmiteUnit.Unity;

public static class SmiteCoroutineExtensions
{
	public static async Task StartCoroutineTask(this MonoBehaviour monoBehaviour, IEnumerator routine)
	{
		var wrapper = AsCoroutineTask(routine);
        monoBehaviour.StartCoroutine(wrapper);
		await wrapper.Task;
	}

	public static IEnumeratorWithTask AsCoroutineTask(this IEnumerator routine)
	{
		return new EnumeratorTaskCompletionSource(routine);
    }
}
