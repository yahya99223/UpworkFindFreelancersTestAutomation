
using System.ComponentModel;
using Shared.Core;

namespace TestScenarios.Helpers
{
    public static class TestSettingsSetter
    {
        public static void SetSettings(string browser)
        {
            if (browser == "f")
            {
                TestSettings.Browser = BroswerType.Firefox;
                return;
            }
            if (browser == "c")
            {
                TestSettings.Browser = BroswerType.Firefox;
                return;
            }
         throw new InvalidEnumArgumentException("Value entered as browser type is not valid");
        }
    }
}
