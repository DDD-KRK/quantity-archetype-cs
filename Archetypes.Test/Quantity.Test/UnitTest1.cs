using Xunit;

namespace Quantity.Test;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {           
        var subject = new Class1();
        Assert.Equal(4, subject.Add(2, 2));
    }

    
}