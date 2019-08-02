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

        static string GameIniFilePath
        {
            get
            {
                var localAppDataPath = Environment.GetEnvironmentVariable("LocalAppData");
                return localAppDataPath + @"\Mordhau\Saved\Config\WindowsClient\game.ini";
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

            using (StreamWriter sw = new StreamWriter(GameIniFilePath, true, Encoding.Unicode))
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
    }
}
