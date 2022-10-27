using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditor
{
    [BsonDiscriminator("Wizard")]
    internal class Wizard : Character
    {
        public Wizard() : base("Маг", "", 10, 20, 15, 35, 5, 40, 0, 150, 15, 500, 1, 0)
        {
        }
    }
}
