using System;
using System.Collections.Generic;

#nullable disable

namespace WebServiceCRUDTokaMVC.Models
{
    public partial class TbUsuario
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
