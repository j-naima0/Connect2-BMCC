using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections.Generic;

public class MentorshipProgramsManager : MonoBehaviour
{
    [Header("UI References")]
    public GameObject programButtonPrefab;
    public Transform programListContainer;
    public Button backButton;
    
    [Header("Details Panel (Optional)")]
    public GameObject detailsPanel;
    public TextMeshProUGUI detailsTitle;
    public TextMeshProUGUI detailsDescription;
    public TextMeshProUGUI detailsLocation;
    public TextMeshProUGUI detailsContact;
    public TextMeshProUGUI detailsHours;
    public Button closeDetailsButton;

    private List<GameObject> instantiatedButtons = new List<GameObject>();
    private bool showingDetails = false;

    private void Start()
    {
        if (backButton != null)
            backButton.onClick.AddListener(OnBackToMenu);

        if (closeDetailsButton != null)
            closeDetailsButton.onClick.AddListener(CloseDetails);

        if (detailsPanel != null)
            detailsPanel.SetActive(false);

        Invoke("DisplayPrograms", 0.1f);
    }

    private void DisplayPrograms()
    {
        if (DataManager.Instance == null)
        {
            Debug.LogError("DataManager not found!");
            return;
        }

        foreach (GameObject btn in instantiatedButtons)
        {
            if (btn != null) Destroy(btn);
        }
        instantiatedButtons.Clear();

        List<Program> programs = DataManager.Instance.mentorshipPrograms;
        
        Debug.Log($"DataManager has {programs.Count} programs");

        foreach (Program program in programs)
        {
            GameObject buttonObj = Instantiate(programButtonPrefab, programListContainer);
            buttonObj.name = $"Button_{program.name}";
            
            TextMeshProUGUI buttonText = buttonObj.GetComponentInChildren<TextMeshProUGUI>();
            if (buttonText != null)
            {
                buttonText.text = program.name;
                Debug.Log($"Created button: {program.name}");
            }

            Button btn = buttonObj.GetComponent<Button>();
            if (btn != null)
            {
                string programId = program.id;
                btn.onClick.AddListener(() => OnProgramClick(programId));
            }

            buttonObj.SetActive(true);
            instantiatedButtons.Add(buttonObj);
        }

        Canvas.ForceUpdateCanvases();
        LayoutRebuilder.ForceRebuildLayoutImmediate(programListContainer.GetComponent<RectTransform>());

        Debug.Log($"Successfully created {instantiatedButtons.Count} program buttons");
    }

    private void OnProgramClick(string programId)
    {
        Program program = DataManager.Instance.GetProgramById(programId);
        
        if (program == null)
        {
            Debug.LogError($"Program not found: {programId}");
            return;
        }

        Debug.Log($"Selected program: {program.name}");

        // If we have a details panel, show it
        if (detailsPanel != null)
        {
            ShowDetails(program);
        }
        else
        {
            // Just log details to console for now
            Debug.Log($"=== {program.name} ===");
            Debug.Log($"Description: {program.description}");
            Debug.Log($"Location: {program.location}");
            Debug.Log($"Contact: {program.contactInfo}");
            Debug.Log($"Hours: {program.officeHours}");
            Debug.Log($"Target: {program.targetAudience}");
            Debug.Log($"Registration: {(program.registrationAvailable ? "Available" : "Closed")}");
        }
    }

    private void ShowDetails(Program program)
    {
        detailsPanel.SetActive(true);
        
        if (detailsTitle != null)
            detailsTitle.text = program.name;
        
        if (detailsDescription != null)
            detailsDescription.text = program.description;
        
        if (detailsLocation != null)
            detailsLocation.text = "📍 Location: " + program.location;
        
        if (detailsContact != null)
            detailsContact.text = "📧 Contact: " + program.contactInfo;
        
        if (detailsHours != null)
            detailsHours.text = "⏰ Hours: " + program.officeHours;

        showingDetails = true;
    }

    private void CloseDetails()
    {
        if (detailsPanel != null)
            detailsPanel.SetActive(false);
        
        showingDetails = false;
    }

    private void OnBackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void OnDestroy()
    {
        foreach (GameObject btn in instantiatedButtons)
        {
            if (btn != null)
                Destroy(btn);
        }
    }
}
