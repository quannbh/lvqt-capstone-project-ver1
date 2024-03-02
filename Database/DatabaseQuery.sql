create database TTS;
use TTS;

drop database TTS;

create table tblChucVu(
MaChucVu varchar(30) primary key,
TenChucVu nvarchar(max),
)
drop table tblChucvu;

create table tblPhongBan(
MaPhongBan varchar(30) primary key,
TenPhongBan nvarchar(max),
)
drop table tblPhongBan;

create table tblTTS(
MaTTS varchar(30) primary key,
TenTTS nvarchar(max),
MaPhongBan varchar(30) foreign key references tblPhongBan(MaPhongBan) ON DELETE CASCADE,
MaChucVu varchar(30) foreign key references tblChucVu(MaChucVu) ON DELETE CASCADE,
MatKhau varchar(max) not null
)
drop table tblTTS;

create table tblQL(
MaQL varchar(30) primary key,
TenQL nvarchar(max),
MaPhongBan varchar(30) foreign key references tblPhongBan(MaPhongBan) ON DELETE CASCADE,
MaChucVu varchar(30) foreign key references tblChucVu(MaChucVu) ON DELETE CASCADE,
MatKhau varchar(max) not null
)
drop table tblQL;

create table tblKhoaDaoTao(
MaKhoaDaoTao varchar(30) primary key,
TenKhoa nvarchar(max),
)
drop table tblKhoaDaoTao;

create table tblNhiemVuDaoTao(
MaNhiemVuDaoTao int identity(1000,1) primary key,
MaKhoaDaoTao varchar(30) foreign key references tblKhoaDaoTao(MaKhoaDaoTao) ON DELETE CASCADE,
MaTTS varchar(30) foreign key references tblTTS(MaTTS) ON DELETE CASCADE,
NgayBatDau datetime,
Deadline datetime,
status varchar(20) CHECK (status IN ('approved','done', 'in-progress', 'expired'))
)
drop table tblNhiemVuDaoTao;

create table tblDuAn(
MaDA varchar(30) primary key,
TenDA nvarchar(max),
)
drop table tblDuAn;

create table tblNhiemVuDA(
MaNhiemVuDA int identity(4000,1) primary key,
MaDA varchar(30) foreign key references tblDuAn(MaDA) ON DELETE CASCADE,
MaTTS varchar(30) foreign key references tblTTS(MaTTS) ON DELETE CASCADE,
NgayBatDau datetime,
Deadline datetime,
NhiemVu nvarchar(max),
status varchar(20) CHECK (status IN ('done', 'in-progress', 'expired'))
)
drop table tblNhiemVuDA;

create table tblNhanXetNhiemVuDA(
MaNhanXetNhiemVuDA int identity(20000,1) primary key,
MaNhiemVuDA int foreign key references tblNhiemVuDA(MaNhiemVuDA) ON DELETE CASCADE,
NhanXet nvarchar(max),
Diem int,
)
drop table tblNhanXetNhiemVuDA;

create table tblNhanSuDA(
MaNhanSuDA int identity(10000,1) primary key,
MaDA varchar(30) foreign key references tblDuAn(MaDA) ON DELETE CASCADE,
MaTTS varchar(30) foreign key references tblTTS(MaTTS) ON DELETE CASCADE,
CONSTRAINT UC_MaDA_MaTTS UNIQUE (MaDA, MaTTS)
)
drop table tblNhanSuDA

create table tblTrucThuoc(
MaTrucThuoc int identity(50000,1) primary key,
MaDA varchar(30) foreign key references tblDuAn(MaDA) ON DELETE CASCADE,
MaPhongBan varchar(30) foreign key references tblPhongBan(MaPhongBan) ON DELETE CASCADE
)
Drop table tblTrucThuoc;

create table tblYeuCau(
MaYeuCau int identity(100000,1) primary key,
NgayNop datetime,
MaTTS varchar(30) foreign key references tblTTS(MaTTS) ON DELETE CASCADE,
NoiDung nvarchar(max),
NgayHieuLuc datetime,
Status varchar(20) CHECK (status IN ('pending','pass', 'reject')),
)
Drop table tblYeuCau

