﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesPaywise.Models
{
    public class Transacao
    {
        public int Id { get; private set; }
        public double Valor { get; set; }
        public string? Tipo { get; set; }
        public DateTime Data { get; set; }
    }
}
