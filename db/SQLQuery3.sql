Create Database QuanLyKhachSan4
Go
Use QuanLyKhachSan4
Go

-- Bảng nhân viên
Create Table tbl_nhanvien(
	MaNhanVien varchar(5) primary key not null,
	TenNhanVien nvarchar(30),
	GioiTinh bit,
	NgaySinh datetime,
	SoDienThoai char(11),
	DiaChi nvarchar(50),
	UserName varchar(30),
	PassWord varchar(30)
)
GO
insert into tbl_nhanvien values('B82',N'Phạm Hải Anh',1,'1999-07-13','0988974952',N'Thái Bình','admin','admin')


-- Bảng khách hàng
Create Table tbl_khachhang(
	SoDienThoai char(11) primary key not null,
	TenKhachHang nvarchar(30),
	GioiTinh bit,
	NgaySinh datetime,
	CMND varchar(12), 
	QuocTich nvarchar(20)
)
Go
select * from tbl_khachhang
insert into tbl_khachhang values('0988974952',N'Phạm Hải Anh',1,'1999-07-13','034099003902',N'Việt Nam')

-- Bảng loại phòng
Create Table tbl_loaiphong(
	MaLoaiPhong varchar(6) primary key not null,
	TenLoaiPhong nvarchar(30),
	SoNguoi int
)
GO

-- Bảng phòng
Create Table tbl_phong(
	MaPhong varchar(6) primary key not null,
	TenPhong nvarchar(20),
	TinhTrang bit,
	MaLoaiPhong varchar(6) foreign key references  tbl_loaiphong(MaLoaiPhong),
	GiaPhong float,
	MieuTa varchar(30),	
)
GO



-- Bảng hóa đơn
Create Table tbl_hoadon(
	MaHoaDon int identity(1,1) primary key not null,
	SoDienThoai char(11),
	MaNhanVien varchar(5),
	TrangThai bit,
	MaPhong varchar(6) foreign key references tbl_phong(MaPhong),
	NgayLap datetime

)
GO

Alter Table tbl_hoadon ADD FOREIGN KEY (SoDienThoai) REFERENCES tbl_khachhang(SoDienThoai)
Alter Table tbl_hoadon ADD FOREIGN KEY (MaNhanVien) REFERENCES tbl_nhanvien(MaNhanVien)



-- Bảng chi tiết hóa đơn
Create Table tbl_chitiethoadon(
	MaChiTietHoaDon int identity(1,1) primary key not null,
	MaPhong varchar(6),
	MaDichVuPhong int,
	Mapd varchar(6),
	MaHoaDon int,
	SoNgayDaO int,
	DonGia float,

)
GO


Alter Table tbl_chitiethoadon ADD FOREIGN KEY (MaPhong) REFERENCES tbl_phong(MaPhong)
Alter Table tbl_chitiethoadon ADD FOREIGN KEY (MaHoaDon) REFERENCES tbl_hoadon(MaHoaDon)
Alter Table tbl_chitiethoadon ADD FOREIGN KEY (MaDichVuPhong) REFERENCES tbl_dichvuphong(MaDichVuPhong)
Alter Table tbl_chitiethoadon ADD FOREIGN KEY (Mapd) REFERENCES tbl_datphong(Mapd)




-- Bảng dịch vụ
Create Table tbl_dichvu(
	MaDichVu varchar(6) primary key not null,
	TenDichVu nvarchar(30),
	MieuTa ntext,
	GiaDichVu float,
)
GO
select * from tbl_dichvu


