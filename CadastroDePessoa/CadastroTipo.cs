using System.ComponentModel.DataAnnotations;

namespace CadastroDePessoa
{
    public class CadastroTipo
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string CadastroNome { get; set; } = string.Empty;
    }
}