create table tblNguoiPheDuyet(
MaPheDuyet int identity(1,1) primary key,
MaQL varchar(30) foreign key references tblQL(MaQL), 
MaYeuCau int foreign key references tblYeuCau(MaYeuCau) ON DELETE CASCADE,
)

drop table tblNguoiPheDuyet


create table tblChamCong(
MaChamCong int identity (10000,1) primary key,
MaTTS varchar(30) foreign key references tblTTS(MaTTS) ON DELETE CASCADE,
NgayChamCong Datetime,
)

/***********************************************************************************************************************/
/*INSERT DEMO DATA (OPTION)*/

insert into tblChucVu values ('GD',N'Giám đốc');
insert into tblChucVu values ('QL',N'Quản lý');
insert into tblChucVu values ('TTS',N'Thực tập sinh');

insert into tblPhongBan values ('KT',N'Kiểm Toán');
insert into tblPhongBan values ('NS',N'Nhân sự');
insert into tblPhongBan values ('IT',N'Công nghệ thông tin');

insert into tblTTS values ('KT01',N'Trần Phương Linh','KT','TTS','db69fc039dcbd2962cb4d28f5891aae1');
insert into tblTTS values ('KT02',N'Lê Vũ Quỳnh Trang','KT','TTS','db69fc039dcbd2962cb4d28f5891aae1');
insert into tblTTS values ('NS01',N'Nguyễn Thị Hà','KT','TTS','db69fc039dcbd2962cb4d28f5891aae1');
insert into tblTTS values ('NS02',N'Nguyễn Thị Thảo','IT','TTS','db69fc039dcbd2962cb4d28f5891aae1');
insert into tblTTS values ('IT01',N'Cao Thanh Thanh','IT','TTS','db69fc039dcbd2962cb4d28f5891aae1');
insert into tblTTS values ('IT02',N'Nguyễn Ngọc Anh','IT','TTS','db69fc039dcbd2962cb4d28f5891aae1');

insert into tblQL values ('QLKT01',N'Trần Hạnh','KT','QL','db69fc039dcbd2962cb4d28f5891aae1');
insert into tblQL values ('QLKT02',N'Lê Quỳnh','KT','GD','db69fc039dcbd2962cb4d28f5891aae1');
insert into tblQL values ('QLNS01',N'Nguyễn Ngọc','NS','QL','db69fc039dcbd2962cb4d28f5891aae1');
insert into tblQL values ('QLNS02',N'Nguyễn Thùy','NS','QL','db69fc039dcbd2962cb4d28f5891aae1');
insert into tblQL values ('QLIT01',N'Cao Vân','IT','QL','db69fc039dcbd2962cb4d28f5891aae1');
insert into tblQL values ('QLIT02',N'Nguyễn Lan','IT','QL','db69fc039dcbd2962cb4d28f5891aae1');

insert into tblKhoaDaoTao values ('DTKT01',N'Kiểm Toán Ngân Hàng');
insert into tblKhoaDaoTao values ('DTKT02',N'Kiểm Toán Nhà Nước');
insert into tblKhoaDaoTao values ('DTNS01',N'Tin học cơ bản');
insert into tblKhoaDaoTao values ('DTC01',N'Bảo mật thông tin');
insert into tblKhoaDaoTao values ('DTIT01',N'Kiểm soát nội bộ');
insert into tblKhoaDaoTao values ('DTIT02',N'Oracle');

insert into tblDuAn values ('DA01', N'TP Bank');
insert into tblDuAn values ('DA02', N'MB Bank');
insert into tblDuAn values ('DA03', N'Viettel');

insert into tblTrucThuoc values ('DA01', 'KT');
insert into tblTrucThuoc values ('DA02', 'IT');
insert into tblTrucThuoc values ('DA02', 'KT');
insert into tblTrucThuoc values ('DA03', 'IT');