--bảng đặt phòng 
create table tbl_datphong(
Mapd varchar(6) primary key not null,
SoDienThoai char(11) foreign key references tbl_khachhang(SoDienThoai),
SoTienDat float,
NgayDen datetime,
NgayDi datetime,
TinhTrang bit,
TinhTrangHD bit,
MaPhong varchar(6) foreign key references tbl_phong(MaPhong)
)
GO
--bảng chi tiết đặt phòng
create table tbl_chitietdat(
Mapd varchar(6) primary key not null,
MaPhong varchar(6)
)
GO
-- Bảng dịch vụ phòng
Create Table tbl_dichvuphong(
	MaDichVuPhong int identity(1,1) primary key not null,
	MaPhong varchar(6)  foreign key references tbl_phong(MaPhong),
	MaDichVu varchar(6) foreign key references tbl_dichvu(MaDichVu),
	Mapd varchar(6) foreign key references tbl_datphong(Mapd),
	SoLuong int,
	DonGia float,
)
GO
Alter Table tbl_chitietdat ADD FOREIGN KEY (Mapd) REFERENCES tbl_datphong(Mapd)
Alter Table tbl_chitietdat ADD FOREIGN KEY (MaPhong) REFERENCES tbl_phong(MaPhong)
---------------------------------------THỦ TỤC---------------------------------------------------------------
--thủ tục đặt phòng
create proc DatPhong
@Mapd varchar(6),
@SoDienThoai char(11),
@SoTienDat float,
@NgayDen datetime,
@NgayDi datetime,
@TinhTrang bit,
@TinhTrangHD bit,
@MaPhong varchar(6)
as 
insert into tbl_datphong values (@Mapd,@SoDienThoai,@SoTienDat,@NgayDen,@NgayDi,@TinhTrang,@TinhTrangHD,@MaPhong)
go
--thủ tục thêm chi tiết đặt phòng
create proc CTDatPhong
@Mapd varchar(6),
@MaPhong varchar(6)
as
insert into tbl_chitietdat values(@Mapd,@MaPhong)
go
--thủ tục update trạng thái phòng
create proc UpdatePhong
@MaPhong varchar(6)
as
update tbl_phong
set TinhTrang = 0
where MaPhong = @MaPhong
go

--thủ tục tìm phòng theo mã phiếu đặt
create proc TimPhong
@Mapd varchar(6)
as
select MaPhong from tbl_chitietdat
where Mapd = @Mapd
go
--thủ tục update nhận phòng
create proc UpdateNhanPhong
@Mapd varchar(6)
as
update tbl_datphong
set TinhTrang = 1
go
--thủ tục trả phòng
create proc UpdateTraPhong
@Maphong varchar(6)
as
update tbl_phong
set TinhTrang = 1
where MaPhong = @MaPhong
-- thủ tục xóa nhận phòng
create proc DelNhanPhong
@Mapd varchar(6)
as
delete from tbl_datphong
where Mapd = @Mapd
go
--thủ tục xóa chi tiết đặt
create proc DelChiTietDat
@Mapd varchar(6)
as
delete from tbl_chitietdat
where Mapd = @Mapd
go


----------------------------------------------------------------------------------------------------------
/*select * from tbl_datphong
select * from tbl_phong
select  * from tbl_chitietdat
delete from tbl_datphong
where Mapd = 'PD01'
select kh.TenKhachHang,p.TenPhong,p.GiaPhong,dp.NgayDen,dp.NgayDi,dv.TenDichVu,dv.GiaDichVu,dvp.SoLuong,sum(dv.GiaDichVu*dvp.SoLuong) as 'total' from tbl_datphong dp inner join tbl_chitietdat ctd
on dp.Mapd =  ctd.Mapd
inner join tbl_khachhang kh 
on dp.SoDienThoai = kh.SoDienThoai
inner join tbl_phong p 
on ctd.MaPhong = p.MaPhong
inner join tbl_dichvuphong dvp 
on dvp.MaPhong = p.MaPhong
inner join tbl_dichvu dv 
on dv.MaDichVu = dvp.MaDichVu

where ctd.MaPhong ='103'
group by kh.TenKhachHang,p.TenPhong,p.GiaPhong,dp.NgayDen,dp.NgayDi,dv.TenDichVu,dv.GiaDichVu,dvp.SoLuong*/
---------------------------------------------------------------------------------------------

