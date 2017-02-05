using NUnit.Framework;

namespace hbehr.FipeAPI.UnitTest
{
    [TestFixture]
    public class TestFipeCaminhoesApi : TestFipeApi
    {
        protected override FipeApi api => new FipeCaminhoesApi();
    }
}
