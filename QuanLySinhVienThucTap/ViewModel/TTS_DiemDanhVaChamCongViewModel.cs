﻿using QuanLySinhVienThucTap.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;
using System.Data.Entity;

namespace QuanLySinhVienThucTap.ViewModel
{
    public class TTS_DiemDanhVaChamCongViewModel : BaseViewModel
    {
        private string _userId;

        public string UserId
        {
            get { return _userId; }
            set
            {
                if (_userId != value)
                {
                    _userId = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _solanChamCong;

        public int SoLanChamCong
        {
            get { return _solanChamCong; }
            set
            {
                if (_solanChamCong != value)
                {
                    _solanChamCong = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand LoadChamCongCommand { get; set; }
        public ICommand ChamCongCommand { get; set; }

        public TTS_DiemDanhVaChamCongViewModel() {
            LoadChamCongCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                SoLanChamCongThang();
            });

            ChamCongCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                ChamCongButton();
                SoLanChamCongThang();

            });



        }

        public void SoLanChamCongThang()
        {
            DateTime ngayHienTai = DateTime.Now;
            int thangHienTai = ngayHienTai.Month;
            int namHienTai = ngayHienTai.Year;
            var listChamCong = DataProvider.Ins.DB.tblChamCongs.Where(x => x.MaTTS == UserId).ToList()
                .Where(x => x.NgayChamCong.Value.Month == thangHienTai && x.NgayChamCong.Value.Year == namHienTai);

            int soLanChamCongThang = listChamCong.Count();
            SoLanChamCong = soLanChamCongThang;
        }

        public void ChamCongButton()
        {
            DateTime chamCongDate = DateTime.Now;
            // Lấy ngày hiện tại (không bao gồm giờ, phút, giây)
            DateTime ngayHienTai = DateTime.Now;

            var chamCongDaChamToday = DataProvider.Ins.DB.tblChamCongs
    .FirstOrDefault(cc => DbFunctions.TruncateTime(cc.NgayChamCong) == ngayHienTai.Date && cc.MaTTS == UserId);

            if (chamCongDaChamToday != null)
            {
                // Lấy giờ, phút và giây từ NgayChamCong
                int hourChamCong = chamCongDaChamToday.NgayChamCong.Value.Hour;
                int minuteChamCong = chamCongDaChamToday.NgayChamCong.Value.Minute;
                int secondChamCong = chamCongDaChamToday.NgayChamCong.Value.Second;

                // Hiển thị thông báo
                MessageBox.Show($"Có lỗi xảy ra. Hôm nay bạn đã chấm công trước đó vào lúc {hourChamCong:D2}:{minuteChamCong:D2}:{secondChamCong:D2}", "Đã chấm công trước đó", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                var newChamCong = new tblChamCong
                {
                    NgayChamCong = chamCongDate,
                    MaTTS = UserId
                };
                DataProvider.Ins.DB.tblChamCongs.Add(newChamCong);
                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("Chấm công thành công.");
            }

        }
    }
}
