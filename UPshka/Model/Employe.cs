using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPshka.Model
{
    internal class Employe
    {
        public int? Id { get; set; }

        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public string? Patronymic { get; set; }

        public int Post { get; set; }

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string? WorkSchedule { get; set; }

    }
}
