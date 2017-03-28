using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic.Simple
{
    public class ItsAlwaysACallback
    {
public async Task Caller()
{
    var t = await this.DoSomething1();
}

public async Task<int> DoSomething1()
{
    return await Task.FromResult(1);
}

public Task<int> DoSomething2()
{
    return Task.FromResult(1);
}
    }
}
