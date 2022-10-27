using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditor
{
    [BsonDiscriminator("Rogue")]
    internal class Rogue : Character
    {
        public Rogue() : base("Разбойник", "", 15, 30, 20, 15, 10, 60, 3, 75, 5, 500, 1, 0)
        {
        }
    }
}
