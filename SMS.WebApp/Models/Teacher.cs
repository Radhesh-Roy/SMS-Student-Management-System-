﻿namespace SMS.WebApp.Models;

public class Teacher
{
    public int Id { get; set; }
    public string Name { get; set; }=string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Qualification { get; set; } = string.Empty;
}
