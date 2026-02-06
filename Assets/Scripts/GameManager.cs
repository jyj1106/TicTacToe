using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject settingsPanelPrefab;
    [SerializeField] private Canvas canvas;

    protected override void OnSceneLoad(Scene scnene, LoadSceneMode mode)
    {
        
    }

    public void OpenSettingsPanel()
    {
        var settingGamePanelObject = Instantiate(settingsPanelPrefab, canvas.transform);
        settingGamePanelObject.GetComponent<SettingsPanelController>().Show();
    }
}
