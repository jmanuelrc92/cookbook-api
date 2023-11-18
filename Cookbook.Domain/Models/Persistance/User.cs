using System;

namespace CookBookApi.Models;
public class User
{
	public int Id { get; set; }
	public string? Username { get; set; }
	public string? FirstName { get; set; }
	public string? MiddleName { get; set; }
	public string? LastName { get; set; }
	public string? SurName { get; set; }
	public DateTime CreatedDate { get; set; }
	public DateTime ModifiedDate { get; set; }
	public string? Password { get; set; }
	public string? Salt { get; set; }
}