using UnityEngine;
using UnityEngine.UI;

public class ColorBlink : MonoBehaviour
{
    Text _text;
    float _color;
    float _step;
    float _time;
    
    [SerializeField] Color _startColor;
    [SerializeField] Color _endColor;

    void Start()
    {
        Debug.Log(message: "Start");
    }
    private void Awake()
    {
        Debug.Log(message: "Awake");
        _text = GetComponent<Text>();
        _step = 1;
        _color = 89;
        _time = 0;
    }
    void Update()
    {
        _time += Time.deltaTime * _step * 0.44f;
        Color _newColor = Color.Lerp(_startColor, _endColor, _time);
        if (_newColor == _endColor && _step == 1)
        {
            _step = -1;
        }
        if (_newColor == _startColor && _step == -1)
        {
            _step = 1;
        }
        
        _text.color = _newColor;
    }
}
