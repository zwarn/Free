using System;
using System.Collections.Generic;
using control;
using model;
using UnityEngine;

namespace ui
{
    public class UIController : MonoBehaviour
    {
        private static UIController _instance;

        public static UIController Instance()
        {
            return _instance;
        }

        public Sprite up;
        public Sprite down;
        public Sprite left;
        public Sprite right;
        private Dictionary<Direction, Sprite> _dictionary;

        private void Awake()
        {
            _instance = this;
        }

        private void Start()
        {
            var state = GameController.Instance().State;
            var heroes = state.Board.GetHeroes();
            var heroesPanel = GetComponentInChildren<HeroesPanelView>();
            heroesPanel.SyncWithModel(heroes);
        }
    }
}