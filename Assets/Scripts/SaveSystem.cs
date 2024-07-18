using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using Newtonsoft.Json;
using UnityEngine;

namespace DefaultNamespace
{
    public static class SaveSystem
    {
        private static string _dataPath = Application.persistentDataPath;
        public static void SaveToFile(int score, int turn, int cardRows, int cardColumns, List<Card> cardList)
        {
            List<CardSave> cardSaves = new List<CardSave>();
            foreach (var card in cardList)
            {
                CardSave cardSave = new CardSave(card.ID, card.transform.position);
                cardSaves.Add(cardSave);
            }

            SaveTemplate saveTemplate = new SaveTemplate(score, turn, cardRows, cardColumns, cardSaves);
            
            Thread saveCardThread = new Thread(() =>
            {
                string saveString = JsonConvert.SerializeObject(saveTemplate);
                using StreamWriter outputFile = new StreamWriter(Path.Combine(_dataPath, "WriteLines.txt"));
                outputFile.WriteLine(saveString);
                outputFile.Close();
            });
            
            saveCardThread.Start();
        }
            
        public static SaveTemplate ReadFromFile()
        {
            using StreamReader reader = new StreamReader(Path.Combine(_dataPath, "WriteLines.txt"));
            var resultString = reader.ReadToEnd();
            SaveTemplate readTemplate = JsonConvert.DeserializeObject<SaveTemplate>(resultString);

            return readTemplate;
        }
    }
}