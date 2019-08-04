using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Obbligo_o_verita.Resources;

namespace Obbligo_o_verita
{
    /// <summary>
    /// Provides access to string resources.
    /// </summary>
    public class LocalizedStrings
    {
        private static AppResources _localizedResources = new AppResources();

        public AppResources LocalizedResources { get { return _localizedResources; } }
    }
}