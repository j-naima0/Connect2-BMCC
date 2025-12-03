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

    [Header("Program Database")]
    public ProgramDatabase programDatabase;

    private List<GameObject> instantiatedButtons = new List<GameObject>();

    private void Start()
    {
        if (backButton != null)
            backButton.onClick.AddListener(OnBackToMenu);

        if (programDatabase == null)
        {
            Debug.LogError("Program Database not assigned!");
            return;
        }

        if (programDatabase.mentorshipPrograms.Count == 0)
        {
            programDatabase.InitializeDefaultData();
        }

        DisplayPrograms();
    }

    private void DisplayPrograms()
    {
        foreach (GameObject btn in instantiatedButtons)
        {
            Destroy(btn);
        }
        instantiatedButtons.Clear();

        foreach (Program program in programDatabase.mentorshipPrograms)
        {
            GameObject buttonObj = Instantiate(programButtonPrefab, programListContainer);
            
            TextMeshProUGUI buttonText = buttonObj.GetComponentInChildren<TextMeshProUGUI>();
            if (buttonText != null)
            {
                buttonText.text = program.name;
            }

            Button btn = buttonObj.GetComponent<Button>();
            if (btn != null)
            {
                string programId = program.id;
                btn.onClick.AddListener(() => OnProgramClick(programId));
            }

            instantiatedButtons.Add(buttonObj);
        }
    }

    private void OnProgramClick(string programId)
    {
        PlayerPrefs.SetString("SelectedProgramId", programId);
        PlayerPrefs.SetString("SelectedCategory", "mentorship");
        PlayerPrefs.Save();

        Debug.Log($"Program selected: {programId}");

        SceneManager.LoadScene("ProgramDetails");
    }

    private void OnBackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}