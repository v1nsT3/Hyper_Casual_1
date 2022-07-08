using UnityEngine;

public class ButtonPause : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;

    public void PausePanelActivate()
    {
        _pausePanel.SetActive(true);
    }
}
