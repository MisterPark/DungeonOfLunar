using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour,IPointerDownHandler,IPointerUpHandler,IDragHandler
{
    [SerializeField] private RectTransform pad;
    [SerializeField] private RectTransform handle;
    [SerializeField] private GameObject player;

    private float radius;

    public bool IsTouch { get; private set; }
    public float Speed { get; private set; }
    public Vector3 Direction { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        radius = pad.rect.width * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos = eventData.position - (Vector2)pad.transform.position;
        pos = Vector2.ClampMagnitude(pos, radius);
        handle.localPosition = pos;
        
        Speed = Vector2.Distance(pad.position, handle.position) / radius;
        Direction = new Vector3(pos.x, 0f, pos.y);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        IsTouch = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        IsTouch = false;
        handle.localPosition = Vector3.zero;
        Speed = 0f;
        Direction = Vector3.zero;
    }
}
