using System.Collections;
using System.Threading.Tasks;

namespace SmiteUnit.Unity;

public interface IEnumeratorWithTask : IEnumerator
{
    public Task Task { get; }
}
