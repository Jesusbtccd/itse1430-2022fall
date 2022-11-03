//Jesus Bustillos
//ITSE-1430/Fall
//10/19/2022

namespace JesusBustillos.CharacterCreator
{
    public class Character
    {
        public string characterName;
        public string characterProfession;
        public string characterRace;
        public string characterBiography;
        public int characterStrength, characterIntelligence, characterAgility, characterConstitution, characterCharisma;
    }

    public enum MenuOption
    {
        View = 1,
        Add,
        Edit,
        Delete,
        Quit,

    }
}