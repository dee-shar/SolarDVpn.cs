# SolarDVpn.cs
Mobile-API for [SOLAR dVPN](https://play.google.com/store/apps/details?id=ee.solarlabs.dvpn) an blockchain-based decentralized VPN service that allows you to easily bypass any regional or dictatorship government restrictions

## Example
```cs
using System;
using SolarDVpnApi;
using System.Threading.Tasks;

namespace Application
{
    internal class Program
    {
        static async Task Main()
        {
            var api = new SolarDVpn();
            string currentIp = await api.getCurrentIp();
            Console.WriteLine(currentIp);
        }
    }
}
```
