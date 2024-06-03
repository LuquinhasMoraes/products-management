using System;

namespace ProductManagement.Application.DTOs
{
    public class ProdutoDTO
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool Situacao { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public int FornecedorId { get; set; }
    }
}
