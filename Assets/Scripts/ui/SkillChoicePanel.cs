using System;
using model;
using UnityEngine;

namespace ui
{
    public class SkillChoicePanel : MonoBehaviour
    {
        private Action<Skill> _callback;

        public void Show(Hero hero, Action<Skill> callback)
        {
            Clear();
            foreach (var skill in hero.PossibleSkills)
            {
                SkillChoice.CreateSkillChoice(skill, transform);
            }

            gameObject.SetActive(true);
            _callback = callback;
        }

        public void ReportChoice(Skill skill)
        {
            _callback.Invoke(skill);
            Hide();
        }

        private void Clear()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}