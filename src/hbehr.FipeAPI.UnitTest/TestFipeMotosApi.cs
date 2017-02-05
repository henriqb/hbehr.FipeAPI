using NUnit.Framework;

namespace hbehr.FipeAPI.UnitTest
{
    [TestFixture]
    public class TestFipeMotosApi : TestFipeApi
    {
        protected override FipeApi api => new FipeMotosApi();
    }
}
