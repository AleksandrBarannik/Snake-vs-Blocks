using System.Collections;
using System.Collections.Generic;
using Common;
using Common.ControlMenu;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameStatusWindow : MonoBehaviour
{
    public static GameStatusWindow Instance;

        [Header("Event")] 
        public UnityEvent onLose;
        
        [Header("Objects links")]
        
       [SerializeField]
        private Button restartButtonLose;
        
        [SerializeField]
        private Button buttonLoadMainMenu;
        
        
        [SerializeField]
        private GameObject screenLose;

        
        private void Awake()
        {
            Instance = this;
        }
        
        private void Start()
        {
            restartButtonLose.onClick.AddListener(HandleRestartClicked);
            buttonLoadMainMenu.onClick.AddListener(HandleLoadMainMenuClicked);
        }

        private void HandleRestartClicked()
        {
            SceneLoader.Instance.ReloadScene();
            PauseHandler.Instance.Play();
            
        }

        
        private void HandleLoadMainMenuClicked()
        {
            SceneLoader.Instance.LoadScene(0);
            
        }

       
        public void EnableLoseScreen()
        {
            screenLose.gameObject.SetActive(true);
            onLose.Invoke();
        }
}
