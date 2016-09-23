using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class PhongBanDTO
    {
        private int _idPhong;

        public int IdPhong
        {
            get { return _idPhong; }
            set { _idPhong = value; }
        }
        private string _tenPhong;

        public string TenPhong
        {
            get { return _tenPhong; }
            set { _tenPhong = value; }
        }
        private int _idTruongPhong;

        public int IdTruongPhong
        {
            get { return _idTruongPhong; }
            set { _idTruongPhong = value; }
        }
        private DateTime _ngayNhanChuc;

        public DateTime NgayNhanChuc
        {
            get { return _ngayNhanChuc; }
            set { _ngayNhanChuc = value; }
        }
    }
}
