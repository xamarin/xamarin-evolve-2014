using System;
using System.Collections.Generic;
using System.Linq;
using WcfServiceHost.Model;

namespace WcfServiceHost
{
    public class MonkeyService : IMonkeyService
    {
        //TODO: Step 2 - Create an implementation our service implementation
        //public string GetRandomMonkeyName()
        //{
        //    var random = new Random();
        //    var monkeyInformation = MonkeyData.GetMonkeyInformation();

        //    return
        //        monkeyInformation.Any()
        //            ? monkeyInformation.ElementAt(random.Next(monkeyInformation.Count)).CommonName
        //            : string.Empty;
        //}

        //public IEnumerable<MonkeyInformation> GetMonkeyMatch(MonkeyQuery query)
        //{
        //    var monkeyInformation = MonkeyData.GetMonkeyInformation();

        //    return
        //        query == null || (String.IsNullOrEmpty(query.Family) && String.IsNullOrEmpty(query.Subfamily) && String.IsNullOrEmpty(query.Genus))
        //        ? Enumerable.Empty<MonkeyInformation>()
        //        : monkeyInformation
        //            .Where(mi => String.IsNullOrEmpty(query.Family) || mi.Family.IndexOf(query.Family, StringComparison.OrdinalIgnoreCase) >= 0)
        //            .Where(mi => String.IsNullOrEmpty(query.Subfamily) || mi.Subfamily.IndexOf(query.Subfamily, StringComparison.OrdinalIgnoreCase) >= 0)
        //            .Where(mi => String.IsNullOrEmpty(query.Genus) || mi.Genus.IndexOf(query.Genus, StringComparison.OrdinalIgnoreCase) >= 0);
        //}
    }
}
