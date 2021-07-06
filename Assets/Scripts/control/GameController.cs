using System;
using System.Collections.Generic;
using animation;
using model;
using scriptableObject;
using UnityEngine;
using view;
using Animation = animation.Animation;

namespace control
{
    public class GameController : MonoBehaviour
    {
        private static GameController _instance;

        public static GameController Instance()
        {
            return _instance;
        }

        public State State { get; private set; }
        // public State UiState { get; private set; }

        private AnimationController _animationController;

        private HeroSo BearSo;
        private HeroSo MouseSo;
        private HeroSo FrogSo;
        private Move Move;
        private Attack Attack;
        private Wait Wait;
        private Direction Up;
        private Direction Down;
        private Direction Left;
        private Direction Right;

        private void Load()
        {
            BearSo = Resources.Load<HeroSo>("Character/Bear");
            MouseSo = Resources.Load<HeroSo>("Character/Mouse");
            FrogSo = Resources.Load<HeroSo>("Character/Frog");
            Move = Resources.Load<Move>("Skill/Move");
            Attack = Resources.Load<Attack>("Skill/Attack");
            Wait = Resources.Load<Wait>("Skill/Wait");
            Up = Resources.Load<Direction>("Direction/Up");
            Down = Resources.Load<Direction>("Direction/Down");
            Left = Resources.Load<Direction>("Direction/Left");
            Right = Resources.Load<Direction>("Direction/Right");
        }

        private void Start()
        {
            _animationController = AnimationController.Instance();
        }

        private void Awake()
        {
            _instance = this;
            Load();
            Init();
        }

        private void Init()
        {
            var bearOrders = new List<Order>()
                {Order.from(Move, Up), Order.from(Attack, Right)};
            var bear = new Hero(new Vector2Int(0, 0), BearSo, bearOrders);
            var mouseOrders = new List<Order>()
                {Order.from(Attack, Up), Order.from(Move, Right), Order.from(Wait, Right), Order.from(Wait, Right)};
            var mouse = new Hero(new Vector2Int(1, 0), MouseSo, mouseOrders);
            var frogOrders = new List<Order>()
                {Order.from(Move, Left), Order.from(Move, Up), Order.from(Wait, Right)};
            var frog = new Hero(new Vector2Int(2, 0), FrogSo, frogOrders);
            var walker = new Walker(new Vector2Int(7, 7));
            var board = new Board(new Vector2Int(8, 11), new List<Character>() {bear, mouse, frog, walker});
            State = new State(board);
            // UiState = State.Copy();

            CreateViews();
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Space) && _animationController.Finished())
            {
                _animationController.Show(GenerateActions());
            }
        }

        private List<Animation> GenerateActions()
        {
            List<Animation> animations = new List<Animation>();
            int currentCharacterIndex = 0;
            while (currentCharacterIndex < State.Board.Characters.Count)
            {
                var currentCharacter = State.Board.Characters[currentCharacterIndex];
                currentCharacterIndex += 1;
                animations.AddRange(currentCharacter.Act(State));
            }

            return animations;
        }

        private void CreateViews()
        {
            var characterParent = transform.Find("Characters");
            State.Board.Characters.ForEach(character =>
            {
                CharacterView.CreateCharacterView(character, characterParent);
            });
        }
    }
}