--thủ tục GetAllByMaPhong
create proc GetallByMaPhong
@MaPhong varchar(6)
as 
select kh.TenKhachHang,kh.SoDienThoai,dvp.MaDichVuPhong,dp.Mapd,p.TenPhong,p.GiaPhong,dp.NgayDen,dp.NgayDi,dv.TenDichVu,dv.GiaDichVu,dvp.SoLuong from tbl_datphong dp inner join tbl_chitietdat ctd
on dp.Mapd =  ctd.Mapd
inner join tbl_khachhang kh 
on dp.SoDienThoai = kh.SoDienThoai
inner join tbl_phong p 
on ctd.MaPhong = p.MaPhong
inner join tbl_dichvuphong dvp 
on dvp.MaPhong = p.MaPhong
inner join tbl_dichvu dv 
on dv.MaDichVu = dvp.MaDichVu
where ctd.MaPhong =@MaPhong
go
-- thủ tục insert hóa đơn
create proc InsertOrder
@SoDienThoai char(11),
@MaNhanVien varchar(5),
@TrangThai bit,
@MaPhong varchar(6),
@NgayLap datetime
as
insert into tbl_hoadon values(@SoDienThoai,@MaNhanVien,@TrangThai,@MaPhong,@NgayLap)
GO
select * from tbl_phong
---------------------------------------------------------------------------------------------------------
/*select kh.TenKhachHang,kh.SoDienThoai,dvp.MaDichVuPhong,dp.Mapd,p.TenPhong,p.GiaPhong,dp.NgayDen,dp.NgayDi,dv.TenDichVu,dv.GiaDichVu,dvp.SoLuong from tbl_datphong dp 
inner join tbl_khachhang kh 
on dp.SoDienThoai = kh.SoDienThoai
inner join tbl_dichvuphong dvp 
on dvp.MaPhong = dp.MaPhong
inner join tbl_phong p 
on dp.MaPhong = p.MaPhong
inner join tbl_dichvu dv 
on dv.MaDichVu = dvp.MaDichVu
inner join tbl_hoadon hd
on hd.MaPhong = dp.MaPhong
where hd.MaPhong ='101'  and hd.TrangThai = 1*/
-------------------------------------------------------------------------------------------------------
--thủ tục insert hóa đơn chi tiết
create proc InsertOrderDetail
@MaPhong varchar(6),
@MaDichVuPhong int,
@Mapd varchar(6),
@MaHoaDon int,
@SoNgayDaO int,
@DonGia float
as
insert into tbl_chitiethoadon values (@MaPhong,@MaDichVuPhong,@Mapd,@MaHoaDon,@SoNgayDaO,@DonGia)
go
------------------------------------------------------------------
/*select kh.TenKhachHang,nv.TenNhanVien,p.TenPhong,p.GiaPhong,dv.TenDichVu,dvp.SoLuong,dv.GiaDichVu from tbl_chitiethoadon cthd
inner join tbl_hoadon hd
on cthd.MaHoaDon = hd.MaHoaDon
inner join tbl_khachhang kh
on kh.SoDienThoai = hd.SoDienThoai
inner join tbl_nhanvien nv 
on nv.MaNhanVien = hd.MaNhanVien
inner join tbl_phong p
on cthd.MaPhong = p.MaPhong
inner join tbl_dichvuphong dvp 
on p.MaPhong = dvp.MaPhong
inner join tbl_dichvu dv 
on dvp.MaDichVu = dv.MaDichVu
where hd.MaPhong ='101 ' and hd.TrangThai = 1*/
-------------------------------
select * from tbl_hoadon
select * from tbl_dichvuphong
-----------------------------------------------hóa đơn
/*select kh.TenKhachHang,nv.TenNhanVien,p.TenPhong,p.GiaPhong,dv.TenDichVu,dvp.SoLuong,dv.GiaDichVu,dp.SoTienDat,cthd.Mapd from tbl_chitiethoadon cthd
inner join tbl_hoadon hd
on cthd.MaHoaDon = hd.MaHoaDon
inner join tbl_khachhang kh
on kh.SoDienThoai = hd.SoDienThoai
inner join tbl_nhanvien nv
on hd.MaNhanVien = nv.MaNhanVien
inner join tbl_phong p 
on cthd.MaPhong = p.MaPhong
inner join tbl_dichvuphong dvp
on cthd.Mapd = dvp.Mapd
inner join tbl_datphong dp
on cthd.Mapd = dp.Mapd
inner join tbl_dichvu dv
on dvp.MaDichVu =dv.MaDichVu
where hd.SoDienThoai = 0123456789  and hd.TrangThai = 1*/
---------------------------------------------------------------------
/*select * from tbl_datphong
select * from tbl_hoadon hd
inner join tbl_chitiethoadon cthd
on hd.MaHoaDon = cthd.MaHoaDon
inner join tbl_phong p
on cthd.MaPhong = p.MaPhong
inner join tbl_datphong dp
on cthd.Mapd = dp.Mapd
where hd.SoDienThoai = 0988974952  and hd.TrangThai = 1*/

