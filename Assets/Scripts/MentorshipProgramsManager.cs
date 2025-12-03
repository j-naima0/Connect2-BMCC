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

    private List<GameObject> instantiatedButtons = new List<GameObject>();

    private void Start()
    {
        if (backButton != null)
            backButton.onClick.AddListener(OnBackToMenu);

        // Wait a frame to ensure DataManager is ready
        Invoke("DisplayPrograms", 0.1f);
    }

    private void DisplayPrograms()
    {
        // Check if DataManager exists
        if (DataManager.Instance == null)
        {
            Debug.LogError("DataManager not found! Make sure it exists in the Login scene.");
            return;
        }

        // Verify container
        if (programListContainer == null)
        {
            Debug.LogError("Program List Container is not assigned!");
            return;
        }

        // Verify prefab
        if (programButtonPrefab == null)
        {
            Debug.LogError("Program Button Prefab is not assigned!");
            return;
        }

        // Clear existing buttons
        foreach (GameObject btn in instantiatedButtons)
        {
            if (btn != null)
                Destroy(btn);
        }
        instantiatedButtons.Clear();

        // Get programs from DataManager
        List<Program> programs = DataManager.Instance.mentorshipPrograms;
        
        Debug.Log($"DataManager has {programs.Count} programs");

        // Create button for each program
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

        // Force layout update
        Canvas.ForceUpdateCanvases();
        LayoutRebuilder.ForceRebuildLayoutImmediate(programListContainer.GetComponent<RectTransform>());

        Debug.Log($"Successfully created {instantiatedButtons.Count} program buttons");
    }

    private void OnProgramClick(string programId)
    {
        PlayerPrefs.SetString("SelectedProgramId", programId);
        PlayerPrefs.SetString("SelectedCategory", "mentorship");
        PlayerPrefs.Save();

        Debug.Log($"Selected program: {programId}");
        SceneManager.LoadScene("ProgramDetails");
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