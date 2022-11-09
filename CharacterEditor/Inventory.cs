using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterEditor
{
    internal partial class Inventory : Form
    {
        static MongoClient client = new MongoClient();
        static IMongoDatabase database = client.GetDatabase("CharacterEditor");
        static IMongoCollection<Character> collection = database.GetCollection<Character>("Characters");
        public List<Item> items = new List<Item>();
        public List<Item> AllItems = new List<Item>();
        Form1 form = new Form1();
        public int Strength = 0;
        public int Dexterity = 0;
        public int Constitution = 0;
        public int Intelligence = 0;
        public double Damage = 0;
        public double Hp = 0;
        public double PhDef = 0;
        public double Mana = 0;
        public double MageAttack = 0;
        public Inventory()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.OK;          
        }

        private void button_BuyItem_Click(object sender, EventArgs e)        
        {
            
            if (Strength >= Convert.ToInt32(lv_Shop.SelectedItems[0].SubItems[4].Text) && Dexterity >= Convert.ToInt32(lv_Shop.SelectedItems[0].SubItems[5].Text)
                && Constitution >= Convert.ToInt32(lv_Shop.SelectedItems[0].SubItems[6].Text) && Intelligence >= Convert.ToInt32(lv_Shop.SelectedItems[0].SubItems[7].Text))
            {
                lb_ItemList.Items.Add(lv_Shop.SelectedItems[0].Text);
                switch (lv_Shop.SelectedItems[0].SubItems[1].Text)
                {
                    case "Шлем":
                        cb_Helmet.Items.Add(lv_Shop.SelectedItems[0].Text);
                        int cash = 0;
                        for (int i = 0; i < lv_Shop.Items.Count; i++)
                        {
                            if (lv_Shop.Items[i].Text == cb_Helmet.Text)
                            {
                                cash = Convert.ToInt32(lv_Shop.Items[i].SubItems[8].Text);
                            }
                        }
                        Helmet helmet = new Helmet(lv_Shop.SelectedItems[0].Text, cash);
                        AllItems.Add(helmet);
                        break;
                    case "Броня":
                        cb_Armor.Items.Add(lv_Shop.SelectedItems[0].Text);
                        int cash1 = 0;
                        for (int i = 0; i < lv_Shop.Items.Count; i++)
                        {
                            if (lv_Shop.Items[i].Text == cb_Helmet.Text)
                            {
                                cash1 = Convert.ToInt32(lv_Shop.Items[i].SubItems[8].Text);
                            }
                        }
                        Armor arm = new Armor(lv_Shop.SelectedItems[0].Text, cash1);
                        AllItems.Add(arm);
                        break;
                    case "Оружие":
                        cb_Weapon.Items.Add(lv_Shop.SelectedItems[0].Text);
                        int cash2 = 0;
                        for (int i = 0; i < lv_Shop.Items.Count; i++)
                        {
                            if (lv_Shop.Items[i].Text == cb_Helmet.Text)
                            {
                                cash2 = Convert.ToInt32(lv_Shop.Items[i].SubItems[8].Text);
                            }
                        }
                        Weapon weap = new Weapon(lv_Shop.SelectedItems[0].Text, cash2);
                        AllItems.Add(weap);
                        break;
                    default: break;
                }
            }

            else
            {
                MessageBox.Show("Предмет не подходит по характеристикам!");
            }
            
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            if (cb_Helmet.Text != "")
            {
                int cash = 0;
                for (int i = 0; i < lv_Shop.Items.Count; i++)
                {
                    if (lv_Shop.Items[i].Text == cb_Helmet.Text)
                    {
                        cash = Convert.ToInt32(lv_Shop.Items[i].SubItems[8].Text);
                        if (lv_Shop.Items[i].SubItems[3].Text == "Воин")
                        {
                            if (lv_Shop.Items[i].SubItems[2].Text == "Низк")
                            {
                                PhDef += 10;
                            }
                            if (lv_Shop.Items[i].SubItems[2].Text == "Средн")
                            {
                                Hp += 30;
                                PhDef += 15;
                            }
                            if (lv_Shop.Items[i].SubItems[2].Text == "Высок")
                            {
                                Hp += 60;
                                PhDef += 40;
                            }
                        }
                        if (lv_Shop.Items[i].SubItems[3].Text == "Разбойник")
                        {
                            if (lv_Shop.Items[i].SubItems[2].Text == "Низк")
                            {
                                PhDef += 7;
                            }
                            if (lv_Shop.Items[i].SubItems[2].Text == "Средн")
                            {
                                Hp += 20;
                                PhDef += 10;
                            }
                            if (lv_Shop.Items[i].SubItems[2].Text == "Высок")
                            {
                                Hp += 50;
                                PhDef += 30;
                            }
                        }
                        if (lv_Shop.Items[i].SubItems[3].Text == "Маг")
                        {
                            if (lv_Shop.Items[i].SubItems[2].Text == "Низк")
                            {
                                PhDef += 5;
                                Mana += 30;
                            }
                            if (lv_Shop.Items[i].SubItems[2].Text == "Средн")
                            {
                                Hp += 10;
                                PhDef += 10;
                                Mana += 60;
                            }
                            if (lv_Shop.Items[i].SubItems[2].Text == "Высок")
                            {
                                Hp += 20;
                                PhDef += 30;
                                Mana += 100;
                            }
                        }
                    }
                }
                Helmet helmet = new Helmet(cb_Helmet.Text, cash);
                helmet.Damage = Damage;
                helmet.Hp = Hp;
                helmet.PhDef = PhDef;
                helmet.Mana = Mana;
                helmet.MageAttack = MageAttack;
                items.Add(helmet);
            }
            if (cb_Armor.Text != "")
            {
                int cash = 0;
                for (int i = 0; i < lv_Shop.Items.Count; i++)
                {
                    if (lv_Shop.Items[i].Text == cb_Armor.Text)
                    {
                        cash = Convert.ToInt32(lv_Shop.Items[i].SubItems[8].Text);
                        if (lv_Shop.Items[i].SubItems[3].Text == "Воин")
                        {
                            if (lv_Shop.Items[i].SubItems[2].Text == "Низк")
                            {
                                PhDef += 30;
                                Hp += 30;
                            }
                            if (lv_Shop.Items[i].SubItems[2].Text == "Средн")
                            {
                                Hp += 60;
                                PhDef += 70;
                                Damage += 20;
                            }
                            if (lv_Shop.Items[i].SubItems[2].Text == "Высок")
                            {
                                Hp += 100;
                                PhDef += 100;
                                Damage += 40;
                            }
                        }
                        if (lv_Shop.Items[i].SubItems[3].Text == "Разбойник")
                        {
                            if (lv_Shop.Items[i].SubItems[2].Text == "Низк")
                            {
                                PhDef += 15;
                                Hp += 15;
                            }
                            if (lv_Shop.Items[i].SubItems[2].Text == "Средн")
                            {
                                Hp += 30;
                                PhDef += 50;
                                Damage += 10;
                            }
                            if (lv_Shop.Items[i].SubItems[2].Text == "Высок")
                            {
                                Hp += 75;
                                PhDef += 80;
                                Damage += 25;
                            }
                        }
                        if (lv_Shop.Items[i].SubItems[3].Text == "Маг")
                        {
                            if (lv_Shop.Items[i].SubItems[2].Text == "Низк")
                            {
                                PhDef += 10;
                                Mana += 50;
                            }
                            if (lv_Shop.Items[i].SubItems[2].Text == "Средн")
                            {
                                Hp += 10;
                                PhDef += 15;
                                Mana += 80;
                                MageAttack += 35;
                            }
                            if (lv_Shop.Items[i].SubItems[2].Text == "Высок")
                            {
                                Hp += 20;
                                PhDef += 30;
                                Mana += 100;
                                MageAttack += 60;
                            }
                        }
                    }
                }
                Armor armor = new Armor(cb_Armor.Text, cash);
                armor.Damage = Damage;
                armor.Hp = Hp;
                armor.PhDef = PhDef;
                armor.Mana = Mana;
                armor.MageAttack = MageAttack;
                items.Add(armor);
            }
            if (cb_Weapon.Text != "")
            {
                int cash = 0;
                for (int i = 0; i < lv_Shop.Items.Count; i++)
                {
                    if (lv_Shop.Items[i].Text == cb_Weapon.Text)
                    {
                        cash = Convert.ToInt32(lv_Shop.Items[i].SubItems[8].Text);
                        if (lv_Shop.Items[i].SubItems[3].Text == "Воин")
                        {
                            if (lv_Shop.Items[i].SubItems[2].Text == "Низк")
                            {
                                Damage += 15;
                            }
                            if (lv_Shop.Items[i].SubItems[2].Text == "Средн")
                            {
                                PhDef += 20;
                                Damage += 40;
                            }
                            if (lv_Shop.Items[i].SubItems[2].Text == "Высок")
                            {
                                PhDef += 40;
                                Damage += 100;
                            }
                        }
                        if (lv_Shop.Items[i].SubItems[3].Text == "Разбойник")
                        {
                            if (lv_Shop.Items[i].SubItems[2].Text == "Низк")
                            {
                                Damage += 10;
                            }
                            if (lv_Shop.Items[i].SubItems[2].Text == "Средн")
                            {
                                Damage += 25;
                                PhDef += 5;
                            }
                            if (lv_Shop.Items[i].SubItems[2].Text == "Высок")
                            {
                                PhDef += 30;
                                Damage += 75;
                            }
                        }
                        if (lv_Shop.Items[i].SubItems[3].Text == "Маг")
                        {
                            if (lv_Shop.Items[i].SubItems[2].Text == "Низк")
                            {
                                Damage += 10;
                                Mana += 50;
                                MageAttack += 20;
                            }
                            if (lv_Shop.Items[i].SubItems[2].Text == "Средн")
                            {
                                Damage += 25;
                                Mana += 100;
                                MageAttack += 45;
                            }
                            if (lv_Shop.Items[i].SubItems[2].Text == "Высок")
                            {
                                Damage += 50;
                                Mana += 200;
                                MageAttack += 90;
                            }
                        }
                    }
                }
                Weapon weapon = new Weapon(cb_Weapon.Text, cash);
                weapon.Damage = Damage;
                weapon.Hp = Hp;
                weapon.PhDef = PhDef;
                weapon.Mana = Mana;
                weapon.MageAttack = MageAttack;
                items.Add(weapon);
            }
            this.Close();
        }

        private void button_Remove_Click(object sender, EventArgs e)
        {
            if (cb_Helmet.Text == lb_ItemList.SelectedItem.ToString())
            {
                cb_Helmet.Text = null;
            }
            if (cb_Armor.Text == lb_ItemList.SelectedItem.ToString())
            {
                cb_Armor.Text = null;
            }
            if (cb_Weapon.Text == lb_ItemList.SelectedItem.ToString())
            {
                cb_Weapon.Text = null;
            }
            for (int i = 0; i < cb_Helmet.Items.Count; i++)
            {
                if (cb_Helmet.Items[i].ToString() == lb_ItemList.SelectedItem.ToString())
                {
                    cb_Helmet.Items.Remove(cb_Helmet.Items[i]);
                }
            }
            for (int i = 0; i < cb_Armor.Items.Count; i++)
            {
                if (cb_Armor.Items[i].ToString() == lb_ItemList.SelectedItem.ToString())
                {
                    cb_Armor.Items.Remove(cb_Armor.Items[i]);
                }
            }
            for (int i = 0; i < cb_Weapon.Items.Count; i++)
            {
                if (cb_Weapon.Items[i].ToString() == lb_ItemList.SelectedItem.ToString())
                {
                    cb_Weapon.Items.Remove(cb_Weapon.Items[i]);
                }
            }
            foreach (var i in AllItems.ToList())
            {
                if (i.ItemName == lb_ItemList.SelectedItem.ToString())
                {
                    AllItems.Remove(i);
                }
            }
            lb_ItemList.Items.Remove(lb_ItemList.SelectedItem);
        }
    }
}
