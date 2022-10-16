//using Common.Audio;
//using Utilites;
using Common.ControlMenu;
using UnityEngine;
using UnityEngine.UI;


//Отвечает за действиz на  кнопки из MainMenu
namespace Common.Menu
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField]
        private Button startButton;
        
        
        [SerializeField]
        private Button quitButton;
        
        [SerializeField]
        private Button settingsButton;
        
        
        private void Start()
        {
            startButton.onClick.AddListener(HandleStartClicked);
            quitButton.onClick.AddListener(HandleQuitClicked);
            settingsButton.onClick.AddListener(HandleSettingClicked);
            
        }

        private void HandleStartClicked()
        {
           // AudioController.Instance.Play(Utils.ButtonSound);
            gameObject.SetActive(false);
           //SceneLoader.Instance.slider.gameObject.SetActive(true);
            SceneLoader.Instance.LoadScene(1);
            
            
        }
        
    
        private void HandleQuitClicked()
        {
            //AudioController.Instance.Play(Utils.ButtonSound);
            MainMenuController.Instance.Exit();
        }
    
        private void HandleSettingClicked()
        {
            //AudioController.Instance.Play(Utils.ButtonSound);
            MainMenuController.Instance.EnableSettings();
            gameObject.SetActive(false);
        }
    
        
    }
}
