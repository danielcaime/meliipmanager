using ipmanager.aplication.Interfaces;
using ipmanager.aplication.ProxyDTOs;
using ipmanager.aplication.Services;
using Moq;

namespace ipmanager.test
{
    [TestClass]
    public class ManagerTest
    {
        private Mock<IIpService> _ipServiceMock;
        private Mock<ICountryService> _countryServiceMock;
        private Mock<IBanService> _banServiceMock;
        private IManagerService _serviceManager;

        public IpApiResponse ipApiResponse { get; set; }
        public CountryInfoResponse  getCountryInfo { get; set; }
        public bool exists { get; set; }
        public ManagerTest()
        {
            _ipServiceMock = new Mock<IIpService>();
            _countryServiceMock = new Mock<ICountryService>();
            _banServiceMock = new Mock<IBanService>();
            _serviceManager = new ManagerService(_countryServiceMock.Object, _ipServiceMock.Object, null, _banServiceMock.Object);
        }

        [TestInitialize]
        public void TestInitialize()
        {
            ipApiResponse = new IpApiResponse
            {
                CountryCode = "AR",
            };

            getCountryInfo = new CountryInfoResponse
            {
                Symbol = "USD"
            };

            exists = false;
        }

        [TestMethod]
        public async Task IpInfoTestMethod()
        {
            string ipstr = "";
            _ipServiceMock.Setup(x => x.GetIPInfo(ipstr)).ReturnsAsync(ipApiResponse);
            var ipInfo = await _serviceManager.GetIpInfo(ipstr);
            Assert.IsNotNull(ipInfo);
        }

        [TestMethod]
        public async Task IpInfoTestMethodAr()
        {
            string ipstr = "190.55.231.181";
            _ipServiceMock.Setup(x => x.GetIPInfo(ipstr)).ReturnsAsync(ipApiResponse);
            var ipInfo = await _serviceManager.GetIpInfo(ipstr);
            Assert.AreEqual("AR", ipInfo.CountryCode);
        }

        [TestMethod]
        public async Task CountryInfoTestMethod()
        {
            string isoCode = "US";
            _countryServiceMock.Setup(x => x.GetCountryInfo(isoCode)).ReturnsAsync(getCountryInfo);
            var countryInfo = await _serviceManager.GetCountryInfo(isoCode);
            Assert.AreEqual("USD", countryInfo.Symbol);
        }

        [TestMethod]
        public async Task BannedIpTestMethod()
        {
            string ipstr = "190.55.231.181";
            _banServiceMock.Setup(s => s.Exist(ipstr)).ReturnsAsync(exists);
            var isBanned = await _serviceManager.IsBanned(ipstr);
            Assert.IsFalse(isBanned);
        }

    }
}