using kolokwium.DTOs;
using kolokwium.Models;
using Kolokwium.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium.Services
{
    public class SqlServerDbService : IDbService
    {
        private readonly APIDbContext _context;

        public SqlServerDbService(APIDbContext context)
        {
            _context = context;
        }

		public GetMusicianResponse GetMusician(int id)
		{
     
            GetMusicianResponse response = new GetMusicianResponse();

			var musician = _context.Musician.SingleOrDefault((System.Linq.Expressions.Expression<Func<Musician, bool>>)(m => m.IdMusician == id));

			if (musician == null)
			{
				throw new ArgumentException("Taki muzyk nie istnieje w bazie!");

			}

			response.FirstName = musician.FirstName;
			response.LastName = musician.LastName;

			var musicianTracks = _context.MusicianTrack
								.Where((System.Linq.Expressions.Expression<Func<MusicianTrack, bool>>)(mt => mt.IdMusician == id))
								.Include(t => t.Track)
								.ToList();

            var tracks = new List<Track>();

            foreach (var mt in musicianTracks)
            {
                var x = _context.Track.Where(e => e.IdTrack == mt.IdTrack).FirstOrDefault();

                tracks.Add(x);

            }

            var tracksResp = new List<TrackResponse>();
            foreach (var e in tracks)
            {
                var tr = new TrackResponse();
                tr.TrackName = e.TrackName;
                tr.Duration = e.Duration;

                tracksResp.Add(tr);

            }

            response.Tracks = tracksResp;

            return response;

		}



	}
}
