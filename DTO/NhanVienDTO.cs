using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class NhanVienDTO
    {
        private int _iDNhanVien;
        public int IDNhanVien
        {
            get { return _iDNhanVien; }
            set { _iDNhanVien = value; }
        }

        private string _hoTen;

        public string HoTen
        {
            get { return _hoTen; }
            set { _hoTen = value; }
        }

        private DateTime _ngaySinh;

        public DateTime NgaySinh
        {
            get { return _ngaySinh; }
            set { _ngaySinh = value; }
        }

        private string _gioiTinh;
        public string GioiTinh
        {
            get { return _gioiTinh; }
            set { _gioiTinh = value; }
        }
        private string _queQuan;

        public string QueQuan
        {
            get { return _queQuan; }
            set { _queQuan = value; }
        }

        private string _chucVu;

        public string ChucVu
        {
            get { return _chucVu; }
            set { _chucVu = value; }
        }

        private string _iDQuanLi;

        public string IDQuanLi
        {
            get { return _iDQuanLi; }
            set { _iDQuanLi = value; }
        }
        private int _luong;

        public int Luong
        {
            get { return _luong; }
            set { _luong = value; }
        }
        private string _idPhong;

        public string IdPhong
        {
            get { return _idPhong; }
            set { _idPhong = value; }
        }
    }
}
