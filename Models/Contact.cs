using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyAgendaAPI.Models
{
  public class Contact
  {
    public Contact()
    {
      Name = string.Empty;
      Email = string.Empty;
      Phone = string.Empty;
    }
    public Contact(int Id, string Name, string Email, string Phone)
    {
      this.Id = Id;
      this.Name = Name;
      this.Email = Email;
      this.Phone = Phone;
    }
    public int Id { get; set; }

    [DisplayName("Nome Completo")]
    [StringLength(255, ErrorMessage = "O campo nome permite no máximo 255 caracteres!")]
    public string Name { get; set; }

    [StringLength(255)]
    [Required(ErrorMessage = "Informe o Email")]
    [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Email inválido.")]
    public string Email { get; set; }
    [DisplayName("Telefone")]
    [StringLength(50, ErrorMessage = "Formato inapropriado!")]
    public string Phone { get; set; }

  }
}
