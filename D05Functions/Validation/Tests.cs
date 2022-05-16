using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace D05Functions.Validation;

[TestClass]
public class Tests
{
    [TestMethod]
    public void WhenTransferDateIsFuture_ThenValidationPasses()
    {
        var sut = new DateNotPastValidator();
        var transfer = MakeTransfer.Dummy with
        {
            Date = new DateTime(2021, 3, 12)
        };
        var actual = sut.IsValid(transfer);
        Assert.AreEqual(true, actual);
    }
}
