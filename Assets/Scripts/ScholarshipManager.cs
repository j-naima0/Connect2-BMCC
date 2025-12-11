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
            
            TextMeshProUGUI[] texts = buttonObj.GetComponentsInChildren<TextMeshProUGUI>();
            if (texts.Length > 0) texts[0].text = scholarship.name;
            if (texts.Length > 1) texts[1].text = $"Amount: {scholarship.amount}";

            buttonObj.SetActive(true);
            instantiatedButtons.Add(buttonObj);
        }

        Canvas.ForceUpdateCanvases();
        LayoutRebuilder.ForceRebuildLayoutImmediate(scholarshipListContainer.GetComponent<RectTransform>());
    }

    private void OnBackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}