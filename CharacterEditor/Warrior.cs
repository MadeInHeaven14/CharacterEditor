using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditor
{
    [BsonDiscriminator("Warrior")]
    internal class Warrior : Character
    {
        public Warrior() : base("Воин", "", 30, 15, 20, 10, 15, 80, 5, 50, 0, 500, 1, 0)
        {

        }
    }
}
