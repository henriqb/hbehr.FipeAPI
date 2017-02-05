using NUnit.Framework;

namespace hbehr.FipeAPI.UnitTest
{
    [TestFixture]
    public class TestFipeCarrosApi : TestFipeApi
    {
        protected override FipeApi api => new FipeCarrosApi();
    }
}
