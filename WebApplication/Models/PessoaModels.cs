using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class PessoaModels
    {
        [Required]
        public int Codigo { get; set; }

        [Required]
        [MaxLength(11, ErrorMessage ="CPF é obrigatório")]
        public string Cpf { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage ="Tamanho máximo para o nome é de 20 caracteres.")]
        public string Nome { get; set; }

        [MaxLength(20)]
        public string SobreNome { get; set; }

        public DateTime DataNascimento { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Telefone { get; set; }

    }
}