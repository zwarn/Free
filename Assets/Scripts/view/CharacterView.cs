using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace view
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class CharacterView : MonoBehaviour
    {
        private Character _model;
        private SpriteRenderer _spriteRenderer;

        public static CharacterView CreateCharacterView(Character model, Transform parent)
        {
            var gameObject = (GameObject) Instantiate(Resources.Load("Character"), parent, true);
            CharacterView characterView = gameObject.GetComponent<CharacterView>();
            characterView._spriteRenderer = characterView.GetComponent<SpriteRenderer>();
            characterView.SetModel(model);
            return characterView;
        }

        private void OnDestroy()
        {
            // _model.OnCharacterDeath -= OnCharacterDeath;
        }

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void SetModel(Character model)
        {
            _model = model;
            SyncWithModel();
            model.SetView(this);
            // model.OnCharacterDeath += OnCharacterDeath;
        }

        public void SyncWithModel()
        {
            _spriteRenderer.sprite = _model.CharacterSo.Sprite;
            transform.localPosition = (Vector2) _model.Position;
        }

        private void Update()
        {
            // SyncWithModel();
        }

        private void OnCharacterDeath()
        {
            Destroy(gameObject);
        }
    }
}