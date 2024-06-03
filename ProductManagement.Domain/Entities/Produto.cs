using System;

namespace ProductManagement.Domain.Entities
{
    public class Produto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool Situacao { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public int FornecedorId { get; set; }
        public Fornecedor Fornecedor { get; set; }
    }
}
