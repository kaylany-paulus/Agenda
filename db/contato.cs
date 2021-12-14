using System;
using System.Collections.Generic;

#nullable disable

namespace Agenda.db
{
    public partial class contato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Fone { get; set; }
        public int? Estrelas { get; set; }
    }
}