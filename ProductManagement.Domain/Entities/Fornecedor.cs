using System.Collections.Generic;

namespace ProductManagement.Domain.Entities
{
    public class Fornecedor
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Cnpj { get; set; }
        public ICollection<Produto> Produtos { get; set; }
    }
}
