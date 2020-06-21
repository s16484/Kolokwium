using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium.DTOs
{
    public class MusicianRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public TrackRequest Track { get; set; }
    }

    public class TrackRequest
    {
        public string TrackName { get; set; }
        public float Duration { get; set; }
    }

}
