using UnityEngine;
using UnityEngine.UI;

public class QualitySetting : MonoBehaviour
{
    public Text shower;
    [HideInInspector] public string vl = "Very Low", l = "Low", m = "Medium", h = "High", vh = "Very High", u = "Ultra";
  [HideInInspector]  public int id;
    // Start is called before the first frame update
    void Start()
    {
        id = QualitySettings.GetQualityLevel()+1;
    }
    public void click()
    {
        id += 1;
    }
    // Update is called once per frame
    void Update()
    {
        if(id<=1)
        {
            QualitySettings.SetQualityLevel(0);
            shower.text = "Quality: " + vl;
        }
        if (id == 2)
        {
            QualitySettings.SetQualityLevel(1);
            shower.text = "Quality: " + l;
        }
        if (id == 3)
        {
            QualitySettings.SetQualityLevel(2);
            shower.text = "Quality: " + m;
        }
        if (id ==4)
        {
            QualitySettings.SetQualityLevel(3);
            shower.text = "Quality: " + h;
        }
        if (id == 5)
        {
            QualitySettings.SetQualityLevel(4);
            shower.text = "Quality: " + vh;
        }
        if (id >= 6)
        {
            QualitySettings.SetQualityLevel(5);
            shower.text = "Quality: " + u;
        }
        if(id>6)
        {
            id = 1;
        }
        if(id<1)
        {
            id = 1;
        }
    }
}
