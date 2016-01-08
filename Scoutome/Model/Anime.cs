using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoutome.Model
{
    public class Anime
    {
        public List<object> reunions { get; set; }
        public double codeAnime { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public double numParent { get; set; }
        public string emailParent { get; set; }
    }
}
