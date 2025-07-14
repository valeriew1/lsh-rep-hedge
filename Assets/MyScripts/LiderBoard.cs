using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.MyScripts
{
    internal class LiderBoard
    {
        private static string Path => $"{Application.persistentDataPath}/save.json";

        private static void SaveData(ScoreData data)
        {
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(Path, json);
        }

        private static ScoreData LoadData()
        {
            if (File.Exists(Path))
            {
                string json = File.ReadAllText(Path);
                return JsonUtility.FromJson<ScoreData>(json);
            }
            return new ScoreData();
        }

        public static void AddScore(string name, int score)
        {
            var data = LoadData();
            data.entries.Add(new ScoreEntry(name, score));

            SaveData(data);
        }

        public static List<ScoreEntry> GetScores()
        {
            return LoadData().entries.OrderByDescending(entry => entry.score).ToList();



        }



        public static ScoreEntry GetLastEntry() 
        {
            return LoadData().entries.LastOrDefault();

        }   


    }

    [Serializable]
    public class ScoreEntry
    {
        public string name;
        public int score;

        public ScoreEntry(string name, int score)
        {
            this.name = name;
            this.score = score;
        }
    }

    [Serializable]
    public class ScoreData
    {
        public List<ScoreEntry> entries = new List<ScoreEntry>();
    }







}

