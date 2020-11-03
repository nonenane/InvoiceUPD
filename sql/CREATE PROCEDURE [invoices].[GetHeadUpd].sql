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
	m.Abbriviation
	-----

	--,a.dprihod as  DocDate,
	--ltrim(rtrim(sto.name))+' '+ ltrim(rtrim(p.cName)) as namePost1,
	--isnull(trim(p.Address),'_') as LegalAdress,
	--trim(p.INN)+'/'+isnull(p.KPP,'') as inn,
	--isnull(ltrim(rtrim(stor.name))+' ','')+trim(pr.cName)+','+trim(pr.Address) as adressPost2,
	--ltrim(rtrim(stor.name))+' '+ trim(pr.cName) as org_name,
	--trim(pr.Address) as org_address,
	--trim(pr.INN)+'/'+trim(pr.KPP) as kpp,
	--isnull(trim(p.ContactBoss),'_') as ResponsiblePerson,
	--isnull(trim(p.ContactBookkeeper),'_') as FIOGlBuh,
	--isnull(ltrim(rtrim(sto.name))+' ','')+isnull(trim(p.cName),'_')+',ИНН/КПП'+isnull(trim(p.INN),'_')+'/'+isnull(trim(p.KPP),'_') as inn_kpp_post1,
	--isnull(ltrim(rtrim(stor.name))+' ','')+isnull(trim(pr.cName),'_')+',ИНН/КПП'+isnull(trim(pr.INN),'_')+'/'+isnull(trim(pr.KPP),'_') as inn_kpp_post2,


	--isnull(ltrim(rtrim(sto.name))+' ','')+isnull(ltrim(rtrim(p.cName))+', ' ,'')+isnull('ИНН: '+p.INN+', ','')+isnull('КПП: '+p.KPP+', ','') 
	--+isnull(p.Address+', ','')+isnull('Р/сч: '+p.PaymentAccount+', ','')+isnull('К/сч: '+p.CorrelativeAccount+', ','')
	--+isnull('БИК: '+p.BIK+', ','')+isnull(ltrim(rtrim(p.Bank)) ,'') as Post1ToNalk,

	--isnull(ltrim(rtrim(stor.name))+' ','')+isnull(ltrim(rtrim(pr.cName))+', ' ,'')+isnull('ИНН: '+pr.INN+', ','')+isnull('КПП: '+pr.KPP+', ','') 
	--+isnull(pr.Address+', ','')+isnull('Р/сч: '+pr.PaymentAccount+', ','')+isnull('К/сч: '+pr.CorrelativeAccount+', ','')
	--+isnull('БИК: '+pr.BIK+', ','')+isnull(ltrim(rtrim(pr.Bank)) ,'') as Post2ToNalk,


	--isnull('ИНН: '+p.INN+', ','')+isnull('КПП: '+p.KPP+'','') as innkpptoSFPost1,
	--isnull('ИНН: '+pr.INN+', ','')+isnull('КПП: '+pr.KPP+'','') as innkpptoSFPost2

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


DROP TABLE #tmpTovarMove

END


/*
в УПД все как в ВН, поставщика адрес тут [dbo].[s_DocumentEntries]

счет и банк тут [dbo].[s_SettlementAccounts]
*/