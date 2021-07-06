using System;
using model;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ui
{
    public class DirectionView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        private Image _image;
        private Order _order;
        private Direction _direction;
        private Color _defaultColor;
        private Color _selectionColor;
        private bool _selected;

        private void Awake()
        {
            _image = GetComponent<Image>();
            _defaultColor = _image.color;
            _selectionColor = Color.yellow;
        }

        private void Update()
        {
            UpdateDirectionChange();
        }

        private void UpdateDirectionChange()
        {
            _direction = _order?.Direction;
            _image.sprite = _direction != null ? _direction.image : null;
            UpdateColor();
        }

        public void SyncWithModel(Order order)
        {
            _order = order;
            UpdateDirectionChange();
        }

        private void UpdateColor()
        {
            _image.color = _direction == null ? Color.clear : _selected ? _selectionColor : _defaultColor;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _selected = true;
            UpdateColor();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _selected = false;
            UpdateColor();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            ModalWindowManager.Instance().ShowDirectionChoice(_order, transform.position);
        }
    }
}