select * from tbl_hoadon
----------thủ tục hóa đơn-------------------------
create proc HD
 @SoDienThoai char(11)
 as
 select * from tbl_hoadon hd
inner join tbl_chitiethoadon cthd
on hd.MaHoaDon = cthd.MaHoaDon
inner join tbl_phong p
on cthd.MaPhong = p.MaPhong
inner join tbl_datphong dp
on cthd.Mapd = dp.Mapd
where hd.SoDienThoai = @SoDienThoai  and hd.TrangThai = 1
---------------------thủ tục getmahd--------------------
create proc GetMaHD
@MaPhong varchar(6)
as
select MaHoaDon,SoDienThoai from tbl_hoadon 
where TrangThai = 1 and MaPhong =@MaPhong
go
-------------------------
/*select * from tbl_datphong
where MaPhong = '101'
select * from tbl_hoadon where SoDienThoai =0123456789 and TrangThai = 1
select MaHoaDon,SoDienThoai from tbl_hoadon 
where TrangThai = 1 and MaPhong ='101'*/
---------------------------------------------------------------------------
/*select * from tbl_chitiethoadon
select * from tbl_chitiethoadon cthd
inner join tbl_hoadon hd
on cthd.MaHoaDon = hd.MaHoaDon
inner join tbl_dichvuphong dvp
on cthd.MaPhong = dvp.MaPhong
where hd.TrangThai = 0 and dvp.MaPhong = '101' and dvp.Mapd='PD04'*/
 --thủ tục xuất báo cáo
 create proc XuatBaoCao
 @SoDienThoai char(11)
 as
 select kh.TenKhachHang,nv.TenNhanVien,p.TenPhong,p.GiaPhong,dv.TenDichVu,dvp.SoLuong,dv.GiaDichVu,dp.SoTienDat,cthd.Mapd from tbl_chitiethoadon cthd
inner join tbl_hoadon hd
on cthd.MaHoaDon = hd.MaHoaDon
inner join tbl_khachhang kh
on kh.SoDienThoai = hd.SoDienThoai
inner join tbl_nhanvien nv
on hd.MaNhanVien = nv.MaNhanVien
inner join tbl_phong p 
on cthd.MaPhong = p.MaPhong
inner join tbl_dichvuphong dvp
on cthd.Mapd = dvp.Mapd
inner join tbl_datphong dp
on cthd.Mapd = dp.Mapd
inner join tbl_dichvu dv
on dvp.MaDichVu =dv.MaDichVu
where hd.TrangThai = 1  and hd.SoDienThoai = @SoDienThoai
go

