using System;
using model;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ui
{
    public class SkillView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        private Image image;
        private Image parentImage;
        private Order _order;
        private Hero _hero;
        private Color _defaultColor;
        private Color _selectionColor;
        private bool _selected;

        private void Awake()
        {
            image = GetComponent<Image>();
            parentImage = transform.parent.GetComponent<Image>();
            _defaultColor = parentImage.color;
            _selectionColor = Color.yellow;
        }

        private void Update()
        {
            UpdateSkill();
        }

        public void SyncWithModel(Order order, Hero hero)
        {
            _order = order;
            _hero = hero;
            UpdateSkill();
        }

        private void UpdateSkill()
        {
            image.sprite = _order.Skill.image;
            UpdateColor();
        }

        private void UpdateColor()
        {
            parentImage.color = _selected ? _selectionColor : _defaultColor;
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
            ModalWindowManager.Instance().ShowSkillChoice(_order, _hero, transform.position);
        }
    }
}