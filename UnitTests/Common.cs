using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace EEM.UnitTests
{
  [TestClass]
  public class UnitTests
  {

    [TestMethod]
    public void Test()
    {
      StreamReader reader = new StreamReader("C:\\Users\\\\Documents\\Visual Studio 2010\\Projects\\EEM\\Enterprise Empire Manager\\bin\\x86\\Debug\\json.txt");
      string json = reader.ReadToEnd();
//      var x = JsonConvert.DeserializeObject<CityResponse>(json);
    }

  }
}
