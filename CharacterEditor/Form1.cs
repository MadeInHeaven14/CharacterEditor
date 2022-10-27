using System.Data;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using static System.Reflection.Metadata.BlobBuilder;
using MongoDB.Bson.Serialization.Attributes;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Transactions;

namespace CharacterEditor
{
    internal partial class Form1 : Form
    {
        public string name;
        public int strength;
        public int dexterity;
        public int constitution;
        public int intelligence;
        double Damage;
        double Hp;
        double PhDef;
        double Mana;
        double MageAttack;
        int SkillPoint;
        int lvl;
        int exp;
        List<Skills> skills = new List<Skills>();
        List<Item> Items = new List<Item>();
        public List<Item> AllItems = new List<Item>();

        static MongoClient client = new MongoClient();
        static IMongoDatabase database = client.GetDatabase("CharacterEditor");
        static IMongoCollection<Character> collection = database.GetCollection<Character>("Characters");


        public void FindAll()
        {
            List<Character> list = collection.AsQueryable().ToList<Character>();
            dataGridView_Characters.DataSource = list;
        }

        public static void ReplaceByName(string name, Character character)
        {
            collection.ReplaceOne(x => x.CharacterName == name, character);
        }

        public Form1()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.OK;
            FindAll();
        }

        private void cb_CharacterClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            skills.Clear();
            if (cb_CharacterClass.Text == "Воин")
            {
                Warrior warrior = new Warrior();
                label_StrengthValue.Text = Convert.ToString(warrior.Strength);
                label_DexterityValue.Text = Convert.ToString(warrior.Dexterity);
                label_ConstitutionValue.Text = Convert.ToString(warrior.Constitution);
                label_IntelligenceValue.Text = Convert.ToString(warrior.Intelligence);
                label_DamageValue.Text = Convert.ToString(warrior.Damage);
                label_HPValue.Text = Convert.ToString(warrior.HP);
                label_PDefValue.Text = Convert.ToString(warrior.PhDefense);
                label_ManaValue.Text = Convert.ToString(warrior.Mana);
                label_MageAttackValue.Text = Convert.ToString(warrior.MageAttack);
                label_ExperienceValue.Text = Convert.ToString(warrior.Exp);
                label_LVLValue.Text = Convert.ToString(warrior.Lvl);
                SkillPoint = warrior.SkillPoint;
                strength = warrior.Strength;
                dexterity = warrior.Dexterity;
                constitution = warrior.Constitution;
                intelligence = warrior.Intelligence;
                Damage = warrior.Damage;
                Hp = warrior.HP;
                PhDef = warrior.PhDefense;
                Mana = warrior.Mana;
                MageAttack = warrior.MageAttack;
                lvl = warrior.Lvl;
                exp = warrior.Exp;
                tb_AboutClass.Text = "Воины — могучие бойцы ближнего боя, закованные в броню с ног до головы. Растущая во время схваток ярость наполняет их силой. ... Основы Воины — класс персонажей, сражающихся в ближнем бою и способных исполнять роль как танков, так и бойцов. Они могут применять в бою множество разновидностей оружия, но начинающим игрокам стоит исходить из специализации персонажа и характеристик предметов, когда они выбирают оружие по душе.";
            }

            if (cb_CharacterClass.Text == "Разбойник")
            {
                Rogue rogue = new Rogue();
                label_StrengthValue.Text = Convert.ToString(rogue.Strength);
                label_DexterityValue.Text = Convert.ToString(rogue.Dexterity);
                label_ConstitutionValue.Text = Convert.ToString(rogue.Constitution);
                label_IntelligenceValue.Text = Convert.ToString(rogue.Intelligence);
                label_DamageValue.Text = Convert.ToString(rogue.Damage);
                label_HPValue.Text = Convert.ToString(rogue.HP);
                label_PDefValue.Text = Convert.ToString(rogue.PhDefense);
                label_ManaValue.Text = Convert.ToString(rogue.Mana);
                label_MageAttackValue.Text = Convert.ToString(rogue.MageAttack);
                label_ExperienceValue.Text = Convert.ToString(rogue.Exp);
                label_LVLValue.Text = Convert.ToString(rogue.Lvl);
                SkillPoint = rogue.SkillPoint;
                strength = rogue.Strength;
                dexterity = rogue.Dexterity;
                constitution = rogue.Constitution;
                intelligence = rogue.Intelligence;
                Damage = rogue.Damage;
                Hp = rogue.HP;
                PhDef = rogue.PhDefense;
                Mana = rogue.Mana;
                MageAttack = rogue.MageAttack;
                lvl = rogue.Lvl;
                exp = rogue.Exp;
                tb_AboutClass.Text = "Разбойники часто нападают из теней, начиная бой комбинацией свирепых ударов. В затяжном бою они изматывают врага тщательно продуманной серией атак, прежде чем нанести решающий удар. Разбойнику следует внимательно отнестись к выбору противника, чтобы оптимально использовать тактику, и не упустить момент, когда надо спрятаться или бежать, если ситуация складывается не в их пользу.";
            }

