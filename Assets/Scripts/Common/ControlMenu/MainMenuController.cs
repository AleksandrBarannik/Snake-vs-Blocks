using Common.Menu;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Common.ControlMenu
{
    public class MainMenuController : MonoBehaviour
    {
        public static MainMenuController Instance;
        
        [SerializeField]
        private MainMenu mainMenu;
        
        [SerializeField]
        private SettingsMenu settingsMenu;
        
        
        private void Awake()
        {
            Instance = this;
        }
        
        
        public void Exit()
        {
            Application.Quit();
        }

        public void EnableSettings()
        {
            settingsMenu.gameObject.SetActive(true);
        }
        
        public void EnableMainMenu()
        {
            mainMenu.gameObject.SetActive(true);
        }
        
        
        
        

        
        
    }
}
