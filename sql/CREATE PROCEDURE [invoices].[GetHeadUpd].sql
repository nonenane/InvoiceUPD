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
-- Description:	Получение списка накладных на дату
-- =============================================
ALTER PROCEDURE [invoices].[GetHeadUpd]
	@dateStart date,
	@dateEnd date
AS
BEGIN
SET NOCOUNT ON
		
		
select a.id_allprihod,a.id_otdel,a.sumBuy,a.sumRealiz
INTO #tmpTovarMove
from (
select 
	p.id_allprihod, 
	p.id_otdel,
	sum(p.netto*p.rcena) as sumRealiz,
	sum(p.netto*p.zcena) as sumBuy
from
	dbo.j_allprihod a
		inner join dbo.j_prihod  p on p.id_allprihod = a.id
where
	@dateStart <= a.dprihod and a.dprihod<=@dateEnd
group by 
	p.id_allprihod, p.id_otdel

union all

select 
	p.id_allprihod, 
	p.id_otdel,
	sum(p.netto*p.rcena) as sumRealiz,
	sum(p.netto*p.zcena) as sumBuy
from
	dbo.j_allprihod a
		inner join dbo.j_otgruz  p on p.id_allprihod = a.id
where
	@dateStart <= a.dprihod and a.dprihod<=@dateEnd
group by 
	p.id_allprihod, p.id_otdel

union all

select 
	p.id_allprihod, 
	p.id_otdel,
	sum(p.netto*p.rcena) as sumRealiz,
	sum(p.netto*p.zcena) as sumBuy
from
	dbo.j_allprihod a
		inner join dbo.j_vozvr  p on p.id_allprihod = a.id
where
	@dateStart <= a.dprihod and a.dprihod<=@dateEnd
group by 
	p.id_allprihod, p.id_otdel
) as a


select 
	a.isSelect,
	a.id,
	a.ttn,
	a.dprihod,	
	a.id_post,
	a.namePost,
	a.inn as inn_original,
	a.id_operand,
	a.nameOperand,
	a.ntypeorg,
	a.id_otdel,
	a.sumBuy,
	a.sumRealiz,
	a.nameDep,
	a.Abbriviation,
	a.id_post1,
	a.id_post2,
	a.dprihod as  DocDate,
	ltrim(rtrim(p.cname)) as namePost1,
	isnull(trim(d.LegalAdress),'_') as LegalAdress,
	trim(p.inn)+'/'+isnull(d.KPP,'') as inn,
	isnull(ltrim(rtrim(pr.cname))+' ','')+','+trim(dr.LegalAdress) as adressPost2,
	trim(pr.cname) as org_name,
	trim(dr.LegalAdress) as org_address,
	trim(pr.inn)+'/'+trim(dr.KPP) as kpp,
	isnull(trim(d.ResponsiblePerson),'_') as ResponsiblePerson,
	isnull(trim(d.FIOGlBuh),'_') as FIOGlBuh,
	isnull(ltrim(rtrim(p.cname))+' ','')+',ИНН/КПП'+isnull(trim(p.inn),'_')+'/'+isnull(trim(d.KPP),'_') as inn_kpp_post1,
	isnull(ltrim(rtrim(pr.cname))+' ','')+',ИНН/КПП'+isnull(trim(pr.inn),'_')+'/'+isnull(trim(dr.KPP),'_') as inn_kpp_post2,


	--isnull(ltrim(rtrim(p.cname))+' ','')+isnull('ИНН: '+p.inn+', ','')+isnull('КПП: '+d.KPP+', ','') 
	--+isnull(d.LegalAdress+', ','')+isnull('Р/сч: '+p.PaymentAccount+', ','')+isnull('К/сч: '+p.CorrelativeAccount+', ','')
	--+isnull('БИК: '+p.BIK+', ','')+isnull(ltrim(rtrim(p.Bank)) ,'') as Post1ToNalk,
	'' as Post1ToNalk,

	--isnull(ltrim(rtrim(stor.name))+' ','')+isnull(ltrim(rtrim(pr.cName))+', ' ,'')+isnull('ИНН: '+pr.INN+', ','')+isnull('КПП: '+pr.KPP+', ','') 
	--+isnull(pr.Address+', ','')+isnull('Р/сч: '+pr.PaymentAccount+', ','')+isnull('К/сч: '+pr.CorrelativeAccount+', ','')
	--+isnull('БИК: '+pr.BIK+', ','')+isnull(ltrim(rtrim(pr.Bank)) ,'') as Post2ToNalk,
	''  as Post2ToNalk,

	isnull('ИНН: '+p.inn+', ','')+isnull('КПП: '+d.KPP+'','') as innkpptoSFPost1,
	isnull('ИНН: '+pr.inn+', ','')+isnull('КПП: '+dr.KPP+'','') as innkpptoSFPost2
from(
select 
	cast(0 as bit) as isSelect,	
	a.id,
	a.ttn,
	a.dprihod,	
	a.id_post,
	ltrim(rtrim(p.cname)) as namePost,
	ltrim(rtrim(p.inn)) as inn,
	a.id_operand,
	ltrim(rtrim(o.name)) as nameOperand,
	a.ntypeorg,
	t.id_otdel,
	t.sumBuy,
	t.sumRealiz,
	ltrim(rtrim(d.name)) as nameDep,
	m.Abbriviation,
	a.id_post as id_post1,
	m.id_Post as id_post2	
from
	dbo.j_allprihod a
		left join dbo.s_post p on p.id = a.id_post
		left join dbo.s_operand o on o.id = a.id_operand
		left join #tmpTovarMove t on t.id_allprihod = a.id
		left join dbo.departments d on d.id = t.id_otdel
		left join dbo.s_MainOrg m on m.nTypeOrg = a.ntypeorg and m.DateStart<=a.dprihod and a.dprihod<=m.DateEnd		

		--left join Caramel.s_Post p on p.id = n.id_PostSender
		--left join dbo.s_type_org sto on sto.id = p.id
		--left join dbo.s_post pr on pr.id = m.id_Post		
		--left join dbo.s_type_org stor on stor.id = pr.id_TypePost
where
	@dateStart <= a.dprihod and a.dprihod<=@dateEnd and a.id_operand in (1,2,3,8) and a.id_post is not null and a.ttn is not null
)as a
	left join dbo.s_post p on p.id = a.id_post1
	left join [dbo].[s_DocumentEntries] d on d.id_Supplier = a.id_post1
	left join [dbo].[s_SettlementAccounts] s on s.id_Supplier = a.id_post1

	left join dbo.s_post pr on pr.id = a.id_post2
	left join [dbo].[s_DocumentEntries] dr on dr.id_Supplier = a.id_post2
	left join [dbo].[s_SettlementAccounts] sr on sr.id_Supplier = a.id_post2

DROP TABLE #tmpTovarMove

END


/*
в УПД все как в ВН, поставщика адрес тут [dbo].[s_DocumentEntries]

счет и банк тут [dbo].[s_SettlementAccounts]
*/