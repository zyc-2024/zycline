using UnityEngine;
using UnityEngine.UI;

public class tips : MonoBehaviour
{
    private float time;
    private int inx;
    public Text text;
    public int SwitchingDuration = 6;
    public string Head = "Tips:";
    public string[] Tips;

    void Start()
    {
        text = this.GetComponent<Text>();
        if (Tips != null && Tips.Length > 0)
        {
            inx = Random.Range(0, Tips.Length);
            text.text = Head + Tips[inx];
        }
        else
        {
            text.text = Head + " No tips available.";
        }
    }

    void Update()
    {
        time += Time.deltaTime;

        if (time >= SwitchingDuration)
        {
            SwitchToRandomTip();
        }
    }

    private void SwitchToRandomTip()
    {
        if (Tips == null || Tips.Length <= 1)
        {
            time = 0;
            return;
        }

        int newInx;
        do
        {
            newInx = Random.Range(0, Tips.Length);
        } while (newInx == inx);

        inx = newInx;
        text.text = Head + Tips[inx];
        time = 0;
    }

    public void ShowCurrentTip()
    {
        if (text != null && Tips != null && Tips.Length > 0 && inx >= 0 && inx < Tips.Length)
        {
            text.text = Head + Tips[inx];
        }
    }
}