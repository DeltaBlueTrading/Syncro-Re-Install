using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Win32;

namespace Mineware.Systems.Global
{
    public class LocalSettings
    {
        private RegistryKey baseRegistryKey = Registry.CurrentUser;
        private RegistryKey theKey;

        public void loadKey()
        {

            object RegReadKeyValue = null;
            RegReadKeyValue = theKey.GetValue("HKEY_CURRENT_USER\\SoftwareName\\CompanyName\\KeyName", "ValueName");
        }
    }
}
