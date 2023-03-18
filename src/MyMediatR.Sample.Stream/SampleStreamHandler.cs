using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace MyMediatR.Sample.Stream;
public class SampleStreamHandler : IStreamRequestHandler<SampleStream, string>
{
    public async IAsyncEnumerable<string> Handle(SampleStream request, CancellationToken cancellationToken)
    {
        foreach (var i in Enumerable.Range(1, 10))
        {
            await Task.Delay(1000, cancellationToken).ConfigureAwait(false);
            yield return $"Return {i}";
        }
    }
}
