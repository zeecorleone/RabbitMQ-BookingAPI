namespace FormulaAirline.API.Models;

public class Booking
{
    public string Id { get; set; }
    public string PessengerName { get; set; } = string.Empty;
    public string PassportNb { get; set; } = string.Empty;
    public string From { get; set; } = string.Empty;
    public string To { get; set; } = string.Empty;
    public int Status { get; set; }
}
