using System;
using model;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ui
{
    public class SkillChoice : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        private Skill _skill;
        private Color _defaultColor;
        private Color _highlightColor = Color.yellow;
        private Image _frameImage;

        public static SkillChoice CreateSkillChoice(Skill skill, Transform parent)
        {
            var gameObject = (GameObject) Instantiate(Resources.Load("SkillChoice"), parent);
            SkillChoice skillChoice = gameObject.GetComponent<SkillChoice>();
            skillChoice.SyncWithModel(skill);
            return skillChoice;
        }

        public void SyncWithModel(Skill skill)
        {
            _skill = skill;
            _frameImage = transform.GetChild(0).GetComponent<Image>();
            transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = skill.image;
            _defaultColor = _frameImage.color;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _frameImage.color = _highlightColor;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _frameImage.color = _defaultColor;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            GetComponentInParent<SkillChoicePanel>().ReportChoice(_skill);
        }
    }
}