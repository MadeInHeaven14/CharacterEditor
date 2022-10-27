using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditor
{
    [BsonKnownTypes(typeof(ShadowWave), typeof(DragonSlave), typeof(Tornado))]
    public class Skills
    {
        public string SkillName { get; set; }
        public int Lvl { get; set; }

        public Skills(string skillName, int lvl)
        {
            SkillName = skillName;
            Lvl = lvl;
        }
    }
}
