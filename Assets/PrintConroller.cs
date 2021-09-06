using UnityEngine;

public class PrintConroller : MonoBehaviour
{
    [SerializeField] private CustomRenderTexture _texture;
    [SerializeField] private Material _material;

    [SerializeField] private float _drawSize;

    private void Awake()
    {
        _texture.Initialize();

        if (_drawSize == 0)
            _drawSize = 0.01f;

        _material.SetFloat("_DrawSize", _drawSize);
    }

    private void Update()
    {
        _texture.Update();
                
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            Vector3 vector = hit.point;

            if (Input.GetMouseButton(0))
            {
                vector.x = (vector.x / transform.localScale.x) + 0.5f;
                vector.y = (vector.y / transform.localScale.y) + 0.5f;

                _material.SetVector("_DrawPosition", vector);
            }
            else
            {
                _material.SetVector("_DrawPosition", -Vector2.one);
            }
        }
    }
} 
