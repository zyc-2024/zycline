using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class FPS : MonoBehaviour
{
    TextMeshProUGUI textUI;
    int frameCount;
    float timer;

    void Awake() => textUI = GetComponent<TextMeshProUGUI>();

    void Update()
    {
        frameCount++;
        timer += Time.unscaledDeltaTime;
        if (timer >= 1f)
        {
            textUI.SetText("FPS: {0:0}", frameCount / timer);
            frameCount = 0;
            timer = 0f;
        }
    }
}