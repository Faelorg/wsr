using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using wsrHospital.Helpers;

namespace wsrHospital.Repos
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
        public string? Surname { get; set; }
        public string? Firstname { get; set; }
        public string? Dadname { get; set; }
        public int? Passport { get; set; }
        public DateTime? Birthdate { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }

        public int NumberPolis { get; set; }

        public DateTime? DateendPolis { get; set; }
    }

    public interface IPacient 
    {
        public Task<List<Pacient>> GetAll();
        public Task<Pacient> GetById(int id);
        public Task Delete(int id);
        public Task Put(int id, PacientDto pacientDto);
        public Task Create(PacientDto pacientDto);
    }

    public class PacientService : IPacient
    {
        private readonly Context _context;
        public PacientService(Context context)
        {

            _context = context;

        }

        public async Task Create(PacientDto pacientDto)
        {
            if (await this._context.Pacients.FirstOrDefaultAsync(x=>x.Passport==pacientDto.Passport)==null)
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
                    Firstname = pacientDto.Firstname,
                    Surname = pacientDto.Surname,
                    Dadname=pacientDto.Dadname,
                    Email = pacientDto.Email,
                    Phone = pacientDto.Phone,
                    Passport = pacientDto.Passport,
                    Birthdate = pacientDto.Birthdate,
                    CardIdCardNavigation = card,
                    PolisIdPolisNavigation = polis,
                };

                await this._context.Cards.AddAsync(card);
                await this._context.Polis.AddAsync(polis);
                await this._context.Pacients.AddAsync(pacient);
                await this._context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            this._context.Pacients.Remove(await _context.Pacients.FindAsync(id));

            await this._context.SaveChangesAsync();
        }

        public async Task<List<Pacient>> GetAll()
        {
            return await this._context.Pacients.ToListAsync();
        }

        public async Task<Pacient> GetById(int id)
        {
            return await this._context.Pacients.FindAsync(id);
        }

        public async Task Put(int id, PacientDto pacientDto)
        {
            var pacient = await _context.Pacients.FindAsync(id)!;

            pacient!.Birthdate = pacientDto.Birthdate;

            pacient.Dadname = pacientDto.Dadname;

            pacient.Firstname = pacientDto.Firstname;

            pacient.Passport = pacientDto.Passport;

            pacient.Phone = pacientDto.Phone;

            pacient.Surname = pacientDto.Surname;

            pacient.Email = pacientDto.Email;

            await this._context.SaveChangesAsync();
        }
    }
}
