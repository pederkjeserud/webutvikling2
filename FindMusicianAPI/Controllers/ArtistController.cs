using FindMusicianAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Linq;

namespace FindMusicianAPI.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class ArtistController : ControllerBase {

        private readonly FindMusicianContext _context;
        private readonly IWebHostEnvironment _hosting;

        public ArtistController( FindMusicianContext context, IWebHostEnvironment hosting ) {
            _context = context;
            _hosting = hosting;
        }

        [HttpGet]
        public async Task<IEnumerable<Artist>> Get() {
            List<Artist> artistList = await _context.Artist.ToListAsync();
            return artistList;
        }

        [HttpGet("{id}")]
        public async Task<Artist> Get(int id) {
            Artist selectedArtist = await _context.Artist.FirstOrDefaultAsync(Artist => Artist.Id == id);
            return selectedArtist;
        }

        // Få tak i artist basert på instrument

        [HttpGet]
        [Route("[action]/{instrument}")]
        public async Task<IEnumerable<Artist>> GetByInstrument( string instrument ) {
            List<Artist> artistList = await _context.Artist
                .Where(artist => artist.Instrument.ToLower()
                .Contains(instrument.ToLower()))
                .ToListAsync();
            return artistList;
        }

        [HttpPost]
        public async Task<Artist> Post( Artist newArtist ) {
            _context.Artist.Add( newArtist );
            await _context.SaveChangesAsync();
            return newArtist;
        }

        // Kode for konfigurering av bildeopplast til ny artist

        [HttpPost]
        [Route("[action]")]
        public void UploadImage(IFormFile file) {
            string webRootPath = _hosting.WebRootPath;
            string absolutePath = Path.Combine($"{webRootPath}/images/{file.FileName}");
            using (var fileStream = new FileStream( absolutePath, FileMode.Create )) {
                file.CopyTo(fileStream);
            }
        }

        // // Metode for å redigere eksisterende artist

        [HttpPut]
        public async Task<Artist> Put(Artist artist) {
            _context.Update( artist );
            await _context.SaveChangesAsync();
            return artist;
        }

        [HttpDelete("{id}")]
        public async Task<Artist> Delete(int id) {
            Artist artistToDelete = await _context.Artist.FirstAsync( artist => artist.Id == id );
            _context.Artist.Remove( artistToDelete );
            await _context.SaveChangesAsync();
            return artistToDelete;
        }

    }
}