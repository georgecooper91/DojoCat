﻿
namespace DojoCat.Members.Domain.Models;

public class Member
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Grade { get; set; } = "white";
    public Address Address { get; set; }
    public ContactDetails ContactDetails { get; set; }
    public EmergencyContact EmergencyContact { get; set; }
    public DateTimeOffset Joined { get; set; }
    public DateTimeOffset Updated { get; set; }
    public bool IsTeacher { get; set; } = false;
    public bool ActiveMember { get; set; } = true;
    public bool DeleteMember { get; set; } = false;
}