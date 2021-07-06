using System;
using model;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ui
{
    public class DirectionChoice : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public Direction direction;
        private Color _defaultColor;
        private Color _highlightColor = Color.yellow;
        private Image _image;

        private void Awake()
        {
            _image = GetComponent<Image>();
            _defaultColor = _image.color;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _image.color = _highlightColor;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _image.color = _defaultColor;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            GetComponentInParent<DirectionChoicePanel>().ReportChoice(direction);
        }

        public void LowLight()
        {
            _image.color = _defaultColor;
        }
    }
}