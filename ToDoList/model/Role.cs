using System.ComponentModel.DataAnnotations;
public class Role
{
    [Key]
    public int ID { get; set; }

    public string Name { get; set; }
    public bool CreatePremission { get; set; }
    public bool ClosePremission { get; set; }
}