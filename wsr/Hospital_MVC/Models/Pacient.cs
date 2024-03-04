using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Hospital_MVC.Models
{
    public partial class Pacient
    {
        public int IdPacient { get; set; }
        public string? Surname { get; set; }
        public string? Firstname { get; set; }
        public string? Dadname { get; set; }
        public int? Passport { get; set; }
        public DateTime? Birthdate { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public int PolisIdPolis { get; set; }
        public int CardIdCard { get; set; }

        public virtual Card CardIdCardNavigation { get; set; } = null!;
        public virtual Poli PolisIdPolisNavigation { get; set; } = null!;
    }

    public class PacientDto
    {
        [Required]
        public string? Surname { get; set; }
        [Required]
        public string? Firstname { get; set; }
        [Required]
        public string? Dadname { get; set; }
        [Required]
        public int? Passport { get; set; }
        [Required]
        [DataType("date")]
        public DateTime? Birthdate { get; set; }
        [Required]
        [Phone]
        public string? Phone { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public int? NumberPolis { get; set; }
        [Required]
        [DataType("date")]
        public DateTime? DateendPolis { get; set; }
    }

    public interface IPacientService
    {
        public Task<List<Pacient>> GetAll();
        public Task<Pacient> GetById(int id);
        public Task Create(PacientDto pacientDto);
        public Task Update(int id, PacientDto pacientDto);
        public Task Remove(int id);
    }

    public class PacientService : IPacientService
    {

        private readonly Context context;

        public PacientService(Context context)
        {
            this.context = context;
        }
        public async Task Create(PacientDto pacientDto)
        {
            if (await context.Pacients.FirstOrDefaultAsync(x => x.Passport == pacientDto.Passport) == null)
            {
                var card = new Card()
                {
                    Dategive = DateTime.Today,
                };

                var polis = new Poli()
                {
                    Number = pacientDto.NumberPolis,
                    Dateend = pacientDto.DateendPolis
                };

                var pacient = new Pacient()
                {
                    Birthdate = pacientDto.Birthdate,
                    Firstname = pacientDto.Firstname,
                    Surname = pacientDto.Surname,
                    Dadname = pacientDto.Dadname,
                    Email = pacientDto.Email,
                    Passport = pacientDto.Passport,
                    Phone = pacientDto.Phone,
                    CardIdCardNavigation = card,
                    PolisIdPolisNavigation = polis
                };

                await context.Cards.AddAsync(card);
                await context.Polis.AddAsync(polis);
                await context.Pacients.AddAsync(pacient);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Pacient>> GetAll()
        {
            return await context.Pacients.ToListAsync();
        }

        public async Task<Pacient> GetById(int id)
        {
            return await context.Pacients.FindAsync(id);
        }

        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, PacientDto pacientDto)
        {
            throw new NotImplementedException();
        }
    }
}
