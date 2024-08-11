using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;

public class InflationAnalysis
{
    public List<Inflation> Inflations { get; set; } = new List<Inflation>();

    public void LoadData(string filePath)
    {
        using (var reader = new StreamReader(filePath))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = args => args.Header.ToLower(),
            };

            csv.Context.RegisterClassMap<InflationMap>();
            Inflations = csv.GetRecords<Inflation>().ToList();
        }
    }

    public List<Inflation> GetInflationRatesForYear(int year)
    {
        return Inflations.Where(i => i.Year == year).ToList();
    }

    public int GetYearWithHighestInflationForCountry(string country)
    {
        return Inflations
            .Where(i => i.RegionalMember.Equals(country, StringComparison.OrdinalIgnoreCase))
            .OrderByDescending(i => i.InflationRate)
            .FirstOrDefault()?.Year ?? 0;
    }

    public List<Inflation> GetTopRegionsWithHighestInflation(int topCount)
    {
        return Inflations
            .OrderByDescending(i => i.InflationRate)
            .Take(topCount)
            .ToList();
    }

    public List<Inflation> GetLowestInflationRatesForYear(int year, int topCount, List<string> countries)
    {
        return Inflations
            .Where(i => i.Year == year && countries.Contains(i.RegionalMember))
            .OrderBy(i => i.InflationRate)
            .Take(topCount)
            .ToList();
    }
}

public sealed class InflationMap : ClassMap<Inflation>
{
    public InflationMap()
    {
        Map(m => m.RegionalMember).Name("RegionalMember");
        Map(m => m.Year).Name("Year");
        Map(m => m.InflationRate).Name("Inflation");
        Map(m => m.UnitOfMeasurement).Name("Unit of Measurement");
        Map(m => m.Subregion).Name(" Subregion");
        Map(m => m.CountryCode).Name(" Country Code");
    }
}