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

			var musician = _context.Musician.SingleOrDefault(m => m.IdMusician == id);

			if (musician == null)
			{
				throw new ArgumentException("Taki muzyk nie istnieje w bazie!");

			}

			response.FirstName = musician.FirstName;
			response.LastName = musician.LastName;

			var musicianTracks = _context.MusicianTrack
								.Where(mt => mt.IdMusician == id)
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

        public void AddMusician(MusicianRequest request)
        {

            var track = _context.Track.SingleOrDefault(t => t.TrackName == request.Track.TrackName);


            if (track == null)
            {
                track = new Track()
                {
                    TrackName = request.Track.TrackName,
                    Duration = request.Track.Duration
                };
            }

            var musician = new Musician()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                NickName = request.NickName
            };

            var musicianTrack = new MusicianTrack()
            {
                Track = track,
                Musician = musician
            };



            //_context.MusicianTrack.Attach(musicianTrack);
            //_context.Musician.Attach(musician);
            //_context.Track.Attach(track);

            _context.MusicianTrack.AddRange(musicianTrack);
            _context.Musician.Add(musician);
            _context.Track.Add(track);


            _context.SaveChanges();




        }


    }
}
