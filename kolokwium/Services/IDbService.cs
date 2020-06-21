using kolokwium.DTOs;
using kolokwium.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium.Services
{
    public interface IDbService
    {
        GetMusicianResponse GetMusician(int id);
        public void AddMusician(MusicianRequest request);


    }
}
