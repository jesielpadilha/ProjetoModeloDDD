using System;

namespace ProjetoModeloDDD.Domain.Entities
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataCadasto { get; set; }
        public bool Ativo { get; set; }

        public bool ClienteEspecial(Cliente cliente)
        {
            return Ativo && (DateTime.Now.Year - cliente.DataCadasto.Year) >= 5;
        }
    }
}
