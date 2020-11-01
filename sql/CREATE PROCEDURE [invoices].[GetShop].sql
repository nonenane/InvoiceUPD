USE [dbase1]
GO
/****** Object:  StoredProcedure [invoices].[GetDeps]    Script Date: 01.11.2020 22:09:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G.Y.
-- Create date: 2020-10-29
-- Description:	Получение списка магазинов
-- =============================================
CREATE PROCEDURE [invoices].[GetShop]
AS
BEGIN
SET NOCOUNT ON
		Select id,cName from dbo.s_Shop where isActive =1
END
