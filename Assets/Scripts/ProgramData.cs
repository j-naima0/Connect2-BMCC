using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class Program
{
    public string id;
    public string name;
    public string description;
    public string location;
    public bool registrationAvailable;
    public string targetAudience;
    public string contactInfo;
    public string officeHours;
}

[Serializable]
public class ProgramList
{
    public List<Program> programs;
}

[CreateAssetMenu(fileName = "ProgramDatabase", menuName = "Connect2/Program Database")]
public class ProgramDatabase : ScriptableObject
{
    public List<Program> mentorshipPrograms = new List<Program>();

    public void InitializeDefaultData()
    {
        mentorshipPrograms = new List<Program>
        {
            new Program
            {
                id = "mp001",
                name = "Crear Futuros",
                description = "One on one mentoring for first year and continuing students",
                location = "Room S-230",
                registrationAvailable = true,
                targetAudience = "First year and continuing students",
                contactInfo = "crearfuturos@bmcc.cuny.edu",
                officeHours = "Mon-Fri 9AM-5PM"
            },
            new Program
            {
                id = "mp002",
                name = "Impact Peer",
                description = "Peer mentoring program connecting students with student leaders",
                location = "Room S-230",
                registrationAvailable = true,
                targetAudience = "All students",
                contactInfo = "impactpeer@bmcc.cuny.edu",
                officeHours = "Mon-Fri 10AM-4PM"
            },
            new Program
            {
                id = "mp003",
                name = "College Discovery",
                description = "Academic and career mentoring for eligible students",
                location = "Room S-230",
                registrationAvailable = true,
                targetAudience = "Eligible students",
                contactInfo = "collegediscovery@bmcc.cuny.edu",
                officeHours = "Mon-Fri 9AM-5PM"
            }
        };
    }
}