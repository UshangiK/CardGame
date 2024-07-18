using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

namespace DefaultNamespace
{
    public class SaveTemplate
    {
        public int CardRows;
        public int CardColumns;
        public int Score;
        public int Turn;
        public List<CardSave> CardList;

        public SaveTemplate(int score, int turn, int cardRows, int cardColumns, List<CardSave> cardList)
        {
            Score = score;
            Turn = turn;
            CardRows = cardRows;
            CardColumns = cardColumns;
            CardList = cardList;
        }

        public override string ToString() => "Save Template: cardColums: " + CardColumns + " CardRows: " + CardRows +
                                             " Score: " + Score + "Turns: " + Turn;
    }

    public class CardSave
    {
        public int ID;
        public SimplePosition Position;

        public CardSave(int id, Vector3 position)
        {
            ID = id;
            Position = new SimplePosition(position.x, position.y, position.z);
        }

        public class SimplePosition
        {
            public float X;
            public float Y;
            public float Z;

            public SimplePosition(float X, float Y, float Z)
            {
                this.X = X;
                this.Y = Y;
                this.Z = Z;
            }

            public static implicit operator Vector3(SimplePosition simplePosition)
            {
                return new Vector3(simplePosition.X, simplePosition.Y, simplePosition.Z);
            }
        }
    }
}