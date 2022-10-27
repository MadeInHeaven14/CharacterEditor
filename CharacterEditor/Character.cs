using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CharacterEditor
{
    [BsonKnownTypes(typeof(Wizard), typeof(Rogue), typeof(Warrior))]
    internal class Character
    {
        [BsonId]
        [BsonIgnoreIfDefault]
        public ObjectId _id;
        public string ClassName { get; set; }
        public string CharacterName { get; set; }
        public double Damage { get; set; }
        public double HP { get; set; }
        public double PhDefense { get; set; }
        public double Mana { get; set; }
        public double MageAttack { get; set; }
        //[BsonIgnore]
        public int Strength { get; set; }
        //[BsonIgnore]
        public int Dexterity { get; set; }
        //[BsonIgnore]
        public int Constitution { get; set; }
        //[BsonIgnore]
        public int Intelligence { get; set; }
        public int SkillPoint { get; set; }
        public int Lvl { get; set; }
        public int Exp { get; set; }



        public Character(string className, string name, int strength, int dexterity, int constitution, int intelligence, double damage, double hP, double phDefense, double mana, double mageAttack, int skillPoint, int lvl, int exp)
        {
            ClassName = className;
            CharacterName = name;
            Strength = strength;
            Dexterity = dexterity;
            Constitution = constitution;
            Intelligence = intelligence;
            Damage = damage;
            HP = hP;
            PhDefense = phDefense;
            Mana = mana;
            MageAttack = mageAttack;
            SkillPoint = skillPoint;
            Items = new List<Item>();
            AllItems = new List<Item>();
            Skills = new List<Skills>();
            Lvl = lvl;
            Exp = exp;
        }

        public void Print()
        {
            MessageBox.Show($" Вы создали персонажа! {"\n"} Имя - {CharacterName} {"\n"} Класс - {ClassName} {"\n"} Здоровье - {HP} {"\n"} Урон - {Damage} {"\n"} Маг.Урон - {MageAttack} {"\n"} Физ.Защита - {PhDefense} {"\n"} Мана - {Mana} {"\n"} Уровень - {Lvl} ");
        }

        public void Change()
        {
            MessageBox.Show($" Вы изменили персонажа! {"\n"} Имя - {CharacterName} {"\n"} Класс - {ClassName} {"\n"} Здоровье - {HP} {"\n"} Урон - {Damage} {"\n"} Маг.Урон - {MageAttack} {"\n"} Физ.Защита - {PhDefense} {"\n"} Мана - {Mana} {"\n"} Уровень - {Lvl} ");
        }

        [BsonIgnoreIfNull]
        public List<Item> Items { get; set; }

        [BsonIgnoreIfNull]
        public List<Item> AllItems { get; set; }
        [BsonIgnoreIfNull]
        public List<Skills> Skills { get; set; }

        public void AddItem(Item item)
        {
            Items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            Items.Remove(item);
        }

        public void AddSkill(Skills skill)
        {
            Skills.Add(skill);
        }
    }
}