--------------------------------------------------------------
select * from tbl_hoadon hd
inner join tbl_chitiethoadon cthd
on hd.MaHoaDon = cthd.MaHoaDon
inner join tbl_dichvuphong dvp
on hd.MaPhong = dvp.MaPhong
where hd.MaPhong ='101 'and  hd.TrangThai = 1
-------------------------------------------------------------
 /*select kh.TenKhachHang,nv.TenNhanVien,p.TenPhong,p.GiaPhong,dv.TenDichVu,dvp.SoLuong,dv.GiaDichVu,cthd.Mapd,dp.SoTienDat from tbl_chitiethoadon cthd
inner join tbl_hoadon hd
on cthd.MaHoaDon = hd.MaHoaDon
inner join tbl_khachhang kh
on kh.SoDienThoai = hd.SoDienThoai
inner join tbl_nhanvien nv 
on nv.MaNhanVien = hd.MaNhanVien
inner join tbl_dichvuphong dvp 
on cthd.MaPhong = dvp.MaPhong
inner join tbl_phong p 
on dvp.MaPhong = p.MaPhong
inner join tbl_datphong dp
on cthd.Mapd = dp.Mapd
inner join tbl_dichvu dv 
on dvp.MaDichVu = dv.MaDichVu
where dvp.MaPhong ='101'  and hd.TrangThai = 1 */
---------------------------------
/*select * from tbl_dichvuphong
select cthd.Mapd from tbl_chitiethoadon cthd inner join tbl_hoadon hd 
on cthd.MaHoaDon = hd.MaHoaDon
where  hd.TrangThai = 1 and cthd.MaPhong = '101'
select * from tbl_hoadon hd
inner join tbl_datphong dp
on hd.MaPhong = dp.MaPhong
where hd.TrangThai = 1*/
--thủ tục get mapd
create proc GetMaDP
 @MaPhong varchar(6)
as
select cthd.Mapd from tbl_chitiethoadon cthd inner join tbl_hoadon hd 
on cthd.MaHoaDon = hd.MaHoaDon
where  hd.TrangThai = 1 and cthd.MaPhong =@MaPhong
go
-------------------------------
--thủ tục kiểm tra khách hàng đang có hóa đơn
alter proc CheckHD
@SoDienThoai char(11)
as 
select * from tbl_hoadon hd inner join tbl_khachhang kh
on hd.SoDienThoai = @SoDienThoai
where hd.TrangThai =1
go
-------------------------


--thủ tục update so luong
create proc UpdateSoluong 
@MaDichVu varchar(6)
as
select * from tbl_dichvuphong dvp inner join tbl_dichvu dv
on dvp.MaDichVu = dv.MaDichVu
where dv.MaDichVu = @MaDichVu
go
--
select *  from tbl_dichvuphong

--thủ tục thanh toán
create proc UpdateTTHD
 @SoDienThoai char(11)
as
update tbl_hoadon
set TrangThai = 0
where SoDienThoai = @SoDienThoai
go
select MaPhong from tbl_hoadon
where SoDienThoai = 0123456789
--thủ tục update trạng thái phòng
create proc UpdateTTPhong
@Maphong varchar(6)
as
update tbl_phong
set TinhTrang = 1
where MaPhong = @MaPhong

---------------------------------
--truy vấn hóa đơn 
 /*select kh.TenKhachHang,nv.TenNhanVien,p.TenPhong,p.GiaPhong,dv.TenDichVu,dvp.SoLuong,dv.GiaDichVu from tbl_chitiethoadon cthd
 inner join tbl_datphong dp 
 on cthd.Mapd = dp.Mapd
 inner join tbl_chitietdat ctd
on dp.Mapd =  ctd.Mapd
inner join tbl_khachhang kh 
on dp.SoDienThoai = kh.SoDienThoai
inner join tbl_hoadon hd
on kh.SoDienThoai = hd.SoDienThoai
inner join tbl_nhanvien nv
on hd.MaNhanVien = nv.MaNhanVien
inner join tbl_dichvuphong dvp 
on dvp.MaPhong = cthd.MaPhong
inner join tbl_phong p 
on dvp.MaPhong = p.MaPhong
inner join tbl_dichvu dv 
on dv.MaDichVu = dvp.MaDichVu
where dvp.MaPhong ='101' and dvp.Mapd ='pd03' and hd.TrangThai = 1*/
---------------------------------
---------------------------
/*select * from tbl_chitiethoadon cthd 
inner join tbl_hoadon hd
on cthd.MaHoaDon = hd.MaHoaDon
inner join tbl_dichvuphong dvp
on cthd.MaPhong = dvp.MaPhong
where  dvp.MaPhong ='101' and hd.TrangThai = 1  and dvp.Mapd = 'pd03'
--chi tiết đặt
delete from tbl_chitietdat where Mapd ='PD02'
delete from tbl_datphong where Mapd ='PD02'*/

