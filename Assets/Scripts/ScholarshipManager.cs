using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections.Generic;

public class ScholarshipManager : MonoBehaviour
{
    [Header("UI References")]
    public GameObject scholarshipButtonPrefab;
    public Transform scholarshipListContainer;
    public Button backButton;

    private List<GameObject> instantiatedButtons = new List<GameObject>();

    private void Start()
{
    if (backButton != null)
        backButton.onClick.AddListener(OnBackToMenu);
    
    Invoke("DisplayScholarships", 0.1f);
}

    private void DisplayScholarships()
{
    if (DataManager.Instance == null) return;

    foreach (GameObject btn in instantiatedButtons)
    {
        if (btn != null) Destroy(btn);
    }
    instantiatedButtons.Clear();

    List<Scholarship> scholarships = DataManager.Instance.scholarships;
    
    Debug.Log($"Loading {scholarships.Count} scholarships from database");

    foreach (Scholarship scholarship in scholarships)
    {
        GameObject buttonObj = Instantiate(scholarshipButtonPrefab, scholarshipListContainer);
        
        // Get ALL text components in the button
        TextMeshProUGUI[] texts = buttonObj.GetComponentsInChildren<TextMeshProUGUI>();
        
        // Build a detailed string
        string detailText = $"{scholarship.name}\n" +
                           $"Amount: {scholarship.amount}\n" +
                           $"Deadline: {scholarship.deadline}\n" +
                           $"{scholarship.eligibility}";
        
        // Set text (works with single or multiple text components)
        if (texts.Length > 0)
        {
            texts[0].text = detailText;
        }

        buttonObj.SetActive(true);
        instantiatedButtons.Add(buttonObj);
        
        Debug.Log($"Created scholarship button: {scholarship.name}");
    }

    Canvas.ForceUpdateCanvases();
    LayoutRebuilder.ForceRebuildLayoutImmediate(scholarshipListContainer.GetComponent<RectTransform>());
    
    Debug.Log($"✅ Created {instantiatedButtons.Count} scholarship buttons");
}

    private void OnBackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}