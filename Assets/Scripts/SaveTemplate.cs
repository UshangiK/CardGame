using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

namespace DefaultNamespace
{
    public class SaveTemplate
    {
        public int _cardRows;
        public int _cardColumns;
        public int _score;
        public int _turn;
        public List<CardSave> _cardList;

        public SaveTemplate(int score, int turn, int cardRows, int cardColumns, List<CardSave> cardList)
        {
            _score = score;
            _turn = turn;
            _cardRows = cardRows;
            _cardColumns = cardColumns;
            _cardList = cardList;
        }

        public override string ToString() => "Save Template: cardColums: " + _cardColumns + " CardRows: " + _cardRows +
                                             " Score: " + _score + "Turns: " + _turn;
    }

    public class CardSave
    {
        public int _id;
        public SimplePosition _position;

        public CardSave(int id, Vector3 position)
        {
            _id = id;
            _position = new SimplePosition(position.x, position.y, position.z);
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