--xóa dv--------------------------------
select * from tbl_dichvuphong 
select * from tbl_chitietdat
delete from tbl_dichvuphong where MaPhong='102'
----------------------------------------

--proc check
create proc checkDv
@MaPhong varchar(6)
as
select * from tbl_hoadon hd
inner join tbl_chitiethoadon cthd 
on hd.MaHoaDon = cthd.MaHoaDon
inner join tbl_dichvuphong dvp 
on cthd.MaDichVuPhong = dvp.MaDichVuPhong
where cthd.MaPhong = @MaPhong
go
------------------------------------------
------proc CheckDELLP---------------
create proc CheckDELLP
@MaLoaiPhong varchar(6)
as
select * from tbl_phong p inner join tbl_loaiphong lp
on p.MaLoaiPhong = lp.MaLoaiPhong
where p.MaLoaiPhong = @MaLoaiPhong
go
---------------------------------------

 /*select * from tbl_dichvuphong dvp inner join tbl_phong p
 on dvp.MaPhong = p.MaPhong
 where p.MaPhong ='101'and dvp.Mapd ='PD02'
 delete from tbl_dichvuphong where MaDichVuPhong = 11
 select * from tbl_hoadon hd
inner join tbl_chitiethoadon cthd 
on hd.MaHoaDon = cthd.MaHoaDon
inner join tbl_dichvuphong dvp 
on cthd.MaDichVuPhong = dvp.MaDichVuPhong
where hd.TrangThai = 0
delete from tbl_chitiethoadon
delete from tbl_hoadon
delete from tbl_dichvuphong
delete from tbl_chitietdat
delete from tbl_datphong
select * from tbl_datphong
select * from tbl_chitietdat
select *  from tbl_dichvuphong
select * from tbl_hoadon
select * from tbl_chitiethoadon
select * from tbl_dichvu*/

--------------

-----------------------------
------IMPORTANT-------------------
/*select * from tbl_dichvuphong dvp inner join tbl_dichvu dv
on dvp.MaDichVu = dv.MaDichVu
where dvp.MaPhong = '101' and dvp.Mapd = 'pd03'
go*/
--------------------------------
----------------


----------thủ tục tìm mã dvp----------------------
create proc GetMaDVP
@MaPhong varchar(6)
as 
select * from tbl_chitietdat ctd inner join tbl_phong
p on ctd.MaPhong = p.MaPhong inner join tbl_dichvuphong dvp
on p.MaPhong = dvp.MaPhong
where p.MaPhong = @MaPhong
go
---thủ tục update ttdp----
alter proc UpdateTTDP
@SoDienThoai char(11)
as
update tbl_datphong
set TinhTrangHD = 0
where SoDienThoai = @SoDienThoai
--------------------------------------
--proc get hd by id------------
create proc GetHDByID
@MaHoaDon int
as
select cthd.Mapd from tbl_chitiethoadon cthd 
inner join tbl_hoadon hd
on cthd.MaHoaDon = hd.MaHoaDon
where hd.MaHoaDon =@MaHoaDon 
go
select * from tbl_hoadon
select cthd.Mapd from tbl_chitiethoadon cthd 
inner join tbl_hoadon hd
on cthd.MaHoaDon = hd.MaHoaDon
where hd.MaHoaDon = 11
------------------------------------------\
select * from tbl_datphong
select * from tbl_dichvuphong dvp inner join tbl_datphong dp
on dvp.Mapd = dp.Mapd
where dp.TinhTrangHD = 1
--xóa
use master
drop database QuanLyKhachSan4
--truy vấn hóa đơn
