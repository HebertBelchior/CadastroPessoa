using System.ComponentModel.DataAnnotations;

namespace CadastroDePessoa
{
    public class Cadastro
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string Status { get; set; } = string.Empty;
        [StringLength(200)]
        public string Nome { get; set; } = string.Empty;
        [StringLength(20)]
        public string Sexo { get; set; } = string.Empty;
        public DateTime DataDeNascimento { get; set; }
        [StringLength(20)]
        public string? Telefone { get; set; }
        [StringLength(200)]
        public string Email { get; set; } = string.Empty;
        public int CadastroTipoId { get; set; }
        public CadastroTipo? CadastroTipo { get; set; }
    }
}
