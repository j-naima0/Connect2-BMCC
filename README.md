# Connect2 BMCC Mobile App

A Unity-based mobile application designed to connect BMCC students with campus resources, mentorship programs, scholarships, and events.

**Course:** CIS 272 - Mobile App Development  
**Professor:** Hao Tang  
**Institution:** Borough of Manhattan Community College (BMCC)  
**Semester:** Fall 2024

## 👥 Team Members
- **Jannatul Naima** - Login System, Main Menu, Campus Events
- **Imranul Rizvee** - Mentorship Programs, Scholarships, Data Management

## 📱 About the Project

Connect2 BMCC is a comprehensive mobile application that serves as a central hub for BMCC students to access:
- Mentorship programs
- Scholarship opportunities
- Campus events
- Academic support resources
- Student services

## ✨ Features

### Completed Features (Week 2-3)

#### Authentication & Navigation
- Username/password login with validation
- Microsoft SSO integration (simulated)
- Session management using PlayerPrefs
- Multi-language support (English, Spanish, Chinese, French)
- Seamless navigation between all app sections

#### Mentorship Programs
- Dynamic program display from JSON database
- Scrollable program list
- Program selection and storage
- Currently featuring:
  - Crear Futuros
  - Impact Peer Mentoring
  - College Discovery Program

#### Scholarships
- JSON-based scholarship database
- Scrollable scholarship list
- Dynamic data loading

#### Campus Events
- Event calendar with scrollable cards
- JSON database integration
- Event titles and dates display

#### Data Management
- Singleton DataManager pattern
- Cross-scene data persistence with DontDestroyOnLoad
- JSON-based database system
- PlayerPrefs for user sessions and preferences

## 🛠️ Technical Stack

- **Engine:** Unity 2022.3+ (or specify your version)
- **Language:** C#
- **Data Storage:** JSON, PlayerPrefs
- **Platform:** Android/iOS (Mobile)

## 📂 Project Structure

```
Assets/
├── Scenes/
│   ├── Login
│   ├── MainMenu
│   ├── MentorshipPrograms
│   ├── Scholarships
│   └── CampusEvents
├── Scripts/
│   ├── LoginManager.cs
│   ├── MainMenuManager.cs
│   ├── MentorshipProgramsManager.cs
│   ├── DataManager.cs
│   └── [Other managers]
├── Data/
│   └── [JSON database files]
└── UI/
    └── [UI prefabs and assets]
```

## 🚀 Getting Started

### Prerequisites
- Unity 2022.3 or later
- Git

### Installation

1. Clone the repository
```bash
git clone https://github.com/yourusername/connect2-bmcc.git
```

2. Open the project in Unity
```bash
cd connect2-bmcc
# Open with Unity Hub or Unity Editor
```

3. Open the Login scene to start
```
Assets/Scenes/Login.unity
```

4. Press Play to test the application

### Default Test Credentials
- Username: `student`
- Password: `password`

## 🧪 Testing

### Manual Test Cases

All test cases are documented in the weekly reports:
- **Week 2:** TC-001 through TC-012 (Login, Main Menu, Mentorship)
- **Week 3:** TC-013 through TC-018 (Integration & Navigation)

### Running Tests
1. Start from the Login scene
2. Navigate through the flow: Login → Main Menu → [Any Category]
3. Test back navigation
4. Verify data persistence across scenes

## 📋 Roadmap

### Week 4 (Upcoming)
- [ ] Fix Scholarship back button navigation
- [ ] Fix Scholarship list UI layout
- [ ] Add Program/Scholarship detail pages
- [ ] Enhance JSON database structure
- [ ] Improve UI consistency across scenes
- [ ] Begin chatbot response logic
- [ ] Add user profile page

### Future Enhancements
- [ ] Actual Microsoft authentication integration
- [ ] Backend API integration
- [ ] Search and filter functionality
- [ ] Image/icon support for programs and events
- [ ] Push notifications for events
- [ ] User favorites and bookmarks
- [ ] Expanded database (10+ programs)

## 🐛 Known Issues

1. **Scholarship Back Button** - Not responding, needs rebinding to MainMenuManager
2. **Scholarship List Layout** - Items misaligned, Layout Group needs configuration
3. **JSON Database** - Limited fields, needs expansion (descriptions, contact info, images)

## 📝 Development Notes

### Key Design Patterns
- **Singleton Pattern:** Used for DataManager to ensure single instance across scenes
- **DontDestroyOnLoad:** Maintains data persistence during scene transitions
- **Dynamic UI:** All lists populate from JSON at runtime

### Data Persistence Strategy
- **PlayerPrefs:** User sessions, language preferences, selected programs
- **DataManager:** Program/scholarship/event data structures
- **JSON Files:** Database for all content

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the LICENSE file for details.

## 📞 Contact

- **Jannatul Naima** - jannatul.naima18@stu.bmcc.cuny.edu
- **Imranul Rizvee** - rizvee285@gmail.com

Project Link: [https://github.com/yourusername/connect2-bmcc](https://github.com/yourusername/connect2-bmcc)

## 🙏 Acknowledgments

**Course:** CIS 272 - Mobile App Development (Fall 2024)  
**Professor:** Hao Tang  
**Last Updated:** December 2024  
