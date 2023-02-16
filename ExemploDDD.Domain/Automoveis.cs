using DTIDomain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExemploDDD.Domain
{
    public class Automoveis : DomainBase
    {
        public int idAutomovel { get; set; }
        public string modeloAutomovel { get; set; }
        public int anoAutomovel { get; set; }
        public override void Validar()
        {
            _regrasQuebradas.Clear();
            if (string.IsNullOrEmpty(modeloAutomovel))
                _regrasQuebradas.Add("O nome não pode ser vazio");

            if(anoAutomovel <= 0)
                _regrasQuebradas.Add("O Código deve ser maior que 0");
        }
    }
}
