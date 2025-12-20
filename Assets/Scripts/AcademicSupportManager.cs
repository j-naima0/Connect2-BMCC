using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections.Generic;

public class AcademicSupportManager : MonoBehaviour
{
    [Header("UI References")]
    public GameObject supportButtonPrefab;
    public Transform supportListContainer;
    public Button backButton;

    private List<GameObject> instantiatedButtons = new List<GameObject>();

    private void Start()
    {
        if (backButton != null)
            backButton.onClick.AddListener(OnBackToMenu);

        Invoke("DisplaySupport", 0.1f);
    }

    private void DisplaySupport()
{
    if (DataManager.Instance == null) return;

    foreach (GameObject btn in instantiatedButtons)
    {
        if (btn != null) Destroy(btn);
    }
    instantiatedButtons.Clear();

    List<AcademicSupport> supportServices = DataManager.Instance.academicSupport;
    
    Debug.Log($"Loading {supportServices.Count} support services from database");

    foreach (AcademicSupport support in supportServices)
    {
        GameObject buttonObj = Instantiate(supportButtonPrefab, supportListContainer);
        
        TextMeshProUGUI[] texts = buttonObj.GetComponentsInChildren<TextMeshProUGUI>();
        
        // Build detailed string
        string detailText = $"{support.name}\n" +
                           $"📍 {support.location}\n" +
                           $"⏰ {support.hours}\n" +
                           $"Services: {support.services}";
        
        if (texts.Length > 0)
        {
            texts[0].text = detailText;
        }

        buttonObj.SetActive(true);
        instantiatedButtons.Add(buttonObj);
    }

    Canvas.ForceUpdateCanvases();
    LayoutRebuilder.ForceRebuildLayoutImmediate(supportListContainer.GetComponent<RectTransform>());
}

    private void OnBackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}