insert into tblNhanSuDA(MaDA,MaTTS) values ('DA01','KT01');
insert into tblNhanSuDA(MaDA,MaTTS) values ('DA01','NS01');
insert into tblNhanSuDA(MaDA,MaTTS) values ('DA01','KT02');
insert into tblNhanSuDA(MaDA,MaTTS) values ('DA02','NS02');
insert into tblNhanSuDA(MaDA,MaTTS) values ('DA02','KT01');
insert into tblNhanSuDA(MaDA,MaTTS) values ('DA03','IT01');
insert into tblNhanSuDA(MaDA,MaTTS) values ('DA03','IT02');
insert into tblNhanSuDA(MaDA,MaTTS) values ('DA03','KT01');
insert into tblNhanSuDA(MaDA,MaTTS) values ('DA03','NS01');

insert into tblNhiemVuDA(MaDA,MaTTS,NgayBatDau,Deadline,NhiemVu,status) values ('DA02', 'IT01','2023-10-05 00:00:00','2023-10-06 00:00:00','Doc tai lieu','done');


insert into tblNhiemVuDaoTao(MaKhoaDaoTao,MaTTS,NgayBatDau,Deadline,status) values ('DTKT01','IT02','2023-10-05 00:00:00','2023-11-05 00:00:00','in-progress')
insert into tblNhiemVuDaoTao(MaKhoaDaoTao,MaTTS,NgayBatDau,Deadline,status) values ('DTKT02','IT02','2023-10-06 00:00:00','2023-11-05 00:00:00','in-progress')
insert into tblNhiemVuDaoTao(MaKhoaDaoTao,MaTTS,NgayBatDau,Deadline,status) values ('DTIT01','IT01','2023-10-08 00:00:00','2023-11-05 00:00:00','in-progress')
insert into tblNhiemVuDaoTao(MaKhoaDaoTao,MaTTS,NgayBatDau,Deadline,status) values ('DTIT01','IT02','2023-10-09 00:00:00','2023-11-05 00:00:00','in-progress')
insert into tblNhiemVuDaoTao(MaKhoaDaoTao,MaTTS,NgayBatDau,Deadline,status) values ('DTIT02','IT01','2023-10-12 00:00:00','2023-11-05 00:00:00','in-progress')
insert into tblNhiemVuDaoTao(MaKhoaDaoTao,MaTTS,NgayBatDau,Deadline,status) values ('DTNS01','IT01','2023-10-12 00:00:00','2023-11-05 00:00:00','done')

insert into tblYeuCau(NgayNop, MaTTS, NoiDung, NgayHieuLuc,Status) values ('2023-10-05 00:00:00','IT01',N'Xin nghỉ phép','2023-10-06 00:00:00','pass')
insert into tblYeuCau(NgayNop, MaTTS, NoiDung, NgayHieuLuc, Status) values ('2023-10-09 00:00:00','IT02',N'Xin nghỉ phép','2023-10-10 00:00:00', 'pass')
insert into tblYeuCau(NgayNop, MaTTS, NoiDung, NgayHieuLuc, Status) values ('2023-11-09 00:00:00','IT01',N'Xin nghỉ phép','2023-11-10 00:00:00', 'pending')

insert into tblNguoiPheDuyet(MaQL, MaYeuCau) values ('QLIT01','100000')
insert into tblNguoiPheDuyet(MaQL, MaYeuCau) values ('QLIT01','100001')

insert into tblChamCong(MaTTS,NgayChamCong) values ('IT01', '2023-10-27 09:01:00')
insert into tblChamCong(MaTTS,NgayChamCong) values ('IT01', '2023-10-30 09:01:00')
insert into tblChamCong(MaTTS,NgayChamCong) values ('IT01', '2023-11-01 09:01:00')
insert into tblChamCong(MaTTS,NgayChamCong) values ('IT01', '2023-11-02 09:01:00')
insert into tblChamCong(MaTTS,NgayChamCong) values ('IT01', '2023-11-03 09:01:00')
insert into tblChamCong(MaTTS,NgayChamCong) values ('IT01', '2023-11-05 09:01:00')
insert into tblChamCong(MaTTS,NgayChamCong) values ('IT01', '2023-11-06 09:01:00')
insert into tblChamCong(MaTTS,NgayChamCong) values ('IT01', '2023-11-07 09:01:00')
insert into tblChamCong(MaTTS,NgayChamCong) values ('IT01', '2023-11-08 09:01:00')
