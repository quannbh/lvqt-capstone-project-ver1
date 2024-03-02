﻿using QuanLySinhVienThucTap.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QuanLySinhVienThucTap.ViewModel
{
    public class BaoCaoTienDoCongViecViewModel : BaseViewModel
    {
        private string _MaPhongBan;

        public string MaPhongBan
        {
            get { return _MaPhongBan; }
            set
            {
                if (_MaPhongBan != value)
                {
                    _MaPhongBan = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<tblTT> _TTSList;
        public ObservableCollection<tblTT> TTSList
        {
            get { return _TTSList; }
            set
            {
                _TTSList = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<tblNhiemVuDA> _NhiemVuDAList;
        public ObservableCollection<tblNhiemVuDA> NhiemVuDAList
        {
            get { return _NhiemVuDAList; }
            set
            {
                _NhiemVuDAList = value;
                OnPropertyChanged();
            }
        }
        private tblTT _SelectedTTS;

        public tblTT SelectedTTS
        {
            get { return _SelectedTTS; }
            set
            {
                _SelectedTTS = value;
                OnPropertyChanged();
            }
        }

        private string _TenTTS;

        public string TenTTS
        {
            get { return _TenTTS; }
            set
            {
                _TenTTS = value;
                OnPropertyChanged();
            }
        }

        private DateTime _NgayBatDau = DateTime.Now;

        public DateTime NgayBatDau
        {
            get { return _NgayBatDau; }
            set
            {
                _NgayBatDau = value;
                OnPropertyChanged();
            }
        }

        private DateTime _NgayKetThuc = DateTime.Now;

        public DateTime NgayKetThuc
        {
            get { return _NgayKetThuc; }
            set
            {
                _NgayKetThuc = value;
                OnPropertyChanged();
            }
        }

        private int _TongSo;

        public int TongSo
        {
            get { return _TongSo; }
            set
            {
                _TongSo = value;
                OnPropertyChanged();
            }
        }

        private double _TiLeHoanThanh;

        public double TiLeHoanThanh
        {
            get { return _TiLeHoanThanh; }
            set
            {
                _TiLeHoanThanh = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoadedCommand { get; set; }
        public ICommand XuatBaoCaoCommand { get; set; }

        public BaoCaoTienDoCongViecViewModel()
        {
            LoadedCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                LoadPage();
            });

            XuatBaoCaoCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (SelectedTTS == null)
                {
                    MessageBox.Show("Vui lòng chọn thực tập sinh cần truy xuất.");
                    return;
                }
                XuatBaoCao();
            });
        }

        public void LoadPage()
        {
            TTSList = new ObservableCollection<tblTT>();
            var TTSlist = DataProvider.Ins.DB.tblTTS.Where(x => x.MaPhongBan == MaPhongBan).ToList();
            foreach (var item in TTSlist)
            {
                tblTT newTTSlist = new tblTT();
                newTTSlist.MaTTS = item.MaTTS;
                newTTSlist.TenTTS = item.TenTTS;
                TTSList.Add(newTTSlist);
            }
        }

        public void XuatBaoCao()
        {
            NhiemVuDAList = new ObservableCollection<tblNhiemVuDA>();
            var nhiemVuList = DataProvider.Ins.DB.tblNhiemVuDAs.Where(x => x.MaTTS == SelectedTTS.MaTTS && x.NgayBatDau >= NgayBatDau && x.NgayBatDau <= NgayKetThuc).OrderBy(x=> x.MaDA).ToList();
            var count = nhiemVuList.Count();
            var nvDone = nhiemVuList.Count(x => x.status == "done");
            if (count == 0)
            {
                MessageBox.Show("Thực tập sinh không có nhiệm vụ dự án nào trong khoảng thời gian này.");
                return;
            }
            foreach (var item in nhiemVuList)
            {
                tblNhiemVuDA newNhiemVuDA = new tblNhiemVuDA();
                newNhiemVuDA.MaDA = item.MaDA;
                newNhiemVuDA.MaNhiemVuDA = item.MaNhiemVuDA;
                newNhiemVuDA.NhiemVu = item.NhiemVu;
                newNhiemVuDA.NgayBatDau = item.NgayBatDau;
                newNhiemVuDA.Deadline = item.Deadline;
                newNhiemVuDA.status = item.status;
                newNhiemVuDA.MaTTS = item.MaTTS;
                NhiemVuDAList.Add(newNhiemVuDA);
            }

            TongSo = count;
            TiLeHoanThanh = Math.Round(((double) nvDone / count)*100, 2);

        }
    }
}
