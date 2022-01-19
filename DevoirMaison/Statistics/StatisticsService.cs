using System;
using System.IO;
using DevoirMaison.Characters;

namespace DevoirMaison.Statistics
{
    public class StatisticsService
    {
        private static string CharacterNames =
            "Alchemist;Assassin;Berserker;Illusionist;Magician;Necromancer;Paladin;Priest;Robot;Vampire;Warrior;Zombie";

        private static string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "results.txt");

        public static void ShowCharacterWins()
        {
            string line = GetValuesLine();
            string[] names = CharacterNames.Split(";");
            string[] values = line.Split(";");

            for (int i = 0; i < names.Length - 1; i++)
            {
                Console.WriteLine("{0} has : {1} wins", names[i], values[i]);
            }
        }

        public static void SaveCharacterWon(Character character)
        {
            if (character != null)
            {
                Console.WriteLine("0");
                try
                {
                    string winnerName = character.GetType().Name;
                    Console.WriteLine("Winning character type was : {0}", winnerName);

                    var line = GetValuesLine();

                    int[] values = GetCharacterValues(line);

                    int index = GetCharacterIndex(winnerName);

                    values[index] = ++values[index];

                    line = ConvertValuesToLine(values);

                    FileStream filestream = new FileStream(FilePath, FileMode.Open);
                    using (var streamWriter = new StreamWriter(filestream))
                    {
                        streamWriter.AutoFlush = true;
                        streamWriter.WriteLine(line);
                        
                        streamWriter.Close();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
            }
        }

        private static string GetValuesLine()
        {
            if (!File.Exists(FilePath))
            {
                File.Create(FilePath);
            }

            string line;
            using (StreamReader streamReader = new StreamReader(FilePath))
            {
                line = streamReader.ReadLine();
                streamReader.Close();
            }

            if (line == null || line == "")
            {
                line = "0;0;0;0;0;0;0;0;0;0;0;0";
            }

            return line;
        }

        private static int GetCharacterIndex(string name)
        {
            string[] names = CharacterNames.Split(";");
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i] == name)
                {
                    return i;
                }
            }

            return -1;
        }

        private static int[] GetCharacterValues(string valueString)
        {
            var names = valueString.Split(";");
            var values = new int[names.Length];
            for (int i = 0; i < names.Length; i++)
            {
                values[i] = int.Parse(names[i]);
            }

            return values;
        }

        private static string ConvertValuesToLine(int[] values)
        {
            return string.Join(';', values);
        }
    }
}