using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var analysis = new InflationAnalysis();
        string filePath = "Inflation.csv";  
        analysis.LoadData(filePath);

        var inflation2021 = analysis.GetInflationRatesForYear(2021);
        Console.WriteLine("Inflation rates for 2021:");
        foreach (var item in inflation2021)
        {
            Console.WriteLine($"{item.RegionalMember}: {item.InflationRate}%");
        }

        int highestInflationYearForNepal = analysis.GetYearWithHighestInflationForCountry("Nepal");
        Console.WriteLine($"Year when Nepal had the highest inflation: {highestInflationYearForNepal}");

        var topRegions = analysis.GetTopRegionsWithHighestInflation(10);
        Console.WriteLine("Top 10 regions with the highest inflation:");
        foreach (var item in topRegions)
        {
            Console.WriteLine($"{item.RegionalMember}: {item.InflationRate}% in {item.Year}");
        }

        var southAsianCountries = new List<string> { "Afghanistan", "Bangladesh", "Bhutan", "India",
         "Maldives", "Nepal", "Pakistan", "Sri Lanka" };
        var lowestInflation2020 = analysis.GetLowestInflationRatesForYear(2020, 3, southAsianCountries);
        Console.WriteLine("Top 3 South Asian countries with lowest inflation rate in 2020:");
        foreach (var item in lowestInflation2020)
        {
            Console.WriteLine($"{item.RegionalMember}: {item.InflationRate}%");
        }
    }
}



//asdfg