namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [Key]
        public int IdUser { get; set; }

        [Display(Name ="Tài khoản")]
        [StringLength(50)]
        public string Username { get; set; }

        [Display(Name = "Mật khẩu")]
        [StringLength(50)]
        public string Password { get; set; }

        [Display(Name = "Tên đầy đủ")]
        [StringLength(50)]
        public string Fullname { get; set; }

        [Display(Name = "Địa chỉ email")]
        [StringLength(50)]
        public string Email { get; set; }

        [Display(Name = "Địa chỉ")]
        [StringLength(50)]
        public string Address { get; set; }

        [Display(Name = "Số điện thoại")]
        [StringLength(50)]
        public string Phone { get; set; }

        public int Role { get; set; }
    }
}
