using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ToggleSaver : MonoBehaviour
{
    public Toggle toggle;
    public bool DisplayLogonStart = false;
    public bool DisplayLogonSave = false;

    private string id;
    private string key;

    void Start()
    {
        id = SceneManager.GetActiveScene().name;

        if (toggle == null) return;

        key = toggle.name + id;
        toggle.onValueChanged.AddListener(s => Togglechanged());

        if (PlayerPrefs.HasKey(key))
        {
            toggle.isOn = PlayerPrefs.GetInt(key) == 1;
            if (DisplayLogonStart)
                Debug.Log("Load_" + toggle.name + ": " + toggle.isOn);
        }

    }

    void Togglechanged()
    {
        if (toggle != null)
        {
            PlayerPrefs.SetInt(key, toggle.isOn ? 1 : 0);
            if (DisplayLogonSave)
                Debug.Log("Save_" + toggle.name + ": " + toggle.isOn);
        }

        PlayerPrefs.Save();
    }

    void OnDestroy()
    {
        toggle.onValueChanged.RemoveListener(k => Togglechanged());
    }
}
