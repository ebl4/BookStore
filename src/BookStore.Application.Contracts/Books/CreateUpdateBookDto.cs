using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Books
{
    public class CreateUpdateBookDto
    {
        /// <summary>
        /// Atributos de Validações (Data Annotations)
        /// para validar um nome de livro obrigatório com tamnho máximo 128 caracteres
        /// e tamanho mínimo de 3 caracteres
        /// </summary>
        [Required]
        [StringLength(128, MinimumLength = 2)]
        public string Name { get; set; }

        /// <summary>
        /// Atributo de Validação (Data Annotations)
        /// para validar um tipo de livro obrigatório 
        /// </summary>
        [Required]
        public BookType Type { get; set; } = BookType.Undefined;

        /// <summary>
        /// Atributo de Validação (Data Annotations)
        /// para validar uma data de publicação obrigatória e do tipo Date
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Atributo de Validação (Data Annotations)
        /// para validar um preço obrigatóro 
        /// </summary>
        [Required]
        public float Price { get; set; }
    }
}
