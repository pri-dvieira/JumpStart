/* DELETES AND DROPS */

DELETE FROM StdTabelasVar WHERE tabela IN ('TDU_PDEXCabimentacao', 'TDU_PDEXEstadosCabimentacao', 'TDU_PDEXMapOrganica', 'TDU_PDEXMapFonteFinan', 'TDU_PDEXMapEconomica')
GO
EXEC STD_DropTable [TDU_PDEXEstadosCabimentacao]
EXEC STD_DropTable [TDU_PDEXCabimentacao]
EXEC STD_DropTable [TDU_PDEXMapOrganica]
EXEC STD_DropTable [TDU_PDEXMapFonteFinan]
EXEC STD_DropTable [TDU_PDEXMapEconomica]
GO

/* INSERTS AND CREATES */

-- TDU_PDEXCabimentacao
CREATE TABLE [dbo].[TDU_PDEXCabimentacao]
(
		[CDU_DocId]						[uniqueidentifier] NOT NULL
	,	[CDU_TipoDoc]					[nvarchar](5) NOT NULL
	,	[CDU_Serie]						[nvarchar](5) NOT NULL
	,	[CDU_NumDoc]					[int] NOT NULL
	,	[CDU_Documento]					[nvarchar](50) NOT NULL
	,	[CDU_NumDocExterno]				[nvarchar](20) NOT NULL
	,	[CDU_DataDoc]					[datetime] NOT NULL
	,	[CDU_TipoEntidade]				[nvarchar](1) NOT NULL
	,	[CDU_Entidade]					[nvarchar](12) NOT NULL	
	,	[CDU_NumContribuinte]			[nvarchar](50) NOT NULL
	,	[CDU_Moeda]						[nvarchar](3) NOT NULL
	,	[CDU_CondPag]					[nvarchar](2) NULL
	,	[CDU_Observacoes]				[nvarchar](max) NULL
	
	,	[CDU_FonteFinancCBL]			[nvarchar](10) NULL
	,	[CDU_OrganicaCBL]				[nvarchar](15) NULL
	,	[CDU_ClasseEcon]				[nvarchar](15) NULL

	,	[CDU_EstadoCab]					[nvarchar](50) NULL
	,	[CDU_NumCab]					[int] NULL

	,	[CDU_DataUltimaActualizacao]	[datetime] NOT NULL CONSTRAINT [TDU_PDEXCabimentacao_DataUltimaActualizacao_DF] DEFAULT (GETDATE())
	,	CONSTRAINT [TDU_PDEXCabimentacao01] PRIMARY KEY CLUSTERED 
		(
			[CDU_DocId] ASC
		) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[TDU_PDEXCabimentacao]  WITH CHECK ADD CONSTRAINT [TDU_PDEXCabimentacao_DocId_FK] FOREIGN KEY([CDU_DocId])
REFERENCES [dbo].[CabecCompras] ([Id])
GO

INSERT INTO StdTabelasVar (Tabela, Apl) VALUES ('TDU_PDEXCabimentacao', 'ERP')
GO

-- TDU_PDEXEstadosCabimentacao
CREATE TABLE [dbo].[TDU_PDEXEstadosCabimentacao]
(
		CDU_DocId		uniqueidentifier	NOT NULL
	,	CDU_NumCab		int					NOT NULL
	,	CDU_EstadoCab	nvarchar(50)		NOT NULL
	,	CDU_DataEstado	datetime			NOT NULL CONSTRAINT [TDU_PDEXEstadosCabimentacao_DataEstado_DF]  DEFAULT (GETDATE())
	,	CONSTRAINT [TDU_PDEXEstadosCabimentacao01] PRIMARY KEY CLUSTERED 
		(
			CDU_DocId ASC, CDU_NumCab ASC, CDU_EstadoCab ASC
		) ON [PRIMARY]
)

ALTER TABLE [dbo].[TDU_PDEXEstadosCabimentacao]  WITH CHECK ADD CONSTRAINT [TDU_PDEXEstadosCabimentacao_DocId_FK] FOREIGN KEY([CDU_DocId])
REFERENCES [dbo].[CabecCompras] ([Id])
GO

INSERT INTO StdTabelasVar (Tabela, Apl) VALUES ('TDU_PDEXEstadosCabimentacao', 'ERP')
GO

-- TDU_PDEXMapOrganica
CREATE TABLE [dbo].[TDU_PDEXMapOrganica]
(
		CDU_ValorERP	nvarchar(50) NULL
	,	CDU_ValorSIGOF	nvarchar(50) NULL
	,	CDU_Descricao	nvarchar(100) NULL
)
GO

INSERT INTO StdTabelasVar (Tabela, Apl) VALUES ('TDU_PDEXMapOrganica', 'ERP')
GO

-- TDU_PDEXMapFonteFinan
CREATE TABLE [dbo].[TDU_PDEXMapFonteFinan]
(
		CDU_ValorERP	nvarchar(50) NULL
	,	CDU_ValorSIGOF	nvarchar(50) NULL
	,	CDU_Descricao	nvarchar(100) NULL
)
GO

INSERT INTO StdTabelasVar (Tabela, Apl) VALUES ('TDU_PDEXMapFonteFinan', 'ERP')
GO

-- TDU_PDEXMapEconomica
CREATE TABLE [dbo].[TDU_PDEXMapEconomica]
(
		CDU_ValorERP	nvarchar(50) NULL
	,	CDU_ValorSIGOF	nvarchar(50) NULL
	,	CDU_Descricao	nvarchar(100) NULL
)
GO

INSERT INTO StdTabelasVar (Tabela, Apl) VALUES ('TDU_PDEXMapEconomica', 'ERP')
GO

--select * from TDU_PDEXCabimentacao
