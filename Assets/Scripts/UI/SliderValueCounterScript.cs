using UnityEngine;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(TMP_Text))]
public class SliderValueCounterScript : MonoBehaviour
{
    private TMP_Text _text;
    
    [SerializeField, Tooltip("The slider that it should take the value from.")]
    private Slider slider;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _text = GetComponent<TMP_Text>();
        if (_text != null)
        {
            if (slider != null)
                _text.SetText(slider.value.ToString());
            else
                _text.SetText("Null.");
        }
    }

    public void ChangeCounter()
    {
        if (slider != null)
            _text.SetText(slider.value.ToString());
    }
}
