using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ToggleColorController : MonoBehaviour
{
    public Toggle toggle;
    public Image toggleBackground;

    void Start()
    {
        // Listener'ı ekliyoruz ve mevcut duruma göre rengi ayarlıyoruz
        toggle.onValueChanged.AddListener(delegate { ToggleValueChanged(toggle); });
        UpdateToggleColor(toggle.isOn);
    }

    void ToggleValueChanged(Toggle change)
    {
        UpdateToggleColor(change.isOn);
    }

    void UpdateToggleColor(bool isOn)
    {
        if (isOn)
        {
            toggleBackground.color = Color.red; // Kırmızı renk (selected)
        }
        else
        {
            toggleBackground.color = Color.green; // Yeşil renk (deselected)
        }
    }
}
