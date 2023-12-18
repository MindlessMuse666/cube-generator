using UnityEngine;
using Random = UnityEngine.Random;

public class RecoloringBehaviour : MonoBehaviour
{
    [SerializeField] private float _recoloringDuration = 2f;
    [SerializeField] private float _delayDuration = 2f;

    private Color _startColor;
    private Color _nextColor;
    private Renderer _renderer;
    private float _recoloringTime;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        GenerateNextColor();
    }

    private void GenerateNextColor()
    {
        _startColor = _renderer.material.color;
        _nextColor = Random.ColorHSV(0f, 1f, 0.8f, 1f, 1f, 1f);
    }

    private void Update()
    {
        _recoloringTime += Time.deltaTime;

        var progress = _recoloringTime / _recoloringDuration;
        var currentColor = Color.Lerp(_startColor, _nextColor, progress);

        _renderer.material.color = currentColor;

        if (_recoloringTime >= _recoloringDuration + _delayDuration)
        {
            _recoloringTime = 0;
            GenerateNextColor();
        }
    }
}