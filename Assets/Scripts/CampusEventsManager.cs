using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections.Generic;

public class CampusEventsManager : MonoBehaviour
{
    [Header("UI References")]
    public GameObject eventButtonPrefab;
    public Transform eventListContainer;
    public Button backButton;

    private List<GameObject> instantiatedButtons = new List<GameObject>();

    private void Start()
    {
        if (backButton != null)
            backButton.onClick.AddListener(OnBackToMenu);

        Invoke("DisplayEvents", 0.1f);
    }

    private void DisplayEvents()
    {
        if (DataManager.Instance == null)
        {
            Debug.LogError("DataManager not found!");
            return;
        }

        // Clear existing
        foreach (GameObject btn in instantiatedButtons)
        {
            if (btn != null) Destroy(btn);
        }
        instantiatedButtons.Clear();

        // Get events from database
        List<CampusEvent> events = DataManager.Instance.campusEvents;
        
        Debug.Log($"Loading {events.Count} events from database");

        // Create buttons
        foreach (CampusEvent evt in events)
        {
            GameObject buttonObj = Instantiate(eventButtonPrefab, eventListContainer);
            
            // Find text components
            TextMeshProUGUI[] texts = buttonObj.GetComponentsInChildren<TextMeshProUGUI>();
            if (texts.Length > 0) texts[0].text = evt.name;
            if (texts.Length > 1) texts[1].text = $"{evt.date} | {evt.time}";

            Button btn = buttonObj.GetComponent<Button>();
            if (btn != null)
            {
                string eventId = evt.id;
                btn.onClick.AddListener(() => OnEventClick(eventId));
            }

            buttonObj.SetActive(true);
            instantiatedButtons.Add(buttonObj);
        }

        Canvas.ForceUpdateCanvases();
        LayoutRebuilder.ForceRebuildLayoutImmediate(eventListContainer.GetComponent<RectTransform>());

        Debug.Log($"✅ Created {instantiatedButtons.Count} event buttons");
    }

    private void OnEventClick(string eventId)
    {
        Debug.Log($"Event clicked: {eventId}");
        // Details view - Week 3
    }

    private void OnBackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}