            if (cb_CharacterClass.Text == "Маг")
            {
                Wizard wizard = new Wizard();
                label_StrengthValue.Text = Convert.ToString(wizard.Strength);
                label_DexterityValue.Text = Convert.ToString(wizard.Dexterity);
                label_ConstitutionValue.Text = Convert.ToString(wizard.Constitution);
                label_IntelligenceValue.Text = Convert.ToString(wizard.Intelligence);
                label_DamageValue.Text = Convert.ToString(wizard.Damage);
                label_HPValue.Text = Convert.ToString(wizard.HP);
                label_PDefValue.Text = Convert.ToString(wizard.PhDefense);
                label_ManaValue.Text = Convert.ToString(wizard.Mana);
                label_MageAttackValue.Text = Convert.ToString(wizard.MageAttack);
                label_ExperienceValue.Text = Convert.ToString(wizard.Exp);
                label_LVLValue.Text = Convert.ToString(wizard.Lvl);
                SkillPoint = wizard.SkillPoint;
                strength = wizard.Strength;
                dexterity = wizard.Dexterity;
                constitution = wizard.Constitution;
                intelligence = wizard.Intelligence;
                Damage = wizard.Damage;
                Hp = wizard.HP;
                PhDef = wizard.PhDefense;
                Mana = wizard.Mana;
                MageAttack = wizard.MageAttack;
                lvl = wizard.Lvl;
                exp = wizard.Exp;
                tb_AboutClass.Text = "Маги уничтожают врагов тайными заклинаниями. Несмотря на магическую силу, маги хрупки, не носят тяжелых доспехов, поэтому уязвимы в ближнем бою. Умные маги при помощи заклинаний удерживают врага на расстоянии или вовсе обездвиживают его.";
            }
            label_SkillPointValue.Text = SkillPoint.ToString();
            label_Strength.Visible = true;
            label_StrengthValue.Visible = true;
            label_Dexterity.Visible = true;
            label_DexterityValue.Visible = true;
            label_Constitution.Visible = true;
            label_ConstitutionValue.Visible = true;
            label_Intelligence.Visible = true;
            label_IntelligenceValue.Visible = true;
            label_Damage.Visible = true;
            label_DamageValue.Visible = true;
            label_HP.Visible = true;
            label_HPValue.Visible = true;
            label_PDef.Visible = true;
            label_PDefValue.Visible = true;
            label_Mana.Visible = true;
            label_ManaValue.Visible = true;
            label_MageAttack.Visible = true;
            label_MageAttackValue.Visible = true;
            PlusStrength_Button.Visible = true;
            PlusDexterity_Button.Visible = true;
            PlusConstitution_Button.Visible = true;
            PlusIntelligence_Button.Visible = true;
            MinusStrength_Button.Visible = true;
            MinusDexterity_Button.Visible = true;
            MinusConstitution_Button.Visible = true;
            MinusIntelligence_Button.Visible = true;
            label_Experience.Visible = true;
            label_ExperienceValue.Visible = true;
            button_Plus100Exp.Visible = true;
            button_Plus500Exp.Visible = true;
            button_Plus1000Exp.Visible = true;
            label_LVL.Visible = true;
            label_LVLValue.Visible = true;
            button_OpenInventory.Visible = true;
        }

        private void PlusStrength_Button_Click(object sender, EventArgs e)
        {
            SkillPoint = Convert.ToInt32(label_SkillPointValue.Text);
            strength = Convert.ToInt32(label_StrengthValue.Text);
            dexterity = Convert.ToInt32(label_DexterityValue.Text);
            constitution = Convert.ToInt32(label_ConstitutionValue.Text);
            intelligence = Convert.ToInt32(label_IntelligenceValue.Text);
            Hp = Convert.ToDouble(label_HPValue.Text);
            Damage = Convert.ToDouble(label_DamageValue.Text);
            MageAttack = Convert.ToDouble(label_MageAttackValue.Text);
            Mana = Convert.ToDouble(label_ManaValue.Text);
            PhDef = Convert.ToDouble(label_PDefValue.Text);
            if (SkillPoint > 0)
            {
                if (cb_CharacterClass.Text == "Воин")
                {
                    if (strength < 250)
                    {
                        strength++;
                        label_StrengthValue.Text = strength.ToString();
                        Damage += 5;
                        label_DamageValue.Text = Damage.ToString();
                        Hp += 2;
                        label_HPValue.Text = Hp.ToString();
                    }

                    else
                    {
                        MessageBox.Show("Больше нелья повышать уровень силы!");
                    }
                }

                if (cb_CharacterClass.Text == "Разбойник")
                {
                    if (strength < 55)
                    {
                        strength++;
                        label_StrengthValue.Text = strength.ToString();
                        Damage += 2;
                        label_DamageValue.Text = Damage.ToString();
                        Hp += 1;
                        label_HPValue.Text = Hp.ToString();
                    }

                    else
                    {
                        MessageBox.Show("Больше нелья повышать уровень силы!");
                    }
                }

                if (cb_CharacterClass.Text == "Маг")
                {
                    if (strength < 45)
                    {
                        strength++;
                        label_StrengthValue.Text = strength.ToString();
                        Damage += 3;
                        label_DamageValue.Text = Damage.ToString();
                        Hp += 1;
                        label_HPValue.Text = Hp.ToString();
                    }

                    else
                    {
                        MessageBox.Show("Больше нелья повышать уровень силы!");
                    }
                }
                SkillPoint--;
                label_SkillPointValue.Text = SkillPoint.ToString();
            }

            else
            {
                MessageBox.Show("Больше нелья повышать уровень силы!");
            }
        }

        private void PlusDexterity_Button_Click(object sender, EventArgs e)
        {
            SkillPoint = Convert.ToInt32(label_SkillPointValue.Text);
            SkillPoint = Convert.ToInt32(label_SkillPointValue.Text);
            strength = Convert.ToInt32(label_StrengthValue.Text);
            dexterity = Convert.ToInt32(label_DexterityValue.Text);
            constitution = Convert.ToInt32(label_ConstitutionValue.Text);
            intelligence = Convert.ToInt32(label_IntelligenceValue.Text);
            Hp = Convert.ToDouble(label_HPValue.Text);
            Damage = Convert.ToDouble(label_DamageValue.Text);
            MageAttack = Convert.ToDouble(label_MageAttackValue.Text);
            Mana = Convert.ToDouble(label_ManaValue.Text);
            PhDef = Convert.ToDouble(label_PDefValue.Text);
            if (SkillPoint > 0)
            {
                if (cb_CharacterClass.Text == "Воин")
                {
                    if (dexterity < 70)
                    {
                        dexterity++;
                        label_DexterityValue.Text = dexterity.ToString();
                        Damage += 1;
                        label_DamageValue.Text = Damage.ToString();
                        PhDef += 1;
                        label_PDefValue.Text = PhDef.ToString();
                    }

                    else
                    {
                        MessageBox.Show("Больше нелья повышать уровень выносливости!");
                    }
                }

                if (cb_CharacterClass.Text == "Разбойник")
                {
                    if (dexterity < 250)
                    {
                        dexterity++;
                        label_DexterityValue.Text = dexterity.ToString();
                        Damage += 4;
                        label_DamageValue.Text = Damage.ToString();
                        PhDef += 1.5;
                        label_PDefValue.Text = PhDef.ToString();
                    }

                    else
                    {
                        MessageBox.Show("Больше нелья повышать уровень выносливости!");
                    }
                }

                if (cb_CharacterClass.Text == "Маг")
                {
                    if (dexterity < 70)
                    {
                        dexterity++;
                        label_DexterityValue.Text = dexterity.ToString();
                        PhDef += 0.5;
                        label_PDefValue.Text = PhDef.ToString();
                    }

                    else
                    {
                        MessageBox.Show("Больше нелья повышать уровень выносливости!");
                    }
                }
                SkillPoint--;
                label_SkillPointValue.Text = SkillPoint.ToString();
            }

            else
            {
                MessageBox.Show("Больше нелья повышать уровень выносливости!");
            }
        }

        private void PlusConstitution_Button_Click(object sender, EventArgs e)
        {
            SkillPoint = Convert.ToInt32(label_SkillPointValue.Text);
            SkillPoint = Convert.ToInt32(label_SkillPointValue.Text);
            strength = Convert.ToInt32(label_StrengthValue.Text);
            dexterity = Convert.ToInt32(label_DexterityValue.Text);
            constitution = Convert.ToInt32(label_ConstitutionValue.Text);
            intelligence = Convert.ToInt32(label_IntelligenceValue.Text);
            Hp = Convert.ToDouble(label_HPValue.Text);
            Damage = Convert.ToDouble(label_DamageValue.Text);
            MageAttack = Convert.ToDouble(label_MageAttackValue.Text);
            Mana = Convert.ToDouble(label_ManaValue.Text);
            PhDef = Convert.ToDouble(label_PDefValue.Text);
            if (SkillPoint > 0)
            {
                if (cb_CharacterClass.Text == "Воин")
                {
                    if (constitution < 100)
                    {
                        constitution++;
                        label_ConstitutionValue.Text = constitution.ToString();
                        Hp += 10;
                        label_HPValue.Text = Hp.ToString();
                        PhDef += 2;
                        label_PDefValue.Text = PhDef.ToString();
                    }

                    else
                    {
                        MessageBox.Show("Больше нелья повышать уровень телосложения!");
                    }
                }

                if (cb_CharacterClass.Text == "Разбойник")
                {
                    if (constitution < 80)
                    {
                        constitution++;
                        label_ConstitutionValue.Text = constitution.ToString();
                        Hp += 6;
                        label_HPValue.Text = Hp.ToString();
                    }

                    else
                    {
                        MessageBox.Show("Больше нелья повышать уровень телосложения!");
                    }
                }

                if (cb_CharacterClass.Text == "Маг")
                {
                    if (constitution < 60)
                    {
                        constitution++;
                        label_ConstitutionValue.Text = constitution.ToString();
                        Hp += 3;
                        label_HPValue.Text = Hp.ToString();
                        PhDef += 1;
                        label_PDefValue.Text = PhDef.ToString();
                    }

                    else
                    {
                        MessageBox.Show("Больше нелья повышать уровень телосложения!");
                    }
                }
                SkillPoint--;
                label_SkillPointValue.Text = SkillPoint.ToString();
            }

            else
            {
                MessageBox.Show("Больше нелья повышать уровень телосложения!");
            }
        }

        private void PlusIntelligence_Button_Click(object sender, EventArgs e)
        {
            SkillPoint = Convert.ToInt32(label_SkillPointValue.Text);
            SkillPoint = Convert.ToInt32(label_SkillPointValue.Text);
            strength = Convert.ToInt32(label_StrengthValue.Text);
            dexterity = Convert.ToInt32(label_DexterityValue.Text);
            constitution = Convert.ToInt32(label_ConstitutionValue.Text);
            intelligence = Convert.ToInt32(label_IntelligenceValue.Text);
            Hp = Convert.ToDouble(label_HPValue.Text);
            Damage = Convert.ToDouble(label_DamageValue.Text);
            MageAttack = Convert.ToDouble(label_MageAttackValue.Text);
            Mana = Convert.ToDouble(label_ManaValue.Text);
            PhDef = Convert.ToDouble(label_PDefValue.Text);
            if (SkillPoint > 0)
            {
                if (cb_CharacterClass.Text == "Воин")
                {
                    if (intelligence < 60)
                    {
                        intelligence++;
                        label_IntelligenceValue.Text = intelligence.ToString();
                        Mana += 1;
                        label_ManaValue.Text = Mana.ToString();
                        MageAttack += 1;
                        label_MageAttackValue.Text = MageAttack.ToString();
                    }

                    else
                    {
                        MessageBox.Show("Больше нелья повышать уровень интеллекта!");
                    }
                }

                if (cb_CharacterClass.Text == "Разбойник")
                {
                    if (intelligence < 70)
                    {
                        intelligence++;
                        label_IntelligenceValue.Text = intelligence.ToString();
                        Mana += 1.5;
                        label_ManaValue.Text = Mana.ToString();
                        MageAttack += 2;
                        label_MageAttackValue.Text = MageAttack.ToString();
                    }

                    else
                    {
                        MessageBox.Show("Больше нелья повышать уровень интеллекта!");
                    }
                }

                if (cb_CharacterClass.Text == "Маг")
                {
                    if (intelligence < 250)
                    {
                        intelligence++;
                        label_IntelligenceValue.Text = intelligence.ToString();
                        Mana += 2;
                        label_ManaValue.Text = Mana.ToString();
                        MageAttack += 5;
                        label_MageAttackValue.Text = MageAttack.ToString();
                    }

                    else
                    {
                        MessageBox.Show("Больше нелья повышать уровень интеллекта!");
                    }
                }
                SkillPoint--;
                label_SkillPointValue.Text = SkillPoint.ToString();
            }

            else
            {
                MessageBox.Show("Больше нелья повышать уровень интеллекта!");
            }
        }

        private void Create_Button_Click(object sender, EventArgs e)
        {
            if (tb_CharacterName.Text != "")
            {
                if (cb_CharacterClass.Text == "Воин")
                {
                    Warrior warrior = new Warrior();
                    warrior.CharacterName = tb_CharacterName.Text;
                    warrior.Damage = Damage;
                    warrior.HP = Hp;
                    warrior.PhDefense = PhDef;
                    warrior.Mana = Mana;
                    warrior.MageAttack = MageAttack;
                    warrior.SkillPoint = SkillPoint;
                    warrior.Strength = strength;
                    warrior.Dexterity = dexterity;
                    warrior.Constitution = constitution;
                    warrior.Intelligence = intelligence;
                    warrior.Lvl = lvl;
                    warrior.Exp = exp;
                    warrior.Skills = skills;
                    warrior.Items = Items;
                    warrior.AllItems = AllItems;
                    collection.InsertOne(warrior);
                    FindAll();
                    warrior.Print();
                }

                if (cb_CharacterClass.Text == "Разбойник")
                {
                    Rogue rogue = new Rogue();
                    rogue.CharacterName = tb_CharacterName.Text;
                    rogue.Damage = Damage;
                    rogue.HP = Hp;
                    rogue.PhDefense = PhDef;
                    rogue.Mana = Mana;
                    rogue.MageAttack = MageAttack;
                    rogue.SkillPoint = SkillPoint;
                    rogue.Strength = strength;
                    rogue.Dexterity = dexterity;
                    rogue.Constitution = constitution;
                    rogue.Intelligence = intelligence;
                    rogue.Lvl = lvl;
                    rogue.Exp = exp;
                    rogue.Skills = skills;
                    rogue.Items = Items;
                    rogue.AllItems = AllItems;
                    collection.InsertOne(rogue);
                    FindAll();
                    rogue.Print();
                }

                if (cb_CharacterClass.Text == "Маг")
                {
                    Wizard wizard = new Wizard();
                    wizard.CharacterName = tb_CharacterName.Text;
                    wizard.Damage = Damage;
                    wizard.HP = Hp;
                    wizard.PhDefense = PhDef;
                    wizard.Mana = Mana;
                    wizard.MageAttack = MageAttack;
                    wizard.SkillPoint = SkillPoint;
                    wizard.Strength = strength;
                    wizard.Dexterity = dexterity;
                    wizard.Constitution = constitution;
                    wizard.Intelligence = intelligence;
                    wizard.Lvl = lvl;
                    wizard.Exp = exp;
                    wizard.Skills = skills;
                    wizard.Items = Items;
                    wizard.AllItems = AllItems;
                    collection.InsertOne(wizard);
                    FindAll();
                    wizard.Print();
                }
            }

            else
            {
                MessageBox.Show("Напишите имя персонажа!");
            }
        }

        private void MinusStrength_Button_Click(object sender, EventArgs e)
        {
            SkillPoint = Convert.ToInt32(label_SkillPointValue.Text);
            SkillPoint = Convert.ToInt32(label_SkillPointValue.Text);
            strength = Convert.ToInt32(label_StrengthValue.Text);
            dexterity = Convert.ToInt32(label_DexterityValue.Text);
            constitution = Convert.ToInt32(label_ConstitutionValue.Text);
            intelligence = Convert.ToInt32(label_IntelligenceValue.Text);
            Hp = Convert.ToDouble(label_HPValue.Text);
            Damage = Convert.ToDouble(label_DamageValue.Text);
            MageAttack = Convert.ToDouble(label_MageAttackValue.Text);
            Mana = Convert.ToDouble(label_ManaValue.Text);
            PhDef = Convert.ToDouble(label_PDefValue.Text);
            if (SkillPoint < 500)
            {
                if (cb_CharacterClass.Text == "Воин")
                {
                    if (strength > 30)
                    {
                        strength--;
                        label_StrengthValue.Text = strength.ToString();
                        Damage -= 5;
                        label_DamageValue.Text = Damage.ToString();
                        Hp -= 2;
                        label_HPValue.Text = Hp.ToString();
                    }

                    else
                    {
                        MessageBox.Show("Больше нелья понижать уровень силы!");
                    }
                }

                if (cb_CharacterClass.Text == "Разбойник")
                {
                    if (strength > 15)
                    {
                        strength--;
                        label_StrengthValue.Text = strength.ToString();
                        Damage -= 2;
                        label_DamageValue.Text = Damage.ToString();
                        Hp -= 1;
                        label_HPValue.Text = Hp.ToString();
                    }

                    else
                    {
                        MessageBox.Show("Больше нелья понижать уровень силы!");
                    }
                }

                if (cb_CharacterClass.Text == "Маг")
                {
                    if (strength > 10)
                    {
                        strength--;
                        label_StrengthValue.Text = strength.ToString();
                        Damage -= 3;
                        label_DamageValue.Text = Damage.ToString();
                        Hp -= 1;
                        label_HPValue.Text = Hp.ToString();
                    }

                    else
                    {
                        MessageBox.Show("Больше нелья понижать уровень силы!");
                    }
                }
                SkillPoint++;
                label_SkillPointValue.Text = SkillPoint.ToString();
            }

            else
            {
                MessageBox.Show("Больше нелья понижать уровень силы!");
            }
        }

        private void MinusDexterity_Button_Click(object sender, EventArgs e)
        {
            SkillPoint = Convert.ToInt32(label_SkillPointValue.Text);
            SkillPoint = Convert.ToInt32(label_SkillPointValue.Text);
            strength = Convert.ToInt32(label_StrengthValue.Text);
            dexterity = Convert.ToInt32(label_DexterityValue.Text);
            constitution = Convert.ToInt32(label_ConstitutionValue.Text);
            intelligence = Convert.ToInt32(label_IntelligenceValue.Text);
            Hp = Convert.ToDouble(label_HPValue.Text);
            Damage = Convert.ToDouble(label_DamageValue.Text);
            MageAttack = Convert.ToDouble(label_MageAttackValue.Text);
            Mana = Convert.ToDouble(label_ManaValue.Text);
            PhDef = Convert.ToDouble(label_PDefValue.Text);
            if (SkillPoint < 500)
            {
                if (cb_CharacterClass.Text == "Воин")
                {
                    if (dexterity > 15)
                    {
                        dexterity--;
                        label_DexterityValue.Text = dexterity.ToString();
                        Damage -= 1;
                        label_DamageValue.Text = Damage.ToString();
                        PhDef -= 1;
                        label_PDefValue.Text = PhDef.ToString();
                    }

                    else
                    {
                        MessageBox.Show("Больше нелья понижать уровень выносливости!");
                    }
                }

                if (cb_CharacterClass.Text == "Разбойник")
                {
                    if (dexterity > 30)
                    {
                        dexterity--;
                        label_DexterityValue.Text = dexterity.ToString();
                        Damage -= 4;
                        label_DamageValue.Text = Damage.ToString();
                        PhDef -= 1.5;
                        label_PDefValue.Text = PhDef.ToString();
                    }

                    else
                    {
                        MessageBox.Show("Больше нелья понижать уровень выносливости!");
                    }
                }

                if (cb_CharacterClass.Text == "Маг")
                {
                    if (dexterity > 20)
                    {
                        dexterity--;
                        label_DexterityValue.Text = dexterity.ToString();
                        PhDef -= 0.5;
                        label_PDefValue.Text = PhDef.ToString();
                    }

                    else
                    {
                        MessageBox.Show("Больше нелья понижать уровень выносливости!");
                    }
                }
                SkillPoint++;
                label_SkillPointValue.Text = SkillPoint.ToString();
            }

            else
            {
                MessageBox.Show("Больше нелья понижать уровень выносливости!");
            }
        }

        private void MinusConstitution_Button_Click(object sender, EventArgs e)
        {
            SkillPoint = Convert.ToInt32(label_SkillPointValue.Text);
            SkillPoint = Convert.ToInt32(label_SkillPointValue.Text);
            strength = Convert.ToInt32(label_StrengthValue.Text);
            dexterity = Convert.ToInt32(label_DexterityValue.Text);
            constitution = Convert.ToInt32(label_ConstitutionValue.Text);
            intelligence = Convert.ToInt32(label_IntelligenceValue.Text);
            Hp = Convert.ToDouble(label_HPValue.Text);
            Damage = Convert.ToDouble(label_DamageValue.Text);
            MageAttack = Convert.ToDouble(label_MageAttackValue.Text);
            Mana = Convert.ToDouble(label_ManaValue.Text);
            PhDef = Convert.ToDouble(label_PDefValue.Text);
            if (SkillPoint < 500)
            {
                if (cb_CharacterClass.Text == "Воин")
                {
                    if (constitution > 20)
                    {
                        constitution--;
                        label_ConstitutionValue.Text = constitution.ToString();
                        Hp -= 10;
                        label_HPValue.Text = Hp.ToString();
                        PhDef -= 2;
                        label_PDefValue.Text = PhDef.ToString();
                    }

                    else
                    {
                        MessageBox.Show("Больше нелья понижать уровень телосложения!");
                    }
                }

                if (cb_CharacterClass.Text == "Разбойник")
                {
                    if (constitution > 20)
                    {
                        constitution--;
                        label_ConstitutionValue.Text = constitution.ToString();
                        Hp -= 6;
                        label_HPValue.Text = Hp.ToString();
                    }

                    else
                    {
                        MessageBox.Show("Больше нелья понижать уровень телосложения!");
                    }
                }

                if (cb_CharacterClass.Text == "Маг")
                {
                    if (constitution > 15)
                    {
                        constitution--;
                        label_ConstitutionValue.Text = constitution.ToString();
                        Hp -= 3;
                        label_HPValue.Text = Hp.ToString();
                        PhDef -= 1;
                        label_PDefValue.Text = PhDef.ToString();
                    }

                    else
                    {
                        MessageBox.Show("Больше нелья понижать уровень телосложения!");
                    }
                }
                SkillPoint++;
                label_SkillPointValue.Text = SkillPoint.ToString();
            }

            else
            {
                MessageBox.Show("Больше нелья понижать уровень телосложения!");
            }

        }

        private void MinusIntelligence_Button_Click(object sender, EventArgs e)
        {
            SkillPoint = Convert.ToInt32(label_SkillPointValue.Text);
            SkillPoint = Convert.ToInt32(label_SkillPointValue.Text);
            strength = Convert.ToInt32(label_StrengthValue.Text);
            dexterity = Convert.ToInt32(label_DexterityValue.Text);
            constitution = Convert.ToInt32(label_ConstitutionValue.Text);
            intelligence = Convert.ToInt32(label_IntelligenceValue.Text);
            Hp = Convert.ToDouble(label_HPValue.Text);
            Damage = Convert.ToDouble(label_DamageValue.Text);
            MageAttack = Convert.ToDouble(label_MageAttackValue.Text);
            Mana = Convert.ToDouble(label_ManaValue.Text);
            PhDef = Convert.ToDouble(label_PDefValue.Text);
            if (SkillPoint < 500)
            {
                if (cb_CharacterClass.Text == "Воин")
                {
                    if (intelligence > 10)
                    {
                        intelligence--;
                        label_IntelligenceValue.Text = intelligence.ToString();
                        Mana -= 1;
                        label_ManaValue.Text = Mana.ToString();
                        MageAttack -= 1;
                        label_MageAttackValue.Text = MageAttack.ToString();
                    }

                    else
                    {
                        MessageBox.Show("Больше нелья понижать уровень интеллекта!");
                    }
                }

                if (cb_CharacterClass.Text == "Разбойник")
                {
                    if (intelligence > 15)
                    {
                        intelligence--;
                        label_IntelligenceValue.Text = intelligence.ToString();
                        Mana -= 1.5;
                        label_ManaValue.Text = Mana.ToString();
                        MageAttack -= 2;
                        label_MageAttackValue.Text = MageAttack.ToString();
                    }

                    else
                    {
                        MessageBox.Show("Больше нелья понижать уровень интеллекта!");
                    }
                }

                if (cb_CharacterClass.Text == "Маг")
                {
                    if (intelligence > 35)
                    {
                        intelligence--;
                        label_IntelligenceValue.Text = intelligence.ToString();
                        Mana -= 2;
                        label_ManaValue.Text = Mana.ToString();
                        MageAttack -= 5;
                        label_MageAttackValue.Text = MageAttack.ToString();
                    }

                    else
                    {
                        MessageBox.Show("Больше нелья понижать уровень интеллекта!");
                    }
                }
                SkillPoint++;
                label_SkillPointValue.Text = SkillPoint.ToString();
            }

            else
            {
                MessageBox.Show("Больше нелья понижать уровень интеллекта!");
            }
        }
        bool temp = false;

        private void dataGridView_Characters_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            temp = true;

            if (temp)
            {
                var unit = collection.Find(x => x.CharacterName == dataGridView_Characters.Rows[e.RowIndex].Cells[1].Value.ToString()).FirstOrDefault();
                tb_CharacterName.Text = unit.CharacterName;
                cb_CharacterClass.Text = unit.ClassName;
                label_DamageValue.Text = unit.Damage.ToString();
                label_HPValue.Text = unit.HP.ToString();
                label_PDefValue.Text = unit.PhDefense.ToString();
                label_ManaValue.Text = unit.Mana.ToString();
                label_MageAttackValue.Text = unit.MageAttack.ToString();
                label_StrengthValue.Text = unit.Strength.ToString();
                label_DexterityValue.Text = unit.Dexterity.ToString();
                label_ConstitutionValue.Text = unit.Constitution.ToString();
                label_IntelligenceValue.Text = unit.Intelligence.ToString();
                label_SkillPointValue.Text = unit.SkillPoint.ToString();
                label_LVLValue.Text = unit.Lvl.ToString();
                label_ExperienceValue.Text = unit.Exp.ToString();
                name = tb_CharacterName.Text;
                skills = unit.Skills;
                Items = unit.Items;
                AllItems = unit.AllItems;
                strength = unit.Strength;
                dexterity = unit.Dexterity;
                constitution = unit.Constitution;
                intelligence = unit.Intelligence;
                Damage = unit.Damage;
                Hp = unit.HP;
                PhDef = unit.PhDefense;
                MageAttack = unit.MageAttack;
                Mana = unit.Mana;

                name = tb_CharacterName.Text;
                Redact_Button.Visible = true;
                Create_Button.Visible = false;
                tb_CharacterName.ReadOnly = true;
                cb_CharacterClass.Enabled = false;
                temp = false;

            }
        }

        private void Return_Button_Click(object sender, EventArgs e)
        {
            if (cb_CharacterClass.Text == "Воин")
            {
                Warrior warrior = new Warrior();
                warrior.CharacterName = tb_CharacterName.Text;
                warrior.Strength = Convert.ToInt32(label_StrengthValue.Text);
                warrior.Dexterity = Convert.ToInt32(label_DexterityValue.Text);
                warrior.Constitution = Convert.ToInt32(label_ConstitutionValue.Text);
                warrior.Intelligence = Convert.ToInt32(label_IntelligenceValue.Text);
                warrior.HP = Convert.ToDouble(label_HPValue.Text);
                warrior.Damage = Convert.ToDouble(label_DamageValue.Text);
                warrior.MageAttack = Convert.ToDouble(label_MageAttackValue.Text);
                warrior.Mana = Convert.ToDouble(label_ManaValue.Text);
                warrior.PhDefense = Convert.ToDouble(label_PDefValue.Text);
                warrior.SkillPoint = Convert.ToInt32(label_SkillPointValue.Text);
                warrior.Lvl = Convert.ToInt32(label_LVLValue.Text);
                warrior.Exp = Convert.ToInt32(label_ExperienceValue.Text);
                warrior.Skills = skills;
                warrior.Items = Items;
                warrior.AllItems = AllItems;

                ReplaceByName(tb_CharacterName.Text, warrior);
                warrior.Change();
            }

            if (cb_CharacterClass.Text == "Разбойник")
            {
                Rogue rogue = new Rogue();
                rogue.CharacterName = tb_CharacterName.Text;
                rogue.Strength = Convert.ToInt32(label_StrengthValue.Text);
                rogue.Dexterity = Convert.ToInt32(label_DexterityValue.Text);
                rogue.Constitution = Convert.ToInt32(label_ConstitutionValue.Text);
                rogue.Intelligence = Convert.ToInt32(label_IntelligenceValue.Text);
                rogue.HP = Convert.ToDouble(label_HPValue.Text);
                rogue.Damage = Convert.ToDouble(label_DamageValue.Text);
                rogue.MageAttack = Convert.ToDouble(label_MageAttackValue.Text);
                rogue.Mana = Convert.ToDouble(label_ManaValue.Text);
                rogue.PhDefense = Convert.ToDouble(label_PDefValue.Text);
                rogue.SkillPoint = Convert.ToInt32(label_SkillPointValue.Text);
                rogue.Lvl = Convert.ToInt32(label_LVLValue.Text);
                rogue.Exp = Convert.ToInt32(label_ExperienceValue.Text);
                rogue.Skills = skills;
                rogue.Items = Items;
                rogue.AllItems = AllItems;

                ReplaceByName(name, rogue);
                rogue.Change();
            }

            if (cb_CharacterClass.Text == "Маг")
            {
                Wizard wizard = new Wizard();
                wizard.CharacterName = tb_CharacterName.Text;
                wizard.Strength = Convert.ToInt32(label_StrengthValue.Text);
                wizard.Dexterity = Convert.ToInt32(label_DexterityValue.Text);
                wizard.Constitution = Convert.ToInt32(label_ConstitutionValue.Text);
                wizard.Intelligence = Convert.ToInt32(label_IntelligenceValue.Text);
                wizard.HP = Convert.ToDouble(label_HPValue.Text);
                wizard.Damage = Convert.ToDouble(label_DamageValue.Text);
                wizard.MageAttack = Convert.ToDouble(label_MageAttackValue.Text);
                wizard.Mana = Convert.ToDouble(label_ManaValue.Text);
                wizard.PhDefense = Convert.ToDouble(label_PDefValue.Text);
                wizard.SkillPoint = Convert.ToInt32(label_SkillPointValue.Text);
                wizard.Lvl = Convert.ToInt32(label_LVLValue.Text);
                wizard.Exp = Convert.ToInt32(label_ExperienceValue.Text);
                wizard.Skills = skills;
                wizard.Items = Items;
                wizard.AllItems = AllItems;

                ReplaceByName(name, wizard);
                wizard.Change();
            }
        }

        private void button_Plus100Exp_Click(object sender, EventArgs e)
        {
            var unit = collection.Find(x => x.CharacterName == tb_CharacterName.Text).FirstOrDefault();
            lvl = Convert.ToInt32(label_LVLValue.Text);
            exp = Convert.ToInt32(label_ExperienceValue.Text);
            exp += 100;
            int nxtLvl = 0;
            for (int i = 0; i <= lvl; i++)
            {
                nxtLvl += 1000 * i;
            }
            label_ExperienceValue.Text = exp.ToString();
            if (exp >= nxtLvl)
            {
                lvl++;
                label_LVLValue.Text = lvl.ToString();
                SkillPoint++;
                label_SkillPointValue.Text = SkillPoint.ToString();
                if (lvl % 3 == 0)
                {
                    SkillWindow window = new SkillWindow();

                    if (window.ShowDialog() == DialogResult.OK)
                    {
                        skills.Add(window.skill);

                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = i + 1; j < skills.Count; j++)
                            {
                                if (skills[i].SkillName == skills[j].SkillName)
                                {
                                    skills[i].Lvl += 1;
                                    skills.Remove(skills[j]);
                                    MessageBox.Show($"Вы улучшили способность {skills[i].SkillName} до {skills[i].Lvl}-ого уровня!");
                                }
                            }
                        }
                    }
                }
            }
        }

        private void button_Plus500Exp_Click(object sender, EventArgs e)
        {
            lvl = Convert.ToInt32(label_LVLValue.Text);
            exp = Convert.ToInt32(label_ExperienceValue.Text);
            exp += 500;
            int nxtLvl = 0;
            for (int i = 0; i <= lvl; i++)
            {
                nxtLvl += 1000 * i;
            }
            label_ExperienceValue.Text = exp.ToString();

            if (exp >= nxtLvl)
            {
                lvl++;
                label_LVLValue.Text = lvl.ToString();
                SkillPoint++;
                label_SkillPointValue.Text = SkillPoint.ToString();
                if (lvl % 3 == 0)
                {
                    SkillWindow window = new SkillWindow();
                    if (window.ShowDialog() == DialogResult.OK)
                    {
                        skills.Add(window.skill);

                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = i + 1; j < skills.Count; j++)
                            {
                                if (skills[i].SkillName == skills[j].SkillName)
                                {
                                    skills[i].Lvl += 1;
                                    skills.Remove(skills[j]);
                                    MessageBox.Show($"Вы улучшили способность {skills[i].SkillName} до {skills[i].Lvl}-ого уровня!");
                                }
                            }
                        }
                    }
                }
            }
        }

        private void button_Plus1000Exp_Click(object sender, EventArgs e)
        {

            lvl = Convert.ToInt32(label_LVLValue.Text);
            exp = Convert.ToInt32(label_ExperienceValue.Text);
            exp += 1000;
            int nxtLvl = 0;
            for (int i = 0; i <= lvl; i++)
            {
                nxtLvl += 1000 * i;
            }
            label_ExperienceValue.Text = exp.ToString();

            if (exp >= nxtLvl)
            {
                lvl++;
                label_LVLValue.Text = lvl.ToString();
                SkillPoint++;
                label_SkillPointValue.Text = SkillPoint.ToString();
                if (lvl % 3 == 0)
                {
                    SkillWindow window = new SkillWindow();

                    if (window.ShowDialog() == DialogResult.OK)
                    {

                        skills.Add(window.skill);

                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = i + 1; j < skills.Count; j++)
                            {
                                if (skills[i].SkillName == skills[j].SkillName)
                                {
                                    skills[i].Lvl += 1;
                                    skills.Remove(skills[j]);
                                    MessageBox.Show($"Вы улучшили способность {skills[i].SkillName} до {skills[i].Lvl}-ого уровня!");
                                }
                            }
                        }
                    }
                }
            }
        }

        private void button_OpenInventory_Click(object sender, EventArgs e)
        {
            Inventory inv = new Inventory();

            if (inv.DialogResult == DialogResult.OK)
            {
                inv.Strength = strength;
                inv.Dexterity = dexterity;
                inv.Constitution = constitution;
                inv.Intelligence = intelligence;

                var unit = collection.Find(x => x.CharacterName == tb_CharacterName.Text.ToString()).FirstOrDefault();
                //MessageBox.Show(unit.CharacterName);
                inv.Show();
                if (unit != null)
                {
                    unit.Items = Items;
                    foreach (var item in AllItems)
                    {
                        inv.lb_ItemList.Items.Add(item.ItemName);
                    }
                    foreach (var item in unit.Items)
                    {
                        for (int i = 0; i < inv.lv_Shop.Items.Count; i++)
                        {
                            if (item.ItemName == inv.lv_Shop.Items[i].Text)
                            {
                                switch (inv.lv_Shop.Items[i].SubItems[1].Text)
                                {
                                    case "Шлем":
                                        inv.cb_Helmet.Text = item.ItemName;
                                        break;
                                    case "Броня":
                                        inv.cb_Armor.Text = item.ItemName;
                                        break;
                                    case "Оружие":
                                        inv.cb_Weapon.Text = item.ItemName;
                                        break;
                                    default: break;
                                }
                            }
                        }
                    }
                    foreach (var item in inv.lb_ItemList.Items)
                    {
                        for (int i = 0; i < inv.lv_Shop.Items.Count; i++)
                        {
                            if (item.ToString() == inv.lv_Shop.Items[i].Text)
                            {
                                switch (inv.lv_Shop.Items[i].SubItems[1].Text)
                                {
                                    case "Шлем":
                                        inv.cb_Helmet.Items.Add(inv.lv_Shop.Items[i].Text);
                                        break;
                                    case "Броня":
                                        inv.cb_Armor.Items.Add(inv.lv_Shop.Items[i].Text);
                                        break;
                                    case "Оружие":
                                        inv.cb_Weapon.Items.Add(inv.lv_Shop.Items[i].Text);
                                        break;
                                    default: break;
                                }
                            }
                        }
                    }
                    //inv.items = unit.Items;
                    inv.AllItems = AllItems;
                }
               else
                {
                    foreach (var item in AllItems)
                    {
                        inv.lb_ItemList.Items.Add(item.ItemName);
                    }
                    foreach (var item in Items)
                    {
                        for (int i = 0; i < inv.lv_Shop.Items.Count; i++)
                        {
                            if (item.ItemName == inv.lv_Shop.Items[i].Text)
                            {
                                switch (inv.lv_Shop.Items[i].SubItems[1].Text)
                                {
                                    case "Шлем":
                                        inv.cb_Helmet.Text = item.ItemName;
                                        break;
                                    case "Броня":
                                        inv.cb_Armor.Text = item.ItemName;
                                        break;
                                    case "Оружие":
                                        inv.cb_Weapon.Text = item.ItemName;
                                        break;
                                    default: break;
                                }
                            }
                        }
                    }
                    foreach (var item in inv.lb_ItemList.Items)
                    {
                        for (int i = 0; i < inv.lv_Shop.Items.Count; i++)
                        {
                            if (item.ToString() == inv.lv_Shop.Items[i].Text)
                            {
                                switch (inv.lv_Shop.Items[i].SubItems[1].Text)
                                {
                                    case "Шлем":
                                        inv.cb_Helmet.Items.Add(inv.lv_Shop.Items[i].Text);
                                        break;
                                    case "Броня":
                                        inv.cb_Armor.Items.Add(inv.lv_Shop.Items[i].Text);
                                        break;
                                    case "Оружие":
                                        inv.cb_Weapon.Items.Add(inv.lv_Shop.Items[i].Text);
                                        break;
                                    default: break;
                                }
                            }
                        }
                        //inv.items = Items;
                        inv.AllItems = AllItems;
                    }
                }
                AllItems = inv.AllItems;
                Items = inv.items;
                Damage = Convert.ToInt32(label_DamageValue.Text);
                Damage = 50;
                PhDef += inv.PhDef;
                Hp += inv.Hp;
                Mana += inv.Mana;
                MageAttack += inv.MageAttack;
                label_DamageValue.Text = Damage.ToString();
            }
        }
    }
}