using System;
using System.Collections;
using System.Collections.Generic;
using model;
using scriptableObject;
using UnityEngine;
using view;
using Animation = animation.Animation;

public abstract class Character
{
    public Vector2Int Position;
    public CharacterSo CharacterSo;
    public bool Friend;
    public int maxHp;
    public int hp;
    public CharacterView View;

    public Character(Vector2Int position, CharacterSo characterSo, bool friend = false)
    {
        Position = position;
        CharacterSo = characterSo;
        Friend = friend;
        maxHp = characterSo.maxHp;
        hp = maxHp;
    }

    public void TakeDamage(State state, int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Die(state);
        }
    }

    public void SetView(CharacterView view)
    {
        View = view;
    }

    private void Die(State state)
    {
        state.Board.Characters.Remove(this);
    }


    public abstract List<Animation> Act(State state);

    public abstract Character Copy();
}