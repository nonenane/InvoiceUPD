USE [dbase1]
GO
/****** Object:  StoredProcedure [invoices].[GetDeps]    Script Date: 01.11.2020 22:09:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2020-11-03
-- Description:	Получение тела накладной для выгрузки в UPD
-- =============================================
CREATE PROCEDURE [invoices].[GetBodyUpd]
		@id_allprihod int
AS
BEGIN
SET NOCOUNT ON


select 
	ROW_NUMBER() over (order by a.id_tovar asc) as pos,
	trim(t.ean) as ean,
	trim(nt.cname) as cname,
	u.InternationalCode,
	u.cunit,
	a.netto as  Netto,
	(a.zcena*100)/(100+isnull(nds.nds,0)) as price_unit,
	ROUND(a.netto*((a.zcena*100)/(100+isnull(nds.nds,0))),2) as price_tovar,
	a.netto*a.zcena as price_netto,
	'Без акциза' as akcize,
	isnull(nds.nds,0) as nds,
	t.id as id_tovar
INTO
	#TMP_END
from (
select 
	p.id_tovar,
	p.netto,
	p.zcena,
	p.rcena
from
	dbo.j_prihod  p
where
	p.id_allprihod  = @id_allprihod

union all

select 
	p.id_tovar,
	p.netto,
	p.zcena,
	p.rcena
from
	dbo.j_otgruz  p
where
	p.id_allprihod  = @id_allprihod

union all

select 
	p.id_tovar,
	p.netto,
	p.zcena,
	p.rcena
from
	dbo.j_vozvr  p 
where
	p.id_allprihod  = @id_allprihod
) as a
		left join [dbo].[s_tovar] t on t.id  = a.id_tovar
		left join [dbo].[s_ntovar] nt on nt.id_tovar = a.id_tovar and nt.isActual = 1 
		left join [dbo].[s_unit] u on u.id = t.id_unit		
		left join dbo.s_nds nds on nds.id = t.id_nds

select 
	pos,
	ean,
	cname,
	InternationalCode,
	cunit,
	Netto,
	price_unit,
	price_tovar,
	price_netto,
	akcize,
	nds,
	id_tovar,
	ROUND(price_netto - price_tovar,2) as p8
from 
	#TMP_END

DROP TABLE #TMP_END

END