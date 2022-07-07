﻿using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Documento
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Tipo { get; set; }
        public string DocumentoPDF { get; set; }
        public bool Activo { get; set; }
    }
}
