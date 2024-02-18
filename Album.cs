using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class Album
    {

        public int ID { get; set; } 
        public string AlbumName { get; set; }
        public String ArtistName {  get; set; }

        public int Year { get; set; }

        public String ImagUrl {  get; set; }

        public String Description { get; set; }

        //A listtrack songs

        public List<Track> Tracks { get; set; } 

    }
}
