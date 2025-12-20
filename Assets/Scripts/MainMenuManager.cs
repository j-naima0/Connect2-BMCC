using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    [Header("UI References")]
    public Button mentorshipButton;
    public Button scholarshipButton;
    public Button academicSupportButton;
    public Button campusEventsButton;
    public Button pantherStationButton;
    public TMP_InputField chatInput;
    public Button sendMessageButton;
    public TMP_Dropdown languageDropdown;

    [Header("Scene Names")]
    public string mentorshipScene = "MentorshipPrograms";
    public string scholarshipScene = "Scholarship";
    public string academicScene = "AcademicSupport";
    public string eventsScene = "CampusEvents";
    public string pantherStationScene = "PantherStation";

    private void Start()
    {
        mentorshipButton.onClick.AddListener(() => LoadScene(mentorshipScene));
        scholarshipButton.onClick.AddListener(() => LoadScene(scholarshipScene));
        academicSupportButton.onClick.AddListener(() => LoadScene(academicScene));
        campusEventsButton.onClick.AddListener(() => LoadScene(eventsScene));
        pantherStationButton.onClick.AddListener(() => LoadScene(pantherStationScene));
        sendMessageButton.onClick.AddListener(OnSendMessage);

        languageDropdown.onValueChanged.AddListener(OnLanguageChanged);

        string username = PlayerPrefs.GetString("CurrentUser", "Student");
        Debug.Log($"Welcome back, {username}!");
    }

    private void LoadScene(string sceneName)
    {
        PlayerPrefs.SetString("LastCategory", sceneName);
        PlayerPrefs.Save();
        
        Debug.Log($"Loading scene: {sceneName}");
        SceneManager.LoadScene(sceneName);
    }

    private void OnSendMessage()
    {
        string message = chatInput.text.Trim();
        
        if (!string.IsNullOrEmpty(message))
        {
            Debug.Log($"Chat message: {message}");
            chatInput.text = "";
        }
    }

    private void OnLanguageChanged(int index)
    {
        string[] languages = { "English", "Spanish", "Chinese", "French" };
        string selectedLanguage = languages[index];
        
        PlayerPrefs.SetString("SelectedLanguage", selectedLanguage);
        PlayerPrefs.Save();
        
        Debug.Log($"Language changed to: {selectedLanguage}");
    }

    public void OnLogout()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Login");
    }
}