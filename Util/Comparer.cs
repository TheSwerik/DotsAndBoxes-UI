using System;
using System.Linq;
using Microsoft.AspNetCore.Components;

namespace UI.Util
{
    public static class Comparer
    {
        public static bool EqualsUri(NavigationManager navigationManager, params string[] uris)
        {
            return uris.Any(uri =>
                                navigationManager.Uri.Equals(navigationManager.BaseUri + uri,
                                                             StringComparison.InvariantCultureIgnoreCase) ||
                                navigationManager.Uri.Equals(navigationManager.BaseUri + "/" + uri,
                                                             StringComparison.InvariantCultureIgnoreCase)
            );
        }

        public static bool ContainsUri(NavigationManager navigationManager, params string[] uris)
        {
            return uris.Any(uri => navigationManager.Uri.Contains(uri, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}