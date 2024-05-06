using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;

namespace MauiCustoViagem.Models
{
    public class Pedagio
    {
        public int Id { get; set; } 
        public string Local { get; set; }
        public double Valor { get; set; }
        public int IdViagem { get; set; }
    }
}
