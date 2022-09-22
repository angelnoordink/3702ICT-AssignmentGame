using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Wire : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler  {

    private Image _image;
    private LineRenderer _lineRenderer;

    private Canvas _canvas;

    private bool _isDragStarted = false;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _lineRenderer = GetComponent<LineRenderer>();
        _canvas = GetComponentInParent<Canvas>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(_isDragStarted) {
            Debug.Log("Moving");
            Vector2 movePos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _canvas.transform as RectTransform,
                Input.mousePosition,
                _canvas.worldCamera,
                out movePos);

            _lineRenderer.SetPosition(0, transform.position);
            _lineRenderer.SetPosition(1, _canvas.transform.TransformPoint(movePos));
            
        }    
    }

    public void SetColor(Color color)
    {
        _image.color = color;
    }

    public void OnDrag(PointerEventData eventData){
        // This is never used but is needed for drag to prevent error
    }

    
    public void OnBeginDrag(PointerEventData eventData){
        _isDragStarted = true;
    }

    public void OnEndDrag(PointerEventData eventData){
        _isDragStarted = false;
    }
}
