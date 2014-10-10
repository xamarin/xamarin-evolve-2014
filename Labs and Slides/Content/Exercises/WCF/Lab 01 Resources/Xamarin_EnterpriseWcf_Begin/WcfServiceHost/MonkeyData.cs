using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WcfServiceHost.Model;

namespace WcfServiceHost
{
    public static class MonkeyData
    {

        private static List<MonkeyInformation> monkeyList;

        public static List<MonkeyInformation> GetMonkeyInformation()
        {
            return 
                monkeyList ??
                (
                    monkeyList = 
                    new List<MonkeyInformation>()
                    {
                        new MonkeyInformation(){ Family = "Callitrichidae", Subfamily = "", Genus = "Callithrix", ScientificName = "Callithrix jacchus", CommonName = "common marmoset" },
                        new MonkeyInformation(){ Family = "Callitrichidae", Subfamily = "", Genus = "Callithrix", ScientificName = "Callithrix penicillata", CommonName = "black-tufted marmoset" },
                        new MonkeyInformation(){ Family = "Callitrichidae", Subfamily = "", Genus = "Callithrix", ScientificName = "Callithrix kuhlii", CommonName = "Wied's marmoset" },
                        new MonkeyInformation(){ Family = "Callitrichidae", Subfamily = "", Genus = "Callithrix", ScientificName = "Callithrix geoffroyi", CommonName = "white-headed marmoset" },

                        new MonkeyInformation(){ Family = "Callitrichidae", Subfamily = "", Genus = "Leontopithecus", ScientificName = "Leontopithecus rosalia", CommonName = "golden lion tamarin" },
                        new MonkeyInformation(){ Family = "Callitrichidae", Subfamily = "", Genus = "Leontopithecus", ScientificName = "Leontopithecus chrysomelas", CommonName = "golden-headed lion tamarin" },
                        new MonkeyInformation(){ Family = "Callitrichidae", Subfamily = "", Genus = "Leontopithecus", ScientificName = "Leontopithecus chrysopygus", CommonName = "black lion tamarin" },
                        new MonkeyInformation(){ Family = "Callitrichidae", Subfamily = "", Genus = "Leontopithecus", ScientificName = "Leontopithecus caissara", CommonName = "Superagui lion tamarin" },

                        new MonkeyInformation(){ Family = "Pitheciidae", Subfamily = "Callicebinae", Genus = "Pithecia", ScientificName = "Pithecia pithecia", CommonName = "white-faced saki" },
                        new MonkeyInformation(){ Family = "Pitheciidae", Subfamily = "Callicebinae", Genus = "Pithecia", ScientificName = "Pithecia monachus", CommonName = "monk saki" },
                        new MonkeyInformation(){ Family = "Pitheciidae", Subfamily = "Callicebinae", Genus = "Pithecia", ScientificName = "Pithecia aequatorialis", CommonName = "equatorial saki" },

                        new MonkeyInformation(){ Family = "Atelidae", Subfamily = "Alouattinae", Genus = "Alouatta", ScientificName = "Alouatta coibensis", CommonName = "Coiba Island howler" },
                        new MonkeyInformation(){ Family = "Atelidae", Subfamily = "Alouattinae", Genus = "Alouatta", ScientificName = "Alouatta palliata", CommonName = "mantled howler" },
                        new MonkeyInformation(){ Family = "Atelidae", Subfamily = "Alouattinae", Genus = "Alouatta pigra", CommonName = "Guatemalan black howler" },
                    }
                );
        }
    }
}