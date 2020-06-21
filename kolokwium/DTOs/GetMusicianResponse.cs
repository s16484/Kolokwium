using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium.DTOs
{
    public class GetMusicianResponse
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }

        public ICollection<TrackResponse> Tracks { get; set; }
    }
}
