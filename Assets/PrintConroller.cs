using UnityEngine;

public class PrintConroller : MonoBehaviour
{
    [SerializeField] private CustomRenderTexture _texture;
    [SerializeField] private Material _material;

    private Color _color;

    private void Awake()
    {
        _texture.Initialize();
        _color = new Color(1, 1, 1, 1);
    }

    private void Update()
    {
        _texture.Update();

        if (Input.GetMouseButton(0))
        {
            _material.SetVector("_DrawPosition", Camera.main.ScreenToViewportPoint(Input.mousePosition));
        }
        else
        {
            _material.SetVector("_DrawPosition", -Vector2.one);
        }
    }
} 
