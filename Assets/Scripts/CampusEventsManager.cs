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

    foreach (GameObject btn in instantiatedButtons)
    {
        if (btn != null) Destroy(btn);
    }
    instantiatedButtons.Clear();

    List<CampusEvent> events = DataManager.Instance.campusEvents;
    
    Debug.Log($"Loading {events.Count} events from database");

    foreach (CampusEvent evt in events)
    {
        GameObject buttonObj = Instantiate(eventButtonPrefab, eventListContainer);
        
        TextMeshProUGUI[] texts = buttonObj.GetComponentsInChildren<TextMeshProUGUI>();
        
        // Build detailed string
        string detailText = $"{evt.name}\n" +
                           $"📅 {evt.date} | ⏰ {evt.time}\n" +
                           $"📍 {evt.location}\n" +
                           $"{evt.description}";
        
        if (texts.Length > 0)
        {
            texts[0].text = detailText;
        }

        Button btn = buttonObj.GetComponent<Button>();
        if (btn != null)
        {
            string eventId = evt.id;
            btn.onClick.AddListener(() => OnEventClick(eventId));
        }

        buttonObj.SetActive(true);
        instantiatedButtons.Add(buttonObj);
        
        Debug.Log($"Created event button: {evt.name}");
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