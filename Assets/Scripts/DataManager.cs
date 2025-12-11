using UnityEngine;
using System.Collections.Generic;
using System;

// Program class (same as before)
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

// NEW: Event class for campus events
[Serializable]
public class CampusEvent
{
    public string id;
    public string name;
    public string description;
    public string location;
    public string date;
    public string time;
    public string category;
    public bool registrationRequired;
}

// NEW: Scholarship class
[Serializable]
public class Scholarship
{
    public string id;
    public string name;
    public string description;
    public string amount;
    public string deadline;
    public string eligibility;
    public string applicationLink;
}

// NEW: Academic Support class
[Serializable]
public class AcademicSupport
{
    public string id;
    public string name;
    public string description;
    public string location;
    public string hours;
    public string services;
    public string contactInfo;
}

// Wrapper class for JSON
[Serializable]
public class DatabaseRoot
{
    public List<Program> mentorshipPrograms;
    public List<CampusEvent> campusEvents;
    public List<Scholarship> scholarships;
    public List<AcademicSupport> academicSupport;
}

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    // Database file
    public TextAsset databaseFile;

    // Data lists
    public List<Program> mentorshipPrograms = new List<Program>();
    public List<CampusEvent> campusEvents = new List<CampusEvent>();
    public List<Scholarship> scholarships = new List<Scholarship>();
    public List<AcademicSupport> academicSupport = new List<AcademicSupport>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadDatabaseFromJSON();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void LoadDatabaseFromJSON()
    {
        if (databaseFile == null)
        {
            Debug.LogError("Database file not assigned! Please assign programs_database.json to DataManager.");
            return;
        }

        try
        {
            // Read JSON file
            string jsonContent = databaseFile.text;
            
            // Parse JSON
            DatabaseRoot database = JsonUtility.FromJson<DatabaseRoot>(jsonContent);

            // Load data
            mentorshipPrograms = database.mentorshipPrograms;
            campusEvents = database.campusEvents;
            scholarships = database.scholarships;
            academicSupport = database.academicSupport;

            Debug.Log($"✅ DATABASE LOADED FROM JSON FILE:");
            Debug.Log($"   - {mentorshipPrograms.Count} Mentorship Programs");
            Debug.Log($"   - {campusEvents.Count} Campus Events");
            Debug.Log($"   - {scholarships.Count} Scholarships");
            Debug.Log($"   - {academicSupport.Count} Academic Support Services");
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to load database: {e.Message}");
        }
    }

    // Helper methods
    public Program GetProgramById(string id)
    {
        return mentorshipPrograms.Find(p => p.id == id);
    }

    public CampusEvent GetEventById(string id)
    {
        return campusEvents.Find(e => e.id == id);
    }

    public Scholarship GetScholarshipById(string id)
    {
        return scholarships.Find(s => s.id == id);
    }

    public AcademicSupport GetAcademicSupportById(string id)
    {
        return academicSupport.Find(a => a.id == id);
    }
}
