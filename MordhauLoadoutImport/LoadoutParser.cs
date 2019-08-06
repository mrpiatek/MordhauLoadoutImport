using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MordhauLoadoutImport
{
    public static class LoadoutParser
    {
        public static List<Loadout> Loadouts { get; } = new List<Loadout>();
        static string GameIniFilePath;
        static string GameIniBackupFilePath;

        static LoadoutParser()
        {
            var localAppDataPath = Environment.GetEnvironmentVariable("LocalAppData");
            GameIniFilePath = localAppDataPath + @"\Mordhau\Saved\Config\WindowsClient\Game.ini";
            GameIniBackupFilePath = localAppDataPath + @"\Mordhau\Saved\Config\WindowsClient\Game.backup.ini";
        }

        public static void BackupGameIniIfNeeded()
        {
            if (!File.Exists(GameIniBackupFilePath))
            {
                File.Copy(GameIniFilePath, GameIniBackupFilePath);
            }
        }

        public static void LoadLoadoutsFromFile()
        {
            if (!File.Exists(GameIniFilePath))
            {
                throw new Exception("Could not locate game.ini");
            }

            Loadouts.Clear();

            using (StreamReader file = new StreamReader(GameIniFilePath))
            {
                string ln;

                while ((ln = file.ReadLine()) != null)
                {
                    if (ln.StartsWith("CharacterProfiles"))
                    {
                        try
                        {
                            Loadouts.Add(new Loadout(ln));
                        }
                        catch (Exception e)
                        {
                            // TODO handle exception
                        }
                    }
                }
                file.Close();
            }
        }

        public static void AppendLoadoutToFile(string name, string profile)
        {
            if (!File.Exists(GameIniFilePath))
            {
                throw new Exception("Could not locate game.ini");
            }

            // swap name in the profile to the one given by the user
            Regex rx = new Regex("^CharacterProfiles=\\(Name=INVTEXT\\(\"(.*?)\"\\)", RegexOptions.Compiled);
            profile = rx.Replace(profile, $"CharacterProfiles=(Name=INVTEXT(\"{name}\")");

            using (StreamWriter sw = new StreamWriter(GameIniFilePath, true, Encoding.UTF8))
            {
                sw.WriteLine();
                sw.WriteLine(@"[/Game/Mordhau/Blueprints/BP_MordhauSingleton.BP_MordhauSingleton_C]");
                sw.WriteLine(profile);
            }
        }

        public static string GetNextAvailableName(string name)
        {
            var currentNameCheck = name;
            for (int i = 1; i < 100; i++)
            {
                if (!Loadouts.Exists(loadout => { return loadout.Name == currentNameCheck; }))
                {
                    return currentNameCheck;
                }
                else
                {
                    currentNameCheck = $"{name} {i}";
                }
            }

            // if no availavle name found, throw an error
            throw new Exception("Could not find next available name");
        }

        public static bool LoadoutNameExist(string name)
        {
            return Loadouts.Exists(loadout => { return loadout.Name == name; });
        }

        public static string GetLoadoutNameFromProfileString(string profile)
        {
            Regex rx = new Regex("^CharacterProfiles=\\(Name=INVTEXT\\(\"(.*?)\"\\)", RegexOptions.Compiled);
            MatchCollection matches = rx.Matches(profile);

            if (matches.Count != 1)
            {
                throw new Exception("Could not parse name from the loadout profile");
            }

            return matches[0].Groups[1].Value.Trim();
        }

        public static ParsedProfile ParseProfile(string profile)
        {
            // remove all whitespaces
            profile = Regex.Replace(profile, @"\s+", "");
            Regex rx = new Regex(@"Wearables=\((.*?)\),Equipment", RegexOptions.Compiled);
            var match = rx.Match(profile);

            if (!match.Success)
            {
                throw new Exception("Could not parse name from the loadout profile");
            }

            var wearablesString = match.Groups[1].Value;

            // hack to fix below loop not including final wearable
            wearablesString += ",";
            //
            var bracketLevel = 0;
            var currentWearableIndex = 0;
            var carretPosition = 0;
            var lastSlicePosition = 0;
            int[] wearableIds = new int[9];
            foreach (char c in wearablesString)
            {
                if (c == '(') bracketLevel++;
                else if (c == ')') bracketLevel--;
                else if (c == ',' && bracketLevel == 0)
                {
                    rx = new Regex(@"ID=(\d+)", RegexOptions.Compiled);
                    match = rx.Match(wearablesString, lastSlicePosition, carretPosition - lastSlicePosition);
                    lastSlicePosition = carretPosition;

                    if (match.Success)
                    {
                        wearableIds[currentWearableIndex] = int.Parse(match.Groups[1].Value);
                    }
                    else
                    {
                        wearableIds[currentWearableIndex] = 0;
                    }

                    if (++currentWearableIndex >= 9)
                    {
                        break;
                    }
                }

                carretPosition++;
            }


            return new ParsedProfile(wearableIds, new int[3]);
        }

        public struct Loadout
        {
            public string Name { get; set; }
            public string Profile { get; set; }

            public Loadout(string profile)
            {
                Name = GetLoadoutNameFromProfileString(profile);
                Profile = profile;
            }
        }

        public struct ParsedProfile
        {
            public int[] Wearables { get; set; }
            public int[] Weapons { get; set; }

            public ParsedProfile(int[] wearables, int[] weapons)
            {
                Wearables = wearables;
                Weapons = weapons;
            }
        }

        public enum Wearable
        {
            Head,
            Neck,
            Torso,
            Shoulders,
            Arms,
            Hands,
            Weist,
            Legs,
            Feet
        }
    }
}
