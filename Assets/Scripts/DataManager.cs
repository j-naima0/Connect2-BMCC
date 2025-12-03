using UnityEngine;
using System.Collections.Generic;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public List<Program> mentorshipPrograms = new List<Program>();

    private void Awake()
    {
        // Singleton pattern - only one DataManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // This persists between scenes!
            InitializeData();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeData()
    {
        Debug.Log("DataManager: Initializing program data");

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

        Debug.Log($"DataManager: Loaded {mentorshipPrograms.Count} programs");
    }

    public Program GetProgramById(string id)
    {
        return mentorshipPrograms.Find(p => p.id == id);
    }
}