using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

namespace SmiteUnit.Unity;

internal class EnumeratorTaskCompletionSource : IEnumeratorWithTask
{
	private bool m_IsFinished = false;
	private readonly IEnumerator m_Enumerator;
	private readonly TaskCompletionSource<bool> m_TaskCompletionSource;
	public Task Task => m_TaskCompletionSource.Task;

	public EnumeratorTaskCompletionSource(IEnumerator enumerator, TaskCreationOptions taskCreationOptions = TaskCreationOptions.None)
	{
		m_Enumerator = enumerator;
		m_TaskCompletionSource = new(this, taskCreationOptions);
	}

	public object Current => m_Enumerator.Current;

	public bool MoveNext()
	{
		bool movedNext = false;
		try
		{
			movedNext = m_Enumerator.MoveNext();
		}
		catch (System.Exception ex)
		{
			m_TaskCompletionSource.SetException(ex);
			throw;
		}

		if (!movedNext && !m_IsFinished)
		{
			m_IsFinished = true;
			m_TaskCompletionSource.SetResult(m_IsFinished);
		}

		return movedNext;
	}

	public void Reset()
	{
		throw new System.NotSupportedException();
	}
}

