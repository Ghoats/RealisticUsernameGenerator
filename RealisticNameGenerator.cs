using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class RealisticNameGenerator : MonoBehaviour
{
    public const float PREFIX_CHANCE = 0.25f;
    public const float SUFFIX_CHANCE = 0.5f;
    public const float CASE_CHANCE = 0.25f;
    public const float MISSPELL_CHANCE = 0.05f;
    public const int MIN_LENGTH = 6;

    public static string GenerateName()
    {
        string newName = "";

        if (Random.value < PREFIX_CHANCE)
        {
            newName += GeneratePrefix();
        }

        newName += GenerateRoot();

        if (Random.value < SUFFIX_CHANCE)
        {
            newName += GenerateSuffix();
        }

        if (Random.value < CASE_CHANCE)
        {
            newName = GenerateCasedName(newName.ToString());
        }

        if (Random.value < MISSPELL_CHANCE)
        {
            newName = GenerateMisspelledName(newName.ToString());
        }

        if (newName.Length < MIN_LENGTH)
        {
            return GenerateName();
        }

        return newName.ToString();
    }

    private static string GeneratePrefix()
    {
        int typeIndex = Random.Range(0, (int)PrefixArchetype.COUNT);
        PrefixArchetype selectedType = (PrefixArchetype)typeIndex;

        switch (selectedType)
        {
            case PrefixArchetype.Stylised:
                return m_StylisedPrefixes[Random.Range(0, m_StylisedPrefixes.Length)];
            case PrefixArchetype.Word:
                return m_WordPrefixes[Random.Range(0, m_WordPrefixes.Length)];
            default:
                return "Guest";
        }
    }

    private static string GenerateRoot()
    {
        int typeIndex = Random.Range(0, (int)RootArchetype.COUNT);
        RootArchetype selectedType = (RootArchetype)typeIndex;

        switch (selectedType)
        {
            case RootArchetype.GivenName:
                return m_GivenNameRoots[Random.Range(0, m_GivenNameRoots.Length)];
            case RootArchetype.ChosenName:
                return m_ChosenNameRoots[Random.Range(0, m_ChosenNameRoots.Length)];
            case RootArchetype.Sports:
                return m_SportsRoots[Random.Range(0, m_SportsRoots.Length)];
            case RootArchetype.Noun:
                return m_NounRoots[Random.Range(0, m_NounRoots.Length)];
            case RootArchetype.Trend:
                return m_TrendRoots[Random.Range(0, m_TrendRoots.Length)];
            default:
                return "Player";
        }
    }

    private static string GenerateSuffix()
    {
        int typeIndex = Random.Range(0, (int)SuffixArchetype.COUNT);
        SuffixArchetype selectedType = (SuffixArchetype)typeIndex;

        switch (selectedType)
        {
            case SuffixArchetype.Stylised:
                return m_StylisedSuffixes[Random.Range(0, m_StylisedSuffixes.Length)];
            case SuffixArchetype.Number:
                return GenerateNumber(9999);
            case SuffixArchetype.Surname:
                return m_SurnameSuffixes[Random.Range(0, m_SurnameSuffixes.Length)];
            case SuffixArchetype.Word:
                return m_WordSuffixes[Random.Range(0, m_WordSuffixes.Length)];
            default:
                return "#" + GenerateNumber(9999);
        }
    }

    private static string GenerateCasedName(string name)
    {
        if (Random.value < 0.5f)
        {
            name = name.ToLower();
        }
        else
        {
            name = name.ToUpper();
        }

        return name;
    }

    private static string GenerateMisspelledName(string name)
    {
        List<char> splitName = name.ToCharArray().ToList();

        int misspellingLevel = Random.Range(0, 3);

        //Swap a random character with it's neighbour but not the first letter
        int randomCharacter = Random.Range(1, splitName.Count - 1);
        int secondCharacter = randomCharacter + 1;

        char tempString = name[randomCharacter];
        splitName[randomCharacter] = name[secondCharacter];
        splitName[secondCharacter] = tempString;

        return System.String.Join("", splitName);
    }

    private static string GenerateNumber(int max)
    {
        int randomNumber = Random.Range(0, max);

        if (Random.value < 0.5f)
        {
            if (Random.value < 0.5f)
            {
                if (Random.value < 0.5f)
                {
                    if (Random.value < 0.5f)
                    {
                        if (Random.value < 0.5f)
                        {
                            return randomNumber.ToString("0");
                        }

                        return randomNumber.ToString("00");
                    }

                    return randomNumber.ToString("000");
                }

                return randomNumber.ToString("0000");
            }

            return randomNumber.ToString("####");
        }

        return randomNumber.ToString();
    }

    /// <summary>
    /// Archetypes
    /// </summary>
    private enum RootArchetype
    {
        GivenName,
        ChosenName,
        Sports,
        Noun,
        Trend,
        COUNT
    }

    private enum PrefixArchetype
    {
        Stylised,
        Number,
        Word,
        COUNT
    }

    private enum SuffixArchetype
    {
        Stylised,
        Number,
        Surname,
        Word,
        COUNT
    }

    /// <summary>
    /// Prefix Arrays
    /// </summary>
    private static string[] m_StylisedPrefixes = new string[]
    {
        "UK",
        "UK_",
        "US",
        "US_",
        "USA",
        "USA_",
        "MEX",
        "-",
        "x",
        "ll",
        "12",
        "123",
        "1234",
        "12345",
        "123456",
    };

    private static string[] m_WordPrefixes = new string[]
    {
        "The",
        "First",
        "Second",
        "Shark",
        "Game",
        "Axis",
        "King",
        "Queen",
        "Lord",
        "Sniper",
        "General",
        "Mr",
        "Miss",
        "My",
        "Tha",
        "Da",
        "No",
        "Full",
        "Demon",

    };

    /// <summary>
    /// Root Arrays
    /// </summary>
    private static string[] m_GivenNameRoots = new string[]
    {
        "Daniel",
        "James",
        "Ali",
        "Said",
        "Junior",
        "Manuel",
        "Aya",
        "Noah",
        "William",
        "Jose",
        "Jayden",
        "Maria",
        "Camila",
        "George",
        "Ori",
        "Elie",
        "Krishna",
        "Eden",
        "Angel",
        "Sara",
        "Mariam",
        "Lukas",
        "Liam",
        "Adam",
        "Yusif",
        "Marc",
        "Gabriel",
        "Leo",
        "Oliver",
        "Harry",
        "Jack",
        "Victor",
        "Jacob",
        "Edward",
        "Kaspar",
        "Thomas",
        "Robert",
        "Oscar",
        "Emma",
        "Holly",
        "Eva",
        "Kevin",
        "John",
        "David",
        "Richard",
        "Mary",
        "Linda",
        "Karen",
        "Susan",

    };

    private static string[] m_ChosenNameRoots = new string[]
    {
        "Jungle",
        "Sniperil",
        "Slother",
        "Pelicandy",
        "Skunk",
        "Demon",
        "Horrible",
        "Orangutank",
        "Alphantom",
        "Shady",
        "Green",
        "Acid",
        "Capitus",
        "Crescent",
        "Numero",
        "Lenierix",
        "Santaxime",
        "Certproc",
        "DreamyMa",
        "Monkeyebar",
        "Sharkop",
        "Xbox",
        "Orbital",
        "Gateway",
        "Wiseman",

    };

    private static string[] m_SportsRoots = new string[]
    {
        "Chelsea",
        "Arsenal",
        "Gunners",
        "Razorbacks",
        "Miners",
        "Spurs",
        "Utd",
        "City",
        "49ers",
        "Scrappers",
        "Boomers",
        "Zoomers",
        "Bullets",
        "Legends",
        "Hotshots",
        "Apollos",
        "Commanders",
        "Ballers",
        "Workers",

    };

    private static string[] m_NounRoots = new string[]
    {
        "Actor",
        "Gold",
        "Pizza",
        "Burger",
        "Ice",
        "Battery",
        "Rocket",
        "River",
        "Queen",
        "Potato",
        "Planet",
        "Rose",
        "Branch",
        "Jackal",
        "Car",
        "Energy",
        "Doctor",
        "Time",
        "Person",
        "Year",
        "Way",
        "Day",
        "Thing",
        "Man",
        "World",
        "Life",
        "Hand",
        "Part",
        "Child",
        "Eye",
        "Woman",
        "Place",
        "Work",
        "Week",
        "Case",
        "Point",
        "Number",
        "Fact",

    };

    private static string[] m_TrendRoots = new string[]
    {
        "COVID",
        "Corona",
        "Virus",
        "Trump",
        "2020",
        "Government",
        "Mask",

    };

    /// <summary>
    /// Suffix Arrays
    /// </summary>
    private static string[] m_StylisedSuffixes = new string[]
    {
        "11",
        "123",
        "1234",
        "x",
        "x",
        "_",
        "z",

    };

    private static string[] m_SurnameSuffixes = new string[]
    {
        "Smith",
        "Jones",
        "Johnson",
        "Lee",
        "Brown",
        "Free",
        "Wu",
        "Son",
        "Beard",
        "Robbins",
        "Wang",
        "King",
        "Devi",
        "Murphy",
        "Garcia",
        "Muller",
        "Rossi",
        "DeJong",

    };

    private static string[] m_WordSuffixes = new string[]
    {
        "God",
        "Boy",
        "Man",
        "Girl",
        "Woman",
        "Lady",
        "Player",
        "Killer",
        "Lord",
        "Champion",
        "Destroyer",
        "Monkey",
        "Donkey",
        "Dog",
        "Cat",
        "London",
        "LA",
        "Delhi",
        "Cairo",
        "Home",
        "Soldier",
        "Mermaid",
        "Grin",
        "Paladin",
        "Rogue",
        "Elf",
        "Cowboy",
        "Stinkbug",
        "Knight",
        "Sailor",
        "Chimp",
        "Monk",
        "Harpy",
        "Pumpkin",
        "Octopus",
        "Koala",
        "Nation",
        "Official",

    };
}
