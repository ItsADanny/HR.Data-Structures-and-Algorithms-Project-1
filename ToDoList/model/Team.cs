using System.ComponentModel.DataAnnotations;
public class Team
{
    [Key]
    public int ID { get; set; }

    public string TeamName { get; set; }
    public User CreateUser { get; set; }
    public int CreateUserID { get; set; }
}