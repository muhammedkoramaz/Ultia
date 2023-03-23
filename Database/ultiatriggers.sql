-- ULTIA TRIGGERS 

create trigger TRG_FiyatEklendi
on Fiyat
after insert 
as 
begin
declare @varlikID int
declare @fiyatID int
	select @varlikID = VarlikID from inserted
	select @fiyatID = FiyatID from inserted
	update Fiyat 
	set AktifMi = 'False'
	where VarlikID= @varlikID

	update Fiyat
	set AktifMi = 'True'
	where FiyatID = @fiyatID
end 
------------------------------------
-- Varlikdepoya eklenirken urundurumu depoda yapacak.
create trigger TRG_DepoEklendi
on VarlikDepo
after insert 
as 
begin
declare @varlikID int
	select @varlikID = VarlikID from inserted
	
	update Varlik 
	set VarlikDurumID = 1
	where VarlikID= @varlikID
end 
---------------------------------------------
-- Zimmete varlýk eklendiðinde varlýkdepodan aktifliði false yapan trigger.
create trigger TRG_ZimmetEklendi
on Zimmet
after insert 
as 
begin
declare @varlikID int
declare @varlikDepoID int
	select @varlikDepoID = VarlikDepoID from inserted

	update VarlikDepo 
	set AktifMi = 'false'
	where VarlikDepoID= @varlikDepoID
end 
---------------------------------------------
-- Varlýkdepo tablosunda aktifliði false olan varlýklarýn durumunu zimmette olarak deðiþtiren trigger.
create trigger TRG_VarlikDurumZimmetlendiYap
on VarlikDepo
after update 
as 
begin
declare @varlikID int
declare @aktifMi bit
	select @varlikID = VarlikID from inserted
	select @aktifMi = AktifMi from inserted
	
	if @aktifMi = 'False'
	begin
	update Varlik 
	set VarlikDurumID = 2
	where VarlikID= @varlikID
	end
end 

-----------------------------------------------
-- Varlik tüketildiðinde varlik durumunu satýldý olarak iþaretleyecek.
alter trigger TRG_VarlikTuket
on MusteriVarlik
after insert 
as 
begin
declare @varlikID int
	select @varlikID = VarlikID from inserted

	update Varlik 
	set VarlikDurumID = 3
	where VarlikID= @varlikID
end 
------------------------------------------------
--  Varlik tüketildiðinde zimmet tablosunda aktifi false olacak. 

insert into MusteriVarlik  (MusteriID,VarlikID,Aciklama) 
values(@MusteriID, @VarlikID ,@Aciklama)

select kz.KullaniciZimmetID as [Kayýt Numarasý], v.Barkod, ut.UrunTipi, fy.ParaMiktari as Fiyat , marka.MarkaAdi as Marka , Model.ModelAd as Model, v.VarlikID from KullaniciZimmet kz join Kullanici k on kz.KullaniciID = k.KullaniciID join Zimmet z on kz.ZimmetID = z.ZimmetID join VarlikDepo vd on z.VarlikDepoID = vd.VarlikDepoID join Varlik v on vd.VarlikID = v.VarlikID 
join UrunTipi ut on v.UrunTipiID = ut.UrunTipiID 
join Fiyat fy on fy.VarlikID = v.VarlikID 
join Model model on v.ModelID = model.ModelID
join Marka marka on model.MarkaID = marka.MarkaID 
where kz.KullaniciID = 2 and kz.AktifMi= 'True' and fy.AktifMi = 'True'

select * from Zimmet
insert into Zimmet(ZimmetNedeniID,ZimmetTuruID,BaslangicTarihi,Aciklama,OlusturanKisiID,VarlikDepoID)
values(@zimmetNedeniID,@zimmetTuruID,@baslangicTarihi,@aciklama,@olusturanID,@varlikDepoID)

insert into KullaniciZimmet(KullaniciID,ZimmetID)values(@kullaniciID,ZimmetID)

insert into EkipZimmet(EkipID,ZimmetID) values (@ekipID,@zimmetID)

select ZimmetID from Zimmet where VarlikDepoID = 3 and AktifMi = 'true'
select VarlikDepoID, DepoID from VarlikDepo where VarlikID = 1 and AktifMi = 'true'

select KullaniciID,KullaniciAdi,AdSoyad,Email,YoneticiID,RoleID,EkipID from Kullanici where AktifMi = 'true'
select ZimmetNedeniID,ZimmetNedeni from ZimmetNedeni where AktifMi = 'true'
select ZimmetTuruID,ZimmetTuru from ZimmetTuru where AktifMi = 'true'
select EkipID,EkipAdi,SirketID from Ekip where AktifMi = 'true'
dbo.VarlikDepo
dbo.VarlikDurum
dbo.Zimmet
dbo.MusteriVarlik
dbo.Musteri
dbo.Kullanici
dbo.Fiyat
dbo.Birim
dbo.ZimmetNedeni
dbo.ZimmetTuru
dbo.KullaniciZimmet

select m.MusteriID,m.MusteriAdSoyad,m.MusteriTel,v.Barkod,marka.MarkaAdi,model.ModelAd,f.ParaMiktari, pb.ParaBirimi from MusteriVarlik mv
join Musteri m on mv.MusteriID = m.MusteriID
join Varlik v on v.VarlikID = mv.VarlikID
left join Fiyat f on f.VarlikID = mv.VarlikID
join Model model on model.ModelID = v.ModelID
join Marka marka on model.MarkaID = marka.MarkaID
join ParaBirimi pb on f.ParaBirimiID = pb.ParaBirimiID
where f.AktifMi = 'true'

select BirimID, BirimAdi from Birim where AktifMi = 'true'

select vd.VarlikDepoID, marka.MarkaAdi,model.ModelAd,f.ParaMiktari , pb.ParaBirimi from VarlikDepo vd inner join Varlik v on vd.VarlikID = v.VarlikID inner join Model model on v.ModelID = model.ModelID inner join Marka marka on model.MarkaID = marka.MarkaID  inner join Fiyat f on f.VarlikID = v.VarlikID  inner join ParaBirimi pb on f.ParaBirimiID = pb.ParaBirimiID where DepoID = {id} and f.AktifMi = 'True'