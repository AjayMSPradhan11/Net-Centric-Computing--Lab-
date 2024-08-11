public class Inflation
{
    public required string RegionalMember { get; set; }
    public int Year { get; set; }
    public double? InflationRate { get; set; } 
    public required string UnitOfMeasurement { get; set; }
    public required string Subregion { get; set; }
    public required string CountryCode { get; set; }
}
