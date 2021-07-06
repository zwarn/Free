using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace model
{
    public class Board
    {
        public Vector2Int Size;
        public List<Character> Characters;

        public Board(Vector2Int size, List<Character> characters)
        {
            this.Size = size;
            Characters = characters;
        }

        public List<Hero> GetHeroes()
        {
            return Characters.OfType<Hero>().ToList();
        }

        public Board Copy()
        {
            return new Board(Size, Characters.Select(chara => chara.Copy()).ToList());
        }
    }
}