using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace D05Functions.Validation;

[TestClass]
public class Tests
{
    [TestMethod]
    public void WhenTransferDateIsFuture_ThenValidationPassesV1()
    {
        var sut = new DateNotPastValidatorOld();
        var transfer = MakeTransfer.Dummy with
        {
            Date = new DateTime(2022, 5, 16)
        };
        var actual = sut.IsValid(transfer);
        Assert.AreEqual(true, actual);
    }

    // Stub
    static DateTime presentDate = new DateTime(2022, 05, 16);
    private class FakeDateTimeService : IDateTimeService
    {
        public DateTime UtcNow => presentDate;
    }

    [TestMethod]
    public void WhenTransferDateIsPast_ThenValidationFails()
    {
        var svc = new FakeDateTimeService();
        var sut = new DateNotPastValidatorOld2(svc);
        var transfer = MakeTransfer.Dummy with
        {
            Date = presentDate.AddDays(-1)
        };
        Assert.AreEqual(false, sut.IsValid(transfer));
    }
}
