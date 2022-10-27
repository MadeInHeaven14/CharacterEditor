using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CharacterEditor
{
    public partial class SkillWindow : Form
    {

        public Skills skill = null;
        public SkillWindow()
        {
            InitializeComponent();
        }
     
        private void button_PlusLvl1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            ShadowWave wave = new ShadowWave();
            skill = wave;
            skill.Lvl++;
            this.Close();
        }

        private void button_PlusLvl2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            DragonSlave dragon = new DragonSlave();
            skill = dragon;
            skill.Lvl++;
            this.Close();
        }

        private void button_PlusLvl3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Tornado tornado = new Tornado();
            skill = tornado;
            skill.Lvl++;
            this.Close();
        }
    }
}
