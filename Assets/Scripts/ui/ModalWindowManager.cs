using System;
using control;
using model;
using UnityEngine;

namespace ui
{
    public class ModalWindowManager : MonoBehaviour
    {
        private static ModalWindowManager _instance;

        public static ModalWindowManager Instance()
        {
            return _instance;
        }

        public DirectionChoicePanel DirectionChoicePanel;
        public SkillChoicePanel SkillChoicePanel;
        private GameObject current;

        private void Awake()
        {
            _instance = this;
        }

        public void ShowDirectionChoice(Order order, Vector3 position)
        {
            CloseOpenChoice();
            current = DirectionChoicePanel.gameObject;
            DirectionChoicePanel.Show(direction => order.Direction = direction);
            DirectionChoicePanel.transform.position = position;
        }

        public void ShowSkillChoice(Order order, Hero hero, Vector3 position)
        {
            CloseOpenChoice();
            current = SkillChoicePanel.gameObject;
            SkillChoicePanel.Show(hero, skill => { order.Skill = skill; });
            SkillChoicePanel.transform.position = position;
        }


        private void CloseOpenChoice()
        {
            if (current != null)
            {
                current.SetActive(false);
                current = null;
            }
        }
    }
}