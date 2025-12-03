using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ProgramDetailsManager : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI programNameText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI locationText;
    public TextMeshProUGUI registrationText;
    public Button backButton;

    [Header("Program Database")]
    public ProgramDatabase programDatabase;

    private Program currentProgram;

    private void Start()
    {
        if (backButton != null)
            backButton.onClick.AddListener(OnBack);

        LoadProgramDetails();
    }

    private void LoadProgramDetails()
    {
        string programId = PlayerPrefs.GetString("SelectedProgramId", "");

        if (string.IsNullOrEmpty(programId))
        {
            Debug.LogError("No program selected!");
            return;
        }

        if (programDatabase != null)
        {
            if (programDatabase.mentorshipPrograms.Count == 0)
            {
                programDatabase.InitializeDefaultData();
            }

            currentProgram = programDatabase.mentorshipPrograms.Find(p => p.id == programId);

            if (currentProgram != null)
            {
                DisplayProgramDetails(currentProgram);
            }
        }
    }

    private void DisplayProgramDetails(Program program)
    {
        if (programNameText != null)
            programNameText.text = program.name;

        if (descriptionText != null)
            descriptionText.text = program.description;

        if (locationText != null)
            locationText.text = "Location: " + program.location;

        if (registrationText != null)
            registrationText.text = program.registrationAvailable ? 
                "Registration available" : "Registration closed";
    }

    private void OnBack()
    {
        SceneManager.LoadScene("MentorshipPrograms");